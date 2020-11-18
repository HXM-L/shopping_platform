using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //数据库的头文件

namespace shopping_platform
{
    public partial class UFavurBox : UserControl
    {
        public string CID; //商品ID
        public UFavurBox(string comID, string imgUrl, string information, string price)
        {
            InitializeComponent();
            CID = comID;
            this.label1.Text = $"￥{price:F2}";
            this.label2.Text = information;
            this.pictureBox1.Image = Image.FromFile(Application.StartupPath + imgUrl);
        }

        //加入购物车
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(AppConst.DbPath))
                {
                    //加载商品的数据
                    string sql = "select * from [commodity_table] where [comID]='" + CID + "'";//sda执行的sql语句、执行的数据库连接
                    var WarEData = new SqlDataAdapter(sql, sqlcon);//创建数据库连接
                    var WareTable = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                    WarEData.Fill(WareTable);//往dt里填充数据。

                    string name = WareTable.Rows[0]["comName"].ToString();
                    string introduction = WareTable.Rows[0]["comIntroduction"].ToString();
                    string price = WareTable.Rows[0]["comPrice"].ToString();
                    string imgUrl = WareTable.Rows[0]["imgUrl"].ToString();
                    SqlCommand sqlcmd = new SqlCommand($"select [comSurplus] from [Shopping_Cart] where [commID]='{CID}'", sqlcon);
                    sqlcon.Open();
                    var obj = sqlcmd.ExecuteScalar();
                    //报错提示列名无效
                    if (obj == null) //还没有添加过商品
                    {
                        //MessageBox.Show("未有数据！");
                        string strsql2 = "insert into [Shopping_Cart]([commID],[comName],[comIntroduction],[comPrice],[comSurplus],[imgUrl]) values(@commID,@comName,@comIntroduction,@comPrice,@comSurplus,@imgUrl)";
                        using (SqlCommand comm = new SqlCommand
                        {
                            CommandText = strsql2,
                            CommandType = CommandType.Text,
                            Connection = sqlcon
                        })
                        {
                            comm.Parameters.AddWithValue("@commID", CID);
                            comm.Parameters.AddWithValue("@comName", name);
                            comm.Parameters.AddWithValue("@comIntroduction", introduction);
                            comm.Parameters.AddWithValue("@comPrice", price);
                            comm.Parameters.AddWithValue("@comSurplus", 1);
                            comm.Parameters.AddWithValue("@imgUrl", imgUrl);
                            //sqlcon.Open();
                            if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
                            {
                                MessageBox.Show("添加成功");
                            }
                            else
                            {
                                MessageBox.Show("添加失败！");
                            }
                        }
                    }
                    else
                    {
                        //MessageBox.Show("商品已在购物车!");
                        //加载商品的数据
                        string sql2 = "select * from [Shopping_Cart] where [commID]='" + CID + "'";//sda执行的sql语句、执行的数据库连接
                        var WarEData2 = new SqlDataAdapter(sql2, sqlcon);//创建数据库连接
                        var WareTable2 = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                        WarEData2.Fill(WareTable2);//往dt里填充数据。

                        int spuls = int.Parse(WareTable2.Rows[0]["comSurplus"].ToString());
                        string strsql2 = "update [Shopping_Cart] set [comSurplus]=@comSurplus where [commID]='" + CID + "'";
                        using (SqlCommand comm = new SqlCommand
                        {
                            CommandText = strsql2,
                            CommandType = CommandType.Text,
                            Connection = sqlcon
                        })
                        {
                            comm.Parameters.AddWithValue("@comSurplus", spuls + 1);
                            //sqlcon.Open();

                            if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
                            {
                                deleteFavour();
                                MessageBox.Show("添加购物车成功!");
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
                MessageBox.Show("数据库连接错误，错误源是" + sqlex);
            }
        }

        void deleteFavour()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                {
                    using (SqlCommand cmd = new SqlCommand($"delete  from [FavouryTable] where [commID]='{this.CID}'", conn))
                    {
                        conn.Open();
                        if (Convert.ToInt32(cmd.ExecuteNonQuery()) > 0)
                        {
                            //MessageBox.Show("删除成功");
                        }
                        else
                        {
                            //MessageBox.Show("删除失败！");
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("数据库连接错误，错误源是" + sqlex);
            }
            this.Dispose();
        }
        //移出收藏夹
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"是否要删除商品吗?", "删除确认提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deleteFavour();
                MessageBox.Show("删除成功");
            }
            
        }
    }
}
