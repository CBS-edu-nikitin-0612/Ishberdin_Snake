using System;
using System.Collections.Generic;
using System.Linq;

namespace Ishberdin_Snake
{
    class Food:ElementSnake
    {
        private Random random = new Random();
        public void Create(Display display)
        {
            X = random.Next(1, display.Widths-2);
            Y = random.Next(1, display.High-2);
            _char = '$';
        }
    }
}
