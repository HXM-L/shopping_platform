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
    public partial class ModifyOrader : Form
    {
        //利用带参构造函数传值
        public ModifyOrader(DataGridViewSelectedRowCollection dataGridViewRow)
        {
            InitializeComponent();
            string tempP = dataGridViewRow[0].Cells[5].Value.ToString(); //付款方式
            string tempT = dataGridViewRow[0].Cells[8].Value.ToString(); //交易状态
            this.textBox1.Text = dataGridViewRow[0].Cells[0].Value.ToString();
            this.textBox2.Text = dataGridViewRow[0].Cells[1].Value.ToString();
            this.textBox3.Text = dataGridViewRow[0].Cells[2].Value.ToString();
            this.textBox4.Text = dataGridViewRow[0].Cells[3].Value.ToString();
            //付款方式
            switch (tempP)
            {
                case "线上付款":
                    this.comboBox1.SelectedIndex = 0;
                    break;
                case "货到付款":
                    this.comboBox1.SelectedIndex = 1;
                    break;
                default:
                    this.comboBox1.SelectedIndex = 2;
                    break;
            }
            //交易状态
            switch (tempT)
            {
                case "待付款":
                    this.comboBox2.SelectedIndex = 0;
                    break;
                case "待发货":
                    this.comboBox2.SelectedIndex = 1;
                    break;
                case "退货/退款中":
                    this.comboBox2.SelectedIndex = 2;
                    break;
                case "已取消":
                    this.comboBox2.SelectedIndex = 3;
                    break;
                case "已退货/退款":
                    this.comboBox2.SelectedIndex = 4;
                    break;
                case "已完成":
                    this.comboBox2.SelectedIndex = 5;
                    break;
                default:
                    this.comboBox2.SelectedIndex = 6;
                    break;
            }


            //如果日期为空值就不显示日期
            if (dataGridViewRow[0].Cells[6].Value.ToString() == "")
            {
                this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
                this.dateTimePicker1.CustomFormat = " ";
            }
            else
            {
                this.dateTimePicker1.Value = Convert.ToDateTime(dataGridViewRow[0].Cells[6].Value);
            }
            if (dataGridViewRow[0].Cells[7].Value.ToString() == "")
            {
                this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
                this.dateTimePicker2.CustomFormat = " ";
            }
            else
            {
                this.dateTimePicker2.Value = Convert.ToDateTime(dataGridViewRow[0].Cells[7].Value);
            }

            this.textBox5.Text = dataGridViewRow[0].Cells[4].Value.ToString();
            //this.comboBox2.SelectedIndex = 2;
        }

        //取消按钮
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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

        //修改订单,确定按钮
        private void button2_Click(object sender, EventArgs e)
        {
            //SqlHelper要改命名空间
            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
            {
                string strsql2 = " ";
                //付款日期和签收日期为空
                if (this.dateTimePicker1.CustomFormat == " " && this.dateTimePicker2.CustomFormat == " ")
                {
                    //不能省去order_table([orderID] ,[userID] ,[shopID] ,[orderTotalPrice] ,[shipAddress] ,[payMethod],[tranStatus])
                    //这里的textBox1.Text要加上tostring()
                    // [orderID]='" + textBox1.Text.ToString() + "'"这里的单引号不能省略
                    strsql2 = "update order_table set [userID]=@userID ,[shopID]=@shopID ,[orderTotalPrice]=@orderTotalPrice ,[shipAddress]=@shipAddress ,[payMethod]=@payMethod,[tranStatus]=@tranStatus where [orderID]='" + textBox1.Text.ToString() + "'";
                    using (SqlCommand comm = new SqlCommand
                    {
                        CommandText = strsql2,
                        CommandType = CommandType.Text,
                        Connection = conn
                    })
                    {
                        comm.Parameters.AddWithValue("@userID", textBox2.Text.ToString());
                        comm.Parameters.AddWithValue("@shopID", textBox3.Text);
                        comm.Parameters.AddWithValue("@orderTotalPrice", textBox4.Text);
                        comm.Parameters.AddWithValue("@shipAddress", textBox5.Text);
                        comm.Parameters.AddWithValue("@payMethod", comboBox1.SelectedIndex);
                        comm.Parameters.AddWithValue("@tranStatus", comboBox2.SelectedIndex);
                        conn.Open();

                        if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
                        {
                            MessageBox.Show("修改成功");
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("修改失败！");
                        }
                    }

                }
                //付款日期为空,签收日期不为空
                else if (this.dateTimePicker1.CustomFormat == " " && this.dateTimePicker2.CustomFormat != " ")
                {
                    strsql2 = "update order_table set [userID]=@userID ,[shopID]=@shopID ,[orderTotalPrice]=@orderTotalPrice ,[shipAddress]=@shipAddress ,[payMethod]=@payMethod,[signDate]=@signDate,[tranStatus]=@tranStatus where [orderID]='" + textBox1.Text + "'";
                    using (SqlCommand comm = new SqlCommand
                    {
                        CommandText = strsql2,
                        CommandType = CommandType.Text,
                        Connection = conn
                    })
                    {
                        comm.Parameters.AddWithValue("@orderID", textBox1.Text.ToString());
                        comm.Parameters.AddWithValue("@userID", textBox2.Text.ToString());
                        comm.Parameters.AddWithValue("@shopID", textBox3.Text.ToString());
                        comm.Parameters.AddWithValue("@orderTotalPrice", textBox4.Text.ToString());
                        comm.Parameters.AddWithValue("@shipAddress", textBox5.Text.ToString());
                        comm.Parameters.AddWithValue("@payMethod", comboBox1.SelectedIndex);
                        comm.Parameters.AddWithValue("@signDate", dateTimePicker1.Value.ToString());
                        comm.Parameters.AddWithValue("@tranStatus", comboBox2.SelectedIndex);
                        conn.Open();

                        if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
                        {
                            MessageBox.Show("修改成功");
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("修改失败！");
                        }
                    }
                }
                //付款日期不为空,签收日期为空
                else if (this.dateTimePicker1.CustomFormat != " " && this.dateTimePicker2.CustomFormat == " ")
                {
                    strsql2 = "update order_table set [userID]=@userID ,[shopID]=@shopID ,[orderTotalPrice]=@orderTotalPrice ,[shipAddress]=@shipAddress ,[payMethod]=@payMethod ,[payDate]=@payDate ,[tranStatus]=@tranStatus where [orderID]='" + textBox1.Text.ToString() + "'";
                    using (SqlCommand comm = new SqlCommand
                    {
                        CommandText = strsql2,
                        CommandType = CommandType.Text,
                        Connection = conn
                    })
                    {
                        comm.Parameters.AddWithValue("@userID", textBox2.Text.ToString());
                        comm.Parameters.AddWithValue("@shopID", textBox3.Text.ToString());
                        comm.Parameters.AddWithValue("@orderTotalPrice", textBox4.Text.ToString());
                        comm.Parameters.AddWithValue("@shipAddress", textBox5.Text.ToString());
                        comm.Parameters.AddWithValue("@payMethod", comboBox1.SelectedIndex);
                        comm.Parameters.AddWithValue("@payDate", dateTimePicker2.Value.ToString());
                        comm.Parameters.AddWithValue("@tranStatus", comboBox2.SelectedIndex);
                        conn.Open();

                        if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
                        {
                            MessageBox.Show("修改成功");
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("修改失败！");
                        }
                    }
                }
                //付款日期和签收日期都不为空
                else if (this.dateTimePicker1.CustomFormat != " " && this.dateTimePicker2.CustomFormat != " ")
                {
                    strsql2 = "update order_table set [userID]=@userID ,[shopID]=@shopID ,[orderTotalPrice]=@orderTotalPrice ,[shipAddress]=@shipAddress ,[payMethod]=@payMethod ,[payDate]=@payDate ,[signDate]=@signDate,[tranStatus]=@tranStatus where [orderID]='" + textBox1.Text.ToString() + "'";
                    using (SqlCommand comm = new SqlCommand
                    {
                        CommandText = strsql2,
                        CommandType = CommandType.Text,
                        Connection = conn
                    })
                    {
                        comm.Parameters.AddWithValue("@orderID", textBox1.Text.ToString());
                        comm.Parameters.AddWithValue("@userID", textBox2.Text.ToString());
                        comm.Parameters.AddWithValue("@shopID", textBox3.Text.ToString());
                        comm.Parameters.AddWithValue("@orderTotalPrice", textBox4.Text.ToString());
                        comm.Parameters.AddWithValue("@shipAddress", textBox5.Text.ToString());
                        comm.Parameters.AddWithValue("@payMethod", comboBox1.SelectedIndex);
                        comm.Parameters.AddWithValue("@payDate", dateTimePicker1.Value.ToString());
                        comm.Parameters.AddWithValue("@signDate", dateTimePicker2.Value.ToString());
                        comm.Parameters.AddWithValue("@tranStatus", comboBox2.SelectedIndex);
                        conn.Open();

                        if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
                        {
                            MessageBox.Show("修改成功");
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("修改失败！");
                        }
                    }
                }
            }
        }
    }
}
