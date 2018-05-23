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

    private Rectangle[] ColorHitBoxes = new Rectangle[0];

    private string ColorCodes = "0123456789abcdef";

    private Rectangle[] FormatHitBoxes = new Rectangle[0];
    private Bitmap[] FormatIcons = new Bitmap[0];

    #region Method: ApplyControlTag

    private void ApplyControlTag(char controlChar)
    {
      string controlTag = "&" + controlChar;
      string currentText = txtText.Text;
      int startPos = txtText.SelectionStart;
      int selectionLength = txtText.SelectionLength;

      if (selectionLength > 0)
      { // part of the text is selected
        string firstPart = currentText.Substring(0, startPos);
        string selectedPart = currentText.Substring(startPos, selectionLength);
        string lastPart = currentText.Substring(startPos + selectionLength, currentText.Length - (startPos + selectionLength));

        // is there a reset control tag in the lastPart ??
        if (lastPart.Length >= 2 && (lastPart.Substring(0, 2) == "&r" || lastPart.Substring(0, 2) == "§r"))
        {
          // Yup, we have a reset controlTag
        }
        else
        {
          // Nope, so prepend it
          lastPart = "&r" + lastPart;
        }

        txtText.Text = firstPart + controlTag + selectedPart + lastPart;
        txtText.SelectionStart = startPos + controlTag.Length;
        txtText.SelectionLength = selectionLength;
      }
      else
      { // nothing is selected: insert the control tag at the selection start position
        string firstPart = currentText.Substring(0, startPos);
        string secondPart = currentText.Substring(startPos, currentText.Length - startPos);

        txtText.Text = firstPart + controlTag + secondPart;
        txtText.SelectionStart = startPos + controlTag.Length;
        txtText.SelectionLength = 0;
      }
    }

    #endregion

    #region Method: BuildColorHitBoxes

    private void BuildColorHitBoxes()
    {
      int boxSpacing = 5;
      int boxWidth = (txtText.Width - (7 * boxSpacing)) / 8;
      int boxHeight = txtText.Height;
      int Y = txtText.Top - ((btnAccept.Height + (boxHeight * 2) + (2 * boxSpacing)) + 10);

      ColorHitBoxes = new Rectangle[16];

      for (int i = 0; i < 8; i++)
      {
        ColorHitBoxes[i] = new Rectangle(
          txtText.Left + (i * (boxWidth + boxSpacing)),
          Y,
          boxWidth,
          boxHeight
          );

        ColorHitBoxes[i + 8] = new Rectangle(
          txtText.Left + (i * (boxWidth + boxSpacing)),
          Y + (boxHeight + boxSpacing),
          boxWidth,
          boxHeight
          );
      }
    }

    #endregion

    #region Method: BuildFormatHitBoxes

    private void BuildFormatHitBoxes()
    {
      int boxSpacing = 5;
      int boxWidth = 23;
      int boxHeight = 23;

      FormatHitBoxes = new Rectangle[4];
      FormatIcons = new Bitmap[4];

      for (int f = 0; f < FormatHitBoxes.Length; f++)
      {
        FormatHitBoxes[f] = new Rectangle(
          txtText.Left + (f * (boxWidth + boxSpacing)),
          btnAccept.Top,
          boxWidth,
          boxHeight
          );
        switch (f)
        {
          case 0: FormatIcons[f] = GetResourceImageByName("CharacterBold"); break;
          case 1: FormatIcons[f] = GetResourceImageByName("CharacterItalic"); break;
          case 2: FormatIcons[f] = GetResourceImageByName("CharacterStrikethrough"); break;
          case 3: FormatIcons[f] = GetResourceImageByName("CharacterUnderlined"); break;
        }
      }
    }

    #endregion

    #region Method: GetHitIndex

    private int GetHitIndex(ref Rectangle[] hitBoxes, int mouseX, int mouseY)
    {
      for (int c = 0; c < hitBoxes.Length; c++)
      {
        if (
          (mouseX >= hitBoxes[c].X && mouseX < hitBoxes[c].X + hitBoxes[c].Width)
          &&
          (mouseY >= hitBoxes[c].Y && mouseY < hitBoxes[c].Y + hitBoxes[c].Height)
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

    #region Method: ResetFormatting

    private void ResetFormatting()
    {
      string controlSymbols = "&§";
      string controlCodes = "0123456789abcdefklmnor";
      string currentText = txtText.Text;

      for (int s = 0; s < controlSymbols.Length; s++)
      {
        for (int c = 0; c < controlCodes.Length; c++)
        {
          currentText = currentText.Replace(
            controlSymbols[s].ToString() + controlCodes[c].ToString(),
            ""
            );
        }
      }

      txtText.Text = currentText;
      txtText.SelectionStart = 0;
      txtText.SelectionLength = 0;
    }

    #endregion

    #endregion

    #region ===== Rendering stuff to form =====

    #region Override: OnPaint

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      // Render the 16 Minecraft chat colors for button selection something
      if (ColorHitBoxes.Length > 0)
      {

        for (int c = 0; c < ColorHitBoxes.Length; c++)
        {
          e.Graphics.FillRectangle(new SolidBrush(MinecraftColors.GetColor(c)), ColorHitBoxes[c]);

          if (c < 8)
          { // Render the text above the current rectangle

            e.Graphics.DrawString(
              ColorCodes[c].ToString(),
              txtText.Font,
              Brushes.White,
              new Rectangle(
                ColorHitBoxes[c].X,
                ColorHitBoxes[c].Y - ColorHitBoxes[c].Height,
                ColorHitBoxes[c].Width,
                ColorHitBoxes[c].Height
                ),
              new StringFormat
              {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
              }
              );

          }
          else
          { // Render the text below the current rectangle

            e.Graphics.DrawString(
              ColorCodes[c].ToString(),
              txtText.Font,
              Brushes.White,
              new Rectangle(
                ColorHitBoxes[c].X,
                ColorHitBoxes[c].Y + ColorHitBoxes[c].Height,
                ColorHitBoxes[c].Width,
                ColorHitBoxes[c].Height
                ),
              new StringFormat
              {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
              }
              );

          }

          if (c == LastColorHitIndex)
          {
            e.Graphics.DrawRectangle(
              Pens.White,
              new Rectangle(
                ColorHitBoxes[c].X - 2,
                ColorHitBoxes[c].Y - 2,
                ColorHitBoxes[c].Width + 3,
                ColorHitBoxes[c].Height + 3
                )
              );
          }
        }
      }
      // If the formatting hit boxes are initialized...
      if (FormatHitBoxes.Length > 0)
      {

        for (int f = 0; f < FormatHitBoxes.Length; f++)
        {

          if (f == LastFormatHitIndex)
          { // Hovered state

            e.Graphics.FillRectangle(
              new SolidBrush(
                Color.FromArgb(128, Color.CornflowerBlue.R, Color.CornflowerBlue.G, Color.CornflowerBlue.B)
                ),
              FormatHitBoxes[f]
              );
            e.Graphics.DrawRectangle(
              new Pen(
                Color.CornflowerBlue
                ),
              FormatHitBoxes[f]
              );

          }
          else
          { // Unhovered state
            e.Graphics.FillRectangle(
              new SolidBrush(
                Color.FromArgb(128, 224, 224, 224)
                ),
              FormatHitBoxes[f]
              );
            e.Graphics.DrawRectangle(
              new Pen(
                Color.FromArgb(255, 224, 224, 224)
                ),
              FormatHitBoxes[f]
              );
          }

          e.Graphics.DrawImage(
            FormatIcons[f],
            FormatHitBoxes[f].X + 4,
            FormatHitBoxes[f].Y + 4
            );

        }

      }

      // Render a black background to contain the custom text stuff
      e.Graphics.FillRectangle(
        Brushes.Black,
        new Rectangle(
          7,
          7,
          ClientRectangle.Width - 14,
          70
          )
        );

      // Finally render the custom font and text
      if (txtText.Text.Trim().Length > 0)
      {
        MCFont.DrawString(txtText.Text, e.Graphics, new Point(15, 15));
      }

    }

    #endregion

    #endregion

    #region ===== Mouse Handling =====

    private int LastColorHitIndex = -1;
    private int LastFormatHitIndex = -1;

    #region Override: OnMouseClick

    protected override void OnMouseClick(MouseEventArgs e)
    {
      base.OnMouseClick(e);

      if (e.Button == MouseButtons.Left)
      {
        if (LastColorHitIndex > -1)
        {
          ApplyControlTag(ColorCodes[LastColorHitIndex]);
        }
        else if (LastFormatHitIndex > -1)
        {
          string formatCodes = "lomn";
          ApplyControlTag(formatCodes[LastFormatHitIndex]);
        }
      }
    }

    #endregion

    #region Override: OnMouseMove

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);

      int hitIndex = GetHitIndex(ref ColorHitBoxes, e.X, e.Y);
      if (hitIndex != LastColorHitIndex)
      {
        LastColorHitIndex = hitIndex;
        Invalidate();
      }
      hitIndex = GetHitIndex(ref FormatHitBoxes, e.X, e.Y);
      if (hitIndex != LastFormatHitIndex)
      {
        LastFormatHitIndex = hitIndex;
        Invalidate();
      }
    }

    #endregion

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

    private void btnReset_Click(object sender, EventArgs e)
    {
      ResetFormatting();
    }

    private void btnAccept_Click(object sender, EventArgs e)
    {
      mvarCustomText = txtText.Text;
      this.DialogResult = DialogResult.OK;
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

      BuildColorHitBoxes();
      BuildFormatHitBoxes();
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
