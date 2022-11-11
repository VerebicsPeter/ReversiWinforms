namespace Reversi
{
    partial class GameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripBlackCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripWhiteCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.onePlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoPlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripPlayerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.ForestGreen;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(772, 772);
            this.panel.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBlackCount,
            this.toolStripWhiteCount,
            this.toolStripPlayerLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 774);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(768, 29);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripBlackCount
            // 
            this.toolStripBlackCount.Name = "toolStripBlackCount";
            this.toolStripBlackCount.Size = new System.Drawing.Size(67, 23);
            this.toolStripBlackCount.Text = "Black: 2";
            // 
            // toolStripWhiteCount
            // 
            this.toolStripWhiteCount.Name = "toolStripWhiteCount";
            this.toolStripWhiteCount.Size = new System.Drawing.Size(73, 23);
            this.toolStripWhiteCount.Text = "White: 2";
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuRestart,
            this.contextMenuSetting,
            this.exitToolStripMenuItem});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(134, 88);
            this.contextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenu_ItemClicked);
            // 
            // contextMenuRestart
            // 
            this.contextMenuRestart.Name = "contextMenuRestart";
            this.contextMenuRestart.Size = new System.Drawing.Size(133, 28);
            this.contextMenuRestart.Text = "Restart";
            // 
            // contextMenuSetting
            // 
            this.contextMenuSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onePlayerToolStripMenuItem,
            this.twoPlayersToolStripMenuItem});
            this.contextMenuSetting.Name = "contextMenuSetting";
            this.contextMenuSetting.Size = new System.Drawing.Size(133, 28);
            this.contextMenuSetting.Text = "Mode";
            this.contextMenuSetting.Click += new System.EventHandler(this.contextMenuSetting_Click);
            // 
            // onePlayerToolStripMenuItem
            // 
            this.onePlayerToolStripMenuItem.Name = "onePlayerToolStripMenuItem";
            this.onePlayerToolStripMenuItem.Size = new System.Drawing.Size(182, 28);
            this.onePlayerToolStripMenuItem.Text = "One Player";
            this.onePlayerToolStripMenuItem.Click += new System.EventHandler(this.onePlayerToolStripMenuItem_Click);
            // 
            // twoPlayersToolStripMenuItem
            // 
            this.twoPlayersToolStripMenuItem.Name = "twoPlayersToolStripMenuItem";
            this.twoPlayersToolStripMenuItem.Size = new System.Drawing.Size(182, 28);
            this.twoPlayersToolStripMenuItem.Text = "Two Players";
            this.twoPlayersToolStripMenuItem.Click += new System.EventHandler(this.twoPlayersToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 28);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStripPlayerLabel
            // 
            this.toolStripPlayerLabel.Name = "toolStripPlayerLabel";
            this.toolStripPlayerLabel.Size = new System.Drawing.Size(60, 23);
            this.toolStripPlayerLabel.Text = "Player:";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 803);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.Text = "Reversi";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripBlackCount;
        private ToolStripStatusLabel toolStripWhiteCount;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem contextMenuRestart;
        private ToolStripMenuItem contextMenuSetting;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem onePlayerToolStripMenuItem;
        private ToolStripMenuItem twoPlayersToolStripMenuItem;
        private ToolStripStatusLabel toolStripPlayerLabel;
    }
}