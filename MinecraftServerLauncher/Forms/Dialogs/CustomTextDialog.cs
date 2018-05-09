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

    #region ===== Rendering stuff to form =====

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
