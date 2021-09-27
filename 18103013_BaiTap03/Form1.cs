using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace _18103013_BaiTap03
{
    public partial class Form1 : Form
    {
        DataService DB;
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadInfo();
            cbbAuthen.SelectedIndex = 0;
        }

        private void cbbAuthen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbAuthen.SelectedIndex == 0)
            {
                txtUserName.Enabled = false;
                txtPass.Enabled = false;
            }
            else
            {
                txtUserName.Enabled = true;
                txtPass.Enabled = true;
            }
            chkSave.Checked = false;
        }

        void LoadInfo()
        {
            StreamReader read = new StreamReader("Save.txt");
            if (read.ReadLine() == "1")
            {
                txtServerName.Text = read.ReadLine();
                txtDatabase.Text = read.ReadLine();
                if (read.ReadLine() == "0")
                {
                    cbbAuthen.SelectedIndex = 0;

                }
                else
                {
                    cbbAuthen.SelectedIndex = 1;
                    txtUserName.Text = read.ReadLine();
                    txtPass.Text = read.ReadLine();
                }
            }
            read.Close();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void Connect()
        {
            string chuoikn = "Server=" + txtServerName.Text + ";";
            chuoikn = "Database=" + txtDatabase.Text + ";";
            if (cbbAuthen.SelectedIndex == 0)
            {
                chuoikn += "Integrated Security=true;";
            }
            else
            {
                chuoikn += "User Id=" + txtUserName.Text + ";";
                chuoikn += "PassWord=" + txtPass.Text + ";";

            }
            DB = new DataService(chuoikn);
            if (DB.KiemTraServer(chuoikn) == true)
            {

                Save();
                Form2 f2 = new Form2(DB);
                this.Hide();
                f2.FormClosed += new FormClosedEventHandler(f2_FormClosed);
                f2.ShowDialog();

            }
            else
            {
                MessageBox.Show("toang");
            }
        }
        void Save()
        {
            StreamWriter wr = new StreamWriter("Save.txt");
            if (chkSave.Checked)
            {
                wr.WriteLine("1");
                wr.WriteLine(txtServerName.Text);
                wr.WriteLine(txtDatabase.Text);

                if (cbbAuthen.SelectedIndex == 0)
                {
                    wr.WriteLine("0");
                }
                else
                {
                    wr.WriteLine("1");
                    wr.WriteLine(txtUserName.Text);
                    wr.WriteLine(txtPass.Text);
                }

            }
            else
            {
                wr.WriteLine("0");
            }
            wr.Close();
        }
        void f2_FormClosed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Connect();
            }
        }

      
    }
}
