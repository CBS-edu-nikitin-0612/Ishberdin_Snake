using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishberdin_Snake
{
    class Display
    {
        public int High { get; }
        public int Widths { get; }
        char[,] field;
        public Display(int high, int widths)
        {
            High = high;
            Widths = widths;
            field = new char[widths, high];
            CalculateArea();
        }
        public void Refresh(Snake snake)
        {
            field = new char[Widths, High];
            CalculateArea();
            CalculateSnake(snake);
            string s = "";
            for (int y = 0; y < High; y++)
            {
                for (int x = 0; x < Widths; x++)
                {
                    s += field[x, y];
                }
                s += "\r\n";
            }

            Console.Clear();
            Console.WriteLine(s);
        }
        void CalculateArea()
        {
            for (int x = 0; x < Widths; x++)
            {
                for (int y = 0; y < High; y++)
                {
                    if ((x == 0) | (y == 0) | x == (Widths - 1) | y == High - 1) field[x, y] = "*"[0];
                }
            }
        }
        public void CalculateSnake(Snake snake)
        {
            CalculateElementSnake(snake.head);
            foreach (ElementSnake element in snake.body.tail)
            {
                CalculateElementSnake(element);
            }
        }
        void CalculateElementSnake(ElementSnake element)
        {
            field[element.X, element.Y] = element._char;
        }
    }
}
