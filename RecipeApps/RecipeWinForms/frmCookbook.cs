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
    public partial class frmCookbook : Form
    {
        DataTable dtCookbook = new DataTable();
        BindingSource bindsource = new BindingSource();

        DataTable dtcookbookrecipe = new DataTable();

        string Deletecolname = "deletecol";
        int cookbookID = 0;

        public frmCookbook()
        {
           InitializeComponent();
           btnSave.Click += BtnSave_Click;
           btnDelete.Click += BtnDelete_Click;
           gCookbookRecipe.CellContentClick += GCookbookRecipe_CellContentClick;
           btnSaveCookbookRecipe.Click += BtnSaveCookbookRecipe_Click;
           WindowsFormUtility.EnforceNumericInput(txtPrice);
           WindowsFormUtility.EnforceNumericInputInGrid(gCookbookRecipe, "CookBookSequenceNumber");

            foreach (Control c in tblMain.Controls)
           {
               c.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
           }
           this.Shown += FrmCookbook_Shown;

        }


        public void LoadForm(int cookbookIDVal)
        {
            cookbookID = cookbookIDVal;
            this.Tag = cookbookID;
            dtCookbook = Cookbook.Load(cookbookID, false);
            bindsource.DataSource = dtCookbook;
            if (cookbookID == 0)
            {
                dtCookbook.Rows.Add();
            }

            this.Text = Cookbook.GetCookbookDescription(dtCookbook);
            DataTable dtUsers = Recipe.GetUserList(); 

            dtCookbook.Columns["CookbookID"].ReadOnly = false;
            dtUsers.Columns["usersid"].ReadOnly = false;
            // Bind controls
            WindowsFormUtility.SetControlBinding(txtCookbookName, bindsource);
            WindowsFormUtility.SetListBinding(lstUsersName, dtUsers, dtCookbook, "users");
            WindowsFormUtility.SetControlBinding(txtPrice, bindsource);
            txtPrice.DataBindings.Add("Text", bindsource, "Price", true, DataSourceUpdateMode.OnPropertyChanged, 0, "N2");

            WindowsFormUtility.SetControlBinding(txtDateCreated, bindsource);
            WindowsFormUtility.SetControlBinding(ChbActive, bindsource);
            SetButtonsEnabledBasedOnNewRecord();
            LoadCookbookRecipe();
        }

        private void SetButtonsEnabledBasedOnNewRecord()
        {
            bool isnewRecord = cookbookID == 0;
            btnDelete.Enabled = !isnewRecord;
            btnSaveCookbookRecipe.Enabled = !isnewRecord;
        }


        private void LoadCookbookRecipe()
        {
            // Load data
            gCookbookRecipe.Columns.Clear();
            dtcookbookrecipe = CookbookRecipe.LoadByCookbookID(cookbookID);
            gCookbookRecipe.DataSource = dtcookbookrecipe;

            if (dtcookbookrecipe.Columns.Contains("recipename"))
            {
                dtcookbookrecipe.Columns.Remove("recipename");
            }

            DataTable dtrecipe = Data_Maintenance.GetDataList("recipe");

            dtcookbookrecipe.Columns["CookbookRecipeID"].ReadOnly = false;
            dtcookbookrecipe.Columns["recipeid"].ReadOnly = false;

            WindowsFormUtility.AddComboBoxToGrid(gCookbookRecipe, dtrecipe, "recipe", "recipename");
        }

        private void FrmCookbook_Shown(object? sender, EventArgs e)
        {
            FormatRecipeGrid();
        }

        private void FormatRecipeGrid()
        {
            // Add delete button
            WindowsFormUtility.AddDeleteButtonToGrid(gCookbookRecipe, Deletecolname);
            // Format the grid for editing
            WindowsFormUtility.FormatGridforEdit(gCookbookRecipe, "cookbookrecipe");
            gCookbookRecipe.ScrollBars = ScrollBars.Vertical;

        }
        private void DeleteCookbookRecipe(int rowIndex)
        {
            try
            {
                int id = WindowsFormUtility.GetIDFromGrid(gCookbookRecipe, rowIndex, "cookbookrecipeID");

                if (id > 0)
                {
                    CookbookRecipe.Delete(id);
                    DataRow row = dtcookbookrecipe.Rows[rowIndex];
                    dtcookbookrecipe.Rows.Remove(row);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting recipe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveCookbookRecipe()
        {
            try
            {
                CookbookRecipe.SaveTable(dtcookbookrecipe, cookbookID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }
        public bool Save()
        {
            bool b = false;
            Application.UseWaitCursor = true;
            try
            {
                if (cookbookID == 0)
                {
                    dtCookbook.Rows[0]["DateCreated"] = DateTime.Now;
                }
                Cookbook.Save(dtCookbook); // Save the cookbook data
                b = true;
                bindsource.ResetBindings(false);
                cookbookID = SQLUtility.GetValueFromFirstRowAsInt(dtCookbook, "cookbookid"); // Update the cookbookID
                this.Tag = cookbookID;
                SetButtonsEnabledBasedOnNewRecord();
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
            var response = MessageBox.Show("are you sure you want to delete this cookbook?", "Hearty Health", MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }
            try
            {
                Cookbook.Delete(dtCookbook);
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

        private void BtnSaveCookbookRecipe_Click(object? sender, EventArgs e)
        {
            SaveCookbookRecipe();
        }


        private void GCookbookRecipe_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gCookbookRecipe.Columns[Deletecolname].Index && e.RowIndex >= 0)
            {
                DeleteCookbookRecipe(e.RowIndex);
            }
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
