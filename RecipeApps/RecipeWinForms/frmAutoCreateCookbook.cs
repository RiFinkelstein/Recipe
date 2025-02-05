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
    public partial class frmAutoCreateCookbook : Form
    {

        int CookbookID = 0;

        public frmAutoCreateCookbook()
        {
            InitializeComponent();
            btnCreateCookbook.Click += BtnCreateCookbook_Click;
            this.Activated += FrmAutoCreateCookbook_Activated;
        }

        private void FrmAutoCreateCookbook_Activated(object? sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            DataTable dtUsers = Recipe.GetUserList();
            WindowsFormUtility.SetListBinding(lstUsersName, dtUsers, dtUsers, "users");
        }

        public bool AutoCreateCookbook()
        {
            bool success = false;
            try
            {
                // Ensure a user is selected
                if (lstUsersName.SelectedValue == null)
                {
                    MessageBox.Show("Please select a user to auto-create a cookbook for.", "Error");
                    return false;
                }

                // Get the selected UsersID
                int selectedUsersID = (int)lstUsersName.SelectedValue;

                // Auto-create the cookbook and get the new CookbookID
                CookbookID = Cookbook.AutoCreateCookbook(selectedUsersID);

                if (CookbookID > 0)
                {
                    // Open the cookbook form
                    frmMain? mdiParent = this.MdiParent as frmMain;
                    if (mdiParent != null)
                    {
                        mdiParent.OpenForm(typeof(frmCookbook), CookbookID);
                    }

                    MessageBox.Show("Cookbook created successfully!", "Success");
                    success = true;

                    // Close the form after success
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to create cookbook. The user may not have any recipes.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating cookbook: {ex.Message}", "Error");
            }
            finally
            {
                Application.UseWaitCursor = false;
            }

            return success;
        }


        private void BtnCreateCookbook_Click(object? sender, EventArgs e)
        {
            AutoCreateCookbook();
        }
    }
}
