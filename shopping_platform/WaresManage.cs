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
    public partial class WaresManage : UserControl
    {
        public WaresManage()
        {
            InitializeComponent();
            setColor();
            loadAllWares();
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
        }
        //加载数据
        void loadAllWares()
        {
            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
            {
                //加载所有商品的数据
                string sql = "select * from commodity_table";//sda执行的sql语句、执行的数据库连接
                var da = new SqlDataAdapter(sql, conn);//创建数据库连接
                var dt = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                da.Fill(dt);//往dt里填充数据。
                dataGridView1.DataSource = dt;//把表格dt里的数据，放在dataGridView2里显示
                getWaresData(dataGridView1, saleStatu0, comType0);

                //0加载待上架商品
                string sql1 = $"select * from commodity_table where saleStatu=0";
                var data1 = new SqlDataAdapter(sql1, conn);
                var dtable1 = new DataTable();
                data1.Fill(dtable1);
                dataGridView2.DataSource = dtable1;
                getWaresData(dataGridView2, saleStatu1, comType1);

                //1加载已发售商品
                string sql2 = $"select * from commodity_table where saleStatu=1";
                var data2 = new SqlDataAdapter(sql2, conn);
                var dtable2 = new DataTable();
                data2.Fill(dtable2);
                dataGridView3.DataSource = dtable2;
                getWaresData(dataGridView3, saleStatu2, comType2);

                //2加载已售罄商品
                string sql3 = $"select * from commodity_table where saleStatu=2";
                var data3 = new SqlDataAdapter(sql3, conn);
                var dtable3 = new DataTable();
                data3.Fill(dtable3);
                dataGridView4.DataSource = dtable3;
                getWaresData(dataGridView4, saleStatu3, comType3);

                //3加载已售罄商品
                string sql4 = $"select * from commodity_table where saleStatu=3";
                var data4 = new SqlDataAdapter(sql4, conn);
                var dtable4 = new DataTable();
                data4.Fill(dtable4);
                dataGridView5.DataSource = dtable4;
                getWaresData(dataGridView5, saleStatu4, comType4);

            }
        }

        //根据数据表的数值商品售卖状态
        void getWaresData(DataGridView dataGridView, DataGridViewTextBoxColumn textBoxColumn1, DataGridViewTextBoxColumn textBoxColumn2)
        {
            string tempStau = textBoxColumn1.Name.ToString();
            string tempType = textBoxColumn2.Name.ToString();
            foreach (DataGridViewRow item in dataGridView.Rows)
            {
                int tempTrans = int.Parse(item.Cells[tempStau].Value.ToString());
                int tempTy = int.Parse(item.Cells[tempType].Value.ToString());
                switch (tempTrans)
                {
                    case 0:
                        item.Cells[tempStau].Value = "待上架";
                        break;
                    case 1:
                        item.Cells[tempStau].Value = "已发售";
                        break;
                    case 2:
                        item.Cells[tempStau].Value = "已售罄";
                        break;
                    case 3:
                        item.Cells[tempStau].Value = "已下架";
                        break;
                    default:
                        item.Cells[tempStau].Value = "数据异常";
                        break;
                }
                switch (tempTy)
                {
                    case 0:
                        item.Cells[tempType].Value = "衣物";
                        break;
                    case 1:
                        item.Cells[tempType].Value = "电子产品";
                        break;
                    case 2:
                        item.Cells[tempType].Value = "家电";
                        break;
                    case 3:
                        item.Cells[tempType].Value = "蔬果";
                        break;
                    case 4:
                        item.Cells[tempType].Value = "生活百货";
                        break;
                    default:
                        item.Cells[tempType].Value = "数据异常";
                        break;
                }
            }
        }
        //添加一行商品信息
        private void toolStripButton29_Click(object sender, EventArgs e)
        {
            wareAdd oraderAdd = new wareAdd();
            oraderAdd.ShowDialog();
            loadAllWares();
        }
        //添加一行商品信息
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            wareAdd oraderAdd = new wareAdd();
            oraderAdd.ShowDialog();
            loadAllWares();
        }
        //添加一行商品信息
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            wareAdd oraderAdd = new wareAdd();
            oraderAdd.ShowDialog();
            loadAllWares();
        }
        //添加一行商品信息
        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            wareModify oraderAdd = new wareModify(dataGridView4.SelectedRows);
            oraderAdd.ShowDialog();
            loadAllWares();
        }
        //添加一行商品信息
        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            wareAdd oraderAdd = new wareAdd();
            oraderAdd.ShowDialog();
            loadAllWares();
        }
        //修改商品信息
        private void toolStripButton18_Click(object sender, EventArgs e)
        {
            wareModify oraderAdd = new wareModify(dataGridView5.SelectedRows);
            oraderAdd.ShowDialog();
            loadAllWares();
        }

        //修改商品信息
        private void toolStripButton30_Click(object sender, EventArgs e)
        {
            wareModify oraderAdd = new wareModify(dataGridView1.SelectedRows);
            oraderAdd.ShowDialog();
            loadAllWares();
        }
        //修改商品信息
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            wareModify oraderAdd = new wareModify(dataGridView2.SelectedRows);
            oraderAdd.ShowDialog();
            loadAllWares();
        }
        //修改商品信息
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            wareModify oraderAdd = new wareModify(dataGridView3.SelectedRows);
            oraderAdd.ShowDialog();
            loadAllWares();
        }

        //删除一行商品信息
        void deleteWareRow(DataGridViewSelectedRowCollection dataGridViewRow, DataGridViewTextBoxColumn textBoxColumn1)
        {
            string tempID = textBoxColumn1.Name.ToString();
            if (MessageBox.Show($"确定要删除【{dataGridViewRow[0].Cells[tempID].Value}】吗?", "删除确认提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                {
                    using (SqlCommand cmd = new SqlCommand($"delete  from commodity_table where comID={dataGridViewRow[0].Cells[tempID].Value}", conn))
                    {
                        conn.Open();
                        if (Convert.ToInt32(cmd.ExecuteNonQuery()) > 0)
                        {
                            MessageBox.Show("删除成功");
                            loadAllWares();
                        }
                        else
                        {
                            MessageBox.Show("删除失败！");
                        }
                    }
                }
            }
        }
        //删除一行商品信息
        private void toolStripButton31_Click(object sender, EventArgs e)
        {
            deleteWareRow(dataGridView1.SelectedRows, comID0);
        }
        //删除一行商品信息
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            deleteWareRow(dataGridView2.SelectedRows, comID1);
        }
        //删除一行商品信息
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            deleteWareRow(dataGridView3.SelectedRows, comID2);
        }
        //删除一行商品信息
        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            deleteWareRow(dataGridView4.SelectedRows, comID3);
        }
        //删除一行商品信息
        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            deleteWareRow(dataGridView5.SelectedRows, comID4);
        }
        //刷新数据
        private void toolStripButton32_Click(object sender, EventArgs e)
        {
            loadAllWares();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            loadAllWares();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            loadAllWares();
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            loadAllWares();
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            loadAllWares();
        }
    }
}
