namespace SalesWinApp
{
    partial class frmOrderInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbOrderID = new System.Windows.Forms.Label();
            this.lbMemberID = new System.Windows.Forms.Label();
            this.lbFreight = new System.Windows.Forms.Label();
            this.lbOrderDate = new System.Windows.Forms.Label();
            this.lbShippedDate = new System.Windows.Forms.Label();
            this.lbRequiredDate = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.cbMemberID = new System.Windows.Forms.ComboBox();
            this.txtFreight = new System.Windows.Forms.TextBox();
            this.dtOrderDate = new System.Windows.Forms.DateTimePicker();
            this.dtShippedDate = new System.Windows.Forms.DateTimePicker();
            this.dtRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dataGridOrderInfo = new System.Windows.Forms.DataGridView();
            this.btnAddOrderInfo = new System.Windows.Forms.Button();
            this.btnDeleteOrderInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // lbOrderID
            // 
            this.lbOrderID.AutoSize = true;
            this.lbOrderID.Location = new System.Drawing.Point(35, 34);
            this.lbOrderID.Name = "lbOrderID";
            this.lbOrderID.Size = new System.Drawing.Size(62, 20);
            this.lbOrderID.TabIndex = 0;
            this.lbOrderID.Text = "OrderID";
            // 
            // lbMemberID
            // 
            this.lbMemberID.AutoSize = true;
            this.lbMemberID.Location = new System.Drawing.Point(312, 34);
            this.lbMemberID.Name = "lbMemberID";
            this.lbMemberID.Size = new System.Drawing.Size(80, 20);
            this.lbMemberID.TabIndex = 0;
            this.lbMemberID.Text = "MemberID";
            // 
            // lbFreight
            // 
            this.lbFreight.AutoSize = true;
            this.lbFreight.Location = new System.Drawing.Point(615, 34);
            this.lbFreight.Name = "lbFreight";
            this.lbFreight.Size = new System.Drawing.Size(55, 20);
            this.lbFreight.TabIndex = 0;
            this.lbFreight.Text = "Freight";
            // 
            // lbOrderDate
            // 
            this.lbOrderDate.AutoSize = true;
            this.lbOrderDate.Location = new System.Drawing.Point(35, 98);
            this.lbOrderDate.Name = "lbOrderDate";
            this.lbOrderDate.Size = new System.Drawing.Size(79, 20);
            this.lbOrderDate.TabIndex = 0;
            this.lbOrderDate.Text = "OrderDate";
            // 
            // lbShippedDate
            // 
            this.lbShippedDate.AutoSize = true;
            this.lbShippedDate.Location = new System.Drawing.Point(312, 98);
            this.lbShippedDate.Name = "lbShippedDate";
            this.lbShippedDate.Size = new System.Drawing.Size(96, 20);
            this.lbShippedDate.TabIndex = 0;
            this.lbShippedDate.Text = "ShippedDate";
            // 
            // lbRequiredDate
            // 
            this.lbRequiredDate.AutoSize = true;
            this.lbRequiredDate.Location = new System.Drawing.Point(615, 98);
            this.lbRequiredDate.Name = "lbRequiredDate";
            this.lbRequiredDate.Size = new System.Drawing.Size(101, 20);
            this.lbRequiredDate.TabIndex = 0;
            this.lbRequiredDate.Text = "RequiredDate";
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(103, 31);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(168, 27);
            this.txtOrderID.TabIndex = 1;
            // 
            // cbMemberID
            // 
            this.cbMemberID.FormattingEnabled = true;
            this.cbMemberID.Location = new System.Drawing.Point(407, 31);
            this.cbMemberID.Name = "cbMemberID";
            this.cbMemberID.Size = new System.Drawing.Size(168, 28);
            this.cbMemberID.TabIndex = 2;
            // 
            // txtFreight
            // 
            this.txtFreight.Location = new System.Drawing.Point(691, 31);
            this.txtFreight.Name = "txtFreight";
            this.txtFreight.Size = new System.Drawing.Size(168, 27);
            this.txtFreight.TabIndex = 1;
            // 
            // dtOrderDate
            // 
            this.dtOrderDate.Location = new System.Drawing.Point(120, 93);
            this.dtOrderDate.Name = "dtOrderDate";
            this.dtOrderDate.Size = new System.Drawing.Size(168, 27);
            this.dtOrderDate.TabIndex = 3;
            // 
            // dtShippedDate
            // 
            this.dtShippedDate.Location = new System.Drawing.Point(407, 98);
            this.dtShippedDate.Name = "dtShippedDate";
            this.dtShippedDate.Size = new System.Drawing.Size(168, 27);
            this.dtShippedDate.TabIndex = 3;
            // 
            // dtRequiredDate
            // 
            this.dtRequiredDate.Location = new System.Drawing.Point(722, 93);
            this.dtRequiredDate.Name = "dtRequiredDate";
            this.dtRequiredDate.Size = new System.Drawing.Size(168, 27);
            this.dtRequiredDate.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(169, 156);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(436, 156);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(139, 36);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridOrderInfo
            // 
            this.dataGridOrderInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrderInfo.Location = new System.Drawing.Point(37, 214);
            this.dataGridOrderInfo.MultiSelect = false;
            this.dataGridOrderInfo.Name = "dataGridOrderInfo";
            this.dataGridOrderInfo.ReadOnly = true;
            this.dataGridOrderInfo.RowHeadersWidth = 51;
            this.dataGridOrderInfo.RowTemplate.Height = 29;
            this.dataGridOrderInfo.Size = new System.Drawing.Size(862, 166);
            this.dataGridOrderInfo.TabIndex = 5;
            // 
            // btnAddOrderInfo
            // 
            this.btnAddOrderInfo.Location = new System.Drawing.Point(169, 402);
            this.btnAddOrderInfo.Name = "btnAddOrderInfo";
            this.btnAddOrderInfo.Size = new System.Drawing.Size(139, 36);
            this.btnAddOrderInfo.TabIndex = 4;
            this.btnAddOrderInfo.Text = "Create";
            this.btnAddOrderInfo.UseVisualStyleBackColor = true;
            this.btnAddOrderInfo.Click += new System.EventHandler(this.btnAddOrderInfo_Click);
            // 
            // btnDeleteOrderInfo
            // 
            this.btnDeleteOrderInfo.Location = new System.Drawing.Point(436, 402);
            this.btnDeleteOrderInfo.Name = "btnDeleteOrderInfo";
            this.btnDeleteOrderInfo.Size = new System.Drawing.Size(139, 36);
            this.btnDeleteOrderInfo.TabIndex = 4;
            this.btnDeleteOrderInfo.Text = "Delete";
            this.btnDeleteOrderInfo.UseVisualStyleBackColor = true;
            this.btnDeleteOrderInfo.Click += new System.EventHandler(this.btnDeleteOrderInfo_Click);
            // 
            // frmOrderInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 450);
            this.Controls.Add(this.dataGridOrderInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeleteOrderInfo);
            this.Controls.Add(this.btnAddOrderInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtRequiredDate);
            this.Controls.Add(this.dtShippedDate);
            this.Controls.Add(this.dtOrderDate);
            this.Controls.Add(this.cbMemberID);
            this.Controls.Add(this.txtFreight);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.lbRequiredDate);
            this.Controls.Add(this.lbShippedDate);
            this.Controls.Add(this.lbOrderDate);
            this.Controls.Add(this.lbFreight);
            this.Controls.Add(this.lbMemberID);
            this.Controls.Add(this.lbOrderID);
            this.Name = "frmOrderInfo";
            this.Text = "frmOrderInfo";
            this.Load += new System.EventHandler(this.frmOrderInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbOrderID;
        private System.Windows.Forms.Label lbMemberID;
        private System.Windows.Forms.Label lbFreight;
        private System.Windows.Forms.Label lbOrderDate;
        private System.Windows.Forms.Label lbShippedDate;
        private System.Windows.Forms.Label lbRequiredDate;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.ComboBox cbMemberID;
        private System.Windows.Forms.TextBox txtFreight;
        private System.Windows.Forms.DateTimePicker dtOrderDate;
        private System.Windows.Forms.DateTimePicker dtShippedDate;
        private System.Windows.Forms.DateTimePicker dtRequiredDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridOrderInfo;
        private System.Windows.Forms.Button btnAddOrderInfo;
        private System.Windows.Forms.Button btnDeleteOrderInfo;
    }
}