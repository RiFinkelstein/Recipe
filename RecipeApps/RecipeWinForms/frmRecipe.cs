﻿using CPUFramework;
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
            btnSaveRecipe.Click+= BtnSave_Click;
            btnChangeStatusRecipe.Click += BtnChangeStatusRecipe_Click;
            this.FormClosing += FrmRecipe_FormClosing;
            btnSaveIngredients.Click += BtnSaveIngredients_Click;
            btnSaveRecipeDirections.Click += BtnSaveRecipeDirections_Click;
            gIngredients.CellContentClick += GIngredients_CellContentClick;
            gSteps.CellContentClick += GSteps_CellContentClick;
            foreach(Control c in tblMain.Controls)
            {
                c.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            }


        }

        public void LoadForm(int RecipeIDval)
        {
            RecipeID = RecipeIDval;
            this.Tag = RecipeID;
            dtRecipe = Recipe.Load(RecipeID);
            bindsource.DataSource = dtRecipe;
            if (RecipeID == 0)
            {
                DataRow newRow = dtRecipe.NewRow();
                newRow["drafteddate"] = DateTime.Now;
                dtRecipe.Rows.Add(newRow);
            }
            this.Text = GetRecipeDescription();

            DataTable dtUsers = Recipe.GetUserList();
            DataTable dtCuisine = Recipe.GetCuisineList();
            dtRecipe.Columns["RecipeID"].ReadOnly = false;
            dtUsers.Columns["usersid"].ReadOnly = false;
            dtCuisine.Columns["CuisineID"].ReadOnly = false;
            dtRecipe.Columns["DraftedDate"].ReadOnly = true;
            dtRecipe.Columns["PublishedDate"].ReadOnly = true;
            dtRecipe.Columns["ArchivedDate"].ReadOnly = true;


            WindowsFormUtility.SetListBinding(lstUsersName, dtUsers, dtRecipe, "users");
            WindowsFormUtility.SetListBinding(lstCuisineName, dtCuisine, dtRecipe, "Cuisine");
            WindowsFormUtility.SetControlBinding(txtRecipeName, bindsource);
            WindowsFormUtility.SetControlBinding(txtCalories, bindsource);
            WindowsFormUtility.SetControlBinding(dtpDraftedDate, bindsource);
            if(dtRecipe.Rows.Count > 0 && dtRecipe.Rows[0].IsNull("DraftedDate")) 
                {
                dtRecipe.Rows[0]["drafteddate"] = DateTime.Now;
                }

            WindowsFormUtility.SetControlBinding(txtPublishedDate, bindsource);
            WindowsFormUtility.SetControlBinding(txtArchivedDate, bindsource);
            WindowsFormUtility.SetControlBinding(txtRecipeStatus, bindsource);
            LoadRecipeIngredient();
            LoadRecipeSteps();

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
            if (dtrecipeingredient.Columns.Contains("Measurement"))
            {
                dtrecipeingredient.Columns.Remove("Measurement");
            }
            DataTable dtingredient = Data_Maintenance.GetDataList("ingredient");
            dtrecipeingredient.Columns["ingredientID"].ReadOnly = false;
            WindowsFormUtility.AddComboBoxToGrid(gIngredients, dtingredient, "ingredient", "ingredientname");

            dtrecipeingredient.Columns["MeasurementID"].ReadOnly = false;
            DataTable dtMeasurement = Data_Maintenance.GetDataList("Measurement");

            WindowsFormUtility.AddComboBoxToGrid(gIngredients, dtMeasurement, "Measurement", "MeasurementName");
            //Add delete button and format the grid
            WindowsFormUtility.AddDeleteButtonToGrid(gIngredients, Deletecolname);
            WindowsFormUtility.FormatGridforEdit(gIngredients, "recipeingredient");
        }

        private void LoadRecipeSteps()
        {

            dtrecipedirections = RecipeDirections.LoadByRecipeID(RecipeID);
            gSteps.DataSource = dtrecipedirections;
            if (!dtrecipedirections.Columns.Contains("directionsID"))
            {
                dtrecipedirections.Columns.Add("directionsID", typeof(int));
            }
            dtrecipedirections.Columns["directionsID"].ReadOnly = false;

            WindowsFormUtility.AddDeleteButtonToGrid(gSteps, Deletecolname);
            WindowsFormUtility.FormatGridforEdit(gSteps, "recipesteps");
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
                bindsource.ResetBindings(false);
                RecipeID = SQLUtility.GetValueFromFirstRowAsInt(dtRecipe, "RecipeID");
                this.Tag = RecipeID;
                SetButtonsEnabledBasedOnNewRecord();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,Application.ProductName);
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
            return b;
        }
        private void delete()
        {
            if (dtRecipe.Rows.Count > 0)
            {
                string alloweddelete = SQLUtility.GetValueFromFirstRowAsString(dtRecipe, "isdeleteallowed");
                if (alloweddelete != "")
                {
                    MessageBox.Show(alloweddelete);
                    return;
                }
            }
            var response = MessageBox.Show("are you sure you want to delete this recipe?", "Hearty Health", MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }
            try
            {
                Recipe.Delete(dtRecipe);
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

        private void DeleteRecipeSteps(int rowIndex)
        {
            try
            {
                int id = WindowsFormUtility.GetIDFromGrid(gSteps, rowIndex, "directionsID");

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }

        private void SetButtonsEnabledBasedOnNewRecord()
        {
            bool b = RecipeID == 0 ? false : true;
            btnDelete.Enabled = b;
            btnSaveIngredients.Enabled = b;
        }

        private string GetRecipeDescription()
        {
            string value = "New Recipe";
            int pkvalue = SQLUtility.GetValueFromFirstRowAsInt(dtRecipe, "RecipeID");
            if (pkvalue > 0)
            {
                value = "Recipe" +  " - " + SQLUtility.GetValueFromFirstRowAsString(dtRecipe, "recipename");
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
                            e.Cancel= true;
                            this.Activate();
                        }
                        break;
                    case DialogResult.No:
                        e.Cancel= false;
                        break;
                }
            }
        }

        private void GSteps_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gIngredients.Columns[Deletecolname].Index && e.RowIndex >= 0)
            {
                DeleteRecipeSteps(e.RowIndex);
            }
        }

        private void GIngredients_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex== gIngredients.Columns[Deletecolname].Index && e.RowIndex >= 0)
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
            delete();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }
    }
}

