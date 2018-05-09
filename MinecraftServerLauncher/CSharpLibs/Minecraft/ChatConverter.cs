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

    private const string ControlCodes = "0123456789abcdef";

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
      switch (controlCode)
      {
        case '0': return "black";
        case '1': return "dark_blue";
        case '2': return "dark_green";
        case '3': return "dark_aqua";
        case '4': return "dark_red";
        case '5': return "dark_purple";
        case '6': return "gold";
        case '7': return "gray";
        case '8': return "dark_gray";
        case '9': return "blue";
        case 'a': return "green";
        case 'b': return "aqua";
        case 'c': return "red";
        case 'd': return "light_purple";
        case 'e': return "yellow";
        case 'f': return "white";
      }

      return "white";
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

    #region Method: ToJSON

    public static string ToJSON(string chatText)
    {
      if (HasControlTags(chatText))
      {
        string motd = ConvertToMOTD(chatText);
        // This is what we get:
        // §aSharidan§f'§2s §6Vanilla §71§8.§712§8.§72
        // Keep in mind, that the above might contain § that should be rendered as actual text, not a control symbol
        string[] parts = motd.Split('§');
        string result = "";

        result += "[";

        for (int p = 0; p < parts.Length; p++)
        {
          string part = parts[p];

          if (part.Length > 0)
          {
            string colorName = "";
            // Do we have a color control code?
            if (ControlCodes.IndexOf(part[0]) > -1)
            { // Yes, we do - so we'll have to handle that...
              colorName = GetJSONColorName(part[0]);
              // Now that we've gotten the proper color name,
              // we will have to remove the control code from the part string
              part = part.Substring(1);
            }
            else
            {
              part = "§" + part;
            }

            if (colorName.Length > 0)
            {
              result += "{";
              // Add in the text part
              result += "\"text\":\"" + part + "\",";
              // and add the color reference
              result += "\"color\":\"" + colorName + "\"";
              result += "}";
            }
            else
            {
              result += "{";
              // Add in the text part
              result += "\"text\":\"" + part + "\"";
              result += "}";
            }

            result += ",";
          }
        }

        // Remove the last comma from the result string
        result = result.Substring(0, result.Length - 1);

        result += "]";

        return result;
      }

      // Now returns a single json chat element containing the passed chat text.
      return "[{\"text\":\"" + chatText + "\"}]";
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
