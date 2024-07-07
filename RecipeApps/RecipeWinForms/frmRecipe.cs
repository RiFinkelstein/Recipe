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

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        public frmRecipe()
        {
            InitializeComponent();
        }

        public void ShowForm(int RecipeID)
        {
            string sql = "select* from recipe r where r.recipeID= " + RecipeID.ToString();
            DataTable dt = SQLUtility.GetDataTable(sql);
            txtRecipeName.DataBindings.Add("Text", dt, "RecipeName");
            txtCalories.DataBindings.Add("Text", dt, "Calories");
            txtDraftedDate.DataBindings.Add("Text", dt, "DraftedDate");
            txtPublishedDate.DataBindings.Add("Text", dt, "PublishedDate");
            txtArchivedDate.DataBindings.Add("Text", dt, "ArchivedDate");
            txtStatus.DataBindings.Add("Text", dt, "Status");
            this.Show();

        }
    }
}
