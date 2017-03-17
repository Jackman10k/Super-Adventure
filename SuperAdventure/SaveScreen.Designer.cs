namespace SuperAdventure
{
    partial class SaveScreen
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
            this.rtbSaveScreen = new System.Windows.Forms.RichTextBox();
            this.btnSaveYes = new System.Windows.Forms.Button();
            this.btnSaveNo = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbSaveScreen
            // 
            this.rtbSaveScreen.BackColor = System.Drawing.SystemColors.Control;
            this.rtbSaveScreen.Location = new System.Drawing.Point(12, 12);
            this.rtbSaveScreen.Name = "rtbSaveScreen";
            this.rtbSaveScreen.ReadOnly = true;
            this.rtbSaveScreen.Size = new System.Drawing.Size(237, 21);
            this.rtbSaveScreen.TabIndex = 0;
            this.rtbSaveScreen.Text = "";
            // 
            // btnSaveYes
            // 
            this.btnSaveYes.Location = new System.Drawing.Point(12, 39);
            this.btnSaveYes.Name = "btnSaveYes";
            this.btnSaveYes.Size = new System.Drawing.Size(75, 23);
            this.btnSaveYes.TabIndex = 1;
            this.btnSaveYes.Text = "Yes";
            this.btnSaveYes.UseVisualStyleBackColor = true;
            this.btnSaveYes.Click += new System.EventHandler(this.btnSaveYes_Click);
            // 
            // btnSaveNo
            // 
            this.btnSaveNo.Location = new System.Drawing.Point(174, 39);
            this.btnSaveNo.Name = "btnSaveNo";
            this.btnSaveNo.Size = new System.Drawing.Size(75, 23);
            this.btnSaveNo.TabIndex = 2;
            this.btnSaveNo.Text = "No";
            this.btnSaveNo.UseVisualStyleBackColor = true;
            this.btnSaveNo.Click += new System.EventHandler(this.btnSaveNo_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(93, 39);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Return";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SaveScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 71);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveNo);
            this.Controls.Add(this.btnSaveYes);
            this.Controls.Add(this.rtbSaveScreen);
            this.Name = "SaveScreen";
            this.Text = "Save Game";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbSaveScreen;
        private System.Windows.Forms.Button btnSaveYes;
        private System.Windows.Forms.Button btnSaveNo;
        private System.Windows.Forms.Button btnClose;
    }
}