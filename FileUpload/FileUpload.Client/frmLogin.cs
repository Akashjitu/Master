using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileUpload.Client
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

     public   Action<string, string> OnLogin; 
        private void btLogin_Click(object sender, EventArgs e)
        {
            OnLogin(txtUserName.Text, txtPassword.Text);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
