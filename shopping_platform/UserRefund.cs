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
    public partial class UserRefund : UserControl
    {
        public static string userID;
        public UserRefund(string name)
        {
            userID = name;
            InitializeComponent();
            setColor();
            loadAllOrder();
        }

        void setColor()
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
        }

        void loadAllOrder()
        {
            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
            {
                //tranStatus:0待付款,1待发货,2用户已申请退货/退款,3.用户已取消订单,4.已退货/退款5.已完成
                //加载所有订单的数据
                string sql = "select * from order_table where  [userID]='" + userID + "' and ([tranStatus]=2 or [tranStatus]=4)";//sda执行的sql语句、执行的数据库连接
                var da = new SqlDataAdapter(sql, conn);//创建数据库连接
                var dt = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                da.Fill(dt);//往dt里填充数据。
                dataGridView1.DataSource = dt;//把表格dt里的数据，放在dataGridView2里显示
                getOrderData(dataGridView1, tranStatus0, payMethod0);
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
