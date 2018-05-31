using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpLibs.Minecraft;

namespace MinecraftServerLauncher.UserControls.MinecraftTextView
{
  public partial class MinecraftTextView : UserControl
  {

    private MinecraftFont MCFont = new MinecraftFont();

    private const string ColorCodes = "0123456789abcdef";

    private Rectangle[] HitBoxes = new Rectangle[0];

    private Bitmap[] FormattingIcons = new Bitmap[0];

    private int LastHitIndex = -1;

    #region ===== Internal Helper Methods =====

    #region Method: BuildFormattingIcons

    private void BuildFormattingIcons()
    {
      FormattingIcons = new Bitmap[]
        {
          GetResourceImageByName("CharacterBold"), // index: 0
          GetResourceImageByName("CharacterItalic"), // index: 1
          GetResourceImageByName("CharacterStrikethrough"), // index: 2
          GetResourceImageByName("CharacterUnderlined") // index: 3
        };
    }

    #endregion

    #region Method: BuildHitBoxes

    private void BuildHitBoxes()
    {
      int boxWidth = 32; // pixels
      int boxHeight = 16; // pixels
      int boxPadding = 2; // pixels
      int x = 0;
      int y = this.Height - (2 * (boxHeight + (2 * boxPadding)));

      HitBoxes = new Rectangle[20];

      for (int h = 0; h < HitBoxes.Length / 2; h++)
      {
        HitBoxes[h] = new Rectangle(
          x + boxPadding,
          y + boxPadding,
          boxWidth,
          boxHeight
          );

        HitBoxes[h + 10] = new Rectangle(
          x + boxPadding,
          y + (boxHeight + (2 * boxPadding)) + boxPadding,
          boxWidth,
          boxHeight
          );

        x += (boxWidth + (2 * boxPadding));
      }
    }

    #endregion

    #region Method: GetHitIndex

    private int GetHitIndex(int mouseX, int mouseY)
    {
      // For reference:
      // These checks can also be done via:
      // if (HitBoxes[c].Contains(new Point(mouseX, mouseY))) ....

      for (int c = 0; c < HitBoxes.Length; c++)
      {
        if (
          (mouseX >= HitBoxes[c].X && mouseX < HitBoxes[c].X + HitBoxes[c].Width)
          &&
          (mouseY >= HitBoxes[c].Y && mouseY < HitBoxes[c].Y + HitBoxes[c].Height)
          )
        {
          return c;
        }
      }

      return -1;
    }

    #endregion

    #region Method: GetResourceBitmapByName

    private Bitmap GetResourceImageByName(string imageName)
    {
      System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
      string resourceName = asm.GetName().Name + ".Properties.Resources";
      var rm = new System.Resources.ResourceManager(resourceName, asm);
      return (Bitmap)rm.GetObject(imageName);
    }

    #endregion

    #endregion

    #region ===== Surface Rendering =====

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      //TODO: add the actual user control surface rendering stuffz
      if (TextBoxLine1 != null && TextBoxLine2 != null)
      {
        // Now we can render our custom surface...

      }

      if (HitBoxes.Length > 0)
      {
        string controlLetters = "01234567lo89abcdefmn";

        for (int h = 0; h < HitBoxes.Length; h++)
        {
          if (h < 8)
          {
            // Lower 8 colors
            e.Graphics.FillRectangle(
              new SolidBrush(
                MinecraftColors.GetColor(h)
                ),
              new Rectangle(
                HitBoxes[h].X + 16,
                HitBoxes[h].Y,
                16,
                16
                )
              );
          }
          else if (h == 8 || h == 9)
          {
            // First two formatting icons
            e.Graphics.DrawImage(
              FormattingIcons[h - 8],
              HitBoxes[h].X + 16,
              HitBoxes[h].Y
              );
          }
          else if (h > 9 && h < 18)
          {
            // Higher 8 colors
            e.Graphics.FillRectangle(
              new SolidBrush(
                MinecraftColors.GetColor(h - 2)
                ),
              new Rectangle(
                HitBoxes[h].X + 16,
                HitBoxes[h].Y,
                16,
                16
                )
              );
          }
          else
          {
            // Last two formatting icons
            e.Graphics.DrawImage(
              FormattingIcons[h - 16],
              HitBoxes[h].X + 16,
              HitBoxes[h].Y
              );
          }

          e.Graphics.DrawString(
            controlLetters[h].ToString(),
            this.Font,
            SystemBrushes.ControlText,
            new Rectangle(
              HitBoxes[h].X,
              HitBoxes[h].Y,
              16,
              16
              ),
            new StringFormat
            {
              Alignment = StringAlignment.Center,
              LineAlignment = StringAlignment.Center
            }
            );

          if (h == LastHitIndex)
          {
            // Bright part of 3D effect
            e.Graphics.DrawLine(SystemPens.ControlLight, HitBoxes[h].X - 2, HitBoxes[h].Y - 2, HitBoxes[h].X + HitBoxes[h].Width + 1, HitBoxes[h].Y - 2);
            e.Graphics.DrawLine(SystemPens.ControlLight, HitBoxes[h].X - 2, HitBoxes[h].Y - 2, HitBoxes[h].X - 2, HitBoxes[h].Y + HitBoxes[h].Height + 1);
            // Dark part of 3D effect
            e.Graphics.DrawLine(SystemPens.ControlDark, HitBoxes[h].X + HitBoxes[h].Width + 1, HitBoxes[h].Y - 1, HitBoxes[h].X + HitBoxes[h].Width + 1, HitBoxes[h].Y + HitBoxes[h].Height + 1);
            e.Graphics.DrawLine(SystemPens.ControlDark, HitBoxes[h].X - 1, HitBoxes[h].Y + HitBoxes[h].Height + 1, HitBoxes[h].X + HitBoxes[h].Width, HitBoxes[h].Y + HitBoxes[h].Height + 1);
          }

        }
      }

    }

    #endregion

    #region ===== Mouse Handling =====

    protected override void OnMouseClick(MouseEventArgs e)
    {
      base.OnMouseClick(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);

      int hitIndex = GetHitIndex(e.X, e.Y);
      if (hitIndex != LastHitIndex)
      {
        LastHitIndex = hitIndex;
        Invalidate();
      }
    }

    #endregion

    #region ===== TextBox Control Handling =====

    private TextBox TextBoxLine1 = null;
    private TextBox TextBoxLine2 = null;

    private void TextBox_TextChanged(object sender, EventArgs e)
    {
      Invalidate();
    }

    public void HookTextBoxes(ref TextBox textBox1, ref TextBox textBox2)
    {
      TextBoxLine1 = textBox1;
      TextBoxLine2 = textBox2;

      TextBoxLine1.TextChanged += TextBox_TextChanged;
      TextBoxLine2.TextChanged += TextBox_TextChanged;
    }

    #endregion

    #region ===== User Control Events =====

    private void MinecraftTextView_Load(object sender, EventArgs e)
    {
      MCFont.SetGlyphBitmap(GetResourceImageByName("FontGlyphsAscii"));
      MCFont.Zoom = 2;

      BuildFormattingIcons();
      BuildHitBoxes();
    }

    #endregion

    #region ===== Constructor =====

    public MinecraftTextView()
    {
      InitializeComponent();

      // Set settings for handling how the control is drawn
      SetStyle(
        ControlStyles.AllPaintingInWmPaint | 
        ControlStyles.OptimizedDoubleBuffer | 
        ControlStyles.ResizeRedraw | 
        ControlStyles.UserPaint, 
        true
        );
      // Prevent the user control from gaining focus
      SetStyle(
        ControlStyles.Selectable, 
        false
        );
    }

    #endregion

  }
}
