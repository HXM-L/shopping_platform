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
    public partial class StockManage : UserControl
    {
        public StockManage()
        {
            InitializeComponent();
            setColor();
            loadStock();
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
        }
        //加载数据
        void loadStock()
        {
            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
            {
                //tranStatus:0待付款,1待发货,2用户已申请退货/退款,3.用户已取消订单,4.已退货/退款5.已完成
                //加载所有订单的数据
                string sql = "select * from [stock_table]";//sda执行的sql语句、执行的数据库连接
                var da = new SqlDataAdapter(sql, conn);//创建数据库连接
                var dt = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                da.Fill(dt);//往dt里填充数据。
                dataGridView1.DataSource = dt;//把表格dt里的数据，放在dataGridView2里显示
                getStockData(dataGridView1, stockFlag0);

                string sql1 = "select * from [stock_table] where [stockFlag]=0";//sda执行的sql语句、执行的数据库连接
                var da1 = new SqlDataAdapter(sql1, conn);//创建数据库连接
                var dt1 = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                da1.Fill(dt1);//往dt里填充数据。
                dataGridView2.DataSource = dt1;//把表格dt里的数据，放在dataGridView2里显示
                getStockData(dataGridView2, stockFlag1);

                string sql2 = "select * from [stock_table] where [stockFlag]=1";//sda执行的sql语句、执行的数据库连接
                var da2 = new SqlDataAdapter(sql2, conn);//创建数据库连接
                var dt2 = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                da2.Fill(dt2);//往dt里填充数据。
                dataGridView3.DataSource = dt2;//把表格dt里的数据，放在dataGridView2里显示
                getStockData(dataGridView3, stockFlag2);

                string sql3 = "select * from [stock_table] where [stockFlag]=2";//sda执行的sql语句、执行的数据库连接
                var da3 = new SqlDataAdapter(sql3, conn);//创建数据库连接
                var dt3 = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                da3.Fill(dt3);//往dt里填充数据。
                dataGridView4.DataSource = dt3;//把表格dt里的数据，放在dataGridView2里显示
                getStockData(dataGridView4, stockFlag3);
            }
        }
        //库存状态的转换
        void getStockData(DataGridView dataGridView, DataGridViewTextBoxColumn textBoxColumn1)
        {
            string tempStau = textBoxColumn1.Name.ToString();
            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                int tempTrans = int.Parse(item.Cells[tempStau].Value.ToString());
                switch (tempTrans)
                {
                    case 0:
                        item.Cells[tempStau].Value = "待入库";
                        break;
                    case 1:
                        item.Cells[tempStau].Value = "已入库";
                        break;
                    case 2:
                        item.Cells[tempStau].Value = "已出库";
                        break;
                    default:
                        item.Cells[tempStau].Value = "数据异常";
                        break;
                }
            }
        }
        //添加数据
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            stockAdd stockAdd = new stockAdd();
            stockAdd.ShowDialog();
            loadStock();
        }
        //添加数据
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            stockAdd stockAdd = new stockAdd();
            stockAdd.ShowDialog();
            loadStock();
        }
        //添加数据
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            stockAdd stockAdd = new stockAdd();
            stockAdd.ShowDialog();
            loadStock();
        }
        //添加数据
        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            stockAdd stockAdd = new stockAdd();
            stockAdd.ShowDialog();
            loadStock();
        }

        //修改数据
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null)
            {
                MessageBox.Show("请选择要修改记录！");
                return;
            }
            else
            {
                stockModify stockModify = new stockModify(dataGridView1.SelectedRows);
                stockModify.ShowDialog();
                loadStock();
            }
        }

        //删除一行库存信息
        void deleteStockRow(DataGridViewSelectedRowCollection dataGridViewRow, DataGridViewTextBoxColumn textBoxColumn1, DataGridViewTextBoxColumn textBoxColumn2)
        {
            string tempID = textBoxColumn1.Name.ToString();
            string tempCID = textBoxColumn2.Name.ToString();
            if (MessageBox.Show($"确定要删除商品【{dataGridViewRow[0].Cells[tempCID].Value}】的库存信息吗?", "删除确认提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                {
                    using (SqlCommand cmd = new SqlCommand($"delete  from [stock_table] where [stockID]='{dataGridViewRow[0].Cells[tempID].Value}' and comID='{dataGridViewRow[0].Cells[tempCID].Value}'", conn))
                    {
                        conn.Open();
                        if (Convert.ToInt32(cmd.ExecuteNonQuery()) > 0)
                        {
                            MessageBox.Show("删除成功");
                            loadStock();
                        }
                        else
                        {
                            MessageBox.Show("删除失败！");
                        }
                    }
                }
            }
        }
        //删除一行库存信息
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            deleteStockRow(dataGridView1.SelectedRows, stockID0, comID0);
        }

        //刷新
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            loadStock();
        }

        //修改数据
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null)
            {
                MessageBox.Show("请选择要修改记录！");
                return;
            }
            else
            {
                stockModify stockModify = new stockModify(dataGridView2.SelectedRows);
                stockModify.ShowDialog();
                loadStock();
            }
        }
        //修改数据
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null)
            {
                MessageBox.Show("请选择要修改记录！");
                return;
            }
            else
            {
                stockModify stockModify = new stockModify(dataGridView3.SelectedRows);
                stockModify.ShowDialog();
                loadStock();
            }
        }
        //修改数据
        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null)
            {
                MessageBox.Show("请选择要修改记录！");
                return;
            }
            else
            {
                stockModify stockModify = new stockModify(dataGridView4.SelectedRows);
                stockModify.ShowDialog();
                loadStock();
            }
        }
        //删除一行库存信息/
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            deleteStockRow(dataGridView2.SelectedRows, stockID1, comID1);
        }
        //删除一行库存信息
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            deleteStockRow(dataGridView3.SelectedRows, stockID2, comID2);
        }
        //删除一行库存信息
        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            deleteStockRow(dataGridView4.SelectedRows, stockID3, comID3);
        }
    }
}
