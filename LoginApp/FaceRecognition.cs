using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceRecognition;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class FaceRecognition : Form
    {
        FaceRec face = new FaceRec();
        DataLoginDataContext db = new DataLoginDataContext();

        public FaceRecognition()
        {
            InitializeComponent();
        }

        private void btnOpenCam_Click(object sender, EventArgs e)
        {
            face.openCamera(pbCamera, pbCapture);
            face.isTrained = true;
            face.getPersonName(verify);
            db.sp_verifyFace(verify.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var fetch = db.sp_verifyFace(verify.Text).Count();
                if (fetch == 1)
                {
                    if (db.sp_faceType(verify.Text) == 1)
                    {
                        MessageBox.Show("Welcome Staff, " + verify.Text, "Staff Account");
                    }
                    else
                    {
                        MessageBox.Show("Welcome Admin, " + verify.Text, "Admin Account");
                    }
                }
                else
                {
                    MessageBox.Show("RECORD NOT FOUND", "MISMATCH", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            
        }
    }
}
