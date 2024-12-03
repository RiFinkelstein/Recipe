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
                id = (int)gRecipe.Rows[RowIndex].Cells["RecipeID"].Value;
            }
            frmRecipe frm = new frmRecipe();
            frm.MdiParent = this.MdiParent;
            frm.LoadForm(id);
            frm.Show();
            //this.Text = Recipe.GetRecipeDescription();

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
