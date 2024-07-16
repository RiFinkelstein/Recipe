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
        public frmRecipe()
        {
            InitializeComponent();
            btnDelete1.Click += BtnDelete_Click;
            btnSave1.Click+= BtnSave_Click; 
        }



        public void ShowForm(int RecipeID)
        {
            dtRecipe = Recipe.Load(RecipeID);
            if (RecipeID == 0)
            {
                dtRecipe.Rows.Add();
            }

            WindowsFormUtility.SetControlBinding(txtRecipeName, dtRecipe);
            WindowsFormUtility.SetControlBinding(txtCalories, dtRecipe);
            WindowsFormUtility.SetControlBinding(dtpDraftedDate, dtRecipe);
            WindowsFormUtility.SetControlBinding(txtPublishedDate, dtRecipe);
            WindowsFormUtility.SetControlBinding(txtArchivedDate, dtRecipe);
            WindowsFormUtility.SetControlBinding(txtStatus, dtRecipe);
            this.Show();



        }
        private void save()
        {
            Recipe.Save(dtRecipe);
        }

        private void delete()
        {
            Recipe.Delete(dtRecipe);
            this.Close();
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
