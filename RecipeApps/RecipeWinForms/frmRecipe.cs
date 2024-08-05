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

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtRecipe;
        BindingSource bindsource = new BindingSource();

        public frmRecipe()
        {
            InitializeComponent();
            btnDelete1.Click += BtnDelete_Click;
            btnSave1.Click+= BtnSave_Click; 
        }



        public void ShowForm(int RecipeID)
        {
            dtRecipe = Recipe.Load(RecipeID);
            bindsource.DataSource = dtRecipe;

            if (RecipeID == 0)
            {
                dtRecipe.Rows.Add();
            }
            dtRecipe.Columns["RecipeID"].ReadOnly = false;


            DataTable dtUsers = Recipe.GetUserList();
            dtUsers.Columns["usersid"].ReadOnly = false;
            WindowsFormUtility.SetListBinding(lstUsersName, dtUsers, dtRecipe, "users");


            DataTable dtCuisine = Recipe.GetCuisineList();
            dtCuisine.Columns["CuisineID"].ReadOnly = false;
            dtRecipe.Columns["DraftedDate"].ReadOnly = true;
            dtRecipe.Columns["PublishedDate"].ReadOnly = true;
            dtRecipe.Columns["ArchivedDate"].ReadOnly = true;
            WindowsFormUtility.SetListBinding(lstCuisineName, dtCuisine, dtRecipe, "Cuisine");

            WindowsFormUtility.SetControlBinding(txtRecipeName, bindsource);
            WindowsFormUtility.SetControlBinding(txtCalories, bindsource);
            WindowsFormUtility.SetControlBinding(dtpDraftedDate, bindsource);
            WindowsFormUtility.SetControlBinding(txtPublishedDate, bindsource);
            WindowsFormUtility.SetControlBinding(txtArchivedDate, bindsource);
            WindowsFormUtility.SetControlBinding(txtStatus, bindsource);
            this.Show();
        }
        private void save()
        {
            Application.UseWaitCursor = true;
            try
            {
                Recipe.Save(dtRecipe);
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

        private void delete()
        {
            Application.UseWaitCursor = true;
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

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            delete();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            save();
        }
    }
}

