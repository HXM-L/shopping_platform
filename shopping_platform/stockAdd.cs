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
    public partial class stockAdd : Form
    {
        public stockAdd()
        {
            InitializeComponent();
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker1.CustomFormat = " ";
            this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker2.CustomFormat = " ";
            this.comboBox1.SelectedIndex = 0;
        }

        //重置按钮
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }

        //取消按钮
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        //添加按钮
        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                    {
                        string strsql2 = " ";
                        //入库日期和出库日期为空
                        if (this.dateTimePicker1.CustomFormat == " " && this.dateTimePicker2.CustomFormat == " ")
                        {
                            strsql2 = "insert into [stock_table]([comID],[comName],[stockSurplus],[stockFlag]) values(@comID,@comName,@stockSurplus,@stockFlag)";
                            using (SqlCommand comm = new SqlCommand
                            {
                                CommandText = strsql2,
                                CommandType = CommandType.Text,
                                Connection = conn
                            })
                            {
                                comm.Parameters.AddWithValue("@comID", textBox1.Text);
                                comm.Parameters.AddWithValue("@comName", textBox2.Text);
                                comm.Parameters.AddWithValue("@stockSurplus", textBox3.Text);
                                comm.Parameters.AddWithValue("@stockFlag", comboBox1.SelectedIndex);
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
                        //入库日期不为空,出库日期为空
                        else if (this.dateTimePicker1.CustomFormat != " " && this.dateTimePicker2.CustomFormat == " ")
                        {
                            strsql2 = "insert into [stock_table]([comID],[comName],[stockSurplus],[inDate],[stockFlag]) values(@comID,@comName,@stockSurplus,@inDate,@stockFlag)";
                            using (SqlCommand comm = new SqlCommand
                            {
                                CommandText = strsql2,
                                CommandType = CommandType.Text,
                                Connection = conn
                            })
                            {
                                comm.Parameters.AddWithValue("@comID", textBox1.Text);
                                comm.Parameters.AddWithValue("@comName", textBox2.Text);
                                comm.Parameters.AddWithValue("@stockSurplus", textBox3.Text);
                                comm.Parameters.AddWithValue("@inDate", dateTimePicker1.Value.ToString());
                                comm.Parameters.AddWithValue("@stockFlag", comboBox1.SelectedIndex);
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
                        //付款日期和签收日期都不为空
                        else
                        {
                            strsql2 = "insert into [stock_table]([comID],[comName],[stockSurplus],[inDate],[outDate],[stockFlag]) values(@comID,@comName,@stockSurplus,@inDate,@outDate,@stockFlag)";
                            using (SqlCommand comm = new SqlCommand
                            {
                                CommandText = strsql2,
                                CommandType = CommandType.Text,
                                Connection = conn
                            })
                            {
                                comm.Parameters.AddWithValue("@comID", textBox1.Text);
                                comm.Parameters.AddWithValue("@comName", textBox2.Text);
                                comm.Parameters.AddWithValue("@stockSurplus", textBox3.Text);
                                comm.Parameters.AddWithValue("@inDate", dateTimePicker1.Value.ToString());
                                comm.Parameters.AddWithValue("@outDate", dateTimePicker2.Value.ToString());
                                comm.Parameters.AddWithValue("@stockFlag", comboBox1.SelectedIndex);
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
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("数据库连接错误，错误源是" + sqlex.Message);
                }
            }
            else
            {
                MessageBox.Show("商品单号ID不能为空!!!");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //设置日期的格式
            this.dateTimePicker1.Format = DateTimePickerFormat.Short;
            this.dateTimePicker1.CustomFormat = null;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //设置日期的格式
            this.dateTimePicker2.Format = DateTimePickerFormat.Short;
            this.dateTimePicker2.CustomFormat = null;
        }
    }
}
