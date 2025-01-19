using CPUFramework;
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
    public partial class frmChangeRecipeStatus : Form
    {

        DataTable dtRecipe = new DataTable();
        BindingSource bindsource = new BindingSource();
        DataTable dtrecipeingredient = new DataTable();
        DataTable dtrecipesteps = new DataTable();

        int recipeID = 0;
        public frmChangeRecipeStatus()
        {
            InitializeComponent();
        }


        public void LoadForm(int recipeidval)
        {
            recipeID = recipeidval;
            this.Tag = recipeID;
            dtRecipe = Recipe.Load(recipeID);
            bindsource.DataSource = dtRecipe;
            if (recipeID == 0)
            {
                DataRow newRow = dtRecipe.NewRow();
                newRow["drafteddate"] = DateTime.Now;
                dtRecipe.Rows.Add(newRow);
            }
            string recipeName = SQLUtility.GetValueFromFirstRowAsString(dtRecipe, "RecipeName");
            this.Text = $"{recipeName} - Change Status";

            dtRecipe.Columns["RecipeID"].ReadOnly = false;
            dtRecipe.Columns["DraftedDate"].ReadOnly = true;
            dtRecipe.Columns["PublishedDate"].ReadOnly = true;
            dtRecipe.Columns["ArchivedDate"].ReadOnly = true;


            WindowsFormUtility.SetControlBinding(lblRecipeName, bindsource);
            WindowsFormUtility.SetControlBinding(lblRecipeStatus, bindsource);
            WindowsFormUtility.SetControlBinding(lblDraftedDate, bindsource);
            WindowsFormUtility.SetControlBinding(lblPublishedDate, bindsource);
            WindowsFormUtility.SetControlBinding(lblArchivedDate, bindsource);

        }
    }
}
