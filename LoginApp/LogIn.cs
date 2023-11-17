using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class LogIn : Form
    {
        DataLoginDataContext db = new DataLoginDataContext();
        FaceRecognition fr = new FaceRecognition();
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int result;
            result = db.sp_login(usernBox.Text, passwordBox.Text).Count();
            if (result == 0)
            {
                MessageBox.Show("Unknown username or password", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (db.sp_type(usernBox.Text, passwordBox.Text) == 0)
                {
                    MessageBox.Show("Welcome Admin");
                }
                else
                {
                    MessageBox.Show("Welcome Staff");
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm regform = new RegisterForm();
            regform.ShowDialog();
        }

        private void btnFacerecog_Click(object sender, EventArgs e)
        {
            FaceRecognition frform = new FaceRecognition();
            frform.Show();
        }
    }
}
