using CSharpLibs.Minecraft;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftServerLauncher
{
  public partial class CustomTextDialog : Form
  {

    #region ===== Internal Helper Methods =====

    private MinecraftFont MCFont = new MinecraftFont();

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

    #region ===== Rendering stuff to form =====

    private Color InvertColor(Color color)
    {
      return Color.FromArgb(color.A, 255 - color.R, 255 - color.G, 255 - color.B);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      //TODO: add in the custom text rendering stuffz
      e.Graphics.FillRectangle(
        Brushes.Black,
        new Rectangle(
          7,
          7,
          ClientRectangle.Width - 14,
          70
          )
        );

      string colorChars = "0123456789abcdef";
      int colorSpacing = 3;
      int colorWidth = (txtText.Width - (7 * colorSpacing)) / 8;
      int colorHeight = txtText.Height;

      StringFormat sf = new StringFormat();
      sf.Alignment = StringAlignment.Center;
      sf.LineAlignment = StringAlignment.Center;

      // Rendering of the 16 Minecraft chat colors
      for (int c = 0; c < 8; c++)
      {
        e.Graphics.FillRectangle(new SolidBrush(MinecraftColors.GetColor(c)), new Rectangle(
          txtText.Left + ((colorWidth + colorSpacing) * c),
          txtText.Top - ((colorHeight * 2) + colorSpacing + 10),
          colorWidth,
          colorHeight
          ));
        e.Graphics.DrawString(colorChars[c].ToString(), this.Font, new SolidBrush(InvertColor(MinecraftColors.GetColor(c))), new Rectangle(
          txtText.Left + ((colorWidth + colorSpacing) * c),
          txtText.Top - ((colorHeight * 2) + colorSpacing + 10),
          colorWidth,
          colorHeight
          ),
          sf
          );

        e.Graphics.FillRectangle(new SolidBrush(MinecraftColors.GetColor(c + 8)), new Rectangle(
          txtText.Left + ((colorWidth + colorSpacing) * c),
          txtText.Top - (colorHeight + 10),
          colorWidth,
          colorHeight
          ));
        e.Graphics.DrawString(colorChars[c + 8].ToString(), this.Font, new SolidBrush(InvertColor(MinecraftColors.GetColor(c + 8))), new Rectangle(
          txtText.Left + ((colorWidth + colorSpacing) * c),
          txtText.Top - (colorHeight + 10),
          colorWidth,
          colorHeight
          ),
          sf
          );
      }

      if (txtText.Text.Trim().Length > 0)
      {
        MCFont.DrawString(txtText.Text, e.Graphics, new Point(15, 15));
      }

    }

    #endregion

    #region ===== Properties =====

    #region Property: CustomText

    private string mvarCustomText = "";

    public string CustomText
    {
      get { return mvarCustomText; }
      set
      {
        mvarCustomText = value;
        //TODO: Perhaps force a render update?
      }
    }

    #endregion

    #endregion

    #region ===== Control Events =====

    private void txtText_TextChanged(object sender, EventArgs e)
    {
      Invalidate();
    }

    private void btnAccept_Click(object sender, EventArgs e)
    {
      //TODO: add in accept code to update the .CustomText property and return dialog OK
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    #endregion

    #region ===== Form Events =====

    private void CustomTextDialog_Load(object sender, EventArgs e)
    {
      MCFont.SetGlyphBitmap(GetResourceImageByName("FontGlyphsAscii"));
      MCFont.Zoom = 2;
    }

    private void CustomTextDialog_Shown(object sender, EventArgs e)
    {
      txtText.Text = mvarCustomText;
      txtText.Focus();
    }

    #endregion

    #region ===== Constructor =====

    public CustomTextDialog()
    {
      InitializeComponent();

      this.Shown += CustomTextDialog_Shown;

      SetStyle(
        ControlStyles.AllPaintingInWmPaint | 
        ControlStyles.OptimizedDoubleBuffer | 
        ControlStyles.ResizeRedraw | 
        ControlStyles.UserPaint, 
        true
        );
    }

    #endregion

  }
}
