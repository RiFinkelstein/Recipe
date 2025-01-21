using CPUWindowsFormFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            mnuListRecipe.Click += MnuListRecipe_Click;
            mnuNewRecipe.Click += MnuNewRecipe_Click;
            mnuClonearecipe.Click += MnuClonearecipe_Click;
            MnuMealsList.Click += MnuMealsList_Click;
            MnuListOfCookbooks.Click += MnuListOfCookbooks_Click;
            mnuNewCookbook.Click += MnuNewCookbook_Click;
            mnuAutocreatecookbook.Click += MnuAutocreatecookbook_Click;
            mnuEditdata.Click += MnuEditdata_Click;
            mnuWindows.Click += MnuWindows_Click;
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
                    f.LoadForm(pkvalue);
                }

                else if(frmType== typeof(frmCookbook))
                {
                    frmCookbook f= new();
                    newfrm = f;
                    f.LoadForm(pkvalue);
                }
                else if (frmType== typeof(frmChangeRecipeStatus))
                {
                    frmChangeRecipeStatus f= new();
                    newfrm = f;
                }

                else if (frmType == typeof(frmRecipeList))
                {
                    frmRecipeList f = new();
                    newfrm = f;
                }
                else if (frmType == typeof(frmRecipe))
                {
                    frmRecipe f = new();
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
                else if (frmType == typeof(frmDataMaintenance))
                {
                    frmDataMaintenance f= new();
                    newfrm = f;
                }
                else if (frmType== typeof(frmCloneRecipe))
                {
                    frmCloneRecipe f = new();
                    newfrm = f;
                }
                else if (frmType == typeof(frmAutoCreateCookbook))
                {
                    frmAutoCreateCookbook f = new();
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
        private void MnuWindows_Click(object? sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void MnuEditdata_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmDataMaintenance));
        }

        private void MnuAutocreatecookbook_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmAutoCreateCookbook));
        }

        private void MnuNewCookbook_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCookbook));
        }

        private void MnuClonearecipe_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCloneRecipe));
        }
    }
}
