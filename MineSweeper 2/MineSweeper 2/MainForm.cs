using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace MineSweeper_2
{
    public partial class MainForm : Form
    {
        int LevelRow;
        int LevelColumn;
        int MineCnt;

        int CurrentLevel;

        Game Game_Current;

        Rectangle Rectangle_Frame;
        Rectangle[,] Rectangle_Block;

        private bool bRight = false, bLeft = false;

        const int BlockMinimumSize = 20;
        const int BlockMaximumSize = 60;
        int BlockSize = 10;
        int FrameWidth, FrameHeigth;

        int FrameGapX, FrameGapY;
        const int BlockGap = 5;

        string[] GameStatus = new string[3] { "ing", "Win !", "Lose !" };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.mine;

            LevelRow = 10;
            LevelColumn = 8;
            MineCnt = 10;

            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            CurrentLevel = 0;
            ColorChangeToolMenuItem(easyToolStripMenuItem, true);
        }

        private void GameForm_Activated(object sender, EventArgs e)
        {
            Refresh();
        }

        #region Menu
        private void Level_Click(object sender, EventArgs e)
        {
            string sTag = ((ToolStripMenuItem)sender).Tag.ToString();
            switch (sTag)
            {
                case "Easy":
                    CurrentLevel = 0;

                    ColorChangeToolMenuItem(easyToolStripMenuItem, true);
                    ColorChangeToolMenuItem(mediumToolStripMenuItem, false);
                    ColorChangeToolMenuItem(hardToolStripMenuItem, false);
                    break;

                case "Medium":
                    CurrentLevel = 1;

                    ColorChangeToolMenuItem(easyToolStripMenuItem, false);
                    ColorChangeToolMenuItem(mediumToolStripMenuItem, true);
                    ColorChangeToolMenuItem(hardToolStripMenuItem, false);
                    break;

                case "Hard":
                    CurrentLevel = 2;

                    ColorChangeToolMenuItem(easyToolStripMenuItem, false);
                    ColorChangeToolMenuItem(mediumToolStripMenuItem, false);
                    ColorChangeToolMenuItem(hardToolStripMenuItem, true);
                    break;
            }
        }
        private void ColorChangeToolMenuItem(ToolStripMenuItem tsm, bool active)
        {
            if (active == true) tsm.Image = Properties.Resources.correct.ToBitmap();
            else tsm.Image = null;
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (CurrentLevel)
            {
                case 0:
                    this.Width = 440;
                    this.Height = 444;

                    LevelRow = 10;
                    LevelColumn = 8;
                    MineCnt = 10;
                    break;

                case 1:
                    this.Width = 760;
                    this.Height = 683;

                    LevelRow = 18;
                    LevelColumn = 14;
                    MineCnt = 40;
                    break;

                case 2:
                    this.Width = 1000;
                    this.Height = 923;

                    LevelRow = 24;
                    LevelColumn = 20;
                    MineCnt = 99;
                    break;
            }

            Game_Current = new Game(LevelRow, LevelColumn, MineCnt);

            ReCalculateSize();

            Refresh();

            tmr_Display.Enabled = true;
        }

        private void Info_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (((ToolStripMenuItem)sender).Tag.ToString())
            {
                case "Icon":
                    MessageBox.Show("designed by Freepik from Flaticon");
                    break;

                case "Program":
                    MessageBox.Show("xxng@kakao.com");
                    break;
            }
        }
        #endregion

        #region Draw
        private void ReCalculateSize()
        {
            int tmp;

            int HeightOffset = panel2.Height + menuStrip.Height;

            // Block이 정사각형을 유지해야하므로 작은 쪽을 기준으로 크기를 조정
            if (this.Width > this.Height) tmp = ((this.ClientSize.Height - HeightOffset) - ((LevelColumn + 3) * BlockGap)) / LevelColumn;
            else tmp = (this.ClientSize.Width - ((LevelRow + 3) * BlockGap)) / LevelRow;

            if (tmp > BlockMaximumSize) tmp = BlockMaximumSize;
            if (tmp < BlockMinimumSize) tmp = BlockMinimumSize;

            FrameWidth = (tmp * LevelRow) + ((LevelRow + 1) * BlockGap);
            FrameGapX = (this.ClientSize.Width - FrameWidth) / 2;
            FrameHeigth = (tmp * LevelColumn) + ((LevelColumn + 1) * BlockGap);
            FrameGapY = (this.ClientSize.Height - FrameHeigth - HeightOffset) / 2 + HeightOffset;

            BlockSize = tmp;
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            ReCalculateSize();

            Refresh();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            Graphics g = e.Graphics;

            DrawLabel(g);

            g = null;
        }

        private void DrawLabel(Graphics g)
        {
            if (Game_Current == null) return;

            // Frame Rectangle
            Brush brush = new System.Drawing.SolidBrush(Color.LightSteelBlue);
            Rectangle_Frame = new Rectangle(FrameGapX, FrameGapY, FrameWidth, FrameHeigth);
            g.FillRectangle(brush, Rectangle_Frame);

            // Block Rectangle
            Rectangle_Block = new Rectangle[LevelRow, LevelColumn];
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;

            for (int j = 0; j < LevelColumn; j++)
            {
                for (int i = 0; i < LevelRow; i++)
                {
                    Rectangle_Block[i, j] = new Rectangle((i * BlockSize) + FrameGapX + ((i + 1) * BlockGap), (j * BlockSize) + FrameGapY + ((j + 1) * BlockGap), BlockSize, BlockSize);

                    switch (Game_Current._Map[i, j]._Status)
                    {
                        case eBlockStatus.Flag:
                            brush = new System.Drawing.SolidBrush(Color.Azure);
                            g.FillRectangle(brush, Rectangle_Block[i, j]);
                            g.DrawIcon(Properties.Resources.flag, Rectangle_Block[i, j]);
                            //g.DrawImage(imglst.Images[0], Rectangle_Block[j, i]);
                            break;

                        case eBlockStatus.Open:
                            if (Game_Current._Map[i, j]._Value == (int)eBlockValue.Nothing)
                            {
                                brush = new System.Drawing.SolidBrush(Color.LightSteelBlue);
                                g.FillRectangle(brush, Rectangle_Block[i, j]);
                            }
                            else if (Game_Current._Map[i, j]._Value == (int)eBlockValue.Mine)
                            {
                                brush = new System.Drawing.SolidBrush(Color.Azure);
                                g.FillRectangle(brush, Rectangle_Block[i, j]);
                                g.DrawIcon(Properties.Resources.bomb, Rectangle_Block[i, j]);
                            }
                            else
                            {
                                brush = new System.Drawing.SolidBrush(Color.LightBlue);
                                g.FillRectangle(brush, Rectangle_Block[i, j]);
                                TextRenderer.DrawText(g, Game_Current._Map[i, j]._Value.ToString(), this.Font, Rectangle_Block[i, j], Color.Black, flags);
                            }
                            break;

                        case eBlockStatus.Ready:
                            brush = new System.Drawing.SolidBrush(Color.Azure);
                            g.FillRectangle(brush, Rectangle_Block[i, j]);
                            break;
                    }
                }
            }

            brush.Dispose();
        }
        #endregion

        #region Mouse
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (Game_Current == null) return;
            if (Game_Current._Status != eGameStatus.ing) return;

            if (e.Button == System.Windows.Forms.MouseButtons.Right) bRight = true;
            if (e.Button == System.Windows.Forms.MouseButtons.Left) bLeft = true;

            for (int j = 0; j < LevelColumn; j++)
            {
                for (int i = 0; i < LevelRow; i++)
                {
                    if (Rectangle_Block[i, j].Contains(new Point(e.X, e.Y)) == true)
                    {
                        if (bRight == true && bLeft == true) Game_Current.OpenAllBlock(i, j);
                        else if (bRight == true) Game_Current.SetFlag(i, j);
                        else if (bLeft == true) Game_Current.OpenOneBlock(i, j);

                        break;
                    }
                }
            }
        }
        private void GameForm_MouseUp(object sender, MouseEventArgs e)
        {
            bRight = false;
            bLeft = false;

            Refresh();
        }
        #endregion

        private void tmr_Display_Tick(object sender, EventArgs e)
        {
            if (Game_Current == null) return;

            lbl_Time.Text = Game_Current._Time.ToString("mm\\:ss");
            lbl_RemainMineCnt.Text = Game_Current._RemainMineCount.ToString();

            lbl_GameStatus.Text = GameStatus[(int)Game_Current._Status];
        }
    }
}