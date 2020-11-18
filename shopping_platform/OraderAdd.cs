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
    public partial class OraderAdd : Form
    {
        public OraderAdd()
        {
            InitializeComponent();
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker1.CustomFormat = " ";
            this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker2.CustomFormat = " ";
            this.comboBox3.SelectedIndex = 1;
            this.comboBox4.SelectedIndex = 1;
            //Random ran = new Random();
            //this.textBox1.Text = DateTime.Now.ToString("yyyyMMddhhmmss") + ran.Next(1000, 9999).ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        //取消按钮
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        //添加一条订单记录确定按钮
        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                    {
                        string strsql2 = " ";
                        //付款日期和签收日期为空
                        if (this.dateTimePicker1.CustomFormat == " " && this.dateTimePicker2.CustomFormat == " ")
                        {
                            //不能省去order_table([orderID] ,[userID] ,[shopID] ,[orderTotalPrice] ,[shipAddress] ,[payMethod],[tranStatus])
                            strsql2 = "insert into order_table([orderID] ,[userID] ,[shopID] ,[orderTotalPrice] ,[shipAddress] ,[payMethod] ,[tranStatus]) values(@orderID,@userID,@shopID,@orderTotalPrice,@shipAddress,@payMethod,@tranStatus)";
                            using (SqlCommand comm = new SqlCommand
                            {
                                CommandText = strsql2,
                                CommandType = CommandType.Text,
                                Connection = conn
                            })
                            {
                                comm.Parameters.AddWithValue("@orderID", textBox1.Text);
                                comm.Parameters.AddWithValue("@userID", textBox2.Text);
                                comm.Parameters.AddWithValue("@shopID", textBox3.Text);
                                comm.Parameters.AddWithValue("@orderTotalPrice", textBox4.Text);
                                comm.Parameters.AddWithValue("@shipAddress", textBox5.Text);
                                comm.Parameters.AddWithValue("@payMethod", comboBox1.SelectedIndex);
                                comm.Parameters.AddWithValue("@tranStatus", comboBox2.SelectedIndex);
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
                        //付款日期为空,签收日期不为空
                        else if (this.dateTimePicker1.CustomFormat == " " && this.dateTimePicker2.CustomFormat != " ")
                        {
                            strsql2 = "insert into order_table([orderID] ,[userID] ,[shopID] ,[orderTotalPrice] ,[shipAddress] ,[payMethod] ,[signDate],[tranStatus]) values(@orderID,@userID,@shopID,@orderTotalPrice,@shipAddress,@payMethod,@signDate,@tranStatus)";
                            using (SqlCommand comm = new SqlCommand
                            {
                                CommandText = strsql2,
                                CommandType = CommandType.Text,
                                Connection = conn
                            })
                            {
                                comm.Parameters.AddWithValue("@orderID", textBox1.Text);
                                comm.Parameters.AddWithValue("@userID", textBox2.Text);
                                comm.Parameters.AddWithValue("@shopID", textBox3.Text);
                                comm.Parameters.AddWithValue("@orderTotalPrice", textBox4.Text);
                                comm.Parameters.AddWithValue("@shipAddress", textBox5.Text);
                                comm.Parameters.AddWithValue("@payMethod", comboBox1.SelectedIndex);
                                comm.Parameters.AddWithValue("@signDate", dateTimePicker1.Value.ToString());
                                comm.Parameters.AddWithValue("@tranStatus", comboBox2.SelectedIndex);
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
                        //付款日期不为空,签收日期为空
                        else if (this.dateTimePicker1.CustomFormat != " " && this.dateTimePicker2.CustomFormat == " ")
                        {
                            strsql2 = "insert into order_table([orderID] ,[userID] ,[shopID] ,[orderTotalPrice] ,[shipAddress] ,[payMethod] ,[payDate] ,[tranStatus]) values(@orderID,@userID,@shopID,@orderTotalPrice,@shipAddress,@payMethod,@payDate,@tranStatus)";
                            using (SqlCommand comm = new SqlCommand
                            {
                                CommandText = strsql2,
                                CommandType = CommandType.Text,
                                Connection = conn
                            })
                            {
                                comm.Parameters.AddWithValue("@orderID", textBox1.Text);
                                comm.Parameters.AddWithValue("@userID", textBox2.Text);
                                comm.Parameters.AddWithValue("@shopID", textBox3.Text);
                                comm.Parameters.AddWithValue("@orderTotalPrice", textBox4.Text);
                                comm.Parameters.AddWithValue("@shipAddress", textBox5.Text);
                                comm.Parameters.AddWithValue("@payMethod", comboBox1.SelectedIndex);  
                                comm.Parameters.AddWithValue("@payDate", dateTimePicker2.Value.ToString());
                                comm.Parameters.AddWithValue("@tranStatus", comboBox2.SelectedIndex);
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
                        else if (this.dateTimePicker1.CustomFormat != " " && this.dateTimePicker2.CustomFormat != " ")
                        {
                            strsql2 = "insert into order_table([orderID] ,([userID] ,[shopID] ,[orderTotalPrice] ,[shipAddress] ,[payMethod] ,[payDate] ,[signDate],[tranStatus]) values(@orderID,@userID,@shopID,@orderTotalPrice,@shipAddress,@payMethod,@payDate,@signDate,@tranStatus)";
                            using (SqlCommand comm = new SqlCommand
                            {
                                CommandText = strsql2,
                                CommandType = CommandType.Text,
                                Connection = conn
                            })
                            {
                                comm.Parameters.AddWithValue("@orderID", textBox1.Text);
                                comm.Parameters.AddWithValue("@userID", textBox2.Text);
                                comm.Parameters.AddWithValue("@shopID", textBox3.Text);
                                comm.Parameters.AddWithValue("@orderTotalPrice", textBox4.Text);
                                comm.Parameters.AddWithValue("@shipAddress", textBox5.Text);
                                comm.Parameters.AddWithValue("@payMethod", comboBox1.SelectedIndex);
                                comm.Parameters.AddWithValue("@payDate", dateTimePicker1.Value.ToString());
                                comm.Parameters.AddWithValue("@signDate", dateTimePicker2.Value.ToString());
                                comm.Parameters.AddWithValue("@tranStatus", comboBox2.SelectedIndex);
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
                MessageBox.Show("用户ID或商家ID为空!!!");
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

        //自动生成订单号
        private void OraderAdd_Load(object sender, EventArgs e)
        {
            Random ran = new Random();
            this.textBox1.Text = DateTime.Now.ToString("yyyyMMddhhmmss")+ ran.Next(1000, 9999).ToString();
        }
    }
}
