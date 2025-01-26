using CPUFramework;
using CPUWindowsFormFramework;
using RecipeSystem;
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

namespace RecipeWinForms
{
    public partial class frmCloneRecipe : Form
    {
        BindingSource bindsource = new BindingSource();

        int recipeID = 0;

        public frmCloneRecipe()
        {
            InitializeComponent();
            this.Activated += FrmCloneRecipe_Activated;
            btnClone.Click += BtnClone_Click;
        }

        private void FrmCloneRecipe_Activated(object? sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            DataTable dtRecipe = CookbookRecipe.GetRecipeList();
            WindowsFormUtility.SetListBinding(lstRecipename, dtRecipe, dtRecipe, "recipe");
        }




        public bool CLoneRecipe()
        {
            bool success = false;
            Application.UseWaitCursor = true;

            try
            {
                // Ensure a recipe is selected
                if (lstRecipename.SelectedValue == null)
                {
                    MessageBox.Show("Please select a recipe to clone.", "Error");
                    return false;
                }

                // Get the selected RecipeID
                recipeID = (int)lstRecipename.SelectedValue;

                // Clone the recipe and get the new RecipeID
                int clonedRecipeID= Recipe.CloneRecipe(recipeID);

                frmMain? mdiParent = this.MdiParent as frmMain;
                if (mdiParent != null)
                {
                    // Pass the form type and primary key (recipe ID) to OpenForm
                    mdiParent.OpenForm(typeof(frmRecipe), clonedRecipeID);
                }

                // Indicate success
                success = true;

                // Close the clone form
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cloning recipe: {ex.Message}", "Error");
            }
            finally
            {
                Application.UseWaitCursor = false;
            }

            return success;
        }

        private void BtnClone_Click(object? sender, EventArgs e)
        {
            CLoneRecipe();
        }

    }
}
