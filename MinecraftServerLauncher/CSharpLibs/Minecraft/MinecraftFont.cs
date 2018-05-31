using CSharpLibs.Encoders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLibs.Minecraft
{
  class MinecraftFont
  {

    //NOTE:
    // The game treats each chat element as having been reset before it's drawn in the chat box
    // So, when we build our text rendering, we have to treat each individual chat element as if it were reset

    private struct Glyph
    {
      public byte Width; // Actual width of this specific glyph
      public byte[] Bits; // List of bits that determine whether a pixel should be drawn or not.
    }

    private byte GlyphWidth = 0;
    private byte GlyphHeight = 0;

    private Glyph[] Glyphs = new Glyph[0];

    #region ===== Internal Helper Methods =====

    #region Method: DrawGlyphPixel

    private void DrawGlyphPixel(int x, int y, int lineWidth, ref byte[] pixelColor, ref byte[] imageBuffer)
    {
      int targetPosition = 0;

      if (mvarZoom == 1)
      {
        // Draw the foreground glyph pixel...
        targetPosition = (y * lineWidth) + (x * 4);
        // Copy the forecolor pixel into the image buffer:
        if (targetPosition < imageBuffer.Length - 4)
        {
          // This is to ensure that we are within the size of the image buffer
          Array.Copy(pixelColor, 0, imageBuffer, targetPosition, pixelColor.Length);
        }
      }
      else
      {
        for (int zy = 0; zy < mvarZoom; zy++)
        {
          for (int zx = 0; zx < mvarZoom; zx++)
          {
            targetPosition = (((y * mvarZoom) + zy)  * (lineWidth * mvarZoom)) + (((x * mvarZoom) + zx) * 4);

            if (targetPosition < imageBuffer.Length - 4)
            {
              // This is to ensure that we are within the size of the image buffer
              Array.Copy(pixelColor, 0, imageBuffer, targetPosition, pixelColor.Length);
            }
          }
        }
      }
    }

    #endregion

    #region Method: GetColor

    // Byte order of the pixel color channels:
    // rasterImage[0] == blue
    // rasterImage[1] == green
    // rasterImage[2] == red
    // rasterImage[3] == alpha

    private byte[] GetColor(ChatElement element)
    {
      return GetColor(element, false);
    }

    private byte[] GetColor(ChatElement element, bool shadowColor)
    {
      if (shadowColor)
      { // Shadow color
        return MinecraftColors.GetColorBytes(element.Color, true);
      }
      
      // Normal color
      return MinecraftColors.GetColorBytes(element.Color);
    }

    #endregion

    #region Method: ScanGlyphWidth

    private void ScanGlyphWidth(int glyphIndex, ref Glyph glyph)
    {
      if (glyphIndex == 32)
      {
        glyph.Width = 4; // 4 pixels forced
      }
      else
      {
        glyph.Width = 0;

        for (int y = 0; y < GlyphHeight; y++)
        {
          for (int x = 0; x < GlyphWidth; x++)
          {
            if (glyph.Bits[(y * GlyphWidth) + x] > 0 && glyph.Width < x + 1)
            {
              glyph.Width = (byte)(x + 1);
            }
          }
        }
      }
    }

    #endregion

    #endregion

    #region ===== Properties =====

    public int LetterSpacing { get; set; } = 1;

    public int LineHeight { get; set; } = 9;

    public bool Shadows { get; set; } = false;


    #region Property: Zoom

    private int mvarZoom = 1;

    public int Zoom
    {
      get { return mvarZoom; }
      set
      {
        if (value >= 1 && value <= 4)
        {
          mvarZoom = value;
        }
      }
    }

    #endregion

    #endregion

    #region ===== Public Methods =====

    #region Method: DisposeAllGlyphs

    public void DisposeAllGlyphs()
    {
      if (Glyphs.Length > 0)
      {
        // Kill off any pre-existing glyphs...
        Glyphs = new Glyph[0];
      }
    }

    #endregion

    #region Method: DrawString

    public Bitmap DrawString(string chatText)
    {
      // Convert the chat text into individual chat elements
      ChatElement[] chatElements = ChatConverter.ToElements(chatText);
      // Calculate the size in pixels required to render this text
      Size surfaceSize = MeasureString(ref chatElements);
      // Create an image buffer we can draw into
      byte[] rasterImage = new byte[((surfaceSize.Width * mvarZoom) * (surfaceSize.Height * mvarZoom)) * 4];
      // Pixel color buffers:
      byte[] ForeColor = new byte[0];
      byte[] ShadowColor = new byte[0];
      int drawX = 0; // Current draw X position
      int drawY = 0; // Current draw Y position
      int pixelLineWidth = surfaceSize.Width * 4;
      int strikethroughY = (surfaceSize.Height / 2) - 1;

      // Loop through all the chat elements....
      for (int e = 0; e < chatElements.Length; e++)
      {
        // Fetch the forecolor for this chat element
        ForeColor = GetColor(chatElements[e]);
        // Do we also need the shadow color?
        if (Shadows)
        {
          // Fetch the shadow color for this element
          ShadowColor = GetColor(chatElements[e], true);
        }

        // Convert the default UTF16 string into ASCII using our custom encoder
        byte[] asciiText = ASCIIEncoder.GetBytes(chatElements[e].Text);

        // Loop through each ascii character reference
        for (int a = 0; a < asciiText.Length; a++)
        {
          int glyphIndex = asciiText[a];

          // Loop through the glyph, drawing only solid pixels....
          for (int gy = 0; gy < GlyphHeight; gy++)
          {

            //INFO:
            // gx = glyph x
            // gy = glyph y

            for (int gx = 0; gx < Glyphs[glyphIndex].Width; gx++)
            {
              byte bit = Glyphs[glyphIndex].Bits[(gy * GlyphWidth) + gx];

              // for the sake of readability:
              int pixelX = drawX + gx;
              int pixelY = drawY + gy;

              if (bit > 0)
              {

                // Draw the shadow here ...
                if (Shadows)
                {
                  DrawGlyphPixel(pixelX + 1, pixelY + 1, pixelLineWidth, ref ShadowColor, ref rasterImage);

                  if (chatElements[e].Bold)
                  {
                    DrawGlyphPixel(pixelX + 2, pixelY + 1, pixelLineWidth, ref ShadowColor, ref rasterImage);
                  }

                  if (gy == GlyphHeight - 1)
                  {
                    // Process Strikethrough & Underline
                    if (chatElements[e].Strikethrough)
                    {
                      DrawGlyphPixel(pixelX + 1, strikethroughY + 1, pixelLineWidth, ref ShadowColor, ref rasterImage);

                      if (chatElements[e].Bold)
                      {
                        DrawGlyphPixel(pixelX + 2, strikethroughY + 1, pixelLineWidth, ref ShadowColor, ref rasterImage);
                      }
                    }
                    if (chatElements[e].Underlined)
                    {
                      DrawGlyphPixel(pixelX + 1, (GlyphHeight + 1), pixelLineWidth, ref ShadowColor, ref rasterImage);

                      if (chatElements[e].Bold)
                      {
                        DrawGlyphPixel(pixelX + 2, (GlyphHeight + 1), pixelLineWidth, ref ShadowColor, ref rasterImage);
                      }
                    }
                  }

                }

                // ---------------------------------------------------------

                DrawGlyphPixel(pixelX, pixelY, pixelLineWidth, ref ForeColor, ref rasterImage);

                if (chatElements[e].Bold)
                {
                  DrawGlyphPixel(pixelX + 1, pixelY, pixelLineWidth, ref ForeColor, ref rasterImage);
                }
              }

              if (gy == GlyphHeight - 1)
              {
                // Process Strikethrough & Underline
                if (chatElements[e].Strikethrough)
                {
                  DrawGlyphPixel(pixelX, strikethroughY, pixelLineWidth, ref ForeColor, ref rasterImage);

                  if (chatElements[e].Bold)
                  {
                    DrawGlyphPixel(pixelX + 1, strikethroughY, pixelLineWidth, ref ForeColor, ref rasterImage);
                  }
                }
                if (chatElements[e].Underlined)
                {
                  DrawGlyphPixel(pixelX, GlyphHeight, pixelLineWidth, ref ForeColor, ref rasterImage);

                  if (chatElements[e].Bold)
                  {
                    DrawGlyphPixel(pixelX + 1, GlyphHeight, pixelLineWidth, ref ForeColor, ref rasterImage);
                  }
                }
              }

            }

          } // for gy

          // Increment the drawX by the glyph width
          drawX += Glyphs[glyphIndex].Width;
          // Is this chat element in bold?
          if (chatElements[e].Bold)
          { // Yup, so add one pixel offset
            drawX++;
          }

          for (int l = 0; l < LetterSpacing; l++)
          {
            // Shadow?
            if (Shadows)
            {
              // Process Strikethrough & Underline
              if (chatElements[e].Strikethrough)
              {
                DrawGlyphPixel((drawX + l) + 1, strikethroughY + 1, pixelLineWidth, ref ShadowColor, ref rasterImage);

                if (chatElements[e].Bold)
                {
                  DrawGlyphPixel((drawX + l) + 2, strikethroughY + 1, pixelLineWidth, ref ShadowColor, ref rasterImage);
                }
              }
              if (chatElements[e].Underlined)
              {
                DrawGlyphPixel((drawX + l) + 1, (GlyphHeight + 1), pixelLineWidth, ref ShadowColor, ref rasterImage);

                if (chatElements[e].Bold)
                {
                  DrawGlyphPixel((drawX + l) + 2, (GlyphHeight + 1), pixelLineWidth, ref ShadowColor, ref rasterImage);
                }
              }
            }

            // Normal

            // Process Strikethrough & Underline
            if (chatElements[e].Strikethrough)
            {
              DrawGlyphPixel((drawX + l), strikethroughY, pixelLineWidth, ref ForeColor, ref rasterImage);

              if (chatElements[e].Bold)
              {
                DrawGlyphPixel((drawX + l) + 1, strikethroughY, pixelLineWidth, ref ForeColor, ref rasterImage);
              }
            }
            if (chatElements[e].Underlined)
            {
              DrawGlyphPixel((drawX + l), GlyphHeight, pixelLineWidth, ref ForeColor, ref rasterImage);

              if (chatElements[e].Bold)
              {
                DrawGlyphPixel((drawX + l) + 1, GlyphHeight, pixelLineWidth, ref ForeColor, ref rasterImage);
              }
            }

            // Increment the drawX by each pixel of letterspacing
            drawX++;
          }
        }
      }

      Bitmap result = new Bitmap(surfaceSize.Width * mvarZoom, surfaceSize.Height * mvarZoom, PixelFormat.Format32bppArgb);
      BitmapData data = result.LockBits(new Rectangle(0, 0, surfaceSize.Width * mvarZoom, surfaceSize.Height * mvarZoom), ImageLockMode.WriteOnly, result.PixelFormat);
      Marshal.Copy(rasterImage, 0, data.Scan0, rasterImage.Length);
      result.UnlockBits(data);
      data = null;

      rasterImage = new byte[0];

      return result;
    }

    public void DrawString(string chatText, Graphics g, Point point)
    {
      g.DrawImage(DrawString(chatText), point);
    }

    #endregion

    #region Method: MeasureString

    public Size MeasureString(string chatText)
    {
      ChatElement[] chatElements = ChatConverter.ToElements(chatText);
      Size result = MeasureString(ref chatElements);
      chatElements = new ChatElement[0];
      return result;
    }

    public Size MeasureString(ref ChatElement[] elements)
    {
      int result = 0;
      int boldExtra = 0;

      for (int e = 0; e < elements.Length; e++)
      {
        boldExtra = 0;
        if (elements[e].Bold)
        {
          boldExtra = 1; // One extra pixel per rendered character/glyph
        }

        // Using our custom ASCII encoder to handle conversion
        byte[] asciiText = ASCIIEncoder.GetBytes(elements[e].Text);
        for (int t = 0; t < asciiText.Length; t++)
        {
          byte charIndex = asciiText[t];

          result += Glyphs[charIndex].Width + boldExtra + LetterSpacing;
        }
      }

      return new Size(result, LineHeight);
    }

    #endregion

    #region Method: SetGlyphBitmap

    public void SetGlyphBitmap(Bitmap glyphBitmap)
    {
      if (glyphBitmap.PixelFormat == PixelFormat.Format32bppArgb)
      {
        DisposeAllGlyphs();

        // Create a buffer that can hold the entire bitmap: width * height * 4
        // The "4" above = 32 bits ~ 8 bits per channel, 4 channels = 32 bits :)
        byte[] rasterImage = new byte[(glyphBitmap.Width * glyphBitmap.Height) * 4];
        // Lock down the bitmap for the memory copy process..
        BitmapData data = glyphBitmap.LockBits(
          new Rectangle(0, 0, glyphBitmap.Width, glyphBitmap.Height), // Define the area of the bitmap we wish to manipulate
          ImageLockMode.ReadOnly, // We only want to read pixels
          glyphBitmap.PixelFormat // and this is the format it's stored in
          );
        Marshal.Copy(data.Scan0, rasterImage, 0, rasterImage.Length);
        glyphBitmap.UnlockBits(data);
        data = null;

        // Byte order of the pixel color channels:
        // rasterImage[0] == blue
        // rasterImage[1] == green
        // rasterImage[2] == red
        // rasterImage[3] == alpha

        GlyphWidth = (byte)(glyphBitmap.Width / 16); // 16 glyphs per line
        GlyphHeight = (byte)(glyphBitmap.Height / 16); // 16 lines of glyphs

        Glyphs = new Glyph[256];

        int glyphIndex = 0;
        int pixelLineWidth = glyphBitmap.Width * 4;

        for (int l = 0; l < 16; l++)
        {
          for (int r = 0; r < 16; r++)
          {
            // Here we need to pixel-scan each glyph
            // Initialize a sufficient buffer to store the glyph bits
            Glyphs[glyphIndex].Bits = new byte[(GlyphWidth * GlyphHeight)];
            for (int h = 0; h < GlyphHeight; h++)
            {
              for (int w = 0; w < GlyphWidth; w++)
              {
                byte a = rasterImage[

                  ((l * (pixelLineWidth * GlyphHeight))
                  +
                  (r * (GlyphWidth * 4)))
                  +
                  (h * pixelLineWidth)
                  +
                  (w * 4)
                  +
                  3 // Alpha channel offset

                  ];

                if (a > 127)
                {
                  // Solid
                  Glyphs[glyphIndex].Bits[(h * GlyphWidth) + w] = 1; // one indicates solid
                }
                else
                {
                  // Transparent
                  Glyphs[glyphIndex].Bits[(h * GlyphWidth) + w] = 0; // zero indicates transparent
                }
              }
            }

            ScanGlyphWidth(glyphIndex, ref Glyphs[glyphIndex]);

            glyphIndex++;
          }
        }

        // Kill off the image buffer; we're done :)
        rasterImage = new byte[0];

      }
    }

    #endregion

    #endregion

    #region ===== Constructor =====

    public MinecraftFont()
    {

    }

    #endregion

  }
}
