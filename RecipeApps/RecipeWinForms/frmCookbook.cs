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
    public partial class frmCookbook : Form
    {
        DataTable dtCookbook = new DataTable();
        BindingSource bindsource = new BindingSource();


        int cookbookID = 0;

        public frmCookbook()
        {
           InitializeComponent();
           foreach (Control c in tblMain.Controls)
            {
                c.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            }

        }


        public void LoadForm(int cookbookval)
        {
            cookbookID= cookbookval;
            this.Tag = cookbookID;
            dtCookbook = Cookbook.Load(cookbookID);
            bindsource.DataSource = dtCookbook;
            if(cookbookID == 0)
            {
                dtCookbook.Rows.Add();
            }
            txtCookbookName.DataBindings.Clear(); 
            txtPrice.DataBindings.Clear(); 
            dtpDateCreated.DataBindings.Clear(); 
            ChbActive.DataBindings.Clear(); lstUsersName.DataBindings.Clear();

            DataTable dtUsers = Recipe.GetUserList();
            WindowsFormUtility.SetControlBinding(txtCookbookName, bindsource);
            WindowsFormUtility.SetListBinding(lstUsersName, dtUsers, dtCookbook, "users");
            WindowsFormUtility.SetControlBinding(txtPrice, bindsource);
            WindowsFormUtility.SetControlBinding(dtpDateCreated, bindsource);
            //WindowsFormUtility.SetControlBinding(ChbActive, bindsource);
        }




    }
}
