using CPUWindowsFormFramework;
using RecipeSystem;
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
    public partial class frmCloneRecipe : Form
    {
        public frmCloneRecipe()
        {
            InitializeComponent();
            this.Activated += FrmCloneRecipe_Activated;
        }

        private void FrmCloneRecipe_Activated(object? sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            DataTable dtRecipe = CookbookRecipe.GetRecipeList();
            lstRecipe.DataSource = dtRecipe;
            lstRecipe.ValueMember = "recipeID";
            lstRecipe.DisplayMember = "recipename";
        }

    }
}
