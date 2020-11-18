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
    public partial class saleModify : Form
    {
        public saleModify(DataGridViewSelectedRowCollection dataGridViewRow)
        {
            InitializeComponent();
            this.textBox1.Text = dataGridViewRow[0].Cells[0].Value.ToString();
            this.textBox2.Text = dataGridViewRow[0].Cells[1].Value.ToString();
            this.textBox3.Text = dataGridViewRow[0].Cells[2].Value.ToString();
            this.textBox4.Text = dataGridViewRow[0].Cells[3].Value.ToString();
            this.textBox5.Text = dataGridViewRow[0].Cells[4].Value.ToString();
            this.textBox6.Text = dataGridViewRow[0].Cells[5].Value.ToString();
            this.textBox7.Text = dataGridViewRow[0].Cells[6].Value.ToString();
            this.textBox8.Text = dataGridViewRow[0].Cells[7].Value.ToString();
            this.textBox9.Text = dataGridViewRow[0].Cells[8].Value.ToString();
            this.dateTimePicker1.Value = Convert.ToDateTime(dataGridViewRow[0].Cells[9].Value);
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
                    //where [purchID]='" + textBox1.Text.ToString() + "'";这里的单引号不能漏
                    string strsql2 = " ";
                    strsql2 = "insert into [sale_table]([comName],[purchPrice],[salePrice],[saleSurplus],[purchSurplus],[comSurplus],[profitAmount],[tranDate]) values(@comID,@comName,@purchPrice,@salePrice,@saleSurplus,@purchSurplus,@comSurplus,@profitAmount,@tranDate)";
                    strsql2 = "update [sale_table] set [comName]=@comName ,[purchPrice]=@purchPrice ,[salePrice]=@salePrice ,[saleSurplus]=@saleSurplus ,[purchSurplus]=@purchSurplus ,[comSurplus]=@comSurplus,[profitAmount]=@profitAmount,[tranDate]=@tranDate where [ID]='" + textBox1.Text.ToString() + "' and [comID]='" + textBox2.Text.ToString() + "'";
                    using (SqlCommand comm = new SqlCommand
                    {
                        CommandText = strsql2,
                        CommandType = CommandType.Text,
                        Connection = conn
                    })
                    {
                        comm.Parameters.AddWithValue("@comName", textBox3.Text);
                        comm.Parameters.AddWithValue("@purchPrice", textBox4.Text);
                        comm.Parameters.AddWithValue("@salePrice", textBox5.Text);
                        comm.Parameters.AddWithValue("@saleSurplus", textBox6.Text);
                        comm.Parameters.AddWithValue("@purchSurplus", textBox7.Text);
                        comm.Parameters.AddWithValue("@comSurplus", textBox8.Text);
                        comm.Parameters.AddWithValue("@profitAmount", textBox9.Text);
                        comm.Parameters.AddWithValue("@tranDate", dateTimePicker1.Value.ToString());
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.ToString() != "")
            {
                //剩余量
                int sur = int.Parse(textBox7.Text.ToString()) - int.Parse(textBox6.Text.ToString());
                textBox8.Text = sur.ToString();
                //盈利金额
                float profit = (float.Parse(textBox5.Text) - float.Parse(textBox4.Text)) * float.Parse(textBox6.Text);
                textBox9.Text = profit.ToString();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //if (textBox6.Text.ToString() != "")
            //{
            //    //剩余量
            //    int sur = int.Parse(textBox7.Text.ToString()) - int.Parse(textBox6.Text.ToString());
            //    textBox8.Text = sur.ToString();
            //    //盈利金额
            //    float profit = (float.Parse(textBox5.Text) - float.Parse(textBox4.Text)) * float.Parse(textBox6.Text);
            //    textBox9.Text = profit.ToString();
            //}
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //if (textBox4.Text.ToString() != "")
            //{
            //    //剩余量
            //    int sur = int.Parse(textBox7.Text.ToString()) - int.Parse(textBox6.Text.ToString());
            //    textBox8.Text = sur.ToString();
            //    //盈利金额
            //    float profit = (float.Parse(textBox5.Text) - float.Parse(textBox4.Text)) * float.Parse(textBox6.Text);
            //    textBox9.Text = profit.ToString();
            //}
        }
    }
}
