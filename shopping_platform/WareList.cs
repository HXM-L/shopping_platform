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
    public partial class WareList : UserControl
    {
        public WareList()
        {
            InitializeComponent();
            getWareData(); //获取商品数据

           /*******************************************************************
            1.添加购物车失败!!!!
            2.如何遍历控件,给他的Text属性赋值
            3.如何循环添加控件
            4.购物车列表的显示问题,listview的item不能直接添加控件
           *********************************************************************/


        }

        void getWareData()
        {
            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
            {
                //加载所有商品的数据
                string sql = "select * from commodity_table";//sda执行的sql语句、执行的数据库连接
                var WarEData = new SqlDataAdapter(sql, conn);//创建数据库连接
                var WareTable = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                WarEData.Fill(WareTable);//往dt里填充数据。

                //Application.StartupPath: G:\Code-Practice\curriculum_design\C#\shopping_platform\shopping_platform\bin\Release\headPortrait
                //获取图片
                this.pictureBox1.Image = Image.FromFile(Application.StartupPath + WareTable.Rows[0]["imgUrl"].ToString());
                this.pictureBox2.Image = Image.FromFile(Application.StartupPath + WareTable.Rows[1]["imgUrl"].ToString());
                this.pictureBox3.Image = Image.FromFile(Application.StartupPath + WareTable.Rows[2]["imgUrl"].ToString());
                this.pictureBox4.Image = Image.FromFile(Application.StartupPath + WareTable.Rows[3]["imgUrl"].ToString());
                this.pictureBox5.Image = Image.FromFile(Application.StartupPath + WareTable.Rows[4]["imgUrl"].ToString());
                this.pictureBox6.Image = Image.FromFile(Application.StartupPath + WareTable.Rows[5]["imgUrl"].ToString());
                this.pictureBox7.Image = Image.FromFile(Application.StartupPath + WareTable.Rows[6]["imgUrl"].ToString());
                this.pictureBox8.Image = Image.FromFile(Application.StartupPath + WareTable.Rows[7]["imgUrl"].ToString());
                this.pictureBox9.Image = Image.FromFile(Application.StartupPath + WareTable.Rows[8]["imgUrl"].ToString());
                this.pictureBox10.Image = Image.FromFile(Application.StartupPath + WareTable.Rows[9]["imgUrl"].ToString());

                //获取商品简介
                this.label1.Text = WareTable.Rows[0]["comIntroduction"].ToString();
                this.label4.Text = WareTable.Rows[1]["comIntroduction"].ToString();
                this.label6.Text = WareTable.Rows[2]["comIntroduction"].ToString();
                this.label8.Text = WareTable.Rows[3]["comIntroduction"].ToString();
                this.label10.Text = WareTable.Rows[4]["comIntroduction"].ToString();
                this.label12.Text = WareTable.Rows[5]["comIntroduction"].ToString();
                this.label14.Text = WareTable.Rows[6]["comIntroduction"].ToString();
                this.label16.Text = WareTable.Rows[7]["comIntroduction"].ToString();
                this.label18.Text = WareTable.Rows[8]["comIntroduction"].ToString();
                this.label20.Text = WareTable.Rows[9]["comIntroduction"].ToString();

                //获取商品价格
                this.label2.Text = "￥" + Convert.ToDecimal(WareTable.Rows[0]["comPrice"].ToString()).ToString("F2");
                this.label3.Text = "￥" + Convert.ToDecimal(WareTable.Rows[1]["comPrice"].ToString()).ToString("F2");
                this.label5.Text = "￥" + Convert.ToDecimal(WareTable.Rows[2]["comPrice"].ToString()).ToString("F2");
                this.label7.Text = "￥" + Convert.ToDecimal(WareTable.Rows[3]["comPrice"].ToString()).ToString("F2");
                this.label9.Text = "￥" + Convert.ToDecimal(WareTable.Rows[4]["comPrice"].ToString()).ToString("F2");
                this.label11.Text = "￥" + Convert.ToDecimal(WareTable.Rows[5]["comPrice"].ToString()).ToString("F2");
                this.label13.Text = "￥" + Convert.ToDecimal(WareTable.Rows[6]["comPrice"].ToString()).ToString("F2");
                this.label15.Text = "￥" + Convert.ToDecimal(WareTable.Rows[7]["comPrice"].ToString()).ToString("F2");
                this.label17.Text = "￥" + Convert.ToDecimal(WareTable.Rows[8]["comPrice"].ToString()).ToString("F2");
                this.label19.Text = "￥" + Convert.ToDecimal(WareTable.Rows[9]["comPrice"].ToString()).ToString("F2");

                //获取商品ID
                this.toolStrip1.Text = WareTable.Rows[0]["comID"].ToString();
                this.toolStrip2.Text = WareTable.Rows[1]["comID"].ToString();
                this.toolStrip3.Text = WareTable.Rows[2]["comID"].ToString();
                this.toolStrip4.Text = WareTable.Rows[3]["comID"].ToString();
                this.toolStrip5.Text = WareTable.Rows[4]["comID"].ToString();
                this.toolStrip6.Text = WareTable.Rows[5]["comID"].ToString();
                this.toolStrip7.Text = WareTable.Rows[6]["comID"].ToString();
                this.toolStrip8.Text = WareTable.Rows[7]["comID"].ToString();
                this.toolStrip9.Text = WareTable.Rows[8]["comID"].ToString();
                this.toolStrip10.Text = WareTable.Rows[9]["comID"].ToString();
            }
        }

        //添加购物车
        void addShoppingCart(string commID)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(AppConst.DbPath))
                {
                    //加载商品的数据
                    string sql = "select * from [commodity_table] where [comID]='" + commID + "'";//sda执行的sql语句、执行的数据库连接
                    var WarEData = new SqlDataAdapter(sql, sqlcon);//创建数据库连接
                    var WareTable = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                    WarEData.Fill(WareTable);//往dt里填充数据。

                    string name = WareTable.Rows[0]["comName"].ToString();
                    string introduction = WareTable.Rows[0]["comIntroduction"].ToString();
                    string price = WareTable.Rows[0]["comPrice"].ToString();
                    string imgUrl = WareTable.Rows[0]["imgUrl"].ToString();
                    SqlCommand sqlcmd = new SqlCommand($"select [comSurplus] from [Shopping_Cart] where [commID]='{commID}'", sqlcon);
                    sqlcon.Open();
                    var obj = sqlcmd.ExecuteScalar();
                    
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
                            comm.Parameters.AddWithValue("@commID", commID);
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
                        string sql2 = "select * from [Shopping_Cart] where [commID]='" + commID + "'";//sda执行的sql语句、执行的数据库连接
                        var WarEData2 = new SqlDataAdapter(sql2, sqlcon);//创建数据库连接
                        var WareTable2 = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                        WarEData2.Fill(WareTable2);//往dt里填充数据。

                        int spuls = int.Parse(WareTable2.Rows[0]["comSurplus"].ToString());
                        string strsql2 = "update [Shopping_Cart] set [comSurplus]=@comSurplus where [commID]='" + commID + "'";
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

        //添加收藏
        void addFavour(string commID)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(AppConst.DbPath))
                {
                    //加载商品的数据
                    string sql = "select * from [commodity_table] where [comID]='" + commID + "'";//sda执行的sql语句、执行的数据库连接
                    var WarEData = new SqlDataAdapter(sql, sqlcon);//创建数据库连接
                    var WareTable = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                    WarEData.Fill(WareTable);//往dt里填充数据。

                    string name = WareTable.Rows[0]["comName"].ToString();
                    string introduction = WareTable.Rows[0]["comIntroduction"].ToString();
                    string price = WareTable.Rows[0]["comPrice"].ToString();
                    string imgUrl = WareTable.Rows[0]["imgUrl"].ToString();
                    SqlCommand sqlcmd = new SqlCommand($"select [comSurplus] from [FavouryTable] where [commID]='{commID}'", sqlcon);
                    sqlcon.Open();
                    var obj = sqlcmd.ExecuteScalar();
                    if (obj == null) //还没有添加过商品
                    {
                        //MessageBox.Show("未有数据！");
                        string strsql2 = "insert into [FavouryTable]([commID],[comName],[comIntroduction],[comPrice],[imgUrl]) values(@commID,@comName,@comIntroduction,@comPrice,@imgUrl)";
                        using (SqlCommand comm = new SqlCommand
                        {
                            CommandText = strsql2,
                            CommandType = CommandType.Text,
                            Connection = sqlcon
                        })
                        {
                            comm.Parameters.AddWithValue("@commID", commID);
                            comm.Parameters.AddWithValue("@comName", name);
                            comm.Parameters.AddWithValue("@comIntroduction", introduction);
                            comm.Parameters.AddWithValue("@comPrice", price);
                            comm.Parameters.AddWithValue("@imgUrl", imgUrl);
                            //sqlcon.Open();
                            if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
                            {
                                MessageBox.Show("收藏成功");
                            }
                            else
                            {
                                MessageBox.Show("收藏失败！");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("已收藏成功!");
                    }
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("数据库连接错误，错误源是" + sqlex);
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            addShoppingCart(toolStrip1.Text);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            addFavour(toolStrip1.Text);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            addShoppingCart(toolStrip2.Text);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            addFavour(toolStrip2.Text);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            addShoppingCart(toolStrip3.Text);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            addFavour(toolStrip3.Text);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            addShoppingCart(toolStrip4.Text);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            addFavour(toolStrip4.Text);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            addShoppingCart(toolStrip5.Text);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            addFavour(toolStrip5.Text);
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            addShoppingCart(toolStrip6.Text);
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            addFavour(toolStrip6.Text);
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            addShoppingCart(toolStrip7.Text);
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            addFavour(toolStrip7.Text);
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            addShoppingCart(toolStrip8.Text);
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            addFavour(toolStrip8.Text);
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            addShoppingCart(toolStrip9.Text);
        }

        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            addFavour(toolStrip9.Text);
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            addShoppingCart(toolStrip10.Text);
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            addFavour(toolStrip10.Text);
        }
    }
}
