using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; //数据库的头文件
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shopping_platform
{
    public partial class PInformation : UserControl
    {
        public PInformation(string userID)
        {
            InitializeComponent();
            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
            {
                //加载所有商品的数据
                string sql = "select * from [user_table] where [userID]='" + userID + "'";//sda执行的sql语句、执行的数据库连接
                var WarEData = new SqlDataAdapter(sql, conn);//创建数据库连接
                var WareTable = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                WarEData.Fill(WareTable);//往dt里填充数据。
                this.textBox2.Text = WareTable.Rows[0]["userID"].ToString();
                this.textBox3.Text = WareTable.Rows[0]["userName"].ToString();
                this.textBox4.Text = WareTable.Rows[0]["userTell"].ToString();
                this.textBox5.Text = WareTable.Rows[0]["userSex"].ToString();
                this.textBox6.Text = WareTable.Rows[0]["shipAddress"].ToString();
                this.dateTimePicker1.Text = WareTable.Rows[0]["birthDay"].ToString();
            }
        }

        //取消按钮
        private void button1_Click(object sender, EventArgs e)
        {
            //this.textBox2.Enabled = true;
            this.textBox3.Enabled = true;
            this.textBox4.Enabled = true;
            this.textBox5.Enabled = true;
            this.textBox6.Enabled = true;
            this.dateTimePicker1.Enabled = true;
        }

        //保存修改后的个人信息
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlHelper要改命名空间
                using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                {
                    //where [purchID]='" + textBox1.Text.ToString() + "'";这里的单引号不能漏
                    string strsql2 = " ";
                    strsql2 = "update [user_table] set [userName]=@userName ,[userTell]=@userTell ,[userSex]=@userSex ,[shipAddress]=@shipAddress ,[birthDay]=@birthDay where [userID]='" + textBox2.Text.ToString() + "'";
                    using (SqlCommand comm = new SqlCommand
                    {
                        CommandText = strsql2,
                        CommandType = CommandType.Text,
                        Connection = conn
                    })
                    {
                        comm.Parameters.AddWithValue("@userName", textBox3.Text);
                        comm.Parameters.AddWithValue("@userTell", textBox4.Text);
                        comm.Parameters.AddWithValue("@userSex", textBox5.Text);
                        comm.Parameters.AddWithValue("@shipAddress", textBox6.Text);
                        comm.Parameters.AddWithValue("@birthDay", dateTimePicker1.Value.ToString());
                        conn.Open();

                        if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
                        {
                            MessageBox.Show("修改成功");
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
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;
            this.textBox4.Enabled = false;
            this.textBox5.Enabled = false;
            this.textBox6.Enabled = false;
            this.dateTimePicker1.Enabled = false;
        }
    }
}
