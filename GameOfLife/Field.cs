using System;

namespace GameOfLife
{
    internal class Field
    {
        private Cell[,] cells;
        public Cell[,] Cells
        {
            get
            {
                return cells;
            }
        }
        Random rand = new Random();
        public Field()
        {
            cells = new Cell[Console.WindowWidth / 2, Console.WindowHeight];
            for (int i = 0; i < cells.GetLength(1); i++)
            {
                for (int j = 0; j < cells.GetLength(0); j++)
                {
                    cells[j, i] = new Cell(j, i);
                    cells[j, i].IsEnabled = Convert.ToBoolean(rand.Next(2)%2);
                }
            }
            int temp = 1;
            for (int i = 0; i < cells.GetLength(1); i++)
            {
                for(int j = 0; j < cells.GetLength(0); j++)
                {
                    Cell[] neighbours = new Cell[8];
                    temp = 0;
                    for(int y = -1; y < 2; y++)
                    {
                        for(int x = -1; x < 2; x++)
                        {
                            if(x == 0 && y == 0)
                            {
                                continue;
                            }
                            int _x = j + x;
                            if (_x < 0)
                            {
                                _x = cells.GetLength(0) - 1;
                            }
                            else if(_x > cells.GetLength(0) - 1)
                            {
                                _x = 0;
                            }
                            int _y = i + y;
                            if (_y < 0)
                            {
                                _y = cells.GetLength(1) - 1;
                            }
                            else if (_y > cells.GetLength(1) - 1)
                            {
                                _y = 0;
                            }
                            neighbours[temp] = cells[_x, _y];
                            temp++;
                        }
                    }
                    cells[j, i].Neighbours = neighbours;
                }
            }
        }

        public void GenerateNextFrame()
        {
            for (int i = 0; i < cells.GetLength(1); i++)
            {
                for (int j = 0; j < cells.GetLength(0); j++)
                {
                    cells[j, i].ComputeBehaviorInNextGeneration();
                }
            }
            for (int i = 0; i < cells.GetLength(1); i++)
            {
                for (int j = 0; j < cells.GetLength(0); j++)
                {
                    cells[j, i].IsEnabled = cells[j, i].IsEnabledInNextGeneration;
                }
            }
        }
    }
}
