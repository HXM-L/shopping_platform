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
    public partial class wareModify : Form
    {
        //利用带参构造函数传值
        public wareModify(DataGridViewSelectedRowCollection dataGridViewRow)
        {
            InitializeComponent();
            string tempType = dataGridViewRow[0].Cells[3].Value.ToString();
            string tempStau = dataGridViewRow[0].Cells[7].Value.ToString();
            this.textBox1.Text = dataGridViewRow[0].Cells[0].Value.ToString();
            this.textBox2.Text = dataGridViewRow[0].Cells[1].Value.ToString();
            this.textBox3.Text = dataGridViewRow[0].Cells[2].Value.ToString();
            this.textBox4.Text = dataGridViewRow[0].Cells[4].Value.ToString();
            this.textBox5.Text = dataGridViewRow[0].Cells[5].Value.ToString();
            this.textBox6.Text = dataGridViewRow[0].Cells[6].Value.ToString();
            //商品类型
            switch (tempType)
            {
                case "衣物":
                    this.comboBox1.SelectedIndex = 0;
                    break;
                case "电子产品":
                    this.comboBox1.SelectedIndex = 1;
                    break;
                case "家电":
                    this.comboBox1.SelectedIndex = 2;
                    break;
                case "蔬果":
                    this.comboBox1.SelectedIndex = 3;
                    break;
                case "生活百货":
                    this.comboBox1.SelectedIndex = 4;
                    break;
                default:
                    this.comboBox1.SelectedIndex = -1;
                    break;
            }
            //售卖状态
            switch (tempStau)
            {
                case "待上架":
                    this.comboBox2.SelectedIndex = 0;
                    break;
                case "已发售":
                    this.comboBox2.SelectedIndex = 1;
                    break;
                case "已售罄":
                    this.comboBox2.SelectedIndex = 2;
                    break;
                case "已下架":
                    this.comboBox2.SelectedIndex = 3;
                    break;
                default:
                    this.comboBox2.SelectedIndex = -1;
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlHelper要改命名空间
                using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                {
                    string strsql2 = " ";
                    strsql2 = "update commodity_table set [comName]=@comName ,[comPrice]=@comPrice ,[comType]=@comType ,[comSurplus]=@comSurplus ,[comIntroduction]=@comIntroduction ,[comAddress]=@comAddress,[saleStatu]=@saleStatu where [comID]=" + textBox1.Text + "";
                    using (SqlCommand comm = new SqlCommand
                    {
                        CommandText = strsql2,
                        CommandType = CommandType.Text,
                        Connection = conn
                    })
                    {
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
            catch (SqlException sqlex)
            {
                MessageBox.Show("数据库连接错误，错误源是" + sqlex.Message);
            }
        }
    }
}
