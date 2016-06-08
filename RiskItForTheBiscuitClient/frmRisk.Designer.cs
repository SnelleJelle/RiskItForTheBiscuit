using System.Drawing;

namespace RiskItForTheBiscuitClient
{
    partial class frmRisk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRisk));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.playersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbRiskMap = new System.Windows.Forms.PictureBox();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRiskMap)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.Color.Transparent;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playersToolStripMenuItem,
            this.chatToolStripMenuItem,
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.mainMenuStrip, "mainMenuStrip");
            this.mainMenuStrip.Name = "mainMenuStrip";
            // 
            // playersToolStripMenuItem
            // 
            this.playersToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.playersToolStripMenuItem.Name = "playersToolStripMenuItem";
            resources.ApplyResources(this.playersToolStripMenuItem, "playersToolStripMenuItem");
            // 
            // chatToolStripMenuItem
            // 
            this.chatToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.chatToolStripMenuItem.Name = "chatToolStripMenuItem";
            resources.ApplyResources(this.chatToolStripMenuItem, "chatToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            // 
            // pbRiskMap
            // 
            this.pbRiskMap.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pbRiskMap, "pbRiskMap");
            this.pbRiskMap.Name = "pbRiskMap";
            this.pbRiskMap.TabStop = false;
            this.pbRiskMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pbRiskMap_Paint);
            this.pbRiskMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbRiskMap_MouseClick);
            // 
            // frmRisk
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.pbRiskMap);
            this.Controls.Add(this.mainMenuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "frmRisk";
            this.Load += new System.EventHandler(this.frmRisk_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRiskMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRiskMap;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

