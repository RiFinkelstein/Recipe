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
    public partial class frmDataMaintenance : Form
    {

        private enum TableTypeEnum { Users, Cuisine, Ingredients, Measurements, Courses }
        DataTable dtlist = new();
        TableTypeEnum currenttabletype = TableTypeEnum.Users;
        string deletecolname = "deletecol";
        public frmDataMaintenance()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click; ;
            this.FormClosing += FrmDataMaintenance_FormClosing;
            BindData(currenttabletype);
            SetupRadioButtons();
            gData.CellContentClick += GData_CellContentClick; ;
        }

        private void SetupRadioButtons()
        {

            foreach (Control c in tblOptionButtons.Controls)
            {
                if (c is RadioButton)
                {
                    c.Click += C_Click; ;
                }
            }
            optUsers.Tag = TableTypeEnum.Users;
            optCuisines.Tag= TableTypeEnum.Cuisine;
            optIngredients.Tag = TableTypeEnum.Ingredients;
            optMeasurements.Tag = TableTypeEnum.Measurements;
            optCourses.Tag = TableTypeEnum.Courses;
        }

        private void C_Click(object? sender, EventArgs e)
        {
            if (sender is Control && ((Control)sender).Tag is TableTypeEnum)
            {
                BindData((TableTypeEnum)((Control)sender).Tag);
            }
        }

        private void BindData(TableTypeEnum tabletype)
        {
            currenttabletype = tabletype;
            dtlist = Data_Maintenance.GetDataList(currenttabletype.ToString());
            gData.Columns.Clear();
            gData.DataSource = dtlist;
            WindowsFormUtility.AddDeleteButtonToGrid(gData, deletecolname);
            WindowsFormUtility.FormatGridforEdit(gData, currenttabletype.ToString());

        }

        private void GData_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
        }

        private void FrmDataMaintenance_FormClosing(object? sender, FormClosingEventArgs e)
        {

        }


        private void BtnSave_Click(object? sender, EventArgs e)
        {
        }
    }
}
