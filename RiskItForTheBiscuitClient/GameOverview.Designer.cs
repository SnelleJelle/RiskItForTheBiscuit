namespace RiskItForTheBiscuit.Risk
{
    partial class GameOverview
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEndTurn = new System.Windows.Forms.Button();
            this.lblCurrentPlayer = new System.Windows.Forms.Label();
            this.lblCurrentPlayerName = new System.Windows.Forms.Label();
            this.lblSelectedTerritory = new System.Windows.Forms.Label();
            this.lblCurrentSelectedTerritory = new System.Windows.Forms.Label();
            this.lblDefending = new System.Windows.Forms.Label();
            this.lblAttacking = new System.Windows.Forms.Label();
            this.lblDefendingTerritoryName = new System.Windows.Forms.Label();
            this.lblAttackingTerritoryName = new System.Windows.Forms.Label();
            this.lblDefenderTroops = new System.Windows.Forms.Label();
            this.lblAttackerTroops = new System.Windows.Forms.Label();
            this.lblDefenderTroopsAmount = new System.Windows.Forms.Label();
            this.lblAttackerTroopsAmount = new System.Windows.Forms.Label();
            this.grpBattle = new System.Windows.Forms.GroupBox();
            this.btnResolveOne = new System.Windows.Forms.Button();
            this.grpBattle.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEndTurn
            // 
            this.btnEndTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEndTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndTurn.Location = new System.Drawing.Point(205, 611);
            this.btnEndTurn.Name = "btnEndTurn";
            this.btnEndTurn.Size = new System.Drawing.Size(112, 36);
            this.btnEndTurn.TabIndex = 0;
            this.btnEndTurn.Text = "End Turn";
            this.btnEndTurn.UseVisualStyleBackColor = true;
            this.btnEndTurn.Click += new System.EventHandler(this.btnEndTurn_Click);
            // 
            // lblCurrentPlayer
            // 
            this.lblCurrentPlayer.AutoSize = true;
            this.lblCurrentPlayer.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPlayer.ForeColor = System.Drawing.Color.White;
            this.lblCurrentPlayer.Location = new System.Drawing.Point(4, 4);
            this.lblCurrentPlayer.Name = "lblCurrentPlayer";
            this.lblCurrentPlayer.Size = new System.Drawing.Size(109, 16);
            this.lblCurrentPlayer.TabIndex = 1;
            this.lblCurrentPlayer.Text = "Current player:";
            // 
            // lblCurrentPlayerName
            // 
            this.lblCurrentPlayerName.AutoSize = true;
            this.lblCurrentPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPlayerName.ForeColor = System.Drawing.Color.White;
            this.lblCurrentPlayerName.Location = new System.Drawing.Point(129, 4);
            this.lblCurrentPlayerName.Name = "lblCurrentPlayerName";
            this.lblCurrentPlayerName.Size = new System.Drawing.Size(134, 16);
            this.lblCurrentPlayerName.TabIndex = 2;
            this.lblCurrentPlayerName.Text = "SomePlayerName";
            // 
            // lblSelectedTerritory
            // 
            this.lblSelectedTerritory.AutoSize = true;
            this.lblSelectedTerritory.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedTerritory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedTerritory.ForeColor = System.Drawing.Color.White;
            this.lblSelectedTerritory.Location = new System.Drawing.Point(4, 29);
            this.lblSelectedTerritory.Name = "lblSelectedTerritory";
            this.lblSelectedTerritory.Size = new System.Drawing.Size(120, 15);
            this.lblSelectedTerritory.TabIndex = 3;
            this.lblSelectedTerritory.Text = "Selected territory:";
            // 
            // lblCurrentSelectedTerritory
            // 
            this.lblCurrentSelectedTerritory.AutoSize = true;
            this.lblCurrentSelectedTerritory.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentSelectedTerritory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSelectedTerritory.ForeColor = System.Drawing.Color.White;
            this.lblCurrentSelectedTerritory.Location = new System.Drawing.Point(129, 29);
            this.lblCurrentSelectedTerritory.Name = "lblCurrentSelectedTerritory";
            this.lblCurrentSelectedTerritory.Size = new System.Drawing.Size(143, 15);
            this.lblCurrentSelectedTerritory.TabIndex = 4;
            this.lblCurrentSelectedTerritory.Text = "Some Territory Name";
            // 
            // lblDefending
            // 
            this.lblDefending.AutoSize = true;
            this.lblDefending.BackColor = System.Drawing.Color.Transparent;
            this.lblDefending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefending.ForeColor = System.Drawing.Color.White;
            this.lblDefending.Location = new System.Drawing.Point(16, 27);
            this.lblDefending.Name = "lblDefending";
            this.lblDefending.Size = new System.Drawing.Size(140, 16);
            this.lblDefending.TabIndex = 6;
            this.lblDefending.Text = "Defending territory:";
            // 
            // lblAttacking
            // 
            this.lblAttacking.AutoSize = true;
            this.lblAttacking.BackColor = System.Drawing.Color.Transparent;
            this.lblAttacking.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttacking.ForeColor = System.Drawing.Color.White;
            this.lblAttacking.Location = new System.Drawing.Point(16, 87);
            this.lblAttacking.Name = "lblAttacking";
            this.lblAttacking.Size = new System.Drawing.Size(133, 16);
            this.lblAttacking.TabIndex = 7;
            this.lblAttacking.Text = "Attacking territory:";
            // 
            // lblDefendingTerritoryName
            // 
            this.lblDefendingTerritoryName.AutoSize = true;
            this.lblDefendingTerritoryName.BackColor = System.Drawing.Color.Transparent;
            this.lblDefendingTerritoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefendingTerritoryName.ForeColor = System.Drawing.Color.White;
            this.lblDefendingTerritoryName.Location = new System.Drawing.Point(162, 28);
            this.lblDefendingTerritoryName.Name = "lblDefendingTerritoryName";
            this.lblDefendingTerritoryName.Size = new System.Drawing.Size(143, 15);
            this.lblDefendingTerritoryName.TabIndex = 8;
            this.lblDefendingTerritoryName.Text = "Some Territory Name";
            // 
            // lblAttackingTerritoryName
            // 
            this.lblAttackingTerritoryName.AutoSize = true;
            this.lblAttackingTerritoryName.BackColor = System.Drawing.Color.Transparent;
            this.lblAttackingTerritoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttackingTerritoryName.ForeColor = System.Drawing.Color.White;
            this.lblAttackingTerritoryName.Location = new System.Drawing.Point(162, 88);
            this.lblAttackingTerritoryName.Name = "lblAttackingTerritoryName";
            this.lblAttackingTerritoryName.Size = new System.Drawing.Size(143, 15);
            this.lblAttackingTerritoryName.TabIndex = 9;
            this.lblAttackingTerritoryName.Text = "Some Territory Name";
            // 
            // lblDefenderTroops
            // 
            this.lblDefenderTroops.AutoSize = true;
            this.lblDefenderTroops.BackColor = System.Drawing.Color.Transparent;
            this.lblDefenderTroops.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefenderTroops.ForeColor = System.Drawing.Color.White;
            this.lblDefenderTroops.Location = new System.Drawing.Point(94, 54);
            this.lblDefenderTroops.Name = "lblDefenderTroops";
            this.lblDefenderTroops.Size = new System.Drawing.Size(55, 15);
            this.lblDefenderTroops.TabIndex = 10;
            this.lblDefenderTroops.Text = "Troops:";
            // 
            // lblAttackerTroops
            // 
            this.lblAttackerTroops.AutoSize = true;
            this.lblAttackerTroops.BackColor = System.Drawing.Color.Transparent;
            this.lblAttackerTroops.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttackerTroops.ForeColor = System.Drawing.Color.White;
            this.lblAttackerTroops.Location = new System.Drawing.Point(94, 113);
            this.lblAttackerTroops.Name = "lblAttackerTroops";
            this.lblAttackerTroops.Size = new System.Drawing.Size(55, 15);
            this.lblAttackerTroops.TabIndex = 11;
            this.lblAttackerTroops.Text = "Troops:";
            // 
            // lblDefenderTroopsAmount
            // 
            this.lblDefenderTroopsAmount.AutoSize = true;
            this.lblDefenderTroopsAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblDefenderTroopsAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefenderTroopsAmount.ForeColor = System.Drawing.Color.White;
            this.lblDefenderTroopsAmount.Location = new System.Drawing.Point(162, 54);
            this.lblDefenderTroopsAmount.Name = "lblDefenderTroopsAmount";
            this.lblDefenderTroopsAmount.Size = new System.Drawing.Size(16, 15);
            this.lblDefenderTroopsAmount.TabIndex = 12;
            this.lblDefenderTroopsAmount.Text = "X";
            // 
            // lblAttackerTroopsAmount
            // 
            this.lblAttackerTroopsAmount.AutoSize = true;
            this.lblAttackerTroopsAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblAttackerTroopsAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttackerTroopsAmount.ForeColor = System.Drawing.Color.White;
            this.lblAttackerTroopsAmount.Location = new System.Drawing.Point(162, 113);
            this.lblAttackerTroopsAmount.Name = "lblAttackerTroopsAmount";
            this.lblAttackerTroopsAmount.Size = new System.Drawing.Size(15, 15);
            this.lblAttackerTroopsAmount.TabIndex = 13;
            this.lblAttackerTroopsAmount.Text = "Y";
            // 
            // grpBattle
            // 
            this.grpBattle.BackColor = System.Drawing.Color.Transparent;
            this.grpBattle.Controls.Add(this.btnResolveOne);
            this.grpBattle.Controls.Add(this.lblAttackingTerritoryName);
            this.grpBattle.Controls.Add(this.lblAttackerTroopsAmount);
            this.grpBattle.Controls.Add(this.lblDefending);
            this.grpBattle.Controls.Add(this.lblDefenderTroopsAmount);
            this.grpBattle.Controls.Add(this.lblAttacking);
            this.grpBattle.Controls.Add(this.lblAttackerTroops);
            this.grpBattle.Controls.Add(this.lblDefendingTerritoryName);
            this.grpBattle.Controls.Add(this.lblDefenderTroops);
            this.grpBattle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBattle.ForeColor = System.Drawing.Color.White;
            this.grpBattle.Location = new System.Drawing.Point(7, 60);
            this.grpBattle.Name = "grpBattle";
            this.grpBattle.Size = new System.Drawing.Size(310, 176);
            this.grpBattle.TabIndex = 14;
            this.grpBattle.TabStop = false;
            this.grpBattle.Text = "Battle";
            // 
            // btnResolveOne
            // 
            this.btnResolveOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResolveOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResolveOne.ForeColor = System.Drawing.Color.Black;
            this.btnResolveOne.Location = new System.Drawing.Point(214, 145);
            this.btnResolveOne.Name = "btnResolveOne";
            this.btnResolveOne.Size = new System.Drawing.Size(90, 25);
            this.btnResolveOne.TabIndex = 15;
            this.btnResolveOne.Text = "Resolve";
            this.btnResolveOne.UseVisualStyleBackColor = true;
            this.btnResolveOne.Click += new System.EventHandler(this.btnResolveOne_Click);
            // 
            // GameOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Controls.Add(this.grpBattle);
            this.Controls.Add(this.lblCurrentSelectedTerritory);
            this.Controls.Add(this.lblSelectedTerritory);
            this.Controls.Add(this.lblCurrentPlayerName);
            this.Controls.Add(this.lblCurrentPlayer);
            this.Controls.Add(this.btnEndTurn);
            this.Name = "GameOverview";
            this.Size = new System.Drawing.Size(320, 650);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameOverview_Paint);
            this.grpBattle.ResumeLayout(false);
            this.grpBattle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEndTurn;
        private System.Windows.Forms.Label lblCurrentPlayer;
        private System.Windows.Forms.Label lblCurrentPlayerName;
        private System.Windows.Forms.Label lblSelectedTerritory;
        private System.Windows.Forms.Label lblCurrentSelectedTerritory;
        private System.Windows.Forms.Label lblDefending;
        private System.Windows.Forms.Label lblAttacking;
        private System.Windows.Forms.Label lblDefendingTerritoryName;
        private System.Windows.Forms.Label lblAttackingTerritoryName;
        private System.Windows.Forms.Label lblDefenderTroops;
        private System.Windows.Forms.Label lblAttackerTroops;
        private System.Windows.Forms.Label lblDefenderTroopsAmount;
        private System.Windows.Forms.Label lblAttackerTroopsAmount;
        private System.Windows.Forms.GroupBox grpBattle;
        private System.Windows.Forms.Button btnResolveOne;
    }
}
