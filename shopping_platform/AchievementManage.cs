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
    public partial class AchievementManage : UserControl
    {
        public AchievementManage()
        {
            InitializeComponent();
            setColor();
            loadAchieve();
        }
        //设置表头颜色
        void setColor()
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Cyan;
        }
        //加载数据
        void loadAchieve()
        {
            using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
            {
                //tranStatus:0待付款,1待发货,2用户已申请退货/退款,3.用户已取消订单,4.已退货/退款5.已完成
                //加载所有订单的数据
                string sql = "select * from [sale_table]";//sda执行的sql语句、执行的数据库连接
                var da = new SqlDataAdapter(sql, conn);//创建数据库连接
                var dt = new DataTable();//DataTable是DataSet里的表，DataTable的对象dt就是一个表格。
                da.Fill(dt);//往dt里填充数据。
                dataGridView1.DataSource = dt;//把表格dt里的数据，放在dataGridView2里显示
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            saleAdd saleAdd = new saleAdd();
            saleAdd.ShowDialog();
            loadAchieve();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows == null)
            {
                MessageBox.Show("请选择要修改记录！");
                return;
            }
            else
            {
                saleModify saleModify = new saleModify(dataGridView1.SelectedRows);
                saleModify.ShowDialog();
                loadAchieve();
            }
        }

        //删除
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"确定要删除商品【{dataGridView1.SelectedRows[0].Cells["ID"].Value}】的进货信息吗?", "删除确认提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                {
                    using (SqlCommand cmd = new SqlCommand($"delete  from [sale_table] where comID='{dataGridView1.SelectedRows[0].Cells["comID"].Value}' and ID='{dataGridView1.SelectedRows[0].Cells["ID"].Value}'", conn))
                    {
                        conn.Open();
                        if (Convert.ToInt32(cmd.ExecuteNonQuery()) > 0)
                        {
                            MessageBox.Show("删除成功");
                            loadAchieve();
                        }
                        else
                        {
                            MessageBox.Show("删除失败！");
                        }
                    }
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            loadAchieve();
        }
    }
}
