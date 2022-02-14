using System;
using System.Drawing;

namespace Ishberdin_Snake
{
    class Food : ElementSnake
    {
        private Random random = new Random();
        private const char _symbol = '$';
        private Display _settings;

        // Я бы подобным образом организовал работу с едой и т.д.
        //public Food(Display display)
        //{
        //    _settings = display;
        //}
        //
        //public Point GetFoodPoint()
        //{
        //    Point point = new Point();
        //    point.X = random.Next(1, _settings.Widths - 2);
        //    point.Y = random.Next(1,_settings.High - 2);
        //
        //    return point;
        //}

        public void Create(Display display)
        {

            X = random.Next(1, display.Widths-2);
            Y = random.Next(1, display.High-2);
            _char = '$';
        }
    }
}
