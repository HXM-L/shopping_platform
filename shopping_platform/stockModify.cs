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
    public partial class stockModify : Form
    {
        public stockModify(DataGridViewSelectedRowCollection dataGridViewRow)
        {
            InitializeComponent();
            string tempStau = dataGridViewRow[0].Cells[6].Value.ToString();
            this.textBox1.Text = dataGridViewRow[0].Cells[0].Value.ToString();
            this.textBox2.Text = dataGridViewRow[0].Cells[1].Value.ToString();
            this.textBox3.Text = dataGridViewRow[0].Cells[2].Value.ToString();
            this.textBox4.Text = dataGridViewRow[0].Cells[3].Value.ToString();
            switch (tempStau)
            {
                case "待入库":
                    this.comboBox1.SelectedIndex = 0;
                    break;
                case "已入库":
                    this.comboBox1.SelectedIndex = 1;
                    break;
                case "已出库":
                    this.comboBox1.SelectedIndex = 2;
                    break;
                default:
                    this.comboBox1.SelectedIndex = -1;
                    break;
            }
            //如果日期为空值就不显示日期
            if (dataGridViewRow[0].Cells[4].Value.ToString() == "")
            {
                this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
                this.dateTimePicker1.CustomFormat = " ";
            }
            else
            {
                this.dateTimePicker1.Value = Convert.ToDateTime(dataGridViewRow[0].Cells[4].Value);
            }
            if (dataGridViewRow[0].Cells[5].Value.ToString() == "")
            {
                this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
                this.dateTimePicker2.CustomFormat = " ";
            }
            else
            {
                this.dateTimePicker2.Value = Convert.ToDateTime(dataGridViewRow[0].Cells[5].Value);
            }
        }

        //取消按钮
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        //确定按钮
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlHelper要改命名空间
                using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                {
                    string strsql2 = " ";
                    if (this.dateTimePicker1.CustomFormat == " " && this.dateTimePicker2.CustomFormat == " ")
                    {
                        strsql2 = "update [stock_table] set [comName]=@comName ,[stockSurplus]=@stockSurplus ,[stockFlag]=@stockFlag where [stockID]=" + textBox1.Text + " and [comID]=" + textBox2.Text + "";
                        using (SqlCommand comm = new SqlCommand
                        {
                            CommandText = strsql2,
                            CommandType = CommandType.Text,
                            Connection = conn
                        })
                        {
                            comm.Parameters.AddWithValue("@comName", textBox3.Text);
                            comm.Parameters.AddWithValue("@stockSurplus", textBox4.Text);
                            comm.Parameters.AddWithValue("@stockFlag", comboBox1.SelectedIndex);
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
                    else if(this.dateTimePicker1.CustomFormat != " " && this.dateTimePicker2.CustomFormat == " ")
                    {
                        strsql2 = "update [stock_table] set [comName]=@comName ,[stockSurplus]=@stockSurplus ,[inDate]=@inDate, [stockFlag]=@stockFlag where [stockID]=" + textBox1.Text + " and [comID]=" + textBox2.Text + "";
                        using (SqlCommand comm = new SqlCommand
                        {
                            CommandText = strsql2,
                            CommandType = CommandType.Text,
                            Connection = conn
                        })
                        {
                            comm.Parameters.AddWithValue("@comName", textBox3.Text);
                            comm.Parameters.AddWithValue("@stockSurplus", textBox4.Text);
                            comm.Parameters.AddWithValue("@inDate", dateTimePicker1.Value.ToString());
                            comm.Parameters.AddWithValue("@stockFlag", comboBox1.SelectedIndex);
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
                    else
                    {
                        strsql2 = "update [stock_table] set [comName]=@comName ,[stockSurplus]=@stockSurplus ,[inDate]=@inDate,[outDate]=@outDate,[stockFlag]=@stockFlag where [stockID]=" + textBox1.Text + " and [comID]=" + textBox2.Text + "";
                        using (SqlCommand comm = new SqlCommand
                        {
                            CommandText = strsql2,
                            CommandType = CommandType.Text,
                            Connection = conn
                        })
                        {
                            comm.Parameters.AddWithValue("@comName", textBox3.Text);
                            comm.Parameters.AddWithValue("@stockSurplus", textBox4.Text);
                            comm.Parameters.AddWithValue("@inDate", dateTimePicker1.Value.ToString());
                            comm.Parameters.AddWithValue("@outDate", dateTimePicker2.Value.ToString());
                            comm.Parameters.AddWithValue("@stockFlag", comboBox1.SelectedIndex);
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
            catch (SqlException sqlex)
            {
                MessageBox.Show("数据库连接错误，错误源是" + sqlex.Message);
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
