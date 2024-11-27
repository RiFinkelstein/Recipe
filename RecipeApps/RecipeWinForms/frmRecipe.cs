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
        string Deletecolname = "deletecol";
        int recipeID = 0;

        public frmRecipe()
        {
            InitializeComponent();
            btnDelete.Click += BtnDelete_Click;
            btnSave1.Click+= BtnSave_Click;
            this.FormClosing += FrmRecipe_FormClosing;
            btnSaveIngredients.Click += BtnSaveIngredients_Click;
            gIngredients.CellContentClick += GIngredients_CellContentClick;
            foreach(Control c in tblMain.Controls)
            {
                c.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            }
        
        }

 

        public void LoadForm(int recipeidval)
        {
            recipeID = recipeidval;
            this.Tag = recipeID;
            dtRecipe = Recipe.Load(recipeID);
            bindsource.DataSource = dtRecipe;
            if (recipeID == 0)
            {
                dtRecipe.Rows.Add();
            }
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
            WindowsFormUtility.SetControlBinding(txtPublishedDate, bindsource);
            WindowsFormUtility.SetControlBinding(txtArchivedDate, bindsource);
            WindowsFormUtility.SetControlBinding(txtStatus, bindsource);


            this.Text = GetRecipeDescription(); 
            // Load ingredients for the recipe
            dtrecipeingredient = RecipeIngredient.LoadByRecipeID(recipeID);
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
            WindowsFormUtility.AddComboBoxToGrid(gIngredients, dtingredient, "ingredient", "ingredientname");
            DataTable dtMeasurement = Data_Maintenance.GetDataList("Measurement");

            WindowsFormUtility.AddComboBoxToGrid(gIngredients, dtMeasurement, "Measurement", "MeasurementName");

            //Add delete button and format the grid
            WindowsFormUtility.AddDeleteButtonToGrid(gIngredients, Deletecolname); 
            WindowsFormUtility.FormatGridforEdit(gIngredients, "recipeingredient");
            //LoadRecipeIngredient();
            //SetButtonsEnabledBasedOnNewRecord();
        }



        private void LoadRecipeIngredient()
        {
            dtrecipeingredient = RecipeIngredient.LoadByRecipeID(recipeID);
            gIngredients.Columns.Clear();
            gIngredients.DataSource = dtrecipeingredient;
            //WindowsFormUtility.AddDeleteButtonToGrid(gIngredients, Deletecolname);
            WindowsFormUtility.FormatGridforEdit(gIngredients, "recipeingredient");

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
                recipeID = SQLUtility.GetValueFromFirstRowAsInt(dtRecipe, "recipeid");
                this.Tag = recipeID;
                SetButtonsEnabledBasedOnNewRecord();
                this.Text = GetRecipeDescription();
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
            //Application.UseWaitCursor = true;
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

        private void DeleteRecipeIngredient(int rowindex)
        {
            int id = WindowsFormUtility.GetIDFromGrid(gIngredients, rowindex, "RecipeIngredientid");
                if (id > 0) {
                try
                {
                    RecipeIngredient.Delete(id);
                    LoadRecipeIngredient();
                }
                catch(Exception ex) 
                { 
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
                }
                else if (id < gIngredients.Rows.Count)
            {
                gIngredients.Rows.RemoveAt(rowindex);
            }
        }

        private void SaveRecipeIngredient()
        {
            try
            {
                RecipeIngredient.SaveTable(dtrecipeingredient, recipeID);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }

        private void SetButtonsEnabledBasedOnNewRecord()
        {
            bool b = recipeID == 0 ? false : true;
            btnDelete.Enabled = b;
            btnSaveIngredients.Enabled = b;
        }

        private string GetRecipeDescription()
        {
            string value = "New Recipe";
            int pkvalue = SQLUtility.GetValueFromFirstRowAsInt(dtRecipe, "recipeID");
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
                        e.Cancel= true;
                        this.Activate();
                        break;
                }
            }
        }



        private void GIngredients_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex== gIngredients.Columns[Deletecolname].Index && e.RowIndex >= 0)
            {
                DeleteRecipeIngredient(e.RowIndex);
            }
        }


        private void BtnSaveIngredients_Click(object? sender, EventArgs e)
        {
            SaveRecipeIngredient();
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

