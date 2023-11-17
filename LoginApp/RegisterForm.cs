using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceRecognition;

namespace LoginApp
{
    public partial class RegisterForm : Form
    {
        DataLoginDataContext db = new DataLoginDataContext();
        FaceRec face = new FaceRec();
        string fullname;
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            db.sp_insertAccount(Fname.Text, Mname.Text, Lname.Text, userName.Text, password.Text, textBox1.Text,int.Parse(comboBox1.Text));
            MessageBox.Show("Registered");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenCam_Click(object sender, EventArgs e)
        {
            face.openCamera(pbCamera, pbCapture);
        }
        private void btnRecord_Click(object sender, EventArgs e)
        {
            face.isTrained = true;
            face.Save_IMAGE(textBox1.Text.ToUpper());
            MessageBox.Show("FACE RECORDED");
        }

        private void Fname_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = Fname.Text;
        }

        private void Lname_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = string.Concat(Fname.Text," ",Mname.Text, " ",Lname.Text);
        }

        private void Mname_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = string.Concat(Fname.Text, " ", Mname.Text);
            
        }
    }
}
