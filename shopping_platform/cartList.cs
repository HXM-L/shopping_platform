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
    public partial class cartList : UserControl
    {
        public string Wprice { get; set; } //商品单价
        public int tempsplus;  //商品数量
        public string tempName { get; set; } //商品名称
        public string COMID; //商品编号
        public event EventHandler OnCheckedChanged;
        public int Spuls
        {
            get { return int.Parse(this.numericUpDown1.Value.ToString()); }
            set { this.numericUpDown1.Value = value; }

        }
        public string wName
        {
            get { return tempName; }
        }
        public bool IsChecked   //商品是否被选中
        {
            get { return this.checkBox1.Checked; }
            set { this.checkBox1.Checked = value; }
        }

        //初始化商品信息,图片路径,简介,单价,数量等
        public cartList(string comID, string imgUrl, string information, string price, int spuls)
        {
            InitializeComponent();
            COMID = comID;
            Wprice = price;
            this.pictureBox1.Image = Image.FromFile(Application.StartupPath + imgUrl);
            this.label1.Text = information;
            this.label2.Text = "￥" + price;
            this.numericUpDown1.Value = spuls;
            this.label3.Text = "￥" + Convert.ToDecimal((float.Parse(price) * spuls).ToString()).ToString("F2");

            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
            {
                //加载所有购物车的数据
                string sql = $"select * from [Shopping_Cart] where commID={comID}";//sda执行的sql语句、执行的数据库连接
                var WarEData = new SqlDataAdapter(sql, conn);//创建数据库连接
                var WareTable = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                WarEData.Fill(WareTable);//往dt里填充数据。
                tempName = WareTable.Rows[0]["comName"].ToString(); //商品ID
            }
        }

        //删除
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"是否要删除商品吗?", "删除确认提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                    {
                        using (SqlCommand cmd = new SqlCommand($"delete  from [Shopping_Cart] where [commID]='{this.COMID}'", conn))
                        {
                            conn.Open();
                            if (Convert.ToInt32(cmd.ExecuteNonQuery()) > 0)
                            {
                                MessageBox.Show("删除成功");
                            }
                            else
                            {
                                MessageBox.Show("删除失败！");
                            }
                        }
                    }
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("数据库连接错误，错误源是" + sqlex);
                }
                this.checkBox1.Checked = false;
                this.Dispose();
            }

        }


        //商品数量
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            tempsplus = Int32.Parse(this.numericUpDown1.Value.ToString());
            this.label3.Text = "￥" + Convert.ToDecimal((float.Parse(Wprice) * tempsplus).ToString()).ToString("F2");

            OnCheckedChanged?.Invoke(sender, e);
        }
        //选择状态改变
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            OnCheckedChanged?.Invoke(sender, e);
            //if (OnCheckedChanged != null) OnCheckedChanged(sender, e);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
