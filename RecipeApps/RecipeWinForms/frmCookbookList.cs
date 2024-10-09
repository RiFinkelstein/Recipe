using CPUFramework;
using CPUWindowsFormFramework;
using Microsoft.Data.SqlClient;
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
        public frmCookbookList()
        {
            InitializeComponent();
            this.Activated += FrmCookbookList_Activated;
            gCookbooklist.CellDoubleClick += GCookbooklist_CellDoubleClick;

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
        }

        private void FrmCookbookList_Activated(object? sender, EventArgs e)
        {
            BindData();
        }
    }
}
