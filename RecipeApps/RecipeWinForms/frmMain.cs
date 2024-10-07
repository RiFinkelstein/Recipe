using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }
    }
}
