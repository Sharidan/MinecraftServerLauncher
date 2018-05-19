using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLibs.Minecraft
{
  static class ChatConverter
  {

    #region ===== Description / Documentation =====

    /*
      Example of input:
      [Server] Scheduled server restart in 10 minutes!
      Including color tags:
      &7[&9Server&7] &eScheduled server restart in &c10&e minutes!
      Prompt (without the quotation marks):
      "&7[&9Server&7] "
      Followed by whatever message needs to go out ....

      The above needs to be converted into:

      /tellraw @a [
        {
          "text": "[",
          "color": "gray"
        },
        {
          "text": "Server",
          "color": "blue"
        },
        {
          "text": "] ",
          "color": "gray"
        },
        {
          "text": "Scheduled server restart in ",
          "color": "yellow"
        },
        {
          "text": "10",
          "color": "red"
        },
        {
          "text": " minutes!",
          "color": "yellow"
        }
        ]
      
      &7[&9Server&7] &eScheduled server restart in &c10&e minutes!

      §7[§9Server§7] §eScheduled server restart in §c10§e minutes!

      [
        {"text":"[","color":"gray"},
        {"text":"Server","color":"blue"},
        {"text":"] ","color":"gray"},
        {"text":"Scheduled server restart in ","color":"yellow"},
        {"text":"10","color":"red"},
        {"text":" minutes!","color":"yellow"}
      ]


      [
        {"text":"[","color":"gray"},
        {"text":"Server","color":"blue"},
        {"text":"] ","color":"gray"}
      ]
      [
        {"text":"Scheduled server restart in ","color":"yellow"},
        {"text":"10","color":"red"},
        {"text":" minutes!","color":"yellow"}
      ]

      Another kind of conversion is:

      Sharidan's Vanilla 1.12.2
      §aSharidan§f'§2s §6Vanilla §71§8.§712§8.§72

      Etho & xumavoid do Minecraft

    */

    #endregion

    private const string ControlSymbols = "&§";

    private const string ControlCodes = "0123456789abcdefklmnor";

    #region ===== Internal Helper Methods =====

    #region Method: ConvertToMOTD

    // Input sample:
    // &aSharidan&f'&2s &6Vanilla &71&8.&712&8.&72&
    // §aSharidan§f'§2s §6Vanilla §71§8.§712§8.§72§
    // Expected output:
    // §aSharidan§f'§2s §6Vanilla §71§8.§712§8.§72

    /// <summary>
    /// Converts the passed chat text into properly section-sign formatted text.
    /// </summary>
    /// <param name="chatText">The chat text to convert.</param>
    /// <returns>Returns a properly formatted section-sign copy of the original chat text.</returns>
    private static string ConvertToMOTD(string chatText)
    {
      // First, let's grab a lower-case copy of the original text to search through
      string searchText = chatText.ToLower();
      char[] resultText = chatText.ToCharArray();

      for (int c = 0; c < ControlCodes.Length; c++)
      {
        for (int s = 0; s < ControlSymbols.Length; s++)
        {
          int pos = searchText.IndexOf("" + ControlSymbols[s] + ControlCodes[c]);
          if (pos > -1)
          {
            // Continue doing this replacement, as long as the same control tag exists!
            while (pos > -1)
            {
              // Do the replacement
              resultText[pos] = '§';
              resultText[pos + 1] = ControlCodes[c];
              // Search for the same thing again
              pos = searchText.IndexOf("" + ControlSymbols[s] + ControlCodes[c], pos + 1);
            }
          }
        }
      }

      return new string(resultText);
    }

    #endregion

    #region Method: GetJSONColorName

    /// <summary>
    /// Accepts a char based control code and returns the json color name asociated with that control code.
    /// </summary>
    /// <param name="controlCode">The control code to fetch the json color name for.</param>
    /// <returns>Returns the chat element json color name for the passed control code.</returns>
    private static string GetJSONColorName(char controlCode)
    {
      return MinecraftColors.GetName(controlCode);
    }

    #endregion

    #region Method: GetJSONFlag

    private static string GetJSONFlag(string name, bool value)
    {
      string result = "";

      result += "\"" + name + "\":";

      if (value)
      {
        result += "true";
      }
      else
      {
        result += "false";
      }

      return result;
    }

    #endregion

    #region Method: GetJSONFormatName

    private static string GetJSONFormatName(char controlCode)
    {
      switch (controlCode)
      {
        case 'k': return "obfuscated";
        case 'l': return "bold";
        case 'm': return "strikethrough";
        case 'n': return "underlined";
        case 'o': return "italic";
        case 'r': return "reset";
      }

      return "none";
    }

    #endregion

    #region Method: HasControlTags

    /// <summary>
    /// Checks the passed string to see if there are any control tags in it.
    /// </summary>
    /// <param name="chatText">The chat text to check.</param>
    /// <returns>Returns true if at least one valid control tag was found, otherwise false.</returns>
    private static bool HasControlTags(string chatText)
    {
      string text = chatText.ToLower();

      // First loop-through will check for: "&0"

      for (int c = 0; c < ControlCodes.Length; c++)
      {
        for (int s = 0; s < ControlSymbols.Length; s++)
        {
          if (text.IndexOf("" + ControlSymbols[s] + ControlCodes[c]) > -1)
          {
            // We found a reference to a control code, so return true!
            return true;
          }
        }
      }

      return false;
    }

    #endregion

    #endregion

    #region ===== Public Methods =====

    #region Method: MergeJSON

    public static string MergeJSON(string firstJSON, string secondJSON)
    {
      if (firstJSON.Length > 0 && (firstJSON[0] == '[' && firstJSON[firstJSON.Length - 1] == ']'))
      {
        if (secondJSON.Length > 0 && (secondJSON[0] == '[' && secondJSON[secondJSON.Length - 1] == ']'))
        {
          string result = "";

          // Remove the trailing close bracket of the first JSON string:
          result = firstJSON.Substring(0, firstJSON.Length - 1);
          // Add a comma to separate for the remaining json elements of the second JSON string
          result += ",";
          // Remove the first open bracket of the second JSON string and add it to the result:
          result += secondJSON.Substring(1, secondJSON.Length - 1);

          return result;
        }
      }

      return "";
    }

    #endregion

    #region Method: ToElements

    public static ChatElement[] ToElements(string chatText)
    {
      if (HasControlTags(chatText))
      {
        ChatElement[] result = new ChatElement[0];
        ChatElement element = new ChatElement("", "none");
        string motd = ConvertToMOTD(chatText);
        // This is what we get:
        // §aSharidan§f'§2s §6Vanilla §71§8.§712§8.§72
        // §aSharidan§f'§2s §6§nVanilla§r §71§8.§712§8.§72
        // Keep in mind, that the above might contain § that should be rendered as actual text, not a control symbol
        // Split the above string into its individual parts
        string[] parts = motd.Split('§');

        for (int p = 0; p < parts.Length; p++)
        {
          string part = parts[p];

          if (part.Length > 0)
          {
            int pos = ControlCodes.IndexOf(part[0]);
            if (pos > -1)
            {
              if (pos < 16)
              {
                element.Color = GetJSONColorName(part[0]);
              }
              else
              {
                switch (GetJSONFormatName(part[0]))
                {
                  case "obfuscated":
                    
                    if (element.Obfuscated)
                    {
                      element.Obfuscated = false;
                    }
                    else
                    {
                      element.Obfuscated = true;
                    }

                    // The same quick and easy way of toggling the bool variable:
                    //element.Obfuscated = !element.Obfuscated;
                    break;
                  case "bold":

                    // Toggle the setting
                    element.Bold = !element.Bold;

                    break;
                  case "strikethrough":

                    // Toggle the setting
                    element.Strikethrough = !element.Strikethrough;

                    break;
                  case "underlined":

                    // Toggle the setting
                    element.Underlined = !element.Underlined;

                    break;
                  case "italic":

                    // Toggle the setting
                    element.Italic = !element.Italic;

                    break;
                  case "reset":
                    element.Color = "none";
                    element.Obfuscated = false;
                    element.Bold = false;
                    element.Strikethrough = false;
                    element.Underlined = false;
                    element.Italic = false;
                    break;
                }
              }

              // Remove/clear the control code character
              if (part.Length == 1)
              {
                part = "";
              }
              else
              {
                part = part.Substring(1);
              }

            }
            else if (p > 0)
            {
              part = "§" + part;
            }

            element.Text = part;

          }

          if (element.Text.Length > 0)
          {
            Array.Resize(ref result, result.Length + 1);
            result[result.Length - 1] = new ChatElement(element);

            element.Text = "";
            element.Color = "none";
            element.Obfuscated = false;
            element.Bold = false;
            element.Strikethrough = false;
            element.Underlined = false;
            element.Italic = false;
          }

        } // for

        return result;
      }

      if (chatText.Trim().Length > 0)
      {
        return new ChatElement[] { new ChatElement(chatText) };
      }

      return new ChatElement[0];
    }

    #endregion

    #region Method: ToJSON

    public static string ToJSON(string chatText)
    {
      ChatElement[] elements = ToElements(chatText);
      string result = "";

      if (elements.Length > 0)
      {

        // Chat settings set to default:
        // color = none (game client renders as white)
        // all text formatting flags are false, leaving plain text

        ChatElement prevElement = new ChatElement("", "none");
        string element = "";

        for (int e = 0; e < elements.Length; e++)
        {
          element = "";
          if (elements[e].Text.Length > 0)
          {
            element += "\"text\":\"" + elements[e].Text + "\",";
            if (prevElement.Color != elements[e].Color)
            {
              element += "\"color\":\"" + elements[e].Color + "\",";
              prevElement.Color = elements[e].Color;
            }
            if (prevElement.Obfuscated != elements[e].Obfuscated)
            {
              element += GetJSONFlag("obfuscated", elements[e].Obfuscated) + ",";
              prevElement.Obfuscated = elements[e].Obfuscated;
            }
            if (prevElement.Bold != elements[e].Bold)
            {
              element += GetJSONFlag("bold", elements[e].Bold) + ",";
              prevElement.Bold = elements[e].Bold;
            }
            if (prevElement.Strikethrough != elements[e].Strikethrough)
            {
              element += GetJSONFlag("strikethrough", elements[e].Strikethrough) + ",";
              prevElement.Strikethrough = elements[e].Strikethrough;
            }
            if (prevElement.Underlined != elements[e].Underlined)
            {
              element += GetJSONFlag("underlined", elements[e].Underlined) + ",";
              prevElement.Underlined = elements[e].Underlined;
            }
            if (prevElement.Italic != elements[e].Italic)
            {
              element += GetJSONFlag("italic", elements[e].Italic) + ",";
              prevElement.Italic = elements[e].Italic;
            }

            // remove the trailing comma:
            element = element.Substring(0, element.Length - 1);
          }

          if (element.Length > 0)
          {
            result += "{";
            result += element;
            result += "},";
          }
        }

        // remove any trailing comma from the result var:
        if (result.Length > 0)
        {
          result = result.Substring(0, result.Length - 1);
        }

        result = "[" + result + "]";
      }

      return result;
    }

    #endregion

    #region Method: ToMOTD

    /// <summary>
    /// Converts the passed chat text into a properly formatted MOTD text.
    /// </summary>
    /// <param name="chatText">The chat text to convert.</param>
    /// <returns>Returns the properly formatted MOTD version of the passed chat text.</returns>
    public static string ToMOTD(string chatText)
    {
      if (HasControlTags(chatText))
      {
        return ConvertToMOTD(chatText);
      }

      return chatText;
    }

    #endregion

    #endregion

  }
}
