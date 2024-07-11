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
            string sql = "select* from recipe r where r.recipeID= " + RecipeID.ToString();
            dtRecipe = SQLUtility.GetDataTable(sql);
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
                SQLUtility.DebugPringDataTable(dtRecipe);
                DataRow r = dtRecipe.Rows[0];
                int id = (int)r["recipeID"];
                string sql = "";

                if (id > 0)
                {
                    sql = string.Join(Environment.NewLine, $"update recipe set",
                        $"RecipeName= '{r["RecipeName"]}',",
                        $"Calories= '{r["Calories"]}',",
                        $"DraftedDate= '{r["DraftedDate"]}',",
                        $"PublishedDate= '{r["PublishedDate"]}',",
                        $"ArchivedDate= '{r["ArchivedDate"]}'",
                        $"where recipeID=  {r["recipeID"]}");
                }
                else
                {
                    sql = "insert president(RecipeName, Calories, DraftedDate,PublishedDate, ArchivedDate, Status)";
                    sql += $"select '{r["RecipeName"]}', {r["Calories"]}, '{r["DraftedDate"]}', '{r["PublishedDate"]}', '{r["ArchivedDate"]}', '{r["Status"]}'";
                }
                Debug.Print("-----------");
                Debug.Print(sql);
                //SQLUtility.ExecuteSQL(sql);
        }

        private void delete()
        {
            int id = (int)dtRecipe.Rows[0]["recipeID"];
            string sql = "delete recipe where recipeID=" + id;
            SQLUtility.ExecuteSQL(sql);
            Debug.Print(sql);
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
//
