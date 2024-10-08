using CPUFramework;
using Microsoft.Data.SqlClient;
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
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            btnCookbookList.Click += BtnCookbookList_Click;
            btnMealList.Click += BtnMealList_Click;
            btnRecipeList.Click += BtnRecipeList_Click;
            this.Activated += FrmDashboard_Activated;
        }
        private void FrmDashboard_Activated(object? sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            // Call the method to get the recipe count and set it to the label
            SetLabelText(lblRecipesNum, "recipes");
        }

        private void SetLabelText(Label lbl, string recordType)
        {
            // Assuming you use a similar stored procedure call to get the number of records
            int numberOfRecords = GetRecipeCount();
            // Update the label with the count
            lbl.Text = $"{numberOfRecords}";
        }

        public static int GetCookbookCount()
        {
            int recipeCount = 0;  // Variable to store the count
            // Get the SQL command using your utility
            SqlCommand cmd = SQLUtility.GetSqlcommand("CookbooksNumGet");
            // Set the parameter as OUTPUT
            SQLUtility.SetParamValue(cmd, "@CookbookNum", SqlDbType.Int);
            // Execute the command
            SQLUtility.ExecuteSQL(cmd);
            // Retrieve the output parameter value (recipe count)
            if (cmd.Parameters["@CookbookNum"].Value != DBNull.Value)
            {
                recipeCount = Convert.ToInt32(cmd.Parameters["@CookbookNum"].Value);
            }
            return recipeCount;  // Return the recipe count
        }

        public static int GetRecipeCount()
        {
            int recipeCount = 0;  // Variable to store the count
            // Get the SQL command using your utility
            SqlCommand cmd = SQLUtility.GetSqlcommand("RecipeNumGet");
            // Set the parameter as OUTPUT
            SQLUtility.SetParamValue(cmd, "@RecipeNum", SqlDbType.Int);
            // Execute the command
            SQLUtility.ExecuteSQL(cmd);
            // Retrieve the output parameter value (recipe count)
            if (cmd.Parameters["@RecipeNum"].Value != DBNull.Value)
            {
                recipeCount = Convert.ToInt32(cmd.Parameters["@RecipeNum"].Value);
            }
            return recipeCount;  // Return the recipe count
        }


        private void BtnRecipeList_Click(object? sender, EventArgs e)
        {
        }

        private void BtnMealList_Click(object? sender, EventArgs e)
        {
        }

        private void BtnCookbookList_Click(object? sender, EventArgs e)
        {
        }
    }
}
