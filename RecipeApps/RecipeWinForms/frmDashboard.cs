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
            int recipeCount = GetRecordCount("RecipeNumGet", "@recipenum");
            lblRecipesNum.Text= recipeCount.ToString();

            int mealCount = GetRecordCount("MealNumGet", "@MealNum");
            lblMealsnum.Text = mealCount.ToString();

            int cookbookCount = GetRecordCount("CookbookNumGet", "@CookbookNum");
            lblCookbooksnum.Text = cookbookCount.ToString();

        }

      
        public static int GetRecordCount(string storedProcedureName, string outputParamName)
        {
            int recordCount = 0;

            // Get the SQL command using your utility
            SqlCommand cmd = SQLUtility.GetSqlcommand(storedProcedureName);

            // Set the output parameter dynamically
            SQLUtility.SetParamValue(cmd, outputParamName, SqlDbType.Int);

            // Execute the command
            SQLUtility.ExecuteSQL(cmd);

            // Retrieve the output parameter value
            if (cmd.Parameters[outputParamName].Value != DBNull.Value)
            {
                recordCount = Convert.ToInt32(cmd.Parameters[outputParamName].Value);
            }

            return recordCount;  // Return the count value
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
