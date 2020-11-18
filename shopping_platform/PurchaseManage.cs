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
    public partial class PurchaseManage : UserControl
    {
        public PurchaseManage()
        {
            InitializeComponent();
            setColor();
            loadPurch();
        }
        //设置表头颜色
        void setColor()
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
        }

        //加载数据
        void loadPurch()
        {
            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
            {
                //tranStatus:0待付款,1待发货,2用户已申请退货/退款,3.用户已取消订单,4.已退货/退款5.已完成
                //加载所有订单的数据
                string sql = "select * from purchase_detail_table";//sda执行的sql语句、执行的数据库连接
                var da = new SqlDataAdapter(sql, conn);//创建数据库连接
                var dt = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                da.Fill(dt);//往dt里填充数据。
                dataGridView1.DataSource = dt;//把表格dt里的数据，放在dataGridView2里显示
            }
        }
        //添加进货单
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            purchAdd purchAdd = new purchAdd();
            purchAdd.ShowDialog();
            loadPurch();
        }

        //修改进货单
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null)
            {
                MessageBox.Show("请选择要修改记录！");
                return;
            }
            else
            {
                purchModify purchModify = new purchModify(dataGridView1.SelectedRows);
                purchModify.ShowDialog();
                loadPurch();
            }
        }

        //删除一行商品信息
        void deleteWareRow(DataGridViewSelectedRowCollection dataGridViewRow, DataGridViewTextBoxColumn textBoxColumn1, DataGridViewTextBoxColumn textBoxColumn2)
        {
            string tempID = textBoxColumn1.Name.ToString();
            string tempPID = textBoxColumn2.Name.ToString();
            if (MessageBox.Show($"确定要删除商品【{dataGridViewRow[0].Cells[tempID].Value}】的进货信息吗?", "删除确认提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                {
                    using (SqlCommand cmd = new SqlCommand($"delete  from purchase_detail_table where comID='{dataGridViewRow[0].Cells[tempID].Value}' and purchID='{dataGridViewRow[0].Cells[tempPID].Value}'", conn))
                    {
                        conn.Open();
                        if (Convert.ToInt32(cmd.ExecuteNonQuery()) > 0)
                        {
                            MessageBox.Show("删除成功");
                            loadPurch();
                        }
                        else
                        {
                            MessageBox.Show("删除失败！");
                        }
                    }
                }
            }
        }
        //删除一条进货单
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            deleteWareRow(dataGridView1.SelectedRows, comID, purchID);
        }

        //刷新进货单
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            loadPurch();
        }
    }
}
