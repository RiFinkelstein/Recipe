using CPUFramework;
using CPUWindowsFormFramework;
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
using System.Diagnostics.Metrics;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtRecipe = new DataTable();
        BindingSource bindsource = new BindingSource();
        DataTable dtrecipeingredient = new DataTable();
        DataTable dtrecipedirections = new DataTable();

        string Deletecolname = "deletecol";
        int RecipeID = 0;
        int DirectionsID = 0;

        public frmRecipe()
        {
            InitializeComponent();
            btnDeleteRecipe.Click += BtnDelete_Click;
            btnSaveRecipe.Click += BtnSave_Click;
            btnChangeStatusRecipe.Click += BtnChangeStatusRecipe_Click;
            this.FormClosing += FrmRecipe_FormClosing;
            btnSaveIngredients.Click += BtnSaveIngredients_Click;
            btnSaveRecipeDirections.Click += BtnSaveRecipeDirections_Click;
            gIngredients.CellContentClick += GIngredients_CellContentClick;
            gSteps.CellContentClick += GSteps_CellContentClick;
            foreach (Control c in tblMain.Controls)
            {
                c.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            }
            this.Shown += FrmRecipe_Shown;
        }




        public void LoadForm(int RecipeIDval)
        {
            RecipeID = RecipeIDval;
            this.Tag = RecipeID;
            dtRecipe = Recipe.Load(RecipeID);
            bindsource.DataSource = dtRecipe;
            bindsource.ResetBindings(false);
            if (RecipeID == 0)
            {
                DataRow newRow = dtRecipe.NewRow();
                newRow["DraftedDate"] = DBNull.Value;
                newRow["Publisheddate"] = DBNull.Value;
                newRow["ArchivedDate"] = DBNull.Value;

                dtRecipe.Rows.Add(newRow);
            }
            this.Text = GetRecipeDescription();

            DataTable dtUsers = Recipe.GetUserList();
            DataTable dtCuisine = Recipe.GetCuisineList();
            dtRecipe.Columns["RecipeID"].ReadOnly = false;
            dtUsers.Columns["usersid"].ReadOnly = false;
            dtCuisine.Columns["CuisineID"].ReadOnly = false;
            dtRecipe.Columns["DraftedDate"].ReadOnly = false;
            dtRecipe.Columns["PublishedDate"].ReadOnly = false;
            dtRecipe.Columns["ArchivedDate"].ReadOnly = false;


            WindowsFormUtility.SetListBinding(lstUsersName, dtUsers, dtRecipe, "users");
            WindowsFormUtility.SetListBinding(lstCuisineName, dtCuisine, dtRecipe, "Cuisine");
            WindowsFormUtility.SetControlBinding(txtRecipeName, bindsource);
            WindowsFormUtility.SetControlBinding(txtCalories, bindsource);
            WindowsFormUtility.SetControlBinding(txtDraftedDate, bindsource);
            WindowsFormUtility.SetControlBinding(txtPublishedDate, bindsource);
            WindowsFormUtility.SetControlBinding(txtArchivedDate, bindsource);
            WindowsFormUtility.SetControlBinding(txtRecipeStatus, bindsource);
            SetButtonsEnabledBasedOnNewRecord();
            LoadRecipeIngredient();
            LoadRecipeDirections();

        }


        private void LoadRecipeIngredient()
        {
            gIngredients.Columns.Clear();
            // Load ingredients for the recipe
            dtrecipeingredient = RecipeIngredient.LoadByRecipeID(RecipeID);
            gIngredients.DataSource = dtrecipeingredient;
            // Load ingredient data and add combo box
            if (dtrecipeingredient.Columns.Contains("ingredientname"))
            {
                dtrecipeingredient.Columns.Remove("ingredientname");
            }
            if (dtrecipeingredient.Columns.Contains("MeasurementName"))
            {
                dtrecipeingredient.Columns.Remove("MeasurementName");
            }
            DataTable dtingredient = Data_Maintenance.GetDataList("ingredient");
            dtrecipeingredient.Columns["ingredientID"].ReadOnly = false;
            WindowsFormUtility.AddComboBoxToGrid(gIngredients, dtingredient, "ingredient", "ingredientname");

            dtrecipeingredient.Columns["MeasurementID"].ReadOnly = false;
            DataTable dtMeasurement = Data_Maintenance.GetDataList("Measurement");

            WindowsFormUtility.AddComboBoxToGrid(gIngredients, dtMeasurement, "Measurement", "MeasurementName");
        }
        private void FrmRecipe_Shown(object? sender, EventArgs e)
        {
            FormatIngredientGrid();
        }
        private void FormatIngredientGrid()
        {
            //Add delete button and format the grid
            WindowsFormUtility.AddDeleteButtonToGrid(gIngredients, Deletecolname);
            WindowsFormUtility.FormatGridforEdit(gIngredients, "recipeingredient");
        }


        private void LoadRecipeDirections()
        {
            dtrecipedirections = RecipeDirections.LoadByRecipeID(RecipeID);
            if (!dtrecipedirections.Columns.Contains("RecipeID"))
            {
                dtrecipedirections.Columns["RecipeID"].ReadOnly = false;
            }
            gSteps.DataSource = null;
            gSteps.DataSource = dtrecipedirections;
            if (!dtrecipedirections.Columns.Contains("DirectionsID"))
            {
                dtrecipedirections.Columns.Add("DirectionsID", typeof(int));
            }
            dtrecipedirections.Columns["DirectionsID"].ReadOnly = false;

            WindowsFormUtility.AddDeleteButtonToGrid(gSteps, Deletecolname);
            WindowsFormUtility.FormatGridforEdit(gSteps, "dtrecipedirections");
        }


        private void ChangeStatus()
        {

            string recipeName = SQLUtility.GetValueFromFirstRowAsString(dtRecipe, "recipename");
            frmChangeRecipeStatus changeRecipeStatus = new frmChangeRecipeStatus();
            changeRecipeStatus.LoadForm(RecipeID);
            changeRecipeStatus.MdiParent = this.MdiParent;
            changeRecipeStatus.Show();
        }



        public bool Save()
        {
            bool b = false;
            Application.UseWaitCursor = true;
            try
            {
                Recipe.Save(dtRecipe);

                b = true;
                RecipeID = SQLUtility.GetValueFromFirstRowAsInt(dtRecipe, "RecipeID");
                this.Tag = RecipeID;
                SetButtonsEnabledBasedOnNewRecord();
                dtRecipe = Recipe.Load(RecipeID);
                bindsource.DataSource = dtRecipe;
                bindsource.ResetBindings(false);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
            return b;
        }


        private void Delete()
        {
            var response = MessageBox.Show("are you sure you want to delete this recipe?", "Hearty Health", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            if (response == DialogResult.No)
            {
                return;
            }
            try
            {
                Recipe.Delete(dtRecipe);
                MessageBox.Show("Recipe deleted successfully", "Hearty Health", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hearty Health");
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
        }


        private void DeleteRecipeIngredient(int rowIndex)
        {
            try
            {
                int id = WindowsFormUtility.GetIDFromGrid(gIngredients, rowIndex, "RecipeIngredientID");

                if (id > 0)
                {
                    RecipeIngredient.Delete(id);
                }
                DataRow row = dtrecipeingredient.Rows[rowIndex];
                dtrecipeingredient.Rows.Remove(row);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting ingredient: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteRecipeDirections(int rowIndex)
        {
            try
            {
                int id = WindowsFormUtility.GetIDFromGrid(gSteps, rowIndex, "DirectionsID");

                if (id > 0)
                {
                    // Delete from database
                    RecipeDirections.Delete(id);
                }

                // Remove the row from the DataTable
                DataRow row = dtrecipedirections.Rows[rowIndex];
                dtrecipedirections.Rows.Remove(row);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting ingredient: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SaveRecipeDirections()
        {
            try
            {
                RecipeDirections.SaveTable(dtrecipedirections, RecipeID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }

        private void SaveRecipeIngredient()
        {
            try
            {
                RecipeIngredient.SaveTable(dtrecipeingredient, RecipeID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }

        private void SetButtonsEnabledBasedOnNewRecord()
        {
            bool isnewRecord = RecipeID == 0;
            btnDeleteRecipe.Enabled = !isnewRecord;
            btnChangeStatusRecipe.Enabled = !isnewRecord;
            btnSaveIngredients.Enabled = !isnewRecord;
            btnSaveRecipeDirections.Enabled = !isnewRecord;
        }

        private string GetRecipeDescription()
        {
            string value = "New Recipe";
            int pkvalue = SQLUtility.GetValueFromFirstRowAsInt(dtRecipe, "RecipeID");
            if (pkvalue > 0)
            {
                value = "Recipe" + " - " + SQLUtility.GetValueFromFirstRowAsString(dtRecipe, "recipename");
            }
            return value;
        }

        private void FrmRecipe_FormClosing(object? sender, FormClosingEventArgs e)
        {
            bindsource.EndEdit();
            if (SQLUtility.TableHasChanges(dtRecipe))
            {
                var response = MessageBox.Show($"do you want to save changes to {this.Text} before closing the form", Application.ProductName, MessageBoxButtons.YesNoCancel);
                switch (response)
                {
                    case DialogResult.Yes:
                        bool b = Save();
                        if (b == false)
                        {
                            e.Cancel = true;
                            this.Activate();
                        }
                        break;
                    case DialogResult.No:
                        e.Cancel = false;
                        break;
                }
            }
        }

        private void GSteps_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gIngredients.Columns[Deletecolname].Index && e.RowIndex >= 0)
            {
                DeleteRecipeDirections(e.RowIndex);
            }
        }

        private void GIngredients_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gIngredients.Columns[Deletecolname].Index && e.RowIndex >= 0)
            {
                DeleteRecipeIngredient(e.RowIndex);
            }
        }

        private void BtnSaveRecipeDirections_Click(object? sender, EventArgs e)
        {
            SaveRecipeDirections();
        }

        private void BtnSaveIngredients_Click(object? sender, EventArgs e)
        {
            SaveRecipeIngredient();
        }
        private void BtnChangeStatusRecipe_Click(object? sender, EventArgs e)
        {
            ChangeStatus();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

    }
}

