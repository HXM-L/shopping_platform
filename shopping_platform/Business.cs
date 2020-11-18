using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace shopping_platform
{
    public partial class Business : Form
    {
        public Business()
        {
            InitializeComponent();
            this.trMenu.SelectedNode = this.trMenu.Nodes[0]; //首次加载选中第一个节点
        }

        
        private void trMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //trMenu.SelectedNode = trMenu.Nodes[0];
            string name = e.Node.Text.ToString();

            switch (name)
            {
                case "首页":
                    pnlCentral.Controls.Clear();
                    BHome zhuye = new BHome();
                    zhuye.Parent = pnlCentral;
                    zhuye.Dock = DockStyle.Fill;
                    zhuye.Show();
                    break;
                case "订单管理":
                    pnlCentral.Controls.Clear();
                    OrderManagement zhu1 = new OrderManagement();
                    zhu1.Parent = pnlCentral;
                    zhu1.Dock = DockStyle.Fill;
                    zhu1.Show();
                    break;
                case "商品管理":
                    pnlCentral.Controls.Clear();
                    WaresManage wares = new WaresManage();
                    wares.Parent = pnlCentral;
                    wares.Dock = DockStyle.Fill;
                    wares.Show();
                    break;
                case "进货管理":
                    pnlCentral.Controls.Clear();
                    PurchaseManage purchase = new PurchaseManage();
                    purchase.Parent = pnlCentral;
                    purchase.Dock = DockStyle.Fill;
                    purchase.Show();
                    break;
                case "库存管理":
                    pnlCentral.Controls.Clear();
                    StockManage stock = new StockManage();
                    stock.Parent = pnlCentral;
                    stock.Dock = DockStyle.Fill;
                    stock.Show();
                    break;
                case "销售管理":
                    pnlCentral.Controls.Clear();
                    SaleManage sale = new SaleManage();
                    sale.Parent = pnlCentral;
                    sale.Dock = DockStyle.Fill;
                    sale.Show();
                    break;
                case "业绩管理":
                    pnlCentral.Controls.Clear();
                    AchievementManage achievement = new AchievementManage();
                    pnlCentral.Controls.Add(achievement);
                    //achievement.Parent = pnlCentral;
                    achievement.Dock = DockStyle.Fill;
                    achievement.Show();
                    break;
                case "信息修改":
                    pnlCentral.Controls.Clear();
                    ModifyInformation modify = new ModifyInformation();
                    modify.Parent = pnlCentral;
                    modify.Dock = DockStyle.Fill;
                    modify.Show();
                    break;
                case "退出登录":
                    login login = new login();
                    this.Dispose();
                    login.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private void Business_Load(object sender, EventArgs e)
        {
            this.label3.Text= DateTime.Now.ToString("yyyy年MM月dd日")+" "+ DateTime.Now.ToString("dddd");
        }
    }
}
