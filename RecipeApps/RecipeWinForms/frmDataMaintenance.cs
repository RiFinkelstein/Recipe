using CPUFramework;
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

        private void BindData(TableTypeEnum tabletype)
        {
            currenttabletype = tabletype;
            dtlist = Data_Maintenance.GetDataList(currenttabletype.ToString());
            gData.Columns.Clear();
            gData.DataSource = dtlist;
            WindowsFormUtility.AddDeleteButtonToGrid(gData, deletecolname);
            WindowsFormUtility.FormatGridforEdit(gData, currenttabletype.ToString());
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

        private bool Save()
        {
            bool b = false;
            try
            {
                Data_Maintenance.SaveDataList(dtlist, currenttabletype.ToString());
                b = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return b;
        }

        private void Delete(int rowindex)
        {

            int id = WindowsFormUtility.GetIDFromGrid(gData, rowindex, currenttabletype.ToString() + "ID");
            if (id != 0)
            {
                if (currenttabletype == TableTypeEnum.Users)
                {
                    var confirmResult = MessageBox.Show(
                        "Are you sure you want to delete this user and all related recipes, meals, and cookbooks?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirmResult != DialogResult.Yes)
                    {
                        return; // Cancel deletion if user selects 'No'
                    }
                }
                try
                {
                    Data_Maintenance.DeleteRow(currenttabletype.ToString(), id);
                    BindData(currenttabletype);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
            }
            else if (id == 0 && rowindex < gData.Rows.Count)
            {
                gData.Rows.Remove(gData.Rows[rowindex]);
            }
        }
        private void C_Click(object? sender, EventArgs e)
        {
            if (sender is Control && ((Control)sender).Tag is TableTypeEnum)
            {
                BindData((TableTypeEnum)((Control)sender).Tag);
            }
        }


        private void GData_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (gData.Columns[e.ColumnIndex].Name == deletecolname)
            {
                Delete(e.RowIndex);
            }
        }

        private void FrmDataMaintenance_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (SQLUtility.TableHasChanges(dtlist))
            {
                var response = MessageBox.Show($"do you want to save changes to {this.Text} before closing the form", Application.ProductName, MessageBoxButtons.YesNoCancel);
                switch (response)
                {
                    case DialogResult.Yes:
                        bool b = Save();
                        if (b == false)
                        {
                            e.Cancel = true;
                            this.Activate();
                        }

                        break;
                    case DialogResult.No:
                        e.Cancel = true;
                        this.Activate();
                        break;
                }
            }
        }


        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }
    }
}
