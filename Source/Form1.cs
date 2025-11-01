using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADBRemoteX
{
    public partial class Form1 : Form
    {
        private bool IsValidIP(string ip)
        {
            string pattern = @"^(\d{1,3}\.){3}\d{1,3}$";
            return Regex.IsMatch(ip, pattern);
        }
        public Form1()
        {
            InitializeComponent();
            txtIP.Text = "192.168.x.xxx";
            txtIP.ForeColor = Color.Gray;
        }
        private void RunADB(string args)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "adb.exe",
                    Arguments = args,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };

                Process proc = Process.Start(psi);
                string output = proc.StandardOutput.ReadToEnd();
                string error = proc.StandardError.ReadToEnd();
                proc.WaitForExit();

                Debug.WriteLine($"ADB Output: {output}");
                Debug.WriteLine($"ADB Error: {error}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ADB error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.LastIP))
            {
                txtIP.Text = Properties.Settings.Default.LastIP;
                txtIP.ForeColor = Color.Black;
            }

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            RunADB("shell input keyevent 19");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!IsValidIP(txtIP.Text))
            {
                MessageBox.Show("Invalid IP address format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Properties.Settings.Default.LastIP = txtIP.Text;
            Properties.Settings.Default.Save();
            RunADB($"connect {txtIP.Text}:5555");
            lblStatus.Text = "Connected :33";
            lblStatus.ForeColor = Color.Green;

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            RunADB("shell input keyevent 2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunADB("shell input keyevent 4");
        }

        private void btnVolUp_Click_1(object sender, EventArgs e)
        {
            RunADB("shell input keyevent 24");

        }

        private void btnVolDown_Click_1(object sender, EventArgs e)
        {
            RunADB("shell input keyevent 25");

        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void btnEnter_Click_1(object sender, EventArgs e)
        {
            RunADB("shell input keyevent 66");
        }

        private void btnRight_Click_1(object sender, EventArgs e)
        {
            RunADB("shell input keyevent 22");
        }

        private void btnLeft_Click_1(object sender, EventArgs e)
        {
            RunADB("shell input keyevent 21");
        }

        private void btnDown_Click_1(object sender, EventArgs e)
        {
            RunADB("shell input keyevent 20");
        }

        private void txtIP_Enter_1(object sender, EventArgs e)
        {

            if (txtIP.ForeColor == Color.Gray)
            {
                txtIP.Text = "";
                txtIP.ForeColor = Color.Black;
            }


        }

        private void txtIP_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIP.Text))
            {
                txtIP.ForeColor = Color.Gray;
                txtIP.Text = "192.168.x.xxx";
            }
        }
    }
}
