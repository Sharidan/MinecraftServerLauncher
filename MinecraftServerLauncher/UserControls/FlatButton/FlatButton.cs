using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftServerLauncher.UserControls.FlatButton
{
  public partial class FlatButton : UserControl
  {

    private bool MouseOverButton = false;

    #region ===== Properties =====

    #region Property: DisabledBackColor

    public Color DisabledBackColor { get; set; } = Color.FromArgb(255, 96, 96, 96);

    #endregion

    #region Property: DisabledForeColor

    public Color DisabledForeColor { get; set; } = Color.Gray;

    #endregion

    #region Property: EnabledBackColor

    public Color EnabledBackColor { get; set; } = Color.FromArgb(255, 224, 224, 224);

    #endregion

    #region Property: EnabledForeColor

    public Color EnabledForeColor { get; set; } = Color.Black;

    #endregion

    #region Property: Text

    // public new string Text { get; set; } = "flatButton";

    #endregion

    #endregion

    #region ===== Rendering =====

    private void DrawButtonBox(Graphics gr, int alpha, Color backColor, Color foreColor)
    {
      gr.FillRectangle(
        new SolidBrush(Color.FromArgb(alpha, backColor.R, backColor.G, backColor.B)),
        new Rectangle(0, 0, this.Width, this.Height)
        );
      gr.DrawRectangle(
        new Pen(backColor),
        new Rectangle(0, 0, this.Width - 1, this.Height - 1)
        );

      //TODO: This is where we need to draw the button's text :)
      StringFormat sf = new StringFormat();
      sf.Alignment = StringAlignment.Center; // Centers the text horizontally
      sf.LineAlignment = StringAlignment.Center; // Middle aligns the text vertically on the line
      gr.DrawString(Text, this.Font, new SolidBrush(foreColor), new Rectangle(0, 0, this.Width, this.Height), sf);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      // Here is where we can do our custom drawing stuff :)

      switch (this.Enabled)
      {
        case true:
          // Render the button in enabled state - i.e. bright setup maybe?

          if (MouseOverButton)
          {
            DrawButtonBox(e.Graphics, 128, Color.CornflowerBlue, EnabledForeColor);
          }
          else
          {
            DrawButtonBox(e.Graphics, 128, EnabledBackColor, EnabledForeColor);
          }

          break;
        case false:
          // Render the button in disabled state - i.e. dark setup maybe?
          DrawButtonBox(e.Graphics, 64, DisabledBackColor, DisabledForeColor);

          break;
      }

    }

    #endregion

    #region ==== Overrides =====

    protected override void OnEnabledChanged(EventArgs e)
    {
      base.OnEnabledChanged(e);

      Invalidate();
    }

    protected override void OnTextChanged(EventArgs e)
    {
      base.OnTextChanged(e);

      Invalidate();
    }

    protected override void OnMouseEnter(EventArgs e)
    {
      base.OnMouseEnter(e);

      MouseOverButton = true;
      if (this.Enabled)
      {
        Invalidate();
      }
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);

      if (this.Enabled && MouseOverButton)
      {
        MouseOverButton = false;
        Invalidate();
      }
      else
      {
        MouseOverButton = false;
      }
    }

    #endregion

    #region ===== UserControl Events =====

    private void FlatButton_Load(object sender, EventArgs e)
    {
      
    }

    #endregion

    #region ===== Constructor =====

    public FlatButton()
    {
      InitializeComponent();

      this.Text = "flatButton";

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
