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
    public partial class Form3 : Form
    {
        DataService DB ;
        string TenDangNhap;
        public Form3(DataService DB,string tendangnhap)
        {
            TenDangNhap = tendangnhap;
            this.DB = DB;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lbTenDangNhap.Text = TenDangNhap;
            dataGridView1.DataSource = DB.LayDuLieu("select * from NhanVien").Tables[0];
        }
    }
}
