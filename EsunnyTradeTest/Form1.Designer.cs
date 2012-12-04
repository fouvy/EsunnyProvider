namespace EsunnyTradeTest
{
  partial class Form1
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

    #region Windows 窗体设计器生成的代码

    /// <summary>
    /// 设计器支持所需的方法 - 不要
    /// 使用代码编辑器修改此方法的内容。
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.idOrderDataGridView = new System.Windows.Forms.DataGridView();
      this.symbolCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.directionTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.offsetTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.clientOrderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.orderInputTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.orderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.orderStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.orderTradeStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tradeVolumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.idOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.idAmountDataGridView = new System.Windows.Forms.DataGridView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.idFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.idLoginMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.idTradeQueryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.idTradeQueryAmountMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.idTradeQueryOrderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.idTradeQueryPositionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.symbolCodeComboBox1 = new DevExpress.XtraEditors.ComboBoxEdit();
      this.idSendOrderButton = new System.Windows.Forms.Button();
      this.idPriceNumericUpDown = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.comboBox2 = new System.Windows.Forms.ComboBox();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.tabControl1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.idOrderDataGridView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.idOrderBindingSource)).BeginInit();
      this.tabPage1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.idAmountDataGridView)).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.symbolCodeComboBox1.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.idPriceNumericUpDown)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(688, 170);
      this.tabControl1.TabIndex = 3;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.idOrderDataGridView);
      this.tabPage2.Location = new System.Drawing.Point(4, 4);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(680, 144);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "报单";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // idOrderDataGridView
      // 
      this.idOrderDataGridView.AllowUserToAddRows = false;
      this.idOrderDataGridView.AllowUserToDeleteRows = false;
      this.idOrderDataGridView.AutoGenerateColumns = false;
      this.idOrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.idOrderDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.symbolCodeDataGridViewTextBoxColumn,
            this.directionTypeDataGridViewTextBoxColumn,
            this.offsetTypeDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn,
            this.clientOrderIDDataGridViewTextBoxColumn,
            this.orderInputTimeDataGridViewTextBoxColumn,
            this.orderTypeDataGridViewTextBoxColumn,
            this.orderStatusDataGridViewTextBoxColumn,
            this.orderTradeStatusDataGridViewTextBoxColumn,
            this.tradeVolumeDataGridViewTextBoxColumn});
      this.idOrderDataGridView.DataSource = this.idOrderBindingSource;
      this.idOrderDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.idOrderDataGridView.Location = new System.Drawing.Point(3, 3);
      this.idOrderDataGridView.Name = "idOrderDataGridView";
      this.idOrderDataGridView.ReadOnly = true;
      this.idOrderDataGridView.RowTemplate.Height = 23;
      this.idOrderDataGridView.Size = new System.Drawing.Size(674, 138);
      this.idOrderDataGridView.TabIndex = 0;
      // 
      // symbolCodeDataGridViewTextBoxColumn
      // 
      this.symbolCodeDataGridViewTextBoxColumn.DataPropertyName = "SymbolCode";
      this.symbolCodeDataGridViewTextBoxColumn.HeaderText = "SymbolCode";
      this.symbolCodeDataGridViewTextBoxColumn.Name = "symbolCodeDataGridViewTextBoxColumn";
      this.symbolCodeDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // directionTypeDataGridViewTextBoxColumn
      // 
      this.directionTypeDataGridViewTextBoxColumn.DataPropertyName = "DirectionType";
      this.directionTypeDataGridViewTextBoxColumn.HeaderText = "DirectionType";
      this.directionTypeDataGridViewTextBoxColumn.Name = "directionTypeDataGridViewTextBoxColumn";
      this.directionTypeDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // offsetTypeDataGridViewTextBoxColumn
      // 
      this.offsetTypeDataGridViewTextBoxColumn.DataPropertyName = "OffsetType";
      this.offsetTypeDataGridViewTextBoxColumn.HeaderText = "OffsetType";
      this.offsetTypeDataGridViewTextBoxColumn.Name = "offsetTypeDataGridViewTextBoxColumn";
      this.offsetTypeDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // priceDataGridViewTextBoxColumn
      // 
      this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
      this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
      this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
      this.priceDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // volumeDataGridViewTextBoxColumn
      // 
      this.volumeDataGridViewTextBoxColumn.DataPropertyName = "Volume";
      this.volumeDataGridViewTextBoxColumn.HeaderText = "Volume";
      this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
      this.volumeDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // clientOrderIDDataGridViewTextBoxColumn
      // 
      this.clientOrderIDDataGridViewTextBoxColumn.DataPropertyName = "ClientOrderID";
      this.clientOrderIDDataGridViewTextBoxColumn.HeaderText = "ClientOrderID";
      this.clientOrderIDDataGridViewTextBoxColumn.Name = "clientOrderIDDataGridViewTextBoxColumn";
      this.clientOrderIDDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // orderInputTimeDataGridViewTextBoxColumn
      // 
      this.orderInputTimeDataGridViewTextBoxColumn.DataPropertyName = "OrderInputTime";
      this.orderInputTimeDataGridViewTextBoxColumn.HeaderText = "OrderInputTime";
      this.orderInputTimeDataGridViewTextBoxColumn.Name = "orderInputTimeDataGridViewTextBoxColumn";
      this.orderInputTimeDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // orderTypeDataGridViewTextBoxColumn
      // 
      this.orderTypeDataGridViewTextBoxColumn.DataPropertyName = "OrderType";
      this.orderTypeDataGridViewTextBoxColumn.HeaderText = "OrderType";
      this.orderTypeDataGridViewTextBoxColumn.Name = "orderTypeDataGridViewTextBoxColumn";
      this.orderTypeDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // orderStatusDataGridViewTextBoxColumn
      // 
      this.orderStatusDataGridViewTextBoxColumn.DataPropertyName = "OrderStatus";
      this.orderStatusDataGridViewTextBoxColumn.HeaderText = "OrderStatus";
      this.orderStatusDataGridViewTextBoxColumn.Name = "orderStatusDataGridViewTextBoxColumn";
      this.orderStatusDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // orderTradeStatusDataGridViewTextBoxColumn
      // 
      this.orderTradeStatusDataGridViewTextBoxColumn.DataPropertyName = "OrderTradeStatus";
      this.orderTradeStatusDataGridViewTextBoxColumn.HeaderText = "OrderTradeStatus";
      this.orderTradeStatusDataGridViewTextBoxColumn.Name = "orderTradeStatusDataGridViewTextBoxColumn";
      this.orderTradeStatusDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // tradeVolumeDataGridViewTextBoxColumn
      // 
      this.tradeVolumeDataGridViewTextBoxColumn.DataPropertyName = "TradeVolume";
      this.tradeVolumeDataGridViewTextBoxColumn.HeaderText = "TradeVolume";
      this.tradeVolumeDataGridViewTextBoxColumn.Name = "tradeVolumeDataGridViewTextBoxColumn";
      this.tradeVolumeDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // idOrderBindingSource
      // 
      this.idOrderBindingSource.DataSource = typeof(CalmBeltFund.Trading.Esunny.EsunnyInputOrder);
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.idAmountDataGridView);
      this.tabPage1.Location = new System.Drawing.Point(4, 4);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(680, 144);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "资金";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // idAmountDataGridView
      // 
      this.idAmountDataGridView.AllowUserToAddRows = false;
      this.idAmountDataGridView.AllowUserToDeleteRows = false;
      this.idAmountDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.idAmountDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
      this.idAmountDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.idAmountDataGridView.Location = new System.Drawing.Point(3, 3);
      this.idAmountDataGridView.Name = "idAmountDataGridView";
      this.idAmountDataGridView.ReadOnly = true;
      this.idAmountDataGridView.RowTemplate.Height = 23;
      this.idAmountDataGridView.Size = new System.Drawing.Size(674, 138);
      this.idAmountDataGridView.TabIndex = 1;
      // 
      // Column1
      // 
      this.Column1.HeaderText = "客户号";
      this.Column1.Name = "Column1";
      this.Column1.ReadOnly = true;
      // 
      // Column2
      // 
      this.Column2.HeaderText = "Column2";
      this.Column2.Name = "Column2";
      this.Column2.ReadOnly = true;
      // 
      // Column3
      // 
      this.Column3.HeaderText = "Column3";
      this.Column3.Name = "Column3";
      this.Column3.ReadOnly = true;
      // 
      // Column4
      // 
      this.Column4.HeaderText = "Column4";
      this.Column4.Name = "Column4";
      this.Column4.ReadOnly = true;
      // 
      // Column5
      // 
      this.Column5.HeaderText = "Column5";
      this.Column5.Name = "Column5";
      this.Column5.ReadOnly = true;
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.idFileMenuItem,
            this.idTradeQueryMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(688, 25);
      this.menuStrip1.TabIndex = 4;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // idFileMenuItem
      // 
      this.idFileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.idLoginMenuItem});
      this.idFileMenuItem.Name = "idFileMenuItem";
      this.idFileMenuItem.Size = new System.Drawing.Size(44, 21);
      this.idFileMenuItem.Text = "文件";
      // 
      // idLoginMenuItem
      // 
      this.idLoginMenuItem.Name = "idLoginMenuItem";
      this.idLoginMenuItem.Size = new System.Drawing.Size(100, 22);
      this.idLoginMenuItem.Text = "登录";
      this.idLoginMenuItem.Click += new System.EventHandler(this.idLoginMenuItem_Click);
      // 
      // idTradeQueryMenuItem
      // 
      this.idTradeQueryMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.idTradeQueryAmountMenuItem,
            this.idTradeQueryOrderMenuItem,
            this.idTradeQueryPositionMenuItem});
      this.idTradeQueryMenuItem.Name = "idTradeQueryMenuItem";
      this.idTradeQueryMenuItem.Size = new System.Drawing.Size(68, 21);
      this.idTradeQueryMenuItem.Text = "交易查询";
      // 
      // idTradeQueryAmountMenuItem
      // 
      this.idTradeQueryAmountMenuItem.Name = "idTradeQueryAmountMenuItem";
      this.idTradeQueryAmountMenuItem.Size = new System.Drawing.Size(100, 22);
      this.idTradeQueryAmountMenuItem.Text = "资金";
      this.idTradeQueryAmountMenuItem.Click += new System.EventHandler(this.idTradeQueryAmountMenuItem_Click);
      // 
      // idTradeQueryOrderMenuItem
      // 
      this.idTradeQueryOrderMenuItem.Name = "idTradeQueryOrderMenuItem";
      this.idTradeQueryOrderMenuItem.Size = new System.Drawing.Size(100, 22);
      this.idTradeQueryOrderMenuItem.Text = "报单";
      this.idTradeQueryOrderMenuItem.Click += new System.EventHandler(this.idTradeQueryOrderMenuItem_Click);
      // 
      // idTradeQueryPositionMenuItem
      // 
      this.idTradeQueryPositionMenuItem.Name = "idTradeQueryPositionMenuItem";
      this.idTradeQueryPositionMenuItem.Size = new System.Drawing.Size(100, 22);
      this.idTradeQueryPositionMenuItem.Text = "持仓";
      this.idTradeQueryPositionMenuItem.Click += new System.EventHandler(this.idTradeQueryPositionMenuItem_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
      this.statusStrip1.Location = new System.Drawing.Point(0, 372);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(688, 22);
      this.statusStrip1.TabIndex = 5;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
      this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 25);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
      this.splitContainer1.Size = new System.Drawing.Size(688, 347);
      this.splitContainer1.SplitterDistance = 173;
      this.splitContainer1.TabIndex = 6;
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.symbolCodeComboBox1);
      this.splitContainer2.Panel2.Controls.Add(this.idSendOrderButton);
      this.splitContainer2.Panel2.Controls.Add(this.idPriceNumericUpDown);
      this.splitContainer2.Panel2.Controls.Add(this.numericUpDown1);
      this.splitContainer2.Panel2.Controls.Add(this.comboBox2);
      this.splitContainer2.Panel2.Controls.Add(this.comboBox1);
      this.splitContainer2.Size = new System.Drawing.Size(688, 173);
      this.splitContainer2.SplitterDistance = 144;
      this.splitContainer2.TabIndex = 0;
      // 
      // symbolCodeComboBox1
      // 
      this.symbolCodeComboBox1.Location = new System.Drawing.Point(7, 3);
      this.symbolCodeComboBox1.Name = "symbolCodeComboBox1";
      this.symbolCodeComboBox1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.symbolCodeComboBox1.Size = new System.Drawing.Size(100, 20);
      this.symbolCodeComboBox1.TabIndex = 4;
      this.symbolCodeComboBox1.SelectedValueChanged += new System.EventHandler(this.symbolCodeComboBox1_SelectedValueChanged);
      // 
      // idSendOrderButton
      // 
      this.idSendOrderButton.Location = new System.Drawing.Point(606, 1);
      this.idSendOrderButton.Name = "idSendOrderButton";
      this.idSendOrderButton.Size = new System.Drawing.Size(75, 23);
      this.idSendOrderButton.TabIndex = 3;
      this.idSendOrderButton.Text = "报单";
      this.idSendOrderButton.UseVisualStyleBackColor = true;
      this.idSendOrderButton.Click += new System.EventHandler(this.idSendOrderButton_Click);
      // 
      // idPriceNumericUpDown
      // 
      this.idPriceNumericUpDown.Location = new System.Drawing.Point(331, 4);
      this.idPriceNumericUpDown.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
      this.idPriceNumericUpDown.Name = "idPriceNumericUpDown";
      this.idPriceNumericUpDown.Size = new System.Drawing.Size(72, 21);
      this.idPriceNumericUpDown.TabIndex = 2;
      // 
      // numericUpDown1
      // 
      this.numericUpDown1.Location = new System.Drawing.Point(253, 3);
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(72, 21);
      this.numericUpDown1.TabIndex = 2;
      this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // comboBox2
      // 
      this.comboBox2.FormattingEnabled = true;
      this.comboBox2.Location = new System.Drawing.Point(183, 3);
      this.comboBox2.Name = "comboBox2";
      this.comboBox2.Size = new System.Drawing.Size(64, 20);
      this.comboBox2.TabIndex = 1;
      // 
      // comboBox1
      // 
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(113, 4);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(64, 20);
      this.comboBox1.TabIndex = 1;
      // 
      // dataGridViewTextBoxColumn1
      // 
      this.dataGridViewTextBoxColumn1.HeaderText = "客户号";
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      // 
      // dataGridViewTextBoxColumn2
      // 
      this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      // 
      // dataGridViewTextBoxColumn3
      // 
      this.dataGridViewTextBoxColumn3.HeaderText = "Column3";
      this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
      // 
      // dataGridViewTextBoxColumn4
      // 
      this.dataGridViewTextBoxColumn4.HeaderText = "Column4";
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      // 
      // dataGridViewTextBoxColumn5
      // 
      this.dataGridViewTextBoxColumn5.HeaderText = "Column5";
      this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(688, 394);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.tabControl1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.idOrderDataGridView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.idOrderBindingSource)).EndInit();
      this.tabPage1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.idAmountDataGridView)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.splitContainer2.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
      this.splitContainer2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.symbolCodeComboBox1.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.idPriceNumericUpDown)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.DataGridView idOrderDataGridView;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem idFileMenuItem;
    private System.Windows.Forms.ToolStripMenuItem idLoginMenuItem;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripMenuItem idTradeQueryMenuItem;
    private System.Windows.Forms.ToolStripMenuItem idTradeQueryAmountMenuItem;
    private System.Windows.Forms.ToolStripMenuItem idTradeQueryOrderMenuItem;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.DataGridView idAmountDataGridView;
    private System.Windows.Forms.BindingSource idOrderBindingSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    private System.Windows.Forms.DataGridViewTextBoxColumn clientNumberDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn tradingAccountIDDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn brokerIDDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn tradingHostTypeDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn tradeDateDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn symbolCodeDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn directionTypeDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn offsetTypeDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn clientOrderIDDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn orderInputTimeDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn orderStatusDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn orderTradeStatusDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn tradeVolumeDataGridViewTextBoxColumn;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.ComboBox comboBox2;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private System.Windows.Forms.Button idSendOrderButton;
    private System.Windows.Forms.NumericUpDown idPriceNumericUpDown;
    private System.Windows.Forms.ToolStripMenuItem idTradeQueryPositionMenuItem;
    private DevExpress.XtraEditors.ComboBoxEdit symbolCodeComboBox1;
  }
}

