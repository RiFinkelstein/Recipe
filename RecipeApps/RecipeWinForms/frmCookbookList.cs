using CPUFramework;
using CPUWindowsFormFramework;
using Microsoft.Data.SqlClient;
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
    public partial class frmCookbookList : Form
    {
        DataTable dtcookbook;
        frmCookbook frm;

        int cookbookID = 0;
        public frmCookbookList()
        {
            InitializeComponent();
            this.Activated += FrmCookbookList_Activated;
            gCookbooklist.CellDoubleClick += GCookbooklist_CellDoubleClick;
            gCookbooklist.KeyDown += GCookbooklist_KeyDown;
            btnNewcookbook.Click += BtnNewcookbook_Click;

        }


        private void ShowCookbookForm(int RowIndex)
        {
            int id = 0;
            if (RowIndex > -1)
            {
                // Get the CookbookID from the selected row in the grid
                id = (int)gCookbooklist.Rows[RowIndex].Cells["CookbookID"].Value;
            }

            // Load cookbook details based on the selected id
            dtcookbook = Cookbook.Load(id);  // This will now load the DataTable for the selected cookbook

            // Get the cookbook description
            string cookbookDescription = Cookbook.GetCookbookDescription(dtcookbook);

            // Use OpenForm to open or focus the appropriate form
            frmMain? mdiParent = this.MdiParent as frmMain;
            if (mdiParent != null)
            {
                // Pass the form type and primary key (cookbook ID) to OpenForm
                mdiParent.OpenForm(typeof(frmCookbook), id);
            }
        }


        public static DataTable GetcookbookList()
        {
            SqlCommand cmd = SQLUtility.GetSqlcommand("CookbookListGet");
            return SQLUtility.GetDataTable(cmd);
        }

        private void BindData()
        {
            gCookbooklist.DataSource = GetcookbookList();
            WindowsFormUtility.FormatGridLforSearchResults(gCookbooklist, "Cookbook");
        }
        private void GCookbooklist_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ShowCookbookForm(e.RowIndex);
        }

        private void GCookbooklist_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gCookbooklist != null)
            {
                e.SuppressKeyPress = true;
                ShowCookbookForm(gCookbooklist.CurrentRow.Index);
            }
        }

        private void FrmCookbookList_Activated(object? sender, EventArgs e)
        {
            BindData();
        }
        private void BtnNewcookbook_Click(object? sender, EventArgs e)
        {
            ShowCookbookForm(-1);
        }

    }
}
