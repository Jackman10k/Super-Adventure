namespace SuperAdventure
{
    partial class TradingScreen
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
            this.lblMyInventory = new System.Windows.Forms.Label();
            this.lblVendorInventory = new System.Windows.Forms.Label();
            this.dgvPlayerItems = new System.Windows.Forms.DataGridView();
            this.dgvVendorItems = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.rtbPlayerItemDescription = new System.Windows.Forms.RichTextBox();
            this.rtbVendorItemDescription = new System.Windows.Forms.RichTextBox();
            this.rtbVendorText = new System.Windows.Forms.RichTextBox();
            this.lblVendorName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayerItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMyInventory
            // 
            this.lblMyInventory.AutoSize = true;
            this.lblMyInventory.Location = new System.Drawing.Point(99, 13);
            this.lblMyInventory.Name = "lblMyInventory";
            this.lblMyInventory.Size = new System.Drawing.Size(68, 13);
            this.lblMyInventory.TabIndex = 0;
            this.lblMyInventory.Text = "My Inventory";
            // 
            // lblVendorInventory
            // 
            this.lblVendorInventory.AutoSize = true;
            this.lblVendorInventory.Location = new System.Drawing.Point(349, 13);
            this.lblVendorInventory.Name = "lblVendorInventory";
            this.lblVendorInventory.Size = new System.Drawing.Size(95, 13);
            this.lblVendorInventory.TabIndex = 1;
            this.lblVendorInventory.Text = "Vendor\'s Inventory";
            // 
            // dgvPlayerItems
            // 
            this.dgvPlayerItems.AllowUserToAddRows = false;
            this.dgvPlayerItems.AllowUserToDeleteRows = false;
            this.dgvPlayerItems.AllowUserToOrderColumns = true;
            this.dgvPlayerItems.AllowUserToResizeColumns = false;
            this.dgvPlayerItems.AllowUserToResizeRows = false;
            this.dgvPlayerItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayerItems.ColumnHeadersVisible = false;
            this.dgvPlayerItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPlayerItems.Location = new System.Drawing.Point(13, 55);
            this.dgvPlayerItems.MultiSelect = false;
            this.dgvPlayerItems.Name = "dgvPlayerItems";
            this.dgvPlayerItems.ReadOnly = true;
            this.dgvPlayerItems.RowHeadersVisible = false;
            this.dgvPlayerItems.Size = new System.Drawing.Size(335, 204);
            this.dgvPlayerItems.TabIndex = 2;
            // 
            // dgvVendorItems
            // 
            this.dgvVendorItems.AllowUserToAddRows = false;
            this.dgvVendorItems.AllowUserToDeleteRows = false;
            this.dgvVendorItems.AllowUserToResizeColumns = false;
            this.dgvVendorItems.AllowUserToResizeRows = false;
            this.dgvVendorItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendorItems.ColumnHeadersVisible = false;
            this.dgvVendorItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvVendorItems.Location = new System.Drawing.Point(362, 55);
            this.dgvVendorItems.MultiSelect = false;
            this.dgvVendorItems.Name = "dgvVendorItems";
            this.dgvVendorItems.ReadOnly = true;
            this.dgvVendorItems.RowHeadersVisible = false;
            this.dgvVendorItems.Size = new System.Drawing.Size(335, 204);
            this.dgvVendorItems.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(441, 388);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rtbPlayerItemDescription
            // 
            this.rtbPlayerItemDescription.BackColor = System.Drawing.SystemColors.Control;
            this.rtbPlayerItemDescription.Location = new System.Drawing.Point(13, 266);
            this.rtbPlayerItemDescription.Name = "rtbPlayerItemDescription";
            this.rtbPlayerItemDescription.ReadOnly = true;
            this.rtbPlayerItemDescription.Size = new System.Drawing.Size(335, 104);
            this.rtbPlayerItemDescription.TabIndex = 5;
            this.rtbPlayerItemDescription.Text = "";
            // 
            // rtbVendorItemDescription
            // 
            this.rtbVendorItemDescription.BackColor = System.Drawing.SystemColors.Control;
            this.rtbVendorItemDescription.Location = new System.Drawing.Point(362, 265);
            this.rtbVendorItemDescription.Name = "rtbVendorItemDescription";
            this.rtbVendorItemDescription.ReadOnly = true;
            this.rtbVendorItemDescription.Size = new System.Drawing.Size(335, 104);
            this.rtbVendorItemDescription.TabIndex = 6;
            this.rtbVendorItemDescription.Text = "";
            // 
            // rtbVendorText
            // 
            this.rtbVendorText.BackColor = System.Drawing.SystemColors.Control;
            this.rtbVendorText.Location = new System.Drawing.Point(711, 42);
            this.rtbVendorText.Name = "rtbVendorText";
            this.rtbVendorText.ReadOnly = true;
            this.rtbVendorText.Size = new System.Drawing.Size(258, 327);
            this.rtbVendorText.TabIndex = 7;
            this.rtbVendorText.Text = "";
            // 
            // lblVendorName
            // 
            this.lblVendorName.AutoSize = true;
            this.lblVendorName.Location = new System.Drawing.Point(534, 13);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(0, 13);
            this.lblVendorName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Item Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Qty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Sell Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(359, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Item Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(516, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Buy Price";
            // 
            // TradingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 423);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblVendorName);
            this.Controls.Add(this.rtbVendorText);
            this.Controls.Add(this.rtbVendorItemDescription);
            this.Controls.Add(this.rtbPlayerItemDescription);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvVendorItems);
            this.Controls.Add(this.dgvPlayerItems);
            this.Controls.Add(this.lblVendorInventory);
            this.Controls.Add(this.lblMyInventory);
            this.Name = "TradingScreen";
            this.Text = "Trade";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayerItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMyInventory;
        private System.Windows.Forms.Label lblVendorInventory;
        private System.Windows.Forms.DataGridView dgvPlayerItems;
        private System.Windows.Forms.DataGridView dgvVendorItems;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RichTextBox rtbPlayerItemDescription;
        private System.Windows.Forms.RichTextBox rtbVendorItemDescription;
        private System.Windows.Forms.RichTextBox rtbVendorText;
        private System.Windows.Forms.Label lblVendorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}