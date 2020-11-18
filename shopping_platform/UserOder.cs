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
    public partial class UserOder : UserControl
    {
        public static string userID;
        public UserOder( string name)
        {
            userID = name;
            InitializeComponent();
            setColor();
            loadAllOrder();
        }

        //设置表头颜色
        void setColor()
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            dataGridView4.EnableHeadersVisualStyles = false;
            dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            dataGridView5.EnableHeadersVisualStyles = false;
            dataGridView5.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            dataGridView6.EnableHeadersVisualStyles = false;
            dataGridView6.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
            dataGridView7.EnableHeadersVisualStyles = false;
            dataGridView7.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
        }

        void loadAllOrder()
        {
            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
            {
                //tranStatus:0待付款,1待发货,2用户已申请退货/退款,3.用户已取消订单,4.已退货/退款5.已完成
                //加载所有订单的数据
                string sql = "select * from order_table where [userID]='" + userID + "'";//sda执行的sql语句、执行的数据库连接
                var da = new SqlDataAdapter(sql, conn);//创建数据库连接
                var dt = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                da.Fill(dt);//往dt里填充数据。
                dataGridView1.DataSource = dt;//把表格dt里的数据，放在dataGridView2里显示
                getOrderData(dataGridView1, tranStatus0, payMethod0);

                //0加载待付款订单
                string sql1 = $"select * from order_table where [tranStatus]=0 and [userID]='" + userID + "'";
                var data1 = new SqlDataAdapter(sql1, conn);
                var dtable1 = new DataTable();
                data1.Fill(dtable1);
                dataGridView2.DataSource = dtable1;
                getOrderData(dataGridView2, tranStatus1, payMethod1);

                //1加载带发货订单
                string sql2 = $"select * from order_table where tranStatus=1 and [userID]='" + userID + "'";
                var data2 = new SqlDataAdapter(sql2, conn);
                var dtable2 = new DataTable();
                data2.Fill(dtable2);
                dataGridView3.DataSource = dtable2;
                getOrderData(dataGridView3, tranStatus2, payMethod2);

                //2加载用户已申请退货/退款订单
                string sql3 = $"select * from order_table where tranStatus=2 and [userID]='" + userID + "'";
                var data3 = new SqlDataAdapter(sql3, conn);
                var dtable3 = new DataTable();
                data3.Fill(dtable3);
                dataGridView4.DataSource = dtable3;
                getOrderData(dataGridView4, tranStatus3, payMethod3);

                //3加载用户已取消
                string sql4 = $"select * from order_table where tranStatus=3 and [userID]='" + userID + "'";
                var data4 = new SqlDataAdapter(sql4, conn);
                var dtable4 = new DataTable();
                data4.Fill(dtable4);
                dataGridView5.DataSource = dtable4;
                getOrderData(dataGridView5, tranStatus4, payMethod4);

                //4加载已退货/退款订单
                string sql5 = $"select * from order_table where tranStatus=4 and [userID]='" + userID + "'";
                var data5 = new SqlDataAdapter(sql5, conn);
                var dtable5 = new DataTable();
                data5.Fill(dtable5);
                dataGridView6.DataSource = dtable5;
                getOrderData(dataGridView6, tranStatus5, payMethod5);

                //5加载已完成交易的订单
                string sql6 = $"select * from order_table where tranStatus=5 and [userID]='" + userID + "'";
                var data6 = new SqlDataAdapter(sql6, conn);
                var dtable6 = new DataTable();
                data6.Fill(dtable6);
                dataGridView7.DataSource = dtable6;
                getOrderData(dataGridView7, tranStatus6, payMethod6);
            }
        }
        //根据数据表的数值显示付款方式和交易状态
        void getOrderData(DataGridView dataGridView, DataGridViewTextBoxColumn textBoxColumn1, DataGridViewTextBoxColumn textBoxColumn2)
        {
            string tempT = textBoxColumn1.Name.ToString();
            string tempP = textBoxColumn2.Name.ToString();
            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                int tempTrans = int.Parse(item.Cells[tempT].Value.ToString());
                int tempPay = int.Parse(item.Cells[tempP].Value.ToString());
                switch (tempTrans)
                {
                    case 0:
                        item.Cells[tempT].Value = "待付款";
                        break;
                    case 1:
                        item.Cells[tempT].Value = "待发货";
                        break;
                    case 2:
                        item.Cells[tempT].Value = "退货/退款中";
                        break;
                    case 3:
                        item.Cells[tempT].Value = "已取消";
                        break;
                    case 4:
                        item.Cells[tempT].Value = "已退货/退款";
                        break;
                    case 5:
                        item.Cells[tempT].Value = "已完成";
                        break;
                    default:
                        item.Cells[tempT].Value = "交易异常";
                        break;
                }
                switch (tempPay)
                {
                    case 0:
                        item.Cells[tempP].Value = "线上付款";
                        break;
                    case 1:
                        item.Cells[tempP].Value = "货到付款";
                        break;
                    default:
                        item.Cells[tempP].Value = "数据异常 ";
                        break;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
