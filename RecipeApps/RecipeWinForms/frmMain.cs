using CPUWindowsFormFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeWinForms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            mnuSearchRecipe.Click += MnuSearchRecipe_Click;
            mnuNewRecipe.Click += MnuNewRecipe_Click;
        }

        private void FrmMain_Shown(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmDashboard));
        }

        public void OpenForm(Type frmType, int pkvalue = 0)
        {
            bool b = WindowsFormUtility.IsFormOpen(frmType);
            Form? newfrm = null;
            if (b == false)
            {
                if (frmType == typeof(frmRecipe))
                {
                    frmRecipe f = new();
                    newfrm = f;
                    f.ShowForm(pkvalue);
                }
                else if (frmType == typeof(frmSearch))
                {
                    frmSearch f = new();
                    newfrm = f;
                }
                if (newfrm != null)
                {
                    newfrm.MdiParent = this;
                    newfrm.WindowState = FormWindowState.Maximized;
                    newfrm.FormClosed += Frm_FormClosed;
                    newfrm.TextChanged += Newfrm_TextChanged;
                    newfrm.Show();
                }
                WindowsFormUtility.SetupNav(tsMain);
            }
        }
        private void Newfrm_TextChanged(object? sender, EventArgs e)
        {
            WindowsFormUtility.SetupNav(tsMain);
        }
        private void Frm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            WindowsFormUtility.SetupNav(tsMain);
        }

        private void MnuNewRecipe_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmRecipe));

        }

        private void MnuSearchRecipe_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmSearch));
        }
        /*
        private void MnuNewRecipe_Click(object? sender, EventArgs e)
        {
            frmRecipe f = new frmRecipe();
            f.MdiParent = this;
            f.Show();
        }

        private void MnuSearchRecipe_Click(object? sender, EventArgs e)
        {
            frmSearch f= new frmSearch();
            f.MdiParent = this;
            f.Show();
        }*/
    }
}
