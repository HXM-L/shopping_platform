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
    public partial class ModifyInformation : UserControl
    {
        public ModifyInformation()
        {
            InitializeComponent();
        }

        private void ModifyInformation_Load(object sender, EventArgs e)
        {
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;
            this.textBox3.Enabled = false;
            this.textBox4.Enabled = false;
            this.textBox5.Enabled = false;
            this.textBox6.Enabled = false;
            this.textBox7.Enabled = false;
            this.button2.Enabled = false;
            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
            {
                //加载所有订单的数据
                string sql = "select * from [shop_table]";//sda执行的sql语句、执行的数据库连接
                var data = new SqlDataAdapter(sql, conn);//创建数据库连接
                var dtable = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                data.Fill(dtable);//往dt里填充数据。
                this.textBox1.Text = dtable.Rows[0]["shopID"].ToString();
                this.textBox2.Text = dtable.Rows[0]["shopName"].ToString();
                this.textBox3.Text = dtable.Rows[0]["registerDate"].ToString();
                this.textBox4.Text = dtable.Rows[0]["servicePhone"].ToString();
                this.textBox5.Text = dtable.Rows[0]["lpersonName"].ToString();
                this.textBox6.Text = dtable.Rows[0]["shopTell"].ToString();
                this.textBox7.Text = dtable.Rows[0]["shopAddress"].ToString();
            }
        }

        //修改按钮
        private void button1_Click(object sender, EventArgs e)
        {
            //this.textBox1.Enabled = true;
            this.textBox2.Enabled = true;
            this.textBox3.Enabled = true;
            this.textBox4.Enabled = true;
            this.textBox5.Enabled = true;
            this.textBox6.Enabled = true;
            this.textBox7.Enabled = true;
            this.button2.Enabled = true;
        }

        //保存按钮
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                {
                    String strsql2 = "update [shop_table] set [shopName]=@shopName ,[registerDate]=@registerDate ,[servicePhone]=@servicePhone ,[lpersonName]=@lpersonName ,[shopTell]=@shopTell,[shopAddress]=@shopAddress where [shopID]='" + textBox1.Text.ToString() + "'";
                    using (SqlCommand comm = new SqlCommand
                    {
                        CommandText = strsql2,
                        CommandType = CommandType.Text,
                        Connection = conn
                    })
                    {
                        comm.Parameters.AddWithValue("@shopName", textBox2.Text);
                        comm.Parameters.AddWithValue("@registerDate", textBox3.Text);
                        comm.Parameters.AddWithValue("@servicePhone", textBox4.Text);
                        comm.Parameters.AddWithValue("@lpersonName", textBox5.Text);
                        comm.Parameters.AddWithValue("@shopTell", textBox6.Text);
                        comm.Parameters.AddWithValue("@shopAddress", textBox7.Text);
                        conn.Open();

                        if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
                        {
                            MessageBox.Show("修改成功");
                            this.textBox1.Enabled = false;
                            this.textBox2.Enabled = false;
                            this.textBox3.Enabled = false;
                            this.textBox4.Enabled = false;
                            this.textBox5.Enabled = false;
                            this.textBox6.Enabled = false;
                            this.textBox7.Enabled = false;
                            this.button2.Enabled = false;
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
