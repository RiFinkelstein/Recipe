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
        DataTable dtRecipe = new DataTable();
        BindingSource bindsource = new BindingSource();
        int recipeID = 0;

        public frmRecipe()
        {
            InitializeComponent();
            btnDelete.Click += BtnDelete_Click;
            btnSave1.Click+= BtnSave_Click; 
        
        }



        public void ShowForm(int RecipeID)
        {
            this.recipeID = RecipeID;

            dtRecipe = Recipe.Load(recipeID);
 
            bindsource.DataSource = dtRecipe;

            if (recipeID == 0)
            {
                DataRow newRow = dtRecipe.NewRow();
                dtRecipe.Rows.Add(newRow);
                bindsource.Position= dtRecipe.Rows.IndexOf(newRow);
                //dtRecipe.Rows.Add();
            }

            DataTable dtUsers = Recipe.GetUserList();
            DataTable dtCuisine = Recipe.GetCuisineList();
            dtRecipe.Columns["RecipeID"].ReadOnly = false;
            dtUsers.Columns["usersid"].ReadOnly = false;
            dtCuisine.Columns["CuisineID"].ReadOnly = false;
            dtRecipe.Columns["DraftedDate"].ReadOnly = true;
            dtRecipe.Columns["PublishedDate"].ReadOnly = true;
            dtRecipe.Columns["ArchivedDate"].ReadOnly = true;

            if (recipeID == 0)
            { // Directly bind to dtUsers and dtCuisine for new recipes
              lstUsersName.DataSource = dtUsers; 
              lstUsersName.DisplayMember = "username";
               //Change this to the appropriate display column name
              lstUsersName.ValueMember = "usersid"; 
              lstCuisineName.DataSource = dtCuisine; 
              lstCuisineName.DisplayMember = "CuisineName"; 
                // Change this to the appropriate display column name
               lstCuisineName.ValueMember = "CuisineID"; 
            } 
            else { 
                // For existing recipes, bind the lists using WindowsFormUtility
                WindowsFormUtility.SetListBinding(lstUsersName, dtUsers, dtRecipe, "users");
                WindowsFormUtility.SetListBinding(lstCuisineName, dtCuisine, dtRecipe, "Cuisine"); 
            }  


                WindowsFormUtility.SetListBinding(lstUsersName, dtUsers, dtRecipe, "users");
            WindowsFormUtility.SetListBinding(lstCuisineName, dtCuisine, dtRecipe, "Cuisine");
            WindowsFormUtility.SetControlBinding(txtRecipeName, bindsource);
            WindowsFormUtility.SetControlBinding(txtCalories, bindsource);
            WindowsFormUtility.SetControlBinding(dtpDraftedDate, bindsource);
            WindowsFormUtility.SetControlBinding(txtPublishedDate, bindsource);
            WindowsFormUtility.SetControlBinding(txtArchivedDate, bindsource);
            WindowsFormUtility.SetControlBinding(txtStatus, bindsource);
            Text= txtRecipeName.Text;
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

