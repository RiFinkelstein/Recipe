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
            btnDraft.Click += BtnDraft_Click;
            btnArchive.Click += BtnArchive_Click;
            btnPublish.Click += BtnPublish_Click;
        }



        public void LoadForm(int recipeidval)
        {
            recipeID = recipeidval;
            this.Tag = recipeID;
            dtRecipe = Recipe.Load(recipeID);
            bindsource.DataSource = dtRecipe;
            this.Text = GetTabTitle();


            dtRecipe.Columns["RecipeID"].ReadOnly = false;
            dtRecipe.Columns["DraftedDate"].ReadOnly = false;
            dtRecipe.Columns["PublishedDate"].ReadOnly = false;
            dtRecipe.Columns["ArchivedDate"].ReadOnly = false;
            dtRecipe.Columns["RecipeStatus"].ReadOnly = false;

            lblRecipeName.DataBindings.Clear();
            lblRecipeStatus.DataBindings.Clear();
            lblDraftedDate.DataBindings.Clear();
            lblPublishedDate.DataBindings.Clear();
            lblArchivedDate.DataBindings.Clear();

            WindowsFormUtility.SetControlBinding(lblRecipeName, bindsource);
            WindowsFormUtility.SetControlBinding(lblRecipeStatus, bindsource);
            WindowsFormUtility.SetControlBinding(lblDraftedDate, bindsource);
            WindowsFormUtility.SetControlBinding(lblPublishedDate, bindsource);
            WindowsFormUtility.SetControlBinding(lblArchivedDate, bindsource);
            DisableCurrentStatusButton();

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

        private void DisableCurrentStatusButton()
        {
            // Ensure case insensitivity matches database values
            string currentStatus = SQLUtility.GetValueFromFirstRowAsString(dtRecipe, "RecipeStatus");

            if (!string.IsNullOrEmpty(currentStatus))
            {
                currentStatus = currentStatus.ToLower(); // Normalize for comparison

                btnDraft.Enabled = currentStatus != "draft";
                btnPublish.Enabled = currentStatus != "published";
                btnArchive.Enabled = currentStatus != "archived";
            }
            else
            {
                // If no status is found, enable all buttons as a fallback
                btnDraft.Enabled = true;
                btnPublish.Enabled = true;
                btnArchive.Enabled = true;
            }
        }
        /*
        private void ChangeRecipeStatus(string newStatus, string columnName)
        {
            var response = MessageBox.Show($"Are you sure you want to change this recipe to {newStatus}?",
                "Confirm Status Change", MessageBoxButtons.YesNo);

            if (response == DialogResult.Yes)
            {
                try
                {
                    // Update the relevant fields in the first DataRow
                    DataRow row = dtRecipe.Rows[0];
                    row[columnName] = DateTime.Now; // Set the date column
                    row["RecipeStatus"] = newStatus; // Set the new status

                    Recipe.Save(dtRecipe); // Save changes to the database

                    MessageBox.Show("Status updated successfully.");
                    LoadForm(recipeID);    // Refresh data and form bindings
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error changing status: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }*/
        private void ChangeRecipeStatus(string newStatus, string columnName)
        {
            var response = MessageBox.Show($"Are you sure you want to change this recipe to {newStatus}?",
                "Confirm Status Change", MessageBoxButtons.YesNo);

            if (response == DialogResult.Yes)
            {
                try
                {
                    // Update the relevant fields in the first DataRow
                    DataRow row = dtRecipe.Rows[0];

                    // Handle Published to Archived transition properly to maintain constraints
                    if (newStatus == "Published")
                    {
                        // Set the PublishedDate and clear ArchivedDate
                        row["PublishedDate"] = DateTime.Now;
                        row["ArchivedDate"] = DBNull.Value;
                    }
                    else if (newStatus == "Archived")
                    {
                        // Set ArchivedDate only if PublishedDate is valid
                        if (row["PublishedDate"] != DBNull.Value)
                        {
                            DateTime publishedDate = (DateTime)row["PublishedDate"];
                            if (publishedDate > DateTime.Now)
                            {
                                MessageBox.Show("Published date cannot be after the Archived date.", "Invalid Operation",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            row["ArchivedDate"] = DateTime.Now;
                        }
                        else
                        {
                            MessageBox.Show("Cannot archive a recipe without a Published date.", "Invalid Operation",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        row["PublishedDate"] = DBNull.Value; // Clear PublishedDate
                    }
                    else
                    {
                        // Reset DraftedDate and clear PublishedDate and ArchivedDate
                        row["DraftedDate"] = DateTime.Now;
                        row["PublishedDate"] = DBNull.Value;
                        row["ArchivedDate"] = DBNull.Value;
                    }

                    // Set Recipe Status
                    row["RecipeStatus"] = newStatus;

                    // Save changes to the database
                    Recipe.Save(dtRecipe);

                    MessageBox.Show("Status updated successfully.");
                    LoadForm(recipeID); // Refresh data and form bindings
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error changing status: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void BtnDraft_Click(object? sender, EventArgs e)
        {
            ChangeRecipeStatus("Draft", "DraftedDate");
        }

        private void BtnPublish_Click(object? sender, EventArgs e)
        {
            ChangeRecipeStatus("Published", "PublishedDate");
        }

        private void BtnArchive_Click(object? sender, EventArgs e)
        {
            ChangeRecipeStatus("Archived", "ArchivedDate");
        }

    }
}


   
