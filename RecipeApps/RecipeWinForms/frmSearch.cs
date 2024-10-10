using CPUFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecipeSystem;

namespace RecipeWinForms
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
            btnSearch.Click += BtnSearch_Click;
            FormatGrid();
            gRecipe.CellDoubleClick += GRecipe_CellDoubleClick;
            btnNew.Click += BtnNew_Click;
        }



        private void FormatGrid()
        {
            gRecipe.AllowUserToAddRows = false;
            gRecipe.ReadOnly = true;
            gRecipe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gRecipe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void SearchForRecipe(string RecipeName)
        {
            DataTable dt= Recipe.SearchRecipe(RecipeName);
            gRecipe.DataSource = dt;
            gRecipe.Columns["RecipeID"].Visible = false;
            gRecipe.Columns["usersid"].Visible = false; 
            gRecipe.Columns["CuisineID"].Visible = false;

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
            Debug.Print(id.ToString());
        }


        private void BtnNew_Click(object? sender, EventArgs e)
        {
            ShowRecipeForm(-1);


        }
        private void GRecipe_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ShowRecipeForm(e.RowIndex);
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchForRecipe(txtRecipeName.Text);
        }
    }
}
