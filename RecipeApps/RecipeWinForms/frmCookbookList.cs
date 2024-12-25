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

        public frmCookbookList()
        {
            InitializeComponent();
            this.Activated += FrmCookbookList_Activated;
            gCookbooklist.CellDoubleClick += GCookbooklist_CellDoubleClick;

        }


        private void ShowCookbookForm(int RowIndex)
        {
            int id = 0;
            if (RowIndex > -1)
            {
                id = (int)gCookbooklist.Rows[RowIndex].Cells["CookbookID"].Value;
            }


            dtcookbook = Cookbook.Load(id);  

            // Get the cookbook description

            string cookbookDescription = Cookbook.GetCookbookDescription(dtcookbook);

            frmMain? mdiParent = this.MdiParent as frmMain;

            // Use OpenForm to open or focus the appropriate form
            if (mdiParent != null)
            {
                // Pass the form type and primary key (cookbook ID) to OpenForm
                mdiParent.OpenForm(typeof(frmCookbook), id);
                //if (frm != null)
                //{
                 //   frm.LoadForm(id);
                //}
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

        private void FrmCookbookList_Activated(object? sender, EventArgs e)
        {
            BindData();
        }
    }
}
