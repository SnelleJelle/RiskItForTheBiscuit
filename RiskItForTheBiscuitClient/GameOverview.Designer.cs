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
            this.SuspendLayout();
            // 
            // btnEndTurn
            // 
            this.btnEndTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEndTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndTurn.Location = new System.Drawing.Point(149, 611);
            this.btnEndTurn.Name = "btnEndTurn";
            this.btnEndTurn.Size = new System.Drawing.Size(112, 36);
            this.btnEndTurn.TabIndex = 0;
            this.btnEndTurn.Text = "End Turn";
            this.btnEndTurn.UseVisualStyleBackColor = true;
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
            this.lblCurrentPlayerName.Location = new System.Drawing.Point(119, 4);
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
            this.lblSelectedTerritory.Location = new System.Drawing.Point(3, 40);
            this.lblSelectedTerritory.Name = "lblSelectedTerritory";
            this.lblSelectedTerritory.Size = new System.Drawing.Size(124, 15);
            this.lblSelectedTerritory.TabIndex = 3;
            this.lblSelectedTerritory.Text = "Selected Territory:";
            // 
            // lblCurrentSelectedTerritory
            // 
            this.lblCurrentSelectedTerritory.AutoSize = true;
            this.lblCurrentSelectedTerritory.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentSelectedTerritory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSelectedTerritory.ForeColor = System.Drawing.Color.White;
            this.lblCurrentSelectedTerritory.Location = new System.Drawing.Point(129, 40);
            this.lblCurrentSelectedTerritory.Name = "lblCurrentSelectedTerritory";
            this.lblCurrentSelectedTerritory.Size = new System.Drawing.Size(143, 15);
            this.lblCurrentSelectedTerritory.TabIndex = 4;
            this.lblCurrentSelectedTerritory.Text = "Some Territory Name";
            // 
            // GameOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.Controls.Add(this.lblCurrentSelectedTerritory);
            this.Controls.Add(this.lblSelectedTerritory);
            this.Controls.Add(this.lblCurrentPlayerName);
            this.Controls.Add(this.lblCurrentPlayer);
            this.Controls.Add(this.btnEndTurn);
            this.Name = "GameOverview";
            this.Size = new System.Drawing.Size(264, 650);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameOverview_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEndTurn;
        private System.Windows.Forms.Label lblCurrentPlayer;
        private System.Windows.Forms.Label lblCurrentPlayerName;
        private System.Windows.Forms.Label lblSelectedTerritory;
        private System.Windows.Forms.Label lblCurrentSelectedTerritory;
    }
}
