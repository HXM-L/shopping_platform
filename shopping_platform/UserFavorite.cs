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
    public partial class UserFavorite : UserControl
    {
        public UserFavorite()
        {
            InitializeComponent();
            flowLayoutPanel1.AutoScroll = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.HorizontalScroll.Maximum = 0; // 把水平滚动范围设成0就看不到水平滚动条了
            flowLayoutPanel1.AutoScroll = true; // 注意启用滚动的顺序，应是完成设置的最后一条语句
            getFavour();
        }

        void getFavour()
        {
            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
            {
                string imaurl, information, price, comID;
                //加载所有购物车的数据
                string sql = "select * from [FavouryTable]";//sda执行的sql语句、执行的数据库连接
                var WarEData = new SqlDataAdapter(sql, conn);//创建数据库连接
                var WareTable = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                WarEData.Fill(WareTable);//往dt里填充数据。

                //cartList[] cartLists = new cartList[WareTable.Rows.Count];
                //生成自定义控件
                for (int i = 0; i < WareTable.Rows.Count; i++)
                {
                    comID = WareTable.Rows[i]["commID"].ToString(); //商品ID
                    imaurl = WareTable.Rows[i]["imgUrl"].ToString();  //图片路径
                    information = WareTable.Rows[i]["comIntroduction"].ToString(); //简介
                    price = WareTable.Rows[i]["comPrice"].ToString();
                    price = Convert.ToDecimal(float.Parse(price).ToString()).ToString("F2"); //价钱
                    UFavurBox uFavurBox = new UFavurBox(comID, imaurl, information, price);
                    uFavurBox.Name = "uFavurBox" + i.ToString();
                    flowLayoutPanel1.Controls.Add(uFavurBox);
                }
            }
        }

        //添加购物车
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        //移出收藏夹
        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
