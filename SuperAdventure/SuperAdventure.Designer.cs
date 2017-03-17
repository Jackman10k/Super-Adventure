namespace SuperAdventure
{
    partial class SuperAdventure
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCurrentHitPoints = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboWeapons = new System.Windows.Forms.ComboBox();
            this.cboConsumables = new System.Windows.Forms.ComboBox();
            this.btnUseWeapon = new System.Windows.Forms.Button();
            this.btnUseConsumable = new System.Windows.Forms.Button();
            this.btnNorth = new System.Windows.Forms.Button();
            this.btnEast = new System.Windows.Forms.Button();
            this.btnSouth = new System.Windows.Forms.Button();
            this.btnWest = new System.Windows.Forms.Button();
            this.rtbLocation = new System.Windows.Forms.RichTextBox();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.dgvQuests = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCurrentAbilityPoints = new System.Windows.Forms.Label();
            this.lblToNextLevel = new System.Windows.Forms.Label();
            this.rtbMonsterStatistics1 = new System.Windows.Forms.RichTextBox();
            this.rtbCombatMessages = new System.Windows.Forms.RichTextBox();
            this.btnUseAbility = new System.Windows.Forms.Button();
            this.cboAbilities = new System.Windows.Forms.ComboBox();
            this.rtbEquipDescription = new System.Windows.Forms.RichTextBox();
            this.rtbAdvice = new System.Windows.Forms.RichTextBox();
            this.btnSaveGame = new System.Windows.Forms.Button();
            this.rtbMonsterStatistics2 = new System.Windows.Forms.RichTextBox();
            this.btnTrade = new System.Windows.Forms.Button();
            this.btnRest = new System.Windows.Forms.Button();
            this.rtbMouseOverDescription = new System.Windows.Forms.RichTextBox();
            this.btnStatDetails = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMaximumHitPoints = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblMaximumAbilityPoints = new System.Windows.Forms.Label();
            this.btnTalk = new System.Windows.Forms.Button();
            this.btnCombine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hit Points:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gold:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Experience:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Level:";
            // 
            // lblCurrentHitPoints
            // 
            this.lblCurrentHitPoints.AutoSize = true;
            this.lblCurrentHitPoints.Location = new System.Drawing.Point(88, 20);
            this.lblCurrentHitPoints.Name = "lblCurrentHitPoints";
            this.lblCurrentHitPoints.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentHitPoints.TabIndex = 4;
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(88, 46);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(0, 13);
            this.lblGold.TabIndex = 5;
            // 
            // lblExperience
            // 
            this.lblExperience.AutoSize = true;
            this.lblExperience.Location = new System.Drawing.Point(264, 46);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(0, 13);
            this.lblExperience.TabIndex = 6;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(88, 73);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(0, 13);
            this.lblLevel.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1035, 433);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Select Action";
            // 
            // cboWeapons
            // 
            this.cboWeapons.FormattingEnabled = true;
            this.cboWeapons.Location = new System.Drawing.Point(787, 461);
            this.cboWeapons.Name = "cboWeapons";
            this.cboWeapons.Size = new System.Drawing.Size(121, 21);
            this.cboWeapons.TabIndex = 9;
            this.cboWeapons.SelectedIndexChanged += new System.EventHandler(this.cboWeapons_SelectedIndexChanged);
            // 
            // cboConsumables
            // 
            this.cboConsumables.FormattingEnabled = true;
            this.cboConsumables.Location = new System.Drawing.Point(787, 495);
            this.cboConsumables.Name = "cboConsumables";
            this.cboConsumables.Size = new System.Drawing.Size(121, 21);
            this.cboConsumables.TabIndex = 10;
            this.cboConsumables.SelectedIndexChanged += new System.EventHandler(this.cboConsumables_SelectedIndexChanged);
            // 
            // btnUseWeapon
            // 
            this.btnUseWeapon.Location = new System.Drawing.Point(1038, 461);
            this.btnUseWeapon.Name = "btnUseWeapon";
            this.btnUseWeapon.Size = new System.Drawing.Size(75, 23);
            this.btnUseWeapon.TabIndex = 11;
            this.btnUseWeapon.Text = "Use";
            this.btnUseWeapon.UseVisualStyleBackColor = true;
            this.btnUseWeapon.Click += new System.EventHandler(this.btnUseWeapon_Click);
            // 
            // btnUseConsumable
            // 
            this.btnUseConsumable.Location = new System.Drawing.Point(1038, 495);
            this.btnUseConsumable.Name = "btnUseConsumable";
            this.btnUseConsumable.Size = new System.Drawing.Size(75, 23);
            this.btnUseConsumable.TabIndex = 12;
            this.btnUseConsumable.Text = "Use";
            this.btnUseConsumable.UseVisualStyleBackColor = true;
            this.btnUseConsumable.Click += new System.EventHandler(this.btnUseConsumable_Click);
            // 
            // btnNorth
            // 
            this.btnNorth.Location = new System.Drawing.Point(493, 433);
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.Size = new System.Drawing.Size(75, 23);
            this.btnNorth.TabIndex = 13;
            this.btnNorth.Text = "North";
            this.btnNorth.UseVisualStyleBackColor = true;
            this.btnNorth.Click += new System.EventHandler(this.btnNorth_Click);
            this.btnNorth.MouseEnter += btnNorth_MouseEnter;
            this.btnNorth.MouseLeave += btnNorth_MouseLeave;
            // 
            // btnEast
            // 
            this.btnEast.Location = new System.Drawing.Point(573, 457);
            this.btnEast.Name = "btnEast";
            this.btnEast.Size = new System.Drawing.Size(75, 23);
            this.btnEast.TabIndex = 14;
            this.btnEast.Text = "East";
            this.btnEast.UseVisualStyleBackColor = true;
            this.btnEast.Click += new System.EventHandler(this.btnEast_Click);
            this.btnEast.MouseEnter += btnEast_MouseEnter;
            this.btnEast.MouseLeave += btnEast_MouseLeave;
            // 
            // btnSouth
            // 
            this.btnSouth.Location = new System.Drawing.Point(493, 487);
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.Size = new System.Drawing.Size(75, 23);
            this.btnSouth.TabIndex = 15;
            this.btnSouth.Text = "South";
            this.btnSouth.UseVisualStyleBackColor = true;
            this.btnSouth.Click += new System.EventHandler(this.btnSouth_Click);
            this.btnSouth.MouseEnter += btnSouth_MouseEnter;
            this.btnSouth.MouseLeave += btnSouth_MouseLeave;
            // 
            // btnWest
            // 
            this.btnWest.Location = new System.Drawing.Point(412, 457);
            this.btnWest.Name = "btnWest";
            this.btnWest.Size = new System.Drawing.Size(75, 23);
            this.btnWest.TabIndex = 16;
            this.btnWest.Text = "West";
            this.btnWest.UseVisualStyleBackColor = true;
            this.btnWest.Click += new System.EventHandler(this.btnWest_Click);
            this.btnWest.MouseEnter += btnWest_MouseEnter;
            this.btnWest.MouseLeave += btnWest_MouseLeave;
            // 
            // rtbLocation
            // 
            this.rtbLocation.Location = new System.Drawing.Point(335, 17);
            this.rtbLocation.Name = "rtbLocation";
            this.rtbLocation.ReadOnly = true;
            this.rtbLocation.Size = new System.Drawing.Size(398, 105);
            this.rtbLocation.TabIndex = 17;
            this.rtbLocation.Text = "";
            // 
            // rtbMessages
            // 
            this.rtbMessages.Location = new System.Drawing.Point(334, 130);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.Size = new System.Drawing.Size(398, 286);
            this.rtbMessages.TabIndex = 18;
            this.rtbMessages.Text = "";
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AllowUserToResizeColumns = false;
            this.dgvInventory.AllowUserToResizeRows = false;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInventory.Enabled = false;
            this.dgvInventory.Location = new System.Drawing.Point(16, 130);
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.Size = new System.Drawing.Size(312, 286);
            this.dgvInventory.TabIndex = 19;
            // 
            // dgvQuests
            // 
            this.dgvQuests.AllowUserToAddRows = false;
            this.dgvQuests.AllowUserToDeleteRows = false;
            this.dgvQuests.AllowUserToResizeColumns = false;
            this.dgvQuests.AllowUserToResizeRows = false;
            this.dgvQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvQuests.Enabled = false;
            this.dgvQuests.Location = new System.Drawing.Point(16, 422);
            this.dgvQuests.MultiSelect = false;
            this.dgvQuests.Name = "dgvQuests";
            this.dgvQuests.ReadOnly = true;
            this.dgvQuests.RowHeadersVisible = false;
            this.dgvQuests.Size = new System.Drawing.Size(312, 143);
            this.dgvQuests.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(180, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Ability Points:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(180, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "To Next Level:";
            // 
            // lblCurrentAbilityPoints
            // 
            this.lblCurrentAbilityPoints.AutoSize = true;
            this.lblCurrentAbilityPoints.Location = new System.Drawing.Point(264, 20);
            this.lblCurrentAbilityPoints.Name = "lblCurrentAbilityPoints";
            this.lblCurrentAbilityPoints.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentAbilityPoints.TabIndex = 24;
            // 
            // lblToNextLevel
            // 
            this.lblToNextLevel.AutoSize = true;
            this.lblToNextLevel.Location = new System.Drawing.Point(264, 73);
            this.lblToNextLevel.Name = "lblToNextLevel";
            this.lblToNextLevel.Size = new System.Drawing.Size(0, 13);
            this.lblToNextLevel.TabIndex = 26;
            // 
            // rtbMonsterStatistics1
            // 
            this.rtbMonsterStatistics1.BackColor = System.Drawing.SystemColors.Control;
            this.rtbMonsterStatistics1.Location = new System.Drawing.Point(738, 17);
            this.rtbMonsterStatistics1.Name = "rtbMonsterStatistics1";
            this.rtbMonsterStatistics1.ReadOnly = true;
            this.rtbMonsterStatistics1.Size = new System.Drawing.Size(208, 105);
            this.rtbMonsterStatistics1.TabIndex = 29;
            this.rtbMonsterStatistics1.Text = "";
            // 
            // rtbCombatMessages
            // 
            this.rtbCombatMessages.BackColor = System.Drawing.SystemColors.Control;
            this.rtbCombatMessages.Location = new System.Drawing.Point(738, 130);
            this.rtbCombatMessages.Name = "rtbCombatMessages";
            this.rtbCombatMessages.ReadOnly = true;
            this.rtbCombatMessages.Size = new System.Drawing.Size(421, 286);
            this.rtbCombatMessages.TabIndex = 30;
            this.rtbCombatMessages.Text = "";
            // 
            // btnUseAbility
            // 
            this.btnUseAbility.Location = new System.Drawing.Point(1038, 529);
            this.btnUseAbility.Name = "btnUseAbility";
            this.btnUseAbility.Size = new System.Drawing.Size(75, 23);
            this.btnUseAbility.TabIndex = 31;
            this.btnUseAbility.Text = "Use";
            this.btnUseAbility.UseVisualStyleBackColor = true;
            this.btnUseAbility.Click += new System.EventHandler(this.btnUseAbility_Click);
            // 
            // cboAbilities
            // 
            this.cboAbilities.FormattingEnabled = true;
            this.cboAbilities.Location = new System.Drawing.Point(787, 529);
            this.cboAbilities.Name = "cboAbilities";
            this.cboAbilities.Size = new System.Drawing.Size(121, 21);
            this.cboAbilities.TabIndex = 32;
            this.cboAbilities.SelectedIndexChanged += new System.EventHandler(this.cboAbilities_SelectedIndexChanged);
            // 
            // rtbEquipDescription
            // 
            this.rtbEquipDescription.BackColor = System.Drawing.SystemColors.Control;
            this.rtbEquipDescription.Location = new System.Drawing.Point(738, 571);
            this.rtbEquipDescription.Name = "rtbEquipDescription";
            this.rtbEquipDescription.ReadOnly = true;
            this.rtbEquipDescription.Size = new System.Drawing.Size(421, 69);
            this.rtbEquipDescription.TabIndex = 33;
            this.rtbEquipDescription.Text = "";
            // 
            // rtbAdvice
            // 
            this.rtbAdvice.BackColor = System.Drawing.SystemColors.Control;
            this.rtbAdvice.Location = new System.Drawing.Point(16, 571);
            this.rtbAdvice.Name = "rtbAdvice";
            this.rtbAdvice.ReadOnly = true;
            this.rtbAdvice.Size = new System.Drawing.Size(312, 69);
            this.rtbAdvice.TabIndex = 34;
            this.rtbAdvice.Text = "";
            // 
            // btnSaveGame
            // 
            this.btnSaveGame.Location = new System.Drawing.Point(496, 542);
            this.btnSaveGame.Name = "btnSaveGame";
            this.btnSaveGame.Size = new System.Drawing.Size(75, 23);
            this.btnSaveGame.TabIndex = 35;
            this.btnSaveGame.Text = "Save Game";
            this.btnSaveGame.UseVisualStyleBackColor = true;
            this.btnSaveGame.Click += new System.EventHandler(this.btnSaveGame_Click);
            // 
            // rtbMonsterStatistics2
            // 
            this.rtbMonsterStatistics2.BackColor = System.Drawing.SystemColors.Control;
            this.rtbMonsterStatistics2.Location = new System.Drawing.Point(951, 19);
            this.rtbMonsterStatistics2.Name = "rtbMonsterStatistics2";
            this.rtbMonsterStatistics2.Size = new System.Drawing.Size(208, 105);
            this.rtbMonsterStatistics2.TabIndex = 36;
            this.rtbMonsterStatistics2.Text = "";
            // 
            // btnTrade
            // 
            this.btnTrade.Location = new System.Drawing.Point(415, 542);
            this.btnTrade.Name = "btnTrade";
            this.btnTrade.Size = new System.Drawing.Size(75, 23);
            this.btnTrade.TabIndex = 21;
            this.btnTrade.Text = "Trade";
            this.btnTrade.UseVisualStyleBackColor = true;
            this.btnTrade.Click += new System.EventHandler(this.btnTrade_Click);
            // 
            // btnRest
            // 
            this.btnRest.Location = new System.Drawing.Point(577, 542);
            this.btnRest.Name = "btnRest";
            this.btnRest.Size = new System.Drawing.Size(75, 23);
            this.btnRest.TabIndex = 37;
            this.btnRest.Text = "Rest";
            this.btnRest.UseVisualStyleBackColor = true;
            this.btnRest.Click += new System.EventHandler(this.btnRest_Click);
            // 
            // rtbMouseOverDescription
            // 
            this.rtbMouseOverDescription.BackColor = System.Drawing.SystemColors.Control;
            this.rtbMouseOverDescription.Location = new System.Drawing.Point(334, 571);
            this.rtbMouseOverDescription.Name = "rtbMouseOverDescription";
            this.rtbMouseOverDescription.ReadOnly = true;
            this.rtbMouseOverDescription.Size = new System.Drawing.Size(398, 69);
            this.rtbMouseOverDescription.TabIndex = 38;
            this.rtbMouseOverDescription.Text = "";
            // 
            // btnStatDetails
            // 
            this.btnStatDetails.Location = new System.Drawing.Point(182, 94);
            this.btnStatDetails.Name = "btnStatDetails";
            this.btnStatDetails.Size = new System.Drawing.Size(75, 23);
            this.btnStatDetails.TabIndex = 39;
            this.btnStatDetails.Text = "More Details";
            this.btnStatDetails.UseVisualStyleBackColor = true;
            this.btnStatDetails.Click += new System.EventHandler(this.btnStatDetails_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(103, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "/";
            // 
            // lblMaximumHitPoints
            // 
            this.lblMaximumHitPoints.AutoSize = true;
            this.lblMaximumHitPoints.Location = new System.Drawing.Point(112, 20);
            this.lblMaximumHitPoints.Name = "lblMaximumHitPoints";
            this.lblMaximumHitPoints.Size = new System.Drawing.Size(0, 13);
            this.lblMaximumHitPoints.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(279, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "/";
            // 
            // lblMaximumAbilityPoints
            // 
            this.lblMaximumAbilityPoints.AutoSize = true;
            this.lblMaximumAbilityPoints.Location = new System.Drawing.Point(287, 20);
            this.lblMaximumAbilityPoints.Name = "lblMaximumAbilityPoints";
            this.lblMaximumAbilityPoints.Size = new System.Drawing.Size(0, 13);
            this.lblMaximumAbilityPoints.TabIndex = 43;
            // 
            // btnTalk
            // 
            this.btnTalk.Location = new System.Drawing.Point(334, 542);
            this.btnTalk.Name = "btnTalk";
            this.btnTalk.Size = new System.Drawing.Size(75, 23);
            this.btnTalk.TabIndex = 44;
            this.btnTalk.Text = "Talk";
            this.btnTalk.UseVisualStyleBackColor = true;
            this.btnTalk.Click += new System.EventHandler(this.btnTalk_Click);
            // 
            // btnCombine
            // 
            this.btnCombine.Location = new System.Drawing.Point(658, 542);
            this.btnCombine.Name = "btnCombine";
            this.btnCombine.Size = new System.Drawing.Size(75, 23);
            this.btnCombine.TabIndex = 45;
            this.btnCombine.Text = "Combine";
            this.btnCombine.UseVisualStyleBackColor = true;
            this.btnCombine.Click += new System.EventHandler(this.btnCombine_Click);
            // 
            // SuperAdventure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 652);
            this.Controls.Add(this.btnCombine);
            this.Controls.Add(this.btnTalk);
            this.Controls.Add(this.lblMaximumAbilityPoints);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblMaximumHitPoints);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnStatDetails);
            this.Controls.Add(this.rtbMouseOverDescription);
            this.Controls.Add(this.btnRest);
            this.Controls.Add(this.rtbMonsterStatistics2);
            this.Controls.Add(this.btnSaveGame);
            this.Controls.Add(this.rtbAdvice);
            this.Controls.Add(this.rtbEquipDescription);
            this.Controls.Add(this.cboAbilities);
            this.Controls.Add(this.btnUseAbility);
            this.Controls.Add(this.rtbCombatMessages);
            this.Controls.Add(this.rtbMonsterStatistics1);
            this.Controls.Add(this.lblToNextLevel);
            this.Controls.Add(this.lblCurrentAbilityPoints);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvQuests);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.rtbLocation);
            this.Controls.Add(this.btnWest);
            this.Controls.Add(this.btnSouth);
            this.Controls.Add(this.btnEast);
            this.Controls.Add(this.btnNorth);
            this.Controls.Add(this.btnUseConsumable);
            this.Controls.Add(this.btnUseWeapon);
            this.Controls.Add(this.cboConsumables);
            this.Controls.Add(this.cboWeapons);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblExperience);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.lblCurrentHitPoints);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTrade);
            this.Name = "SuperAdventure";
            this.Text = "SuperAdventure";
            this.Load += new System.EventHandler(this.SuperAdventure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCurrentHitPoints;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboWeapons;
        private System.Windows.Forms.ComboBox cboConsumables;
        private System.Windows.Forms.Button btnUseWeapon;
        private System.Windows.Forms.Button btnUseConsumable;
        private System.Windows.Forms.Button btnNorth;
        private System.Windows.Forms.Button btnEast;
        private System.Windows.Forms.Button btnSouth;
        private System.Windows.Forms.Button btnWest;
        private System.Windows.Forms.RichTextBox rtbLocation;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.DataGridView dgvQuests;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCurrentAbilityPoints;
        private System.Windows.Forms.Label lblToNextLevel;
        private System.Windows.Forms.RichTextBox rtbMonsterStatistics1;
        private System.Windows.Forms.RichTextBox rtbCombatMessages;
        private System.Windows.Forms.Button btnUseAbility;
        private System.Windows.Forms.ComboBox cboAbilities;
        private System.Windows.Forms.RichTextBox rtbEquipDescription;
        private System.Windows.Forms.RichTextBox rtbAdvice;
        private System.Windows.Forms.Button btnSaveGame;
        private System.Windows.Forms.RichTextBox rtbMonsterStatistics2;
        private System.Windows.Forms.Button btnTrade;
        private System.Windows.Forms.Button btnRest;
        private System.Windows.Forms.RichTextBox rtbMouseOverDescription;
        private System.Windows.Forms.Button btnStatDetails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMaximumHitPoints;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblMaximumAbilityPoints;
        private System.Windows.Forms.Button btnTalk;
        private System.Windows.Forms.Button btnCombine;
    }
}

