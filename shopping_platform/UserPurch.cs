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
using System.Threading;  //导入命名空间,类Thread就在此空间中
using System.Runtime.InteropServices;

namespace shopping_platform
{
    public partial class UserPurch : Form
    {
        public List<string> WIDS;
        public double SUM { get; set; }
        public UserPurch(List<string> tempID,double sum,Dictionary<string,int> temp)
        {
            InitializeComponent();
            WIDS = tempID;
            SUM = sum;
            string tempstr = "";
            foreach(string item in temp.Keys){
                tempstr += item + temp[item].ToString()+"份 ";
            }
            this.label1.Text = "您购买的商品有:" + tempstr;
            this.label2.Text = "总价为:" + Convert.ToDecimal(sum.ToString()).ToString("F2");
        }

        //Messagebox定时关闭
        public class MessageBoxTimeOut
        {
            private string _caption;

            public void Show(string text, string caption)
            {
                Show(3000, text, caption);
            }
            public void Show(int timeout, string text, string caption)
            {
                Show(timeout, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            public void Show(int timeout, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
            {
                this._caption = caption;
                StartTimer(timeout);
                MessageBox.Show(text, caption, buttons, icon);
            }
            private void StartTimer(int interval)
            {
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = interval;
                timer.Tick += new EventHandler(Timer_Tick);
                timer.Enabled = true;
            }
            private void Timer_Tick(object sender, EventArgs e)
            {
                KillMessageBox();
                //停止计时器
                ((System.Windows.Forms.Timer)sender).Enabled = false;
            }
            [DllImport("User32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
            private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
            [DllImport("User32.dll", CharSet = CharSet.Auto)]
            public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
            public const int WM_CLOSE = 0x10;
            private void KillMessageBox()
            {
                //查找MessageBox的弹出窗口,注意对应标题
                IntPtr ptr = FindWindow(null, this._caption);
                if (ptr != IntPtr.Zero)
                {
                    //查找到窗口则关闭
                    PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                }
            }
        }
        //取消
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        //购买确定按钮
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBoxTimeOut mb = new MessageBoxTimeOut();
            Random ran = new Random();
            string orderid = DateTime.Now.ToString("yyyyMMddhhmmss") + ran.Next(1000, 9999).ToString();  //自动生成订单号
            string paydate = DateTime.Now.ToString("yyyy-MM-dd");
            try
            {
                using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                {
                    string strsql2 = " ";
                    strsql2 = "insert into order_table([orderID] ,[userID] ,[shopID] ,[orderTotalPrice] ,[shipAddress] ,[payMethod] ,[payDate] ,[tranStatus]) values(@orderID,@userID,@shopID,@orderTotalPrice,@shipAddress,@payMethod,@payDate,@tranStatus)";
                    using (SqlCommand comm = new SqlCommand
                    {
                        CommandText = strsql2,
                        CommandType = CommandType.Text,
                        Connection = conn
                    })
                    {
                        comm.Parameters.AddWithValue("@orderID", orderid);
                        comm.Parameters.AddWithValue("@userID", "201801");
                        comm.Parameters.AddWithValue("@shopID", "1001");
                        comm.Parameters.AddWithValue("@orderTotalPrice", this.SUM);
                        comm.Parameters.AddWithValue("@shipAddress", "广东省湛江市赤坎区");
                        comm.Parameters.AddWithValue("@payMethod", 0);
                        comm.Parameters.AddWithValue("@payDate", paydate);
                        comm.Parameters.AddWithValue("@tranStatus", 1);
                        conn.Open();

                        if (Convert.ToInt32(comm.ExecuteNonQuery()) > 0)
                        {
                            //MessageBox.Show("添加成功");
                            //DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("添加失败！");
                        }
                    }
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("数据库连接错误，错误源是" + sqlex.Message);
            }
            foreach (var item in WIDS)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(AppConst.DbPath))
                    {
                        using (SqlCommand cmd = new SqlCommand($"delete  from [Shopping_Cart] where commID='{item}'", conn))
                        {
                            conn.Open();
                            if (Convert.ToInt32(cmd.ExecuteNonQuery()) > 0)
                            {
                                //MessageBox.Show("删除成功");
                            }
                            else
                            {
                                MessageBox.Show(item);
                            }
                        }
                    }
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("数据库连接错误，错误源是" + sqlex.Message);
                }
            }
            
            mb.Show("支付中.........", "提示");
            MessageBox.Show("支付完成","success");
            DialogResult = DialogResult.Cancel;
        }
    }
}
