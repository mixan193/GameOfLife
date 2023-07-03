using System;

namespace GameOfLife
{
    internal class ConsoleRenderer
    {
        private ConsoleColor color;
        public ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
        }
        public ConsoleRenderer(ConsoleColor color)
        {
            this.color = color;
        }

        public void RenderNextFrame(Cell[,] cells)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < cells.GetLength(1); i++)
            {
                for(int j = 0; j < cells.GetLength(0); j++)
                {

                    if (cells[j, i].IsEnabled)
                    {
                        Console.BackgroundColor = color;
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("  ");
                    }
                }
            }
        }
    }
}
