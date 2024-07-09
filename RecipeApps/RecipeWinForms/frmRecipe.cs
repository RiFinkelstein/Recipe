using CPUFramework;
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
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
        }



        public void ShowForm(int RecipeID)
        {
            string sql = "select* from recipe r where r.recipeID= " + RecipeID.ToString();
            DataTable dt = SQLUtility.GetDataTable(sql);
            txtRecipeName.DataBindings.Add("Text", dt, "RecipeName");
            txtCalories.DataBindings.Add("Text", dt, "Calories");
            txtDraftedDate.DataBindings.Add("Text", dt, "DraftedDate");
            txtPublishedDate.DataBindings.Add("Text", dt, "PublishedDate");
            txtArchivedDate.DataBindings.Add("Text", dt, "ArchivedDate");
            txtStatus.DataBindings.Add("Text", dt, "Status");
            this.Show();

        }

        public void SetListBinding(ComboBox lst, DataTable dt, string tablename)
        {
            lst.DataSource = dt;
            lst.ValueMember = tablename + "ID";
            lst.DisplayMember = lst.Name.Substring(3);
            lst.DataBindings.Add("selectedValue", dtRecipe, lst.ValueMember, false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void SetControlBinding(Control ctrl, DataTable dt)
        {
            string propertyname = "";
            string controlname = ctrl.Name.ToLower();
            string controltype = controlname.Substring(0, 3);
            string columnname = controlname.Substring(3);
            switch (controltype)
            {
                case "txt":
                case "lbl":
                    propertyname = "text";
                    break;
                case "dtp":
                    propertyname = "value";
                    break;
            }
            if (propertyname != " " && columnname != " ")
            {
                ctrl.DataBindings.Add(propertyname, dt, columnname, true, DataSourceUpdateMode.OnPropertyChanged);

            }
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
                    $"Status= '{r["Status"]}'",
                    $"where recipeID=  {r["recipeID"]}");
            }
            else
            {
               sql = "insert president(RecipeName, Calories, DraftedDate,PublishedDate, ArchivedDate, Status)";
               sql += $"select '{r["RecipeName"]}', {r["Calories"]}, '{r["DraftedDate"]}', '{r["PublishedDate"]}', '{r["ArchivedDate"]}', '{r["Status"]}'";
            }
            Debug.Print("-----------");
            SQLUtility.ExecuteSQL(sql);
        }

        private void delete()
        {
            int id = (int)dtRecipe.Rows[0]["recipeID"];
            string sql = "delete president where recipeID=" + id;
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
