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

    public bool Shadows { get; set; } = false;

    public int LetterSpacing { get; set; } = 1;

    public int LineHeight { get; set; } = 9;

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
      ChatElement[] chatElements = ChatConverter.ToElements(chatText);
      Size surfaceSize = MeasureString(ref chatElements);





      return null;
    }

    public void DrawString(string chatText, Graphics g, Point point)
    {

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

        for (int t = 0; t < elements[e].Text.Length; t++)
        {
          byte charIndex = (byte)elements[e].Text[t];

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
