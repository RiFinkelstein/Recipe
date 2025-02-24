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
            int CookbookCount;
            int RecipeCount;
            int MealCount;

            GetDashboardsCount(out CookbookCount, out RecipeCount, out MealCount);

            lblRecipesNum.Text= RecipeCount.ToString();
            lblCookbooksnum.Text = CookbookCount.ToString();
            lblMealsnum.Text = MealCount.ToString();

        }

        
        public static void GetDashboardsCount(out int CookbookCount, out int RecipeCount, out int MealCount)
        {
            SqlCommand cmd = SQLUtility.GetSqlcommand("DashboardGet");

            //set up OUTPUT parameters
            SQLUtility.SetParamValue(cmd, "@CookbookNum", SqlDbType.Int);
            SQLUtility.SetParamValue(cmd, "@MealNum", SqlDbType.Int);
            SQLUtility.SetParamValue(cmd, "@recipenum", SqlDbType.Int);

            // Execute the command
            SQLUtility.ExecuteSQL(cmd);

            // Retrieve the values
            CookbookCount = Convert.ToInt32(cmd.Parameters["@CookbookNum"].Value);
            MealCount = Convert.ToInt32(cmd.Parameters["@MealNum"].Value);
            RecipeCount = Convert.ToInt32(cmd.Parameters["@RecipeNum"].Value);


        }


        private void BtnRecipeList_Click(object? sender, EventArgs e)
        {
            if (this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipeList));
            }
        }

        private void BtnMealList_Click(object? sender, EventArgs e)
        {
            if (this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmMealList));
            }
        }

        private void BtnCookbookList_Click(object? sender, EventArgs e)
        {
            if (this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmCookbookList));
            }
        }
    }
}
