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
using System.Configuration;
using RecipeWinForms.Properties;

namespace RecipeWinForms
{

    public partial class frmLogin : Form
    {
        bool loginsuccess = false;

        public frmLogin()
        {
            InitializeComponent();
            btnCancel.Click += BtnCancel_Click;
            btnLogin.Click += BtnLogin_Click;
        }



        public bool ShowLogin()
        {
            
            txtUserID.Text = Settings.Default.userid;
            txtPassword.Text = Settings.Default.password;
#if DEBUG
            this.Text = this.Text + " -Dev";

#endif
            
            this.ShowDialog();
            return loginsuccess;
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            try
            {
                string connstringkey = "";
#if DEBUG
                connstringkey = "localconnstring";
#else
                connstringkey = "devconn";

#endif

                string connstring = ConfigurationManager.ConnectionStrings[connstringkey].ConnectionString;

                // Attempt to set the connection and open it
                DBManager.SetConnectionString(connstring, true, txtUserID.Text, txtPassword.Text);

                loginsuccess = true;
                Settings.Default.userid = txtUserID.Text;
                Settings.Default.password = txtPassword.Text;
                Settings.Default.Save();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login Failed: {ex.Message}", "Error");
            }
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
