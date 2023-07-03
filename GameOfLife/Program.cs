using System;
using System.Threading;

namespace GameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Field field = new Field();
            ConsoleRenderer renderer = new ConsoleRenderer(ConsoleColor.White);
            renderer.RenderNextFrame(field.Cells);
            while (true)
            {
                field.GenerateNextFrame();
                renderer.RenderNextFrame(field.Cells);
                Thread.Sleep(100);
            }
        }
    }
}
