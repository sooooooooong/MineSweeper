namespace MineSweeper_2
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.levelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.levelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.lbl_RemainMineCnt = new System.Windows.Forms.Label();
            this.lbl_GameStatus = new System.Windows.Forms.Label();
            this.tmr_Display = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.White;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.levelToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(424, 24);
            this.menuStrip.TabIndex = 1;
            // 
            // levelToolStripMenuItem
            // 
            this.levelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.levelToolStripMenuItem1,
            this.newGameToolStripMenuItem});
            this.levelToolStripMenuItem.Name = "levelToolStripMenuItem";
            this.levelToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.levelToolStripMenuItem.Text = "Game";
            // 
            // levelToolStripMenuItem1
            // 
            this.levelToolStripMenuItem1.BackColor = System.Drawing.Color.White;
            this.levelToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.hardToolStripMenuItem});
            this.levelToolStripMenuItem1.Name = "levelToolStripMenuItem1";
            this.levelToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.levelToolStripMenuItem1.Text = "Level";
            // 
            // easyToolStripMenuItem
            // 
            this.easyToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.easyToolStripMenuItem.Name = "easyToolStripMenuItem";
            this.easyToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.easyToolStripMenuItem.Tag = "Easy";
            this.easyToolStripMenuItem.Text = "Easy";
            this.easyToolStripMenuItem.Click += new System.EventHandler(this.Level_Click);
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.mediumToolStripMenuItem.Tag = "Medium";
            this.mediumToolStripMenuItem.Text = "Medium";
            this.mediumToolStripMenuItem.Click += new System.EventHandler(this.Level_Click);
            // 
            // hardToolStripMenuItem
            // 
            this.hardToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.hardToolStripMenuItem.Name = "hardToolStripMenuItem";
            this.hardToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.hardToolStripMenuItem.Tag = "Hard";
            this.hardToolStripMenuItem.Text = "Hard";
            this.hardToolStripMenuItem.Click += new System.EventHandler(this.Level_Click);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutIconToolStripMenuItem,
            this.aboutProgramToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // aboutIconToolStripMenuItem
            // 
            this.aboutIconToolStripMenuItem.Name = "aboutIconToolStripMenuItem";
            this.aboutIconToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.aboutIconToolStripMenuItem.Tag = "Icon";
            this.aboutIconToolStripMenuItem.Text = "About Icon";
            this.aboutIconToolStripMenuItem.Click += new System.EventHandler(this.Info_ToolStripMenuItem_Click);
            // 
            // aboutProgramToolStripMenuItem
            // 
            this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            this.aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.aboutProgramToolStripMenuItem.Tag = "Program";
            this.aboutProgramToolStripMenuItem.Text = "About Program";
            this.aboutProgramToolStripMenuItem.Click += new System.EventHandler(this.Info_ToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbl_Time);
            this.panel2.Controls.Add(this.lbl_RemainMineCnt);
            this.panel2.Controls.Add(this.lbl_GameStatus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(424, 37);
            this.panel2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Time :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Remain Mine :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Game Status :";
            // 
            // lbl_Time
            // 
            this.lbl_Time.AutoSize = true;
            this.lbl_Time.Location = new System.Drawing.Point(374, 13);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(38, 15);
            this.lbl_Time.TabIndex = 1;
            this.lbl_Time.Text = "00:00";
            // 
            // lbl_RemainMineCnt
            // 
            this.lbl_RemainMineCnt.AutoSize = true;
            this.lbl_RemainMineCnt.Location = new System.Drawing.Point(264, 13);
            this.lbl_RemainMineCnt.Name = "lbl_RemainMineCnt";
            this.lbl_RemainMineCnt.Size = new System.Drawing.Size(14, 15);
            this.lbl_RemainMineCnt.TabIndex = 0;
            this.lbl_RemainMineCnt.Text = "0";
            // 
            // lbl_GameStatus
            // 
            this.lbl_GameStatus.AutoSize = true;
            this.lbl_GameStatus.Location = new System.Drawing.Point(99, 13);
            this.lbl_GameStatus.Name = "lbl_GameStatus";
            this.lbl_GameStatus.Size = new System.Drawing.Size(40, 15);
            this.lbl_GameStatus.TabIndex = 0;
            this.lbl_GameStatus.Text = "Ready";
            // 
            // tmr_Display
            // 
            this.tmr_Display.Tick += new System.EventHandler(this.tmr_Display_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(424, 405);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MineSweeper";
            this.Activated += new System.EventHandler(this.GameForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseUp);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem levelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem levelToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_RemainMineCnt;
        private System.Windows.Forms.Label lbl_GameStatus;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Timer tmr_Display;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutProgramToolStripMenuItem;
    }
}

