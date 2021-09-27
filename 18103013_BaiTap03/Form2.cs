using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _18103013_BaiTap03
{
    public partial class Form2 : Form
    {
        DataService DB;
        public Form2(DataService DB)
        {
            this.DB=DB;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           DataSet DS= DB.LayDuLieu("select * from NhanVien Where TenDangNhap='"+txtUser.Text+"'and MatKhau='"+ txtPass.Text+"'");
            if(DS.Tables[0].Rows.Count>0)
            {
                Form3 f3=new Form3(DB,DS.Tables[0].Rows[0]["TenDangNhap"].ToString());
                this.Hide();
                f3.FormClosed+=new FormClosedEventHandler(f3_FormClosed);
                f3.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai");
            }
        }

        void f3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        
    }
}
