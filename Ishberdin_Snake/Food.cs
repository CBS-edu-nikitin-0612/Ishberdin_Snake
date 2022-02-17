using System;
using System.Collections.Generic;

namespace Ishberdin_Snake
{
    class Food : ElementGame
    {
        private Random _random = new Random();
        private Display _display;
        private Snake _snake;

        public void Create()
        {
            X = _random.Next(1, _display.Settings.Widths - 2);
            Y = _random.Next(1, _display.Settings.High - 2);
            if (CheckCollisionSnake()) Create();
            else _display.Refresh(this);
        }

        public Food(Display display, Snake snake)
        {
            _char = '$';
            _display = display;
            _snake = snake;
        }
        private bool CheckCollisionSnake()
        {
            foreach (ElementGame item in _snake.body.tail)
            {
                if (X == item.X & Y == item.Y)
                {
                    return true;
                }
            }
            if (X == _snake.head.X & Y == _snake.head.Y)
            {
                return true;
            }
            return false;
        }
    }
}
