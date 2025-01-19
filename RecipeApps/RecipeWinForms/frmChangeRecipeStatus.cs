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

            this.Text = GetTabTitle();

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

        private string GetTabTitle()
        {
            string value = "Recipe - Change Status"; // Default title

            // Check if dtRecipe has rows and the 'recipename' column exists
            if (dtRecipe.Rows.Count > 0 && dtRecipe.Columns.Contains("recipename"))
            {
                string recipeName = SQLUtility.GetValueFromFirstRowAsString(dtRecipe, "recipename");

                // Ensure recipeName is not empty or null
                if (!string.IsNullOrEmpty(recipeName))
                {
                    value = $"{recipeName} - Change Status"; // Set title with recipe name
                }
                else
                {
                    MessageBox.Show("Recipe name is empty!");
                }
            }

            return value;
        }
    }
}
