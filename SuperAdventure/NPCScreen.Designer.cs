namespace SuperAdventure
{
    partial class NPCScreen
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
            this.btnNPC1 = new System.Windows.Forms.Button();
            this.btnNPC2 = new System.Windows.Forms.Button();
            this.btnNPC3 = new System.Windows.Forms.Button();
            this.lblNPC1 = new System.Windows.Forms.Label();
            this.lblNPC2 = new System.Windows.Forms.Label();
            this.lblNPC3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNPC1
            // 
            this.btnNPC1.Location = new System.Drawing.Point(12, 44);
            this.btnNPC1.Name = "btnNPC1";
            this.btnNPC1.Size = new System.Drawing.Size(75, 23);
            this.btnNPC1.TabIndex = 0;
            this.btnNPC1.Text = "Talk";
            this.btnNPC1.UseVisualStyleBackColor = true;
            this.btnNPC1.Click += new System.EventHandler(this.btnNPC1_Click);
            // 
            // btnNPC2
            // 
            this.btnNPC2.Location = new System.Drawing.Point(176, 44);
            this.btnNPC2.Name = "btnNPC2";
            this.btnNPC2.Size = new System.Drawing.Size(75, 23);
            this.btnNPC2.TabIndex = 1;
            this.btnNPC2.Text = "Talk";
            this.btnNPC2.UseVisualStyleBackColor = true;
            this.btnNPC2.Click += new System.EventHandler(this.btnNPC2_Click);
            // 
            // btnNPC3
            // 
            this.btnNPC3.Location = new System.Drawing.Point(93, 115);
            this.btnNPC3.Name = "btnNPC3";
            this.btnNPC3.Size = new System.Drawing.Size(75, 23);
            this.btnNPC3.TabIndex = 2;
            this.btnNPC3.Text = "Talk";
            this.btnNPC3.UseVisualStyleBackColor = true;
            this.btnNPC3.Click += new System.EventHandler(this.btnNPC3_Click);
            // 
            // lblNPC1
            // 
            this.lblNPC1.AutoSize = true;
            this.lblNPC1.Location = new System.Drawing.Point(11, 25);
            this.lblNPC1.Name = "lblNPC1";
            this.lblNPC1.Size = new System.Drawing.Size(0, 13);
            this.lblNPC1.TabIndex = 3;
            // 
            // lblNPC2
            // 
            this.lblNPC2.AutoSize = true;
            this.lblNPC2.Location = new System.Drawing.Point(173, 25);
            this.lblNPC2.Name = "lblNPC2";
            this.lblNPC2.Size = new System.Drawing.Size(0, 13);
            this.lblNPC2.TabIndex = 4;
            // 
            // lblNPC3
            // 
            this.lblNPC3.AutoSize = true;
            this.lblNPC3.Location = new System.Drawing.Point(93, 96);
            this.lblNPC3.Name = "lblNPC3";
            this.lblNPC3.Size = new System.Drawing.Size(0, 13);
            this.lblNPC3.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(190, 163);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // NPCScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 198);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblNPC3);
            this.Controls.Add(this.lblNPC2);
            this.Controls.Add(this.lblNPC1);
            this.Controls.Add(this.btnNPC3);
            this.Controls.Add(this.btnNPC2);
            this.Controls.Add(this.btnNPC1);
            this.Name = "NPCScreen";
            this.Text = "Converse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNPC1;
        private System.Windows.Forms.Button btnNPC2;
        private System.Windows.Forms.Button btnNPC3;
        private System.Windows.Forms.Label lblNPC1;
        private System.Windows.Forms.Label lblNPC2;
        private System.Windows.Forms.Label lblNPC3;
        private System.Windows.Forms.Button btnClose;
    }
}