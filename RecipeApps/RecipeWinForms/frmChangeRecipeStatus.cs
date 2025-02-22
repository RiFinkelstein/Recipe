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
        string currentStatus;

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
            DisableCurrentStatusButton();

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
            currentStatus = SQLUtility.GetValueFromFirstRowAsString(dtRecipe, "RecipeStatus");

            if (!string.IsNullOrEmpty(currentStatus))
            {
                currentStatus = currentStatus.ToLower(); // Normalize for comparison

                btnDraft.Enabled = currentStatus != "drafted";
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
        private void ChangeRecipeStatus(string newStatus)
        {
            currentStatus = SQLUtility.GetValueFromFirstRowAsString(dtRecipe, "RecipeStatus");

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
                        if (currentStatus == "Archived")
                        {
                            // Set the PublishedDate and clear ArchivedDate
                            row["PublishedDate"] = DateTime.Now;
                            row["ArchivedDate"] = DBNull.Value;
                        }
                        else if (currentStatus == "drafted")
                        {
                            // Set the PublishedDate
                            row["PublishedDate"] = DateTime.Now;
                        }

                    }
                    else if (newStatus == "Archived")
                    {
                        if (currentStatus == "Published")
                        {
                            // Set the ArchivedDate
                            row["ArchivedDate"] = DateTime.Now;
                        }
                        else if (currentStatus == "Drafted")
                        {
                            // Set the PublishedDate and ArchivedDate
                            row["PublishedDate"] = DateTime.Now;
                            row["ArchivedDate"] = DateTime.Now;
                        }
                    }
                    else if (newStatus == "Draft")
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
            ChangeRecipeStatus("Drafted");
        }

        private void BtnPublish_Click(object? sender, EventArgs e)
        {
            ChangeRecipeStatus("Published");
        }

        private void BtnArchive_Click(object? sender, EventArgs e)
        {
            ChangeRecipeStatus("Archived");
        }

    }
}


   
