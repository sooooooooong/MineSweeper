using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;       // StopWatch를 사용하기 위한 네임스페이스 추가

namespace MineSweeper_2
{
    public enum eGameStatus
    {
        ing = 0,
        Win = 1,
        Lose = 2,
    }
    public enum eBlockStatus
    {
        Ready = 0,
        Flag = 1,
        Open = 2,
    }
    public enum eBlockValue
    {
        Mine = -1,
        Nothing = 0,
    }

    public class Game
    {
        private eGameStatus GameStatus;

        private Stopwatch Time = new Stopwatch();

        private int MapRow;
        private int MapColumn;

        private Block[,] Map;

        private int MineCnt;
        private int RemainMineCnt;
        private int OpenBlockCnt;

        public Game(int nRow, int nColomn, int nMine)
        {
            MapRow = nRow;
            MapColumn = nColomn;

            Map = new Block[MapRow, MapColumn];

            for (int j = 0; j < MapColumn; j++)
                for (int i = 0; i < MapRow; i++)
                    Map[i, j] = new Block((int)eBlockStatus.Ready, (int)eBlockValue.Nothing);

            MineCnt = nMine;
            RemainMineCnt = nMine;

            PlantMine(MineCnt);
            CalculateValue();

            GameStatus = eGameStatus.ing;
            Timer(true);
        }

        public eGameStatus _Status { get { return GameStatus; } set { GameStatus = value; } }
        public Block[,] _Map { get { return Map; } }
        public int _RemainMineCount { get { return RemainMineCnt; } }
        public TimeSpan _Time { get { return Time.Elapsed; } }

        private void Timer(bool start)
        {
            if (start == true)
            {
                Time.Reset();
                Time.Start();
            }
            else
            {
                Time.Stop();
            }
        }

        public void PlantMine(int mineCnt)
        {
            Random random = new Random();
            int i, j;
            while (mineCnt != 0)
            {
                i = random.Next(0, MapRow);
                j = random.Next(0, MapColumn);

                if (Map[i, j]._Value != (int)eBlockValue.Mine)
                {
                    Map[i, j]._Value = (int)eBlockValue.Mine;
                    mineCnt--;
                }
            }
        }

        public void CalculateValue()
        {
            int value;

            for (int j = 0; j < MapColumn; j++)
            {
                for (int i = 0; i < MapRow; i++)
                {
                    if (Map[i, j]._Value == (int)eBlockValue.Mine) continue;

                    value = 0;      // initialize value

                    for (int n = (j - 1); n < (j + 2); n++)
                    {
                        for (int m = (i - 1); m < (i + 2); m++)
                        {
                            if (m < 0 || n < 0 || m > (MapRow - 1) || n > (MapColumn - 1)) continue;        // skip wrong index
                            if (m == i && n == j) continue;                                                 // skip itself
                            if (Map[m, n]._Value == (int)eBlockValue.Mine) value++;                         // count mine 
                        }
                    }
                    Map[i, j]._Value = value;
                }
            }
        }

        public void SetFlag(int row, int column)
        {
            if (Map[row, column]._Status == eBlockStatus.Flag)
            {
                Map[row, column]._Status = eBlockStatus.Ready;
                RemainMineCnt++;
            }
            else if (Map[row, column]._Status == eBlockStatus.Ready)
            {
                Map[row, column]._Status = eBlockStatus.Flag;
                RemainMineCnt--;
            }

            if (OpenBlockCnt == (Map.Length - MineCnt) && RemainMineCnt == 0)
            {
                GameStatus = eGameStatus.Win;
                Timer(false);
            }
        }

        public void OpenOneBlock(int row, int column)
        {
            if (Map[row, column]._Status != eBlockStatus.Ready) return;

            switch (Map[row, column]._Value)
            {
                case (int)eBlockValue.Mine:
                    MineOpen();//Map[row, column]._Status = eBlockStatus.Open;
                    GameStatus = eGameStatus.Lose;
                    Timer(false);
                    break;

                default://case (int)eBlockValue.Nothing:
                    Map[row, column]._Status = eBlockStatus.Open;
                    NormalOpen(row, column);
                    break;

                //default:
                //    Map[row, column]._Status = eBlockStatus.Open;
                //    OpenBlockCnt++;
                //    break;
            }

            if (OpenBlockCnt == (Map.Length - MineCnt) && RemainMineCnt == 0)
            {
                GameStatus = eGameStatus.Win;
                Timer(false);
            }
        }
        public void OpenAllBlock(int row, int column)
        {
            int flagCnt = 0;

            for (int j = column - 1; j < column + 2; j++)
            {
                for (int i = row - 1; i < row + 2; i++)
                {
                    if (i < 0 || j < 0 || i > (MapRow - 1) || j > (MapColumn - 1)) continue;
                    if (Map[i, j]._Status == eBlockStatus.Flag) flagCnt++;
                }
            }

            if (flagCnt == Map[row, column]._Value)
            {
                for (int m = column - 1; m < column + 2; m++)
                {
                    for (int n = row - 1; n < row + 2; n++)
                    {
                        if (n < 0 || m < 0 || n > (MapRow - 1) || m > (MapColumn - 1)) continue;
                        OpenOneBlock(n, m);
                    }
                }
            }

            if (OpenBlockCnt == (Map.Length - MineCnt) && RemainMineCnt == 0)
            {
                GameStatus = eGameStatus.Win;
                Timer(false);
            }
        }

        private void NormalOpen(int row, int column)
        {
            Map[row, column]._Status = eBlockStatus.Open;
            OpenBlockCnt++;

            if (Map[row, column]._Value != (int)eBlockValue.Nothing) return;

            for (int j = column - 1; j < column + 2; j++)
            {
                for (int i = row - 1; i < row + 2; i++)
                {
                    if (i < 0 || j < 0 || i > (MapRow - 1) || j > (MapColumn - 1)) continue;
                    if (Map[i, j]._Value == (int)eBlockValue.Mine) continue;
                    if (Map[i, j]._Status == eBlockStatus.Open) continue;

                    NormalOpen(i, j);
                }
            }

        }
        private void MineOpen()
        {
            foreach (Block block in Map)
            {
                if (block._Value == (int)eBlockValue.Mine) block._Status = eBlockStatus.Open;
            }
        }
    }

    public class Block
    {
        public Block(eBlockStatus status, int value)
        {
            Status = status;
            Value = value;
        }

        private eBlockStatus Status;
        private int Value;

        public eBlockStatus _Status { get { return Status; } set { Status = value; } }
        public int _Value { get { return Value; } set { Value = value; } }
    }
}
