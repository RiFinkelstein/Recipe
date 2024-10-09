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
            mnuDashboard.Click += MnuDashboard_Click;
            mnuSearchRecipe.Click += MnuSearchRecipe_Click;
            mnuNewRecipe.Click += MnuNewRecipe_Click;
            mnuListRecipe.Click += MnuListRecipe_Click;
            MnuMealsList.Click += MnuMealsList_Click;
            MnuListOfCookbooks.Click += MnuListOfCookbooks_Click;
            this.Shown += FrmMain_Shown;

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

                else if (frmType == typeof(frmRecipeList))
                {
                    frmRecipeList f = new();
                    newfrm = f;
                }

                else if (frmType == typeof(frmMealList))
                {
                    frmMealList f = new();
                    newfrm = f;
                }
                else if (frmType== typeof(frmCookbookList))
                {
                    frmCookbookList f= new();
                    newfrm = f;
                }
                else if (frmType == typeof(frmDashboard))
                {
                    frmDashboard f = new();
                    newfrm = f;
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
        private void MnuListOfCookbooks_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCookbookList));
        }

        private void MnuMealsList_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmMealList));
        }
        private void MnuListRecipe_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmRecipeList));
        }

        private void MnuNewRecipe_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmRecipe));

        }

        private void MnuSearchRecipe_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmSearch));
        }

        private void MnuDashboard_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmDashboard));
        }

    }
}
