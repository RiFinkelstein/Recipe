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
           foreach (Control c in tblMain.Controls)
            {
                c.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            }

        }


        public void LoadForm(int cookbookIDVal)
        {
            cookbookID = cookbookIDVal;
            this.Tag = cookbookID;
            dtCookbook = Cookbook.Load(cookbookID);
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
            WindowsFormUtility.SetControlBinding(dtpDateCreated, bindsource);
            WindowsFormUtility.SetControlBinding(ChbActive, bindsource);
            LoadCookbookRecipe();
        }

        private void LoadCookbookRecipe()
        {
            dtcookbookrecipe = CookbookRecipe.LoadByCookbookID(cookbookID);
            gCookbookRecipe.Columns.Clear();
            gCookbookRecipe.DataSource= dtcookbookrecipe;
            WindowsFormUtility.AddDeleteButtonToGrid(gCookbookRecipe, Deletecolname);
            //WindowsFormUtility.FormatGridforEdit(gCookbookRecipe, dtcookbookrecipe);

        }


        private void DeleteCookbookRecipe(int rowIndex)
        {
            try
            {
                int id = WindowsFormUtility.GetIDFromGrid(gCookbookRecipe, rowIndex, "CookbookRecipeID");

                if (id > 0)
                {
                    RecipeIngredient.Delete(id);
                }
                DataRow row = dtcookbookrecipe.Rows[rowIndex];
                dtcookbookrecipe.Rows.Remove(row);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting ingredient: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool Save()
        {
            bool b = false;
            Application.UseWaitCursor = true;
            try
            {
                Cookbook.Save(dtCookbook); // Save the cookbook data
                b = true;
                bindsource.ResetBindings(false);
                cookbookID = SQLUtility.GetValueFromFirstRowAsInt(dtCookbook, "cookbookid"); // Update the cookbookID
                this.Tag = cookbookID;
                //SetButtonsEnabledBasedOnNewRecord();
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
