using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shopping_platform
{
    public partial class Home : Form
    {
        public static string userID="";
        public Home(string name)
        {
            InitializeComponent();
            userID = name;
            //显示选显卡1的内容(每日推荐)
            WareList wareList1 = new WareList();
            this.tabPage1.Controls.Add(wareList1);
            wareList1.Show();

            WareShoes wareShoes2 = new WareShoes();
            this.tabPage2.Controls.Add(wareShoes2);
            wareShoes2.Show();

            WareList wareList3 = new WareList();
            this.tabPage3.Controls.Add(wareList3);
            wareList3.Show();

            WareShoes wareShoes4 = new WareShoes();
            this.tabPage4.Controls.Add(wareShoes4);
            wareShoes4.Show();

            WareList wareList5 = new WareList();
            this.tabPage5.Controls.Add(wareList5);
            wareList5.Show();

            WareShoes wareShoes6 = new WareShoes();
            this.tabPage6.Controls.Add(wareShoes6);
            wareShoes6.Show();

            WareList wareList7 = new WareList();
            this.tabPage7.Controls.Add(wareList7);
            wareList7.Show();

            WareShoes wareShoes8 = new WareShoes();
            this.tabPage8.Controls.Add(wareShoes8);
            wareShoes8.Show();

            WareList wareList9 = new WareList();
            this.tabPage9.Controls.Add(wareList9);
            wareList9.Show();

        }

        private void Home_Load(object sender, EventArgs e)
        {
            this.Focus();
        }

        //搜索按钮
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //进入个人中心
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserHome userHome = new UserHome(userID,"0");
            userHome.ShowDialog();
            this.Show();

        }

        //退出登录
        private void 退出登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login login = new login();
            this.Dispose();
            login.ShowDialog();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void 我的购物车ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserHome userHome = new UserHome(userID,"2");
            userHome.ShowDialog();
            this.Show();
        }

        private void 我的订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserHome userHome = new UserHome(userID, "1");
            userHome.ShowDialog();
            this.Show();
        }

        private void 我的收藏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserHome userHome = new UserHome(userID, "3");
            userHome.ShowDialog();
            this.Show();
        }
    }
}
