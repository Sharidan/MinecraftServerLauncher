using CSharpLibs.ConfigTools;
using CSharpLibs.Minecraft;
using CSharpLibs.Networking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 
 * Update: 6. April 2018
 * So far this form is still one huge mess of test setups.
 * As we progress further with this project, most of the
 * current code in this form will be replaced.
 * 
 */

namespace MinecraftServerLauncher
{
  public partial class MainForm : Form
  {

    #region ===== Form Events =====

    private void MainForm_Load(object sender, EventArgs e)
    {

    }

    private void MainForm_Shown(object sender, EventArgs e)
    {

    }

    #endregion

    #region ===== Constructor =====

    public MainForm()
    {
      InitializeComponent();

      this.Shown += MainForm_Shown;
    }

    #endregion

  }
}
