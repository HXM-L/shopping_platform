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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;

        }

        //重置按钮
        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
        }

        //取消按钮
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        //注册按钮
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (this.textBox3.Text == this.textBox4.Text)
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        try
                        {
                            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                            {
                                string strsql2 = "insert into [user_table]([userID] ,[userName],[userPwd],[userTell],[userSex],[shipAddress]) values(@userID,@userName,@userPwd,@userTell,@userSex,@shipAddress)";
                                using (SqlCommand comm = new SqlCommand
                                {
                                    CommandText = strsql2,
                                    CommandType = CommandType.Text,
                                    Connection = conn
                                })
                                {
                                    comm.Parameters.AddWithValue("@userID", textBox1.Text);
                                    comm.Parameters.AddWithValue("@userName", textBox2.Text);
                                    comm.Parameters.AddWithValue("@userPwd", textBox3.Text);
                                    comm.Parameters.AddWithValue("@userTell", textBox4.Text);
                                    comm.Parameters.AddWithValue("@userSex", (radioButton1.Checked ? "男" : "女"));
                                    comm.Parameters.AddWithValue("@shipAddress", textBox5.Text);
                                    conn.Open();

                                    if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
                                    {
                                        MessageBox.Show("添加成功");
                                        DialogResult = DialogResult.OK;
                                    }
                                    else
                                    {
                                        MessageBox.Show("添加失败！");
                                    }
                                }
                            }
                        }
                        catch (SqlException sqlex)
                        {
                            if (sqlex.ErrorCode.ToString() == "0x80131904")
                                MessageBox.Show("账号已存在,不能重复注册!!!!!!!!!!!");
                            else
                                MessageBox.Show("数据库连接错误，错误源是" + sqlex.Message);
                        }
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        try
                        {
                            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                            {
                                string strsql2 = "insert into [shop_table]([shopID] ,[lpersonName],[shopPwd],[shopTell],[shopSex],[shopAddress]) values(@shopID,@lpersonName,@shopPwd,@shopTell,@shopSex,@shopAddress)";
                                using (SqlCommand comm = new SqlCommand
                                {
                                    CommandText = strsql2,
                                    CommandType = CommandType.Text,
                                    Connection = conn
                                })
                                {
                                    comm.Parameters.AddWithValue("@shopID", textBox1.Text);
                                    comm.Parameters.AddWithValue("@lpersonName", textBox2.Text);
                                    comm.Parameters.AddWithValue("@shopPwd", textBox3.Text);
                                    comm.Parameters.AddWithValue("@shopTell", textBox4.Text);
                                    comm.Parameters.AddWithValue("@shopSex", (radioButton1.Checked ? "男" : "女"));
                                    comm.Parameters.AddWithValue("@shopAddress", textBox5.Text);
                                    conn.Open();

                                    if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
                                    {
                                        MessageBox.Show("添加成功");
                                        DialogResult = DialogResult.OK;
                                    }
                                    else
                                    {
                                        MessageBox.Show("添加失败！");
                                    }
                                }
                            }
                        }
                        catch (SqlException sqlex)
                        {
                            MessageBox.Show("数据库连接错误，错误源是" + sqlex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("密码不一致,请检查!!!!!!!");
                }
            }
            else
            {
                MessageBox.Show("账号不能为空!!!!!!!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Application.StartupPath: G:\Code-Practice\curriculum_design\C#\shopping_platform\shopping_platform\bin\Release
            if (comboBox1.SelectedIndex == 0)
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\headPortrait\\p1.jpg");
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\headPortrait\\p2.png");
            }
            else if (comboBox1.SelectedIndex  == 2)
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\headPortrait\\p3.gif");
            }
            else if (comboBox1.SelectedIndex  == 3)
            {
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\headPortrait\\p4.jpg");
            }
        }
    }
}
