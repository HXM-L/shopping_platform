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
    public partial class wareAdd : Form
    {
        public wareAdd()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
        }

        //添加一行商品数据
        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                    {
                        string strsql2 = "insert into commodity_table([comID],[comName],[comPrice],[comType],[comSurplus],[comIntroduction],[comAddress],[saleStatu]) values(@comID,@comName,@comPrice,@comType,@comSurplus,@comIntroduction,@comAddress,@saleStatu)";
                        using (SqlCommand comm = new SqlCommand
                        {
                            CommandText = strsql2,
                            CommandType = CommandType.Text,
                            Connection = conn
                        })
                        {
                            comm.Parameters.AddWithValue("@comID", textBox1.Text);
                            comm.Parameters.AddWithValue("@comName", textBox2.Text);
                            comm.Parameters.AddWithValue("@comPrice", textBox3.Text);
                            comm.Parameters.AddWithValue("@comType", comboBox1.SelectedIndex);
                            comm.Parameters.AddWithValue("@comSurplus", textBox4.Text);
                            comm.Parameters.AddWithValue("@comIntroduction", textBox5.Text);
                            comm.Parameters.AddWithValue("@comAddress", textBox6.Text);
                            comm.Parameters.AddWithValue("@saleStatu", comboBox2.SelectedIndex);
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
            else
            {
                MessageBox.Show("订单号不能为空!!!");
            }
        }
    }
}
