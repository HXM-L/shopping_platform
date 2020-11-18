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
    public partial class UserHome : Form
    {
        public static string userID = "";
        public UserHome(string name,string node)
        {
            InitializeComponent();
            userID = name;
            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
            {
                //加载所有商品的数据
                string sql = "select * from [user_table] where [userID]='" + userID + "'";//sda执行的sql语句、执行的数据库连接
                var WarEData = new SqlDataAdapter(sql, conn);//创建数据库连接
                var WareTable = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                WarEData.Fill(WareTable);//往dt里填充数据。
                this.label1.Text = "Hi,"+WareTable.Rows[0]["userName"].ToString() + "!";
            }
           
            //判断显示那一个页面
            switch (node)
            {
                case "0":
                    this.treeView1.SelectedNode = this.treeView1.Nodes[0];
                    break;
                case "1":
                    this.treeView1.SelectedNode = this.treeView1.Nodes[1];
                    break;
                case "2":
                    this.treeView1.SelectedNode = this.treeView1.Nodes[2];
                    break;
                case "3":
                    this.treeView1.SelectedNode = this.treeView1.Nodes[3];
                    break;
                default:
                    MessageBox.Show("出错了!!!!!!", "ERROR");
                    break;

            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string name = e.Node.Text.ToString();

            switch (name)
            {
                case "个人信息":
                    panel1.Controls.Clear();
                    PInformation pInformation = new PInformation(userID);
                    panel1.Controls.Add(pInformation);
                    pInformation.Dock = DockStyle.Fill;
                    pInformation.Show();
                    break;
                case "我的订单":
                    panel1.Controls.Clear();
                    UserOder userOder = new UserOder(userID);
                    panel1.Controls.Add(userOder);
                    userOder.Dock = DockStyle.Fill;
                    userOder.Show();
                    break;
                case "购物车":
                    panel1.Controls.Clear();
                    Shopping_cart shopping_Cart = new Shopping_cart();
                    panel1.Controls.Add(shopping_Cart);
                    shopping_Cart.Dock = DockStyle.Fill;
                    shopping_Cart.Show();
                    break;
                case "收藏夹":
                    panel1.Controls.Clear();
                    UserFavorite userFavorite = new UserFavorite();
                    panel1.Controls.Add(userFavorite);
                    userFavorite.Dock = DockStyle.Fill;
                    userFavorite.Show();
                    break;
                case "评价晒单":
                    panel1.Controls.Clear();
                    Comment_Dryinglist comment_Dryinglist = new Comment_Dryinglist();
                    panel1.Controls.Add(comment_Dryinglist);
                    comment_Dryinglist.Dock = DockStyle.Fill;
                    comment_Dryinglist.Show();
                    break;
                case "退款维权":
                    panel1.Controls.Clear();
                    UserRefund userRefund = new UserRefund(userID);
                    panel1.Controls.Add(userRefund);
                    userRefund.Dock = DockStyle.Fill;
                    userRefund.Show();
                    break;
                case "账号安全":
                    panel1.Controls.Clear();
                    UserAccount_Security userAccount_Security = new UserAccount_Security();
                    panel1.Controls.Add(userAccount_Security);
                    userAccount_Security.Dock = DockStyle.Fill;
                    userAccount_Security.Show();
                    break;
                case "信息修改":
                    panel1.Controls.Clear();
                    ModifyInformation modify = new ModifyInformation();
                    modify.Parent = panel1;
                    modify.Dock = DockStyle.Fill;
                    modify.Show();
                    break;
                default:
                    MessageBox.Show("出错了!!!!!!", "ERROR");
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void 退出登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //login login = new login();
            this.Dispose();
            //login.ShowDialog();
        }
    }
}
