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
    public partial class purchAdd : Form
    {
        public purchAdd()
        {
            InitializeComponent();
        }

        //取消按钮
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        //重置按钮
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        //添加按钮
        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                    {
                        string strsql2 = " ";
                        strsql2 = "insert into [purchase_detail_table]([purchID] ,[shopName],[comID],[comName],[comPrice],[comSurplus],[comAddress],[purchDate]) values(@purchID,@shopName,@comID,@comName,@comPrice,@comSurplus,@comAddress,@purchDate)";
                        using (SqlCommand comm = new SqlCommand
                        {
                            CommandText = strsql2,
                            CommandType = CommandType.Text,
                            Connection = conn
                        })
                        {
                            comm.Parameters.AddWithValue("@purchID", textBox1.Text);
                            comm.Parameters.AddWithValue("@shopName", textBox2.Text);
                            comm.Parameters.AddWithValue("@comID", textBox3.Text);
                            comm.Parameters.AddWithValue("@comName", textBox4.Text);
                            comm.Parameters.AddWithValue("@comPrice", textBox5.Text);
                            comm.Parameters.AddWithValue("@comSurplus", textBox6.Text);
                            comm.Parameters.AddWithValue("@comAddress", textBox7.Text);
                            comm.Parameters.AddWithValue("@purchDate", dateTimePicker1.Value.ToString());
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
                MessageBox.Show("进货单号不能为空!!!");
            }
        }
    }
}
