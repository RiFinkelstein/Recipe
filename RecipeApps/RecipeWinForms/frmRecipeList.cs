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

            frmRecipe frm = new frmRecipe();
            frm.MdiParent = this.MdiParent;
            frm.LoadForm(id);  // Pass the recipe ID to the frmRecipe form

            // Set the title of the current form (tab label) based on the loaded recipe's description
            this.Text = Recipe.GetRecipeDescription(dtrecipe);  // Ensure dtrecipe has the loaded data

            frm.Show();  // Show the recipe form

            this.MdiParent.Refresh();
            Debug.Print(id.ToString());
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
            ShowRecipeForm(e.RowIndex);
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
