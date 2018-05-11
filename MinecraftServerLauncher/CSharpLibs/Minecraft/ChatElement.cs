namespace CSharpLibs.Minecraft
{

  /* 
   * JSON names for text formatting:
   * 
   * Obfuscated     => "obfuscated"
   * Bold           => "bold"
   * Strikethrough  => "strikethrough"
   * Underlined     => "underlined"
   * Italic         => "italic"
   * 
   */

  public struct ChatElement
  {
    public string Text;
    public string Color;
    public bool Obfuscated;
    public bool Bold;
    public bool Strikethrough;
    public bool Underlined;
    public bool Italic;

    public ChatElement(string text)
    {
      Text = text;
      Color = "";
      Obfuscated = false;
      Bold = false;
      Strikethrough = false;
      Underlined = false;
      Italic = false;
    }

    public ChatElement(string text, string color)
    {
      Text = text;
      Color = color;
      Obfuscated = false;
      Bold = false;
      Strikethrough = false;
      Underlined = false;
      Italic = false;
    }

    public ChatElement(string text, string color, bool obfuscated, bool bold, bool strikethrough, bool underlined, bool italic)
    {
      Text = text;
      Color = color;
      Obfuscated = obfuscated;
      Bold = bold;
      Strikethrough = strikethrough;
      Underlined = underlined;
      Italic = italic;
    }

    public ChatElement(ChatElement element)
    {
      Text = element.Text;
      Color = element.Color;
      Obfuscated = element.Obfuscated;
      Bold = element.Bold;
      Strikethrough = element.Strikethrough;
      Underlined = element.Underlined;
      Italic = element.Italic;
    }

  }
}
