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
            foreach (Control c in tblMain.Controls)
            {
                c.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            }
        }



        public void ShowForm(int RecipeID)
        {
            string sql = "select* from recipe r where r.recipeID= " + RecipeID.ToString();
            DataTable dtRecipe = SQLUtility.GetDataTable(sql);
            SetControlBinding(txtRecipeName, dtRecipe);
            SetControlBinding(txtCalories, dtRecipe);
            SetControlBinding(dtpDraftedDate, dtRecipe);
            SetControlBinding(dtpPublishedDate, dtRecipe);
            SetControlBinding(dtpArchivedDate, dtRecipe);
            SetControlBinding(lstStatus, dtRecipe);

            //txtRecipeName.DataBindings.Add("Text", dtRecipe, "RecipeName");
            //txtCalories.DataBindings.Add("Text", dtRecipe, "Calories");
            //dtpDraftedDate.DataBindings.Add("Text", dtRecipe, "DraftedDate");
            //dtpPublishedDate.DataBindings.Add("Text", dtRecipe, "PublishedDate");
            //dtpArchivedDate.DataBindings.Add("Text", dtRecipe, "ArchivedDate");
            //lstStatus.DataBindings.Add("Text", dtRecipe, "Status");
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
