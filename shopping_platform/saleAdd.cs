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
    public partial class saleAdd : Form
    {
        public saleAdd()
        {
            InitializeComponent();
        }

        //重置
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }
        //取消按钮
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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
                        strsql2 = "insert into [sale_table]([comID] ,[comName],[purchPrice],[salePrice],[saleSurplus],[purchSurplus],[comSurplus],[profitAmount],[tranDate]) values(@comID,@comName,@purchPrice,@salePrice,@saleSurplus,@purchSurplus,@comSurplus,@profitAmount,@tranDate)";
                        using (SqlCommand comm = new SqlCommand
                        {
                            CommandText = strsql2,
                            CommandType = CommandType.Text,
                            Connection = conn
                        })
                        {
                            comm.Parameters.AddWithValue("@comID", textBox1.Text);
                            comm.Parameters.AddWithValue("@comName", textBox2.Text);
                            comm.Parameters.AddWithValue("@purchPrice", textBox3.Text);
                            comm.Parameters.AddWithValue("@salePrice", textBox4.Text);
                            comm.Parameters.AddWithValue("@saleSurplus", textBox5.Text);
                            comm.Parameters.AddWithValue("@purchSurplus", textBox6.Text);
                            comm.Parameters.AddWithValue("@comSurplus", textBox7.Text);
                            comm.Parameters.AddWithValue("@profitAmount", textBox8.Text);
                            comm.Parameters.AddWithValue("@tranDate", dateTimePicker1.Value.ToString());
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
                MessageBox.Show("商品ID不能为空!!!");
            }
        }

        //当填入商品进货量,就自动计算剩余量和盈利金额
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.ToString() != "")
            {
                //剩余量
                int sur = int.Parse(textBox6.Text.ToString()) - int.Parse(textBox5.Text.ToString());
                textBox7.Text = sur.ToString();
                //盈利金额
                float profit = (float.Parse(textBox4.Text)- float.Parse(textBox3.Text)) * float.Parse(textBox5.Text);
                textBox8.Text = profit.ToString();
            }
        }
    }
}
