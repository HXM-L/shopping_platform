using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; //数据库的命名空间
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shopping_platform
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        //取消按钮
        private void button1_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.Cancel;
            //关闭当前窗体,释放资源
            //this.Dispose();
            //DialogResult result = MessageBox.Show("您确认bai关闭当前du窗口zhi吗？", "操作提示dao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    //关闭当前窗口
            //    this.Close();
            //}
            //关闭当前窗口
            this.Close();
        }

        //确定按钮
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                //MessageBox.Show("用户登录");
                using (SqlConnection sqlcon = new SqlConnection(AppConst.DbPath))
                {
                    SqlCommand sqlcmd = new SqlCommand($"select [userID] from [user_table] where [userID]='{textBox1.Text}' and [userPwd]='{textBox2.Text}'", sqlcon);
                    sqlcon.Open();
                    var obj = sqlcmd.ExecuteScalar();
                    if (obj == null)
                    {
                        MessageBox.Show("您输入的用户名或密码有误！");
                    }
                    else
                    {
                        this.Hide();
                        Home home = new Home(textBox1.Text);
                        home.ShowDialog();
                        //UserHome userHome = new UserHome();
                        //userHome.ShowDialog();
                        this.Dispose();//释放所有资源
                    }
                }
            }
            else if (this.radioButton2.Checked)
            {
                //MessageBox.Show("商家登录");
                using (SqlConnection sqlcon = new SqlConnection(AppConst.DbPath))
                {
                    SqlCommand sqlcmd = new SqlCommand($"select [shopID] from [shop_table] where [shopID]='{textBox1.Text}' and [shopPwd]='{textBox2.Text}'", sqlcon);
                    sqlcon.Open();
                    var obj = sqlcmd.ExecuteScalar();
                    if (obj == null)
                    {
                        MessageBox.Show("您输入的用户名或密码有误！");
                    }
                    else
                    {
                        this.Hide();
                        Business business = new Business();
                        business.ShowDialog();
                        this.Dispose();//释放所有资源
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }
    }
}
