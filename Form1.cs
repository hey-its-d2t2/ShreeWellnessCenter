using System;
using System.Windows.Forms;

namespace ShreeWellnessCenter
{
    public partial class splash : Form
    {
        frm_login frm_Login = new frm_login();
        public splash()
        {
            InitializeComponent();
            circularProgressBar1.Value = 0;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            circularProgressBar1.Value += 5;
            if (circularProgressBar1.Value == 100)
            {
                timer1.Enabled = false;
                frm_Login.Show();
                this.Hide();
            }
        }
    }
}
