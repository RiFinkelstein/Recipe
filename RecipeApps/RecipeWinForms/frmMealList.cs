using CPUFramework;
using CPUWindowsFormFramework;
using Microsoft.Data.SqlClient;
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
    public partial class frmMealList : Form
    {
        public frmMealList()
        {
            InitializeComponent();
            this.Activated += FrmMealList_Activated;
        }



        public static DataTable GetMealList()
        {
            SqlCommand cmd = SQLUtility.GetSqlcommand("MealListGet");
            return SQLUtility.GetDataTable(cmd);
        }

        

        private void BindData()
        {
            gMealList.DataSource = GetMealList();
            WindowsFormUtility.FormatGridLforSearchResults(gMealList, "Meal");
        }

        private void FrmMealList_Activated(object? sender, EventArgs e)
        {
            BindData();
        }
    }
}
