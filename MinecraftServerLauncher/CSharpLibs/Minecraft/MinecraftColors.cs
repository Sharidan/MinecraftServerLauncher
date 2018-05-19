using System.Drawing;

namespace CSharpLibs.Minecraft
{
  /// <summary>
  /// References the 16 Minecraft colors, including chat text shadows and conversion tools between color references.
  /// </summary>
  static class MinecraftColors
  {

    #region ===== Internal Helper Methods =====

    #region Method: ConvertColor

    /// <summary>
    /// Converts the passed 4 BGRA color byte array into a System.Drawing.Color object.
    /// </summary>
    /// <param name="colorBytes">The 4 BGRA color bytes to convert.</param>
    /// <returns>Returns a System.Drawing.Color object of the passed color bytes.</returns>
    private static Color ConvertColor(byte[] colorBytes)
    {
      return Color.FromArgb(colorBytes[3], colorBytes[2], colorBytes[1], colorBytes[0]);
    }

    #endregion

    #region Method: FetchColor

    /// <summary>
    /// Fetches one of the 16 the 4 BGRA color bytes according to the color number.
    /// </summary>
    /// <param name="colorNumber">The color number to fetch.</param>
    /// <returns>Returns the specified 4 byte BGRA color pair.</returns>
    private static byte[] FetchColor(int colorNumber)
    {
      switch (colorNumber)
      {
        case 0: return new byte[] { 0, 0, 0, 255 }; // black
        case 1: return new byte[] { 170, 0, 0, 255 }; // dark_blue
        case 2: return new byte[] { 0, 170, 0, 255 }; // dark_green
        case 3: return new byte[] { 170, 170, 0, 255 }; // dark_aqua
        case 4: return new byte[] { 0, 0, 170, 255 }; // dark_red
        case 5: return new byte[] { 170, 0, 170, 255 }; // dark_purple
        case 6: return new byte[] { 0, 170, 255, 255 }; // gold
        case 7: return new byte[] { 170, 170, 170, 255 }; // gray
        case 8: return new byte[] { 85, 85, 85, 255 }; // dark_gray
        case 9: return new byte[] { 255, 85, 85, 255 }; // blue
        case 10: return new byte[] { 85, 255, 85, 255 }; // green
        case 11: return new byte[] { 255, 255, 85, 255 }; // aqua
        case 12: return new byte[] { 85, 85, 255, 255 }; // red
        case 13: return new byte[] { 255, 85, 255, 255 }; // light_purple
        case 14: return new byte[] { 85, 255, 255, 255 }; // yellow
      }

      // white
      return new byte[] { 255, 255, 255, 255 };
    }

    #endregion

    #region Method: FetchShadowColor

    /// <summary>
    /// Fetches one of the 16 the 4 BGRA shadow color bytes according to the color number.
    /// </summary>
    /// <param name="colorNumber">The shadow color number to fetch.</param>
    /// <returns>Returns the specified 4 byte BGRA shadow color pair.</returns>
    private static byte[] FetchShadowColor(int colorNumber)
    {
      switch (colorNumber)
      {
        case 0: return new byte[] { 0, 0, 0, 255 }; // black
        case 1: return new byte[] { 42, 0, 0, 255 }; // dark_blue
        case 2: return new byte[] { 0, 42, 0, 255 }; // dark_green
        case 3: return new byte[] { 42, 42, 0, 255 }; // dark_aqua
        case 4: return new byte[] { 0, 0, 42, 255 }; // dark_red
        case 5: return new byte[] { 42, 0, 42, 255 }; // dark_purple
        case 6: return new byte[] { 0, 42, 42, 255 }; // gold
        case 7: return new byte[] { 42, 42, 42, 255 }; // gray
        case 8: return new byte[] { 21, 21, 21, 255 }; // dark_gray
        case 9: return new byte[] { 63, 21, 21, 255 }; // blue
        case 10: return new byte[] { 21, 63, 21, 255 }; // green
        case 11: return new byte[] { 63, 63, 21, 255 }; // aqua
        case 12: return new byte[] { 21, 21, 63, 255 }; // red
        case 13: return new byte[] { 63, 21, 63, 255 }; // light_purple
        case 14: return new byte[] { 21, 63, 63, 255 }; // yellow
      }

      // white
      return new byte[] { 63, 63, 63, 255 };
    }

    #endregion

    #endregion

    #region Method: GetColor

    /// <summary>
    /// Gets the specified Minecraft color represented in a System.Drawing.Color object according to it's hexadecimal value.
    /// </summary>
    /// <param name="hexValue">The hexadecimal char value of the color to get.</param>
    /// <returns>Returns the specified Minecraft color as a System.Drawing.Color object.</returns>
    public static Color GetColor(char hexValue)
    {
      return GetColor(hexValue, false);
    }

    /// <summary>
    /// Gets the specified Minecraft color represented in a System.Drawing.Color object according to it's color number.
    /// </summary>
    /// <param name="colorNumber">The color number to get.</param>
    /// <returns>Returns the specified Minecraft color as a System.Drawing.Color object.</returns>
    public static Color GetColor(int colorNumber)
    {
      return GetColor(colorNumber, false);
    }

    /// <summary>
    /// Gets the specified Minecraft color represented in a System.Drawing.Color object according to it's technical name.
    /// </summary>
    /// <param name="technicalName">The technical name of the color to get.</param>
    /// <returns>Returns the specified Minecraft color as a System.Drawing.Color object.</returns>
    public static Color GetColor(string technicalName)
    {
      return GetColor(technicalName, false);
    }

    /// <summary>
    /// Gets the specified Minecraft color or shadow color represented in a System.Drawing.Color object according to it's hexadecimal value.
    /// </summary>
    /// <param name="hexValue">The hexadecimal char value of the color to get.</param>
    /// <param name="shadowColor">Whether to return the normal or shadow color.</param>
    /// <returns>Returns the specified Minecraft color or shadow color as a System.Drawing.Color object.</returns>
    public static Color GetColor(char hexValue, bool shadowColor)
    {
      if (shadowColor)
      {
        return ConvertColor(FetchShadowColor(GetColorNumber(hexValue)));
      }

      return ConvertColor(FetchColor(GetColorNumber(hexValue)));
    }

    /// <summary>
    /// Gets the specified Minecraft color or shadow color represented in a System.Drawing.Color object according to it's color number.
    /// </summary>
    /// <param name="colorNumber">The color number to get.</param>
    /// <param name="shadowColor">Whether to return the normal or shadow color.</param>
    /// <returns>Returns the specified Minecraft color as a System.Drawing.Color object.</returns>
    public static Color GetColor(int colorNumber, bool shadowColor)
    {
      if (shadowColor)
      {
        return ConvertColor(FetchShadowColor(colorNumber));
      }

      return ConvertColor(FetchColor(colorNumber));
    }

    /// <summary>
    /// Gets the specified Minecraft color represented in a System.Drawing.Color object according to it's technical name.
    /// </summary>
    /// <param name="technicalName">The technical name of the color to get.</param>
    /// <param name="shadowColor">Whether to return the normal or shadow color.</param>
    /// <returns>Returns the specified Minecraft color as a System.Drawing.Color object.</returns>
    public static Color GetColor(string technicalName, bool shadowColor)
    {
      if (shadowColor)
      {
        return ConvertColor(FetchShadowColor(GetColorNumber(technicalName)));
      }

      return ConvertColor(FetchColor(GetColorNumber(technicalName)));
    }

    #endregion

    #region Method: GetColorBytes

    /// <summary>
    /// Gets the specified Minecraft color represented as a 4 byte BGRA byte array according to it's hexadecimal value.
    /// </summary>
    /// <param name="hexValue">The hexadecimal char value of the color to get.</param>
    /// <returns>Returns the specified Minecraft color as a 4 byte BGRA byte array.</returns>
    public static byte[] GetColorBytes(char hexValue)
    {
      return GetColorBytes(hexValue, false);
    }

    /// <summary>
    /// Gets the specified Minecraft color represented as a 4 byte BGRA byte array according to it's color number.
    /// </summary>
    /// <param name="colorNumber">The color number to get.</param>
    /// <returns>Returns the specified Minecraft color as a 4 byte BGRA byte array.</returns>
    public static byte[] GetColorBytes(int colorNumber)
    {
      return GetColorBytes(colorNumber, false);
    }

    /// <summary>
    /// Gets the specified Minecraft color represented as a 4 byte BGRA byte array according to it's technical name.
    /// </summary>
    /// <param name="technicalName">The technical name of the color to get.</param>
    /// <returns>Returns the specified Minecraft color as a 4 byte BGRA byte array.</returns>
    public static byte[] GetColorBytes(string technicalName)
    {
      return GetColorBytes(technicalName, false);
    }

    /// <summary>
    /// Gets the specified Minecraft color represented as a 4 byte BGRA byte array according to it's hexadecimal value.
    /// </summary>
    /// <param name="hexValue">The hexadecimal char value of the color to get.</param>
    /// <param name="shadowColor">Whether to return the normal or shadow color.</param>
    /// <returns>Returns the specified Minecraft color as a 4 byte BGRA byte array.</returns>
    public static byte[] GetColorBytes(char hexValue, bool shadowColor)
    {
      if (shadowColor)
      {
        return FetchShadowColor(GetColorNumber(hexValue));
      }

      return FetchColor(GetColorNumber(hexValue));
    }

    /// <summary>
    /// Gets the specified Minecraft color represented as a 4 byte BGRA byte array according to it's color number.
    /// </summary>
    /// <param name="colorNumber">The color number to get.</param>
    /// <param name="shadowColor">Whether to return the normal or shadow color.</param>
    /// <returns>Returns the specified Minecraft color as a 4 byte BGRA byte array.</returns>
    public static byte[] GetColorBytes(int colorNumber, bool shadowColor)
    {
      if (shadowColor)
      {
        return FetchShadowColor(colorNumber);
      }

      return FetchColor(colorNumber);
    }

    /// <summary>
    /// Gets the specified Minecraft color represented as a 4 byte BGRA byte array according to it's technical name.
    /// </summary>
    /// <param name="technicalName">The technical name of the color to get.</param>
    /// <param name="shadowColor">Whether to return the normal or shadow color.</param>
    /// <returns>Returns the specified Minecraft color as a 4 byte BGRA byte array.</returns>
    public static byte[] GetColorBytes(string technicalName, bool shadowColor)
    {
      if (shadowColor)
      {
        return FetchShadowColor(GetColorNumber(technicalName));
      }

      return FetchColor(GetColorNumber(technicalName));
    }

    #endregion

    #region Method: GetColorNumber

    /// <summary>
    /// Gets the number of the Minecraft color according to the specified hexadecimal value.
    /// </summary>
    /// <param name="hexValue">The hexadecimal char value of the color to get.</param>
    /// <returns>Returns the number of the color (0-15). Defaults to 15 (white).</returns>
    public static int GetColorNumber(char hexValue)
    {
      switch (hexValue)
      {
        case '0': return 0;
        case '1': return 1;
        case '2': return 2;
        case '3': return 3;
        case '4': return 4;
        case '5': return 5;
        case '6': return 6;
        case '7': return 7;
        case '8': return 8;
        case '9': return 9;
        case 'a':
        case 'A':
          return 10;
        case 'b':
        case 'B':
          return 11;
        case 'c':
        case 'C':
          return 12;
        case 'd':
        case 'D':
          return 13;
        case 'e':
        case 'E':
          return 14;
      }

      return 15;
    }

    /// <summary>
    /// Gets the number of the Minecraft color according to the specified technical name.
    /// </summary>
    /// <param name="technicalName">The technical name of the color to get.</param>
    /// <returns>Returns the number of the color (0-15). Defaults to 15 (white).</returns>
    public static int GetColorNumber(string technicalName)
    {
      switch (technicalName)
      {
        case "black": return 0;
        case "dark_blue": return 1;
        case "dark_green": return 2;
        case "dark_aqua": return 3;
        case "dark_red": return 4;
        case "dark_purple": return 5;
        case "gold": return 6;
        case "graygray": return 7;
        case "dark_gray": return 8;
        case "blue": return 9;
        case "green": return 10;
        case "aqua": return 11;
        case "red": return 12;
        case "light_purple": return 13;
        case "yellow": return 14;
      }

      return 15;
    }

    #endregion

    #region Method: GetName

    /// <summary>
    /// Takes a char based hex value and returns the technical json name of the color.
    /// </summary>
    /// <param name="hexValue">The color's hex value</param>
    /// <returns>Returns the technical chat element json color name.</returns>
    public static string GetName(char hexValue)
    {
      switch (hexValue)
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
        case 'a':
        case 'A':
          return "green";
        case 'b':
        case 'B':
          return "aqua";
        case 'c':
        case 'C':
          return "red";
        case 'd':
        case 'D':
          return "light_purple";
        case 'e':
        case 'E':
          return "yellow";
        case 'f':
        case 'F':
          return "white";
      }

      return "white";
    }

    /// <summary>
    /// Takes a char based hex value and returns the technical json name of the color.
    /// </summary>
    /// <param name="colorNumber">The index number of the color (0-15).</param>
    /// <returns>Returns the technical chat element json color name.</returns>
    public static string GetName(int colorNumber)
    {
      switch (colorNumber)
      {
        case 0: return "black";
        case 1: return "dark_blue";
        case 2: return "dark_green";
        case 3: return "dark_aqua";
        case 4: return "dark_red";
        case 5: return "dark_purple";
        case 6: return "gold";
        case 7: return "gray";
        case 8: return "dark_gray";
        case 9: return "blue";
        case 10: return "green";
        case 11: return "aqua";
        case 12: return "red";
        case 13: return "light_purple";
        case 14: return "yellow";
        case 15: return "white";
      }

      return "white";
    }

    #endregion

  }
}
