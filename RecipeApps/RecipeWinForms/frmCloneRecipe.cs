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
    public partial class frmCloneRecipe : Form
    {
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
            lstRecipe.DataSource = dtRecipe;
            lstRecipe.ValueMember = "recipeID";
            lstRecipe.DisplayMember = "recipename";
        }

        private void CloneData()
        {
            // Ensure a recipe is selected
            if (lstRecipe.SelectedValue != null && int.TryParse(lstRecipe.SelectedValue.ToString(), out int originalRecipeID))
            {
                try
                {
                    // Call the Recipe.CloneRecipe method to perform the clone operation
                    Recipe.CloneRecipe(originalRecipeID);

                    // Notify the user of success
                    MessageBox.Show("Recipe cloned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the recipe list to show the cloned recipe
                    BindData();
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during cloning
                    MessageBox.Show($"An error occurred while cloning the recipe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Notify the user if no recipe was selected
                MessageBox.Show("Please select a recipe to clone.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnClone_Click(object? sender, EventArgs e)
        {
            CloneData();
        }

    }
}
