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
    public partial class WareShoes : UserControl
    {
        public WareShoes()
        {
            InitializeComponent();
            getWareData();
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

                //Application.StartupPath: G:\Code-Practice\curriculum_design\C#\shopping_platform\shopping_platform\bin\Release
                //获取图片
                this.pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\WareListImg\\child1\\001.png");
                this.pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\WareListImg\\child1\\002.png");
                this.pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\WareListImg\\child1\\003.png");
                this.pictureBox4.Image = Image.FromFile(Application.StartupPath + "\\WareListImg\\child1\\004.png");
                this.pictureBox5.Image = Image.FromFile(Application.StartupPath + "\\WareListImg\\child1\\005.png");
                this.pictureBox6.Image = Image.FromFile(Application.StartupPath + "\\WareListImg\\child1\\006.png");
                this.pictureBox7.Image = Image.FromFile(Application.StartupPath + "\\WareListImg\\child1\\007.png");
                this.pictureBox8.Image = Image.FromFile(Application.StartupPath + "\\WareListImg\\child1\\008.png");
                this.pictureBox9.Image = Image.FromFile(Application.StartupPath + "\\WareListImg\\child1\\009.png");
                this.pictureBox10.Image = Image.FromFile(Application.StartupPath + "\\WareListImg\\child1\\010.png");

                //获取商品简介
                this.label1.Text = "雪地靴女2020年新款秋冬季女鞋短筒女靴子保暖棉鞋加厚加绒面包鞋";
                this.label4.Text = "英伦粗跟高跟马丁靴女2020秋冬新款厚底防水台加绒系带中筒靴单靴";
                this.label6.Text = "小短靴女2020新款百搭网红小码33码秋高跟鞋细跟马丁靴女冬季女鞋";
                this.label8.Text = "安踏官网旗舰运动鞋男鞋2020年冬季新款皮面男士鞋子休闲鞋跑步鞋";
                this.label10.Text = "花花公子男鞋秋冬季2020年新款韩版潮流中帮帆布高帮百搭休闲潮鞋";
                this.label12.Text = "短靴女2020年新款秋冬季加绒加厚百搭磨砂皮粗跟短筒靴高跟鞋靴子";
                this.label14.Text = "香港潮牌赵丽颖明星同款真皮小白鞋女内增高夏季透气学生百搭板鞋";
                this.label16.Text = "冬季加绒加厚保暖雪地靴男防水高帮男鞋潮流运动冬天高邦东北棉鞋";
                this.label18.Text = "雪地靴男冬季保暖加绒加厚棉鞋高帮防水防滑男士抗寒东北大码棉靴";
                this.label20.Text = "高帮鞋女内增高小白鞋女2020秋季新款百搭拉链短靴厚底休闲马丁靴";

                //获取商品价格
                this.label2.Text = "￥" + "45.80";
                this.label3.Text = "￥" + "255.95";
                this.label5.Text = "￥" + "58.88";
                this.label7.Text = "￥" + "105.24";
                this.label9.Text = "￥" + "650.00";
                this.label11.Text = "￥" + "415.23";
                this.label13.Text = "￥" + "123.45";
                this.label15.Text = "￥" + "55.27";
                this.label17.Text = "￥" + "66.58";
                this.label19.Text = "￥" + "88.99";

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
    }
}
