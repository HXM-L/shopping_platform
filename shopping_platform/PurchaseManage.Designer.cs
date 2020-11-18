
namespace shopping_platform
{
    partial class PurchaseManage
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseManage));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.purchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shopNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comSurplusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasedetailtableBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.shopping_platformDataSet1 = new shopping_platform.Shopping_platformDataSet1();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.shopping_platformDataSet = new shopping_platform.Shopping_platformDataSet();
            this.purchasedetailtableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.purchase_detail_tableTableAdapter = new shopping_platform.Shopping_platformDataSetTableAdapters.purchase_detail_tableTableAdapter();
            this.purchasedetailtableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.purchase_detail_tableTableAdapter1 = new shopping_platform.Shopping_platformDataSet1TableAdapters.purchase_detail_tableTableAdapter();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasedetailtableBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopping_platformDataSet1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shopping_platformDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasedetailtableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasedetailtableBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1128, 647);
            this.tabMain.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 51);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1120, 592);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "全部进货单";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.90909F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1114, 586);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.purchID,
            this.shopNameDataGridViewTextBoxColumn,
            this.comID,
            this.comNameDataGridViewTextBoxColumn,
            this.comPriceDataGridViewTextBoxColumn,
            this.comSurplusDataGridViewTextBoxColumn,
            this.comAddressDataGridViewTextBoxColumn,
            this.purchDateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.purchasedetailtableBindingSource2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.Location = new System.Drawing.Point(3, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1108, 527);
            this.dataGridView1.TabIndex = 1;
            // 
            // purchID
            // 
            this.purchID.DataPropertyName = "purchID";
            this.purchID.HeaderText = "进货单号";
            this.purchID.MinimumWidth = 6;
            this.purchID.Name = "purchID";
            this.purchID.ReadOnly = true;
            // 
            // shopNameDataGridViewTextBoxColumn
            // 
            this.shopNameDataGridViewTextBoxColumn.DataPropertyName = "shopName";
            this.shopNameDataGridViewTextBoxColumn.HeaderText = "负责人姓名";
            this.shopNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.shopNameDataGridViewTextBoxColumn.Name = "shopNameDataGridViewTextBoxColumn";
            this.shopNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // comID
            // 
            this.comID.DataPropertyName = "comID";
            this.comID.HeaderText = "商品ID";
            this.comID.MinimumWidth = 6;
            this.comID.Name = "comID";
            this.comID.ReadOnly = true;
            // 
            // comNameDataGridViewTextBoxColumn
            // 
            this.comNameDataGridViewTextBoxColumn.DataPropertyName = "comName";
            this.comNameDataGridViewTextBoxColumn.HeaderText = "商品名称";
            this.comNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.comNameDataGridViewTextBoxColumn.Name = "comNameDataGridViewTextBoxColumn";
            this.comNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // comPriceDataGridViewTextBoxColumn
            // 
            this.comPriceDataGridViewTextBoxColumn.DataPropertyName = "comPrice";
            this.comPriceDataGridViewTextBoxColumn.HeaderText = "商品单价";
            this.comPriceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.comPriceDataGridViewTextBoxColumn.Name = "comPriceDataGridViewTextBoxColumn";
            this.comPriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // comSurplusDataGridViewTextBoxColumn
            // 
            this.comSurplusDataGridViewTextBoxColumn.DataPropertyName = "comSurplus";
            this.comSurplusDataGridViewTextBoxColumn.HeaderText = "进货数量";
            this.comSurplusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.comSurplusDataGridViewTextBoxColumn.Name = "comSurplusDataGridViewTextBoxColumn";
            this.comSurplusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // comAddressDataGridViewTextBoxColumn
            // 
            this.comAddressDataGridViewTextBoxColumn.DataPropertyName = "comAddress";
            this.comAddressDataGridViewTextBoxColumn.HeaderText = "进货地址";
            this.comAddressDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.comAddressDataGridViewTextBoxColumn.Name = "comAddressDataGridViewTextBoxColumn";
            this.comAddressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // purchDateDataGridViewTextBoxColumn
            // 
            this.purchDateDataGridViewTextBoxColumn.DataPropertyName = "purchDate";
            this.purchDateDataGridViewTextBoxColumn.HeaderText = "进货日期";
            this.purchDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.purchDateDataGridViewTextBoxColumn.Name = "purchDateDataGridViewTextBoxColumn";
            this.purchDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // purchasedetailtableBindingSource2
            // 
            this.purchasedetailtableBindingSource2.DataMember = "purchase_detail_table";
            this.purchasedetailtableBindingSource2.DataSource = this.shopping_platformDataSet1;
            // 
            // shopping_platformDataSet1
            // 
            this.shopping_platformDataSet1.DataSetName = "Shopping_platformDataSet1";
            this.shopping_platformDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.88209F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.67327F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.29157F));
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1108, 47);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripButton3,
            this.toolStripSeparator4,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(231, 47);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(44, 44);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "添加";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 47);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(44, 44);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "修改";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 47);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(44, 44);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "删除";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 47);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(44, 44);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.ToolTipText = "刷新";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LawnGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(596, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(234, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(356, 36);
            this.textBox1.TabIndex = 2;
            this.textBox1.WordWrap = false;
            // 
            // shopping_platformDataSet
            // 
            this.shopping_platformDataSet.DataSetName = "Shopping_platformDataSet";
            this.shopping_platformDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // purchasedetailtableBindingSource
            // 
            this.purchasedetailtableBindingSource.DataMember = "purchase_detail_table";
            this.purchasedetailtableBindingSource.DataSource = this.shopping_platformDataSet;
            // 
            // purchase_detail_tableTableAdapter
            // 
            this.purchase_detail_tableTableAdapter.ClearBeforeFill = true;
            // 
            // purchasedetailtableBindingSource1
            // 
            this.purchasedetailtableBindingSource1.DataMember = "purchase_detail_table";
            this.purchasedetailtableBindingSource1.DataSource = this.shopping_platformDataSet1;
            // 
            // purchase_detail_tableTableAdapter1
            // 
            this.purchase_detail_tableTableAdapter1.ClearBeforeFill = true;
            // 
            // PurchaseManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabMain);
            this.Name = "PurchaseManage";
            this.Size = new System.Drawing.Size(1128, 647);
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasedetailtableBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopping_platformDataSet1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shopping_platformDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasedetailtableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchasedetailtableBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private Shopping_platformDataSet shopping_platformDataSet;
        private System.Windows.Forms.BindingSource purchasedetailtableBindingSource;
        private Shopping_platformDataSetTableAdapters.purchase_detail_tableTableAdapter purchase_detail_tableTableAdapter;
        private Shopping_platformDataSet1 shopping_platformDataSet1;
        private System.Windows.Forms.BindingSource purchasedetailtableBindingSource1;
        private Shopping_platformDataSet1TableAdapters.purchase_detail_tableTableAdapter purchase_detail_tableTableAdapter1;
        private System.Windows.Forms.BindingSource purchasedetailtableBindingSource2;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn shopNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comID;
        private System.Windows.Forms.DataGridViewTextBoxColumn comNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comSurplusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchDateDataGridViewTextBoxColumn;
    }
}
