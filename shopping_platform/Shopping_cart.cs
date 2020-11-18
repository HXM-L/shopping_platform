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
using System.Collections;

namespace shopping_platform
{
    public partial class Shopping_cart : UserControl
    {
        public Shopping_cart()
        {
            InitializeComponent();
            //this.listView1.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
            //this.listView1.FullRowSelect = true;
            //CheckBox checkBox = new CheckBox();
            //checkBox.Text = "全选";
            //this.listView1.Controls.Add(checkBox); //添加选择控件

            getShopCart();
            flowLayoutPanel1.AutoScroll = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.HorizontalScroll.Maximum = 0; // 把水平滚动范围设成0就看不到水平滚动条了
            flowLayoutPanel1.AutoScroll = true; // 注意启用滚动的顺序，应是完成设置的最后一条语句

        }

        //加载购物车
        void getShopCart()
        {
            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
            {
                string imaurl, information, price, comID;
                int splus;
                //加载所有购物车的数据
                string sql = "select * from [Shopping_Cart]";//sda执行的sql语句、执行的数据库连接
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
                    splus = int.Parse(WareTable.Rows[i]["comSurplus"].ToString()); //数量
                    //cartList cartList = (cartList)flowLayoutPanel1.Controls["cartList" + i.ToString()];
                    cartList cartList = new cartList(comID, imaurl, information, price, splus);
                    cartList.OnCheckedChanged += CartList_OnCheckedChanged;
                    cartList.Name = "cartList" + i.ToString();
                    flowLayoutPanel1.Controls.Add(cartList);
                }
            }
        }

        //计算勾选商品总价
        private void CartList_OnCheckedChanged(object sender, EventArgs e)
        {
            double total = 0;
            foreach (var ctl in flowLayoutPanel1.Controls)
            {
                if (ctl is cartList clst && clst.IsChecked)
                {
                    total += Convert.ToDouble(clst.Wprice) * clst.Spuls;
                }
            }
            label6.Text = $"总价:{total:F2}元";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.listView1.FullRowSelect = !this.listView1.FullRowSelect;
        }

        //实现全选
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var ctl in flowLayoutPanel1.Controls)
            {
                if (ctl is cartList clst) 
                    clst.IsChecked = checkBox1.Checked;
            }

        }

        //购买
        private void button1_Click(object sender, EventArgs e)
        {
            double sum = 0.0;
            double temprice;
            List<string> tempID = new List<string>();
            Dictionary<string, int> tempSplus = new Dictionary<string, int>();
            foreach (var ctl in flowLayoutPanel1.Controls)
            {
                if (ctl is cartList clst)
                    if (clst.IsChecked == true)
                    {
                        temprice = float.Parse(clst.Wprice);
                        tempID.Add(clst.COMID);
                        sum += clst.Spuls * temprice;
                        tempSplus.Add(clst.tempName, clst.Spuls);
                    }
            }
            UserPurch userPurch = new UserPurch(tempID, sum, tempSplus);
            userPurch.ShowDialog();
            flowLayoutPanel1.Controls.Clear();
            getShopCart();
        }
    }
}
