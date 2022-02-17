using System;

namespace Ishberdin_Snake
{
    class Display
    {
        char[,] field;
        DisplaySettings _settings;
        public DisplaySettings Settings { get { return _settings; } }
        public Display(int high, int widths)
        {
            _settings = new DisplaySettings(high, widths);
            field = new char[_settings.High, _settings.Widths];
            CalculateArea();
        }
        public void Refresh(Snake snake, Food food)
        {
            field = new char[_settings.High, _settings.Widths];
            CalculateArea();
            CalculateElementGame(food);
            CalculateSnake(snake);
            for (int y = 0; y < _settings.High; y++)
            {
                for (int x = 0; x < _settings.Widths; x++)
                {
                    Console.SetCursorPosition(x, y);
                    if (field[x, y] == '*')
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                    }
                    else Console.Write(field[x, y]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }

        }
        public void Refresh(ElementGame element)
        {
            CalculateElementGame(element);
            Console.SetCursorPosition(element.X, element.Y);
            Console.Write(element.Char);
            Console.SetCursorPosition(0, Settings.High);
        }

        private void CalculateArea()
        {
            for (int x = 0; x < _settings.Widths; x++)
            {
                for (int y = 0; y < _settings.High; y++)
                {
                    if ((x == 0) | (y == 0) | x == (_settings.Widths - 1) | y == _settings.High - 1) field[x, y] = "*"[0];
                }
            }
        }
        public void CalculateSnake(Snake snake)
        {
            CalculateElementGame(snake.head);
            foreach (ElementGame element in snake.body.tail)
            {
                CalculateElementGame(element);
            }
        }
        private void CalculateElementGame(ElementGame element)
        {
            field[element.X, element.Y] = element.Char;
        }
    }
    class DisplaySettings
    {
        public int High { get; }
        public int Widths { get; }
        public DisplaySettings(int high, int widths)
        {
            High = high;
            Widths = widths;
        }
    }
}
