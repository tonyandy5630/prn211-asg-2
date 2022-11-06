namespace SalesWinApp
{
    partial class frmMemberViewOrder
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
            this.dataGridOrder = new System.Windows.Forms.DataGridView();
            this.dataGridOrderDetail = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridOrder
            // 
            this.dataGridOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrder.Location = new System.Drawing.Point(43, 30);
            this.dataGridOrder.Name = "dataGridOrder";
            this.dataGridOrder.ReadOnly = true;
            this.dataGridOrder.RowHeadersWidth = 51;
            this.dataGridOrder.RowTemplate.Height = 29;
            this.dataGridOrder.Size = new System.Drawing.Size(717, 151);
            this.dataGridOrder.TabIndex = 0;
            // 
            // dataGridOrderDetail
            // 
            this.dataGridOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrderDetail.Location = new System.Drawing.Point(43, 238);
            this.dataGridOrderDetail.Name = "dataGridOrderDetail";
            this.dataGridOrderDetail.ReadOnly = true;
            this.dataGridOrderDetail.RowHeadersWidth = 51;
            this.dataGridOrderDetail.RowTemplate.Height = 29;
            this.dataGridOrderDetail.Size = new System.Drawing.Size(721, 138);
            this.dataGridOrderDetail.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(275, 391);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(280, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmMemberViewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridOrderDetail);
            this.Controls.Add(this.dataGridOrder);
            this.Name = "frmMemberViewOrder";
            this.Text = "frmMemberViewOrder";
            this.Load += new System.EventHandler(this.frmMemberViewOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridOrder;
        private System.Windows.Forms.DataGridView dataGridOrderDetail;
        private System.Windows.Forms.Button btnClose;
    }
}