namespace SuperAdventure
{
    partial class InnScreen
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
            this.rtbInnDescription = new System.Windows.Forms.RichTextBox();
            this.rtbInnMessage = new System.Windows.Forms.RichTextBox();
            this.btnInnYes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInnCost = new System.Windows.Forms.Label();
            this.btnInnNo = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbInnDescription
            // 
            this.rtbInnDescription.BackColor = System.Drawing.SystemColors.Control;
            this.rtbInnDescription.Location = new System.Drawing.Point(13, 13);
            this.rtbInnDescription.Name = "rtbInnDescription";
            this.rtbInnDescription.ReadOnly = true;
            this.rtbInnDescription.Size = new System.Drawing.Size(510, 96);
            this.rtbInnDescription.TabIndex = 0;
            this.rtbInnDescription.Text = "";
            // 
            // rtbInnMessage
            // 
            this.rtbInnMessage.BackColor = System.Drawing.SystemColors.Control;
            this.rtbInnMessage.Location = new System.Drawing.Point(13, 116);
            this.rtbInnMessage.Name = "rtbInnMessage";
            this.rtbInnMessage.Size = new System.Drawing.Size(510, 96);
            this.rtbInnMessage.TabIndex = 1;
            this.rtbInnMessage.Text = "";
            // 
            // btnInnYes
            // 
            this.btnInnYes.Location = new System.Drawing.Point(170, 218);
            this.btnInnYes.Name = "btnInnYes";
            this.btnInnYes.Size = new System.Drawing.Size(75, 23);
            this.btnInnYes.TabIndex = 2;
            this.btnInnYes.Text = "Heal";
            this.btnInnYes.UseVisualStyleBackColor = true;
            this.btnInnYes.Click += new System.EventHandler(this.btnInnYes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cost to stay here:";
            // 
            // lblInnCost
            // 
            this.lblInnCost.AutoSize = true;
            this.lblInnCost.Location = new System.Drawing.Point(109, 227);
            this.lblInnCost.Name = "lblInnCost";
            this.lblInnCost.Size = new System.Drawing.Size(0, 13);
            this.lblInnCost.TabIndex = 4;
            // 
            // btnInnNo
            // 
            this.btnInnNo.Location = new System.Drawing.Point(339, 218);
            this.btnInnNo.Name = "btnInnNo";
            this.btnInnNo.Size = new System.Drawing.Size(75, 23);
            this.btnInnNo.TabIndex = 5;
            this.btnInnNo.Text = "Leave";
            this.btnInnNo.UseVisualStyleBackColor = true;
            this.btnInnNo.Click += new System.EventHandler(this.btnInnNo_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(255, 218);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(75, 23);
            this.btnReturn.TabIndex = 6;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // InnScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 256);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnInnNo);
            this.Controls.Add(this.lblInnCost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInnYes);
            this.Controls.Add(this.rtbInnMessage);
            this.Controls.Add(this.rtbInnDescription);
            this.Name = "InnScreen";
            this.Text = "InnScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbInnDescription;
        private System.Windows.Forms.RichTextBox rtbInnMessage;
        private System.Windows.Forms.Button btnInnYes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInnCost;
        private System.Windows.Forms.Button btnInnNo;
        private System.Windows.Forms.Button btnReturn;
    }
}