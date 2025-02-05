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
    public partial class frmAutoCreateCookbook : Form
    {
        public frmAutoCreateCookbook()
        {
            InitializeComponent();
            btnCreateCookbook.Click += BtnCreateCookbook_Click;
            this.Activated += FrmAutoCreateCookbook_Activated;
        }

        private void FrmAutoCreateCookbook_Activated(object? sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            DataTable dtUsers = Recipe.GetUserList();
            WindowsFormUtility.SetListBinding(lstUsersName, dtUsers, dtUsers, "users");
        }

        private void BtnCreateCookbook_Click(object? sender, EventArgs e)
        {
        }
    }
}
