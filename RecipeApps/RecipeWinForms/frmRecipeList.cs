using CPUWindowsFormFramework;
using CPUFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using RecipeSystem;

namespace RecipeWinForms
{
    public partial class frmRecipeList : Form
    {
        DataTable dtrecipe;
        public frmRecipeList()
        {
            InitializeComponent();
            this.Activated += FrmRecipeList_Activated;
            gRecipe.CellDoubleClick += GRecipe_CellDoubleClick;
            gRecipe.KeyDown += GRecipe_KeyDown;
            btnNewrecipe.Click += BtnNewrecipe_Click;
        }


        private void ShowRecipeForm(int RowIndex)
        {
            int id = 0;
            if (RowIndex > -1)
            {
                // Get the RecipeID from the selected row in the grid
                id = (int)gRecipe.Rows[RowIndex].Cells["RecipeID"].Value;
            }

            // Load recipe details based on the selected id
            dtrecipe = Recipe.Load(id);  // This will now load the DataTable for the selected recipe

            // Get the recipe description
            string recipeDescription = Recipe.GetRecipeDescription(dtrecipe);

            // Use OpenForm to open or focus the appropriate form
            frmMain? mdiParent = this.MdiParent as frmMain;
            if (mdiParent != null)
            {
                // Pass the form type and primary key (recipe ID) to OpenForm
                mdiParent.OpenForm(typeof(frmRecipe), id);
            }
        }




        public static DataTable GetRecipeList()
        {
            SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeListGet");
            return SQLUtility.GetDataTable(cmd);
        }
        
        private void BindData()
        {
            gRecipe.DataSource = GetRecipeList();
            WindowsFormUtility.FormatGridLforSearchResults(gRecipe, "Recipe");
        }

        private void GRecipe_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            ShowRecipeForm(e.RowIndex);
        }
        private void GRecipe_KeyDown(object? sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter && gRecipe != null)
            {
                e.SuppressKeyPress = true;
                ShowRecipeForm(gRecipe.CurrentRow.Index);
            }
        }


        private void BtnNewrecipe_Click(object? sender, EventArgs e)
        {
            ShowRecipeForm(-1);

        }
        private void FrmRecipeList_Activated(object? sender, EventArgs e)
        {
            BindData();
        }


    }
}
