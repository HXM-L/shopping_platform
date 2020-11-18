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
    public partial class purchModify : Form
    {
        public purchModify(DataGridViewSelectedRowCollection dataGridViewRow)
        {
            InitializeComponent();
            this.textBox1.Text = dataGridViewRow[0].Cells[0].Value.ToString();
            this.textBox2.Text = dataGridViewRow[0].Cells[1].Value.ToString();
            this.textBox3.Text = dataGridViewRow[0].Cells[2].Value.ToString();
            this.textBox4.Text = dataGridViewRow[0].Cells[3].Value.ToString();
            this.textBox5.Text = dataGridViewRow[0].Cells[4].Value.ToString();
            this.textBox6.Text = dataGridViewRow[0].Cells[5].Value.ToString();
            this.textBox7.Text = dataGridViewRow[0].Cells[6].Value.ToString();
            this.dateTimePicker1.Value = Convert.ToDateTime(dataGridViewRow[0].Cells[7].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlHelper要改命名空间
                using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                {
                    //where [purchID]='" + textBox1.Text.ToString() + "'";这里的单引号不能漏
                    string strsql2 = " ";
                    strsql2 = "update [purchase_detail_table] set [shopName]=@shopName ,[comName]=@comName ,[comPrice]=@comPrice ,[comSurplus]=@comSurplus ,[comAddress]=@comAddress ,[purchDate]=@purchDate where [purchID]='" + textBox1.Text.ToString() + "' and [comID]='" + textBox3.Text.ToString() + "'";
                    using (SqlCommand comm = new SqlCommand
                    {
                        CommandText = strsql2,
                        CommandType = CommandType.Text,
                        Connection = conn
                    })
                    {
                        comm.Parameters.AddWithValue("@shopName", textBox2.Text);
                        comm.Parameters.AddWithValue("@comName", textBox4.Text);
                        comm.Parameters.AddWithValue("@comPrice", textBox5.Text);
                        comm.Parameters.AddWithValue("@comSurplus", textBox6.Text);
                        comm.Parameters.AddWithValue("@comAddress", textBox7.Text);
                        comm.Parameters.AddWithValue("@purchDate", dateTimePicker1.Value.ToString());
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

        //取消按钮
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
