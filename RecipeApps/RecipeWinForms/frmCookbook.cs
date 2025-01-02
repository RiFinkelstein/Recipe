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


        int cookbookID = 0;

        public frmCookbook()
        {
           InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
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
            if (dtCookbook.Rows.Count > 0)
            {
                string alloweddelete = SQLUtility.GetValueFromFirstRowAsString(dtCookbook, "isdeleteallowed");
                if (alloweddelete != "")
                {
                    MessageBox.Show(alloweddelete);
                    return;
                }
            }
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
