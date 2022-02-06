using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Ishberdin_Snake
{
    class Program
    {
        private static Timer timer;
        private static Display display;
        private static Snake snake;
        private static ConsoleKeyInfo key;
        private static Status status;

        static void Main()
        {
            display = new Display(22, 22);
            snake = new Snake();
            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            status = Status.play;
            do
            {
                key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case 'w':
                        snake.direction = Direction.up;
                        break;
                    case 'a':
                        snake.direction = Direction.left;
                        break;
                    case 's':
                        snake.direction = Direction.down;
                        break;
                    case 'd':
                        snake.direction = Direction.right;
                        break;
                    case (char)27:
                        status = Status.over;
                        break;
                    default:
                        break;
                }
            } while (true);
        }
        public static void CheckCollision()
        {
            if ((snake.head.X == 0) | (snake.head.Y == 0) | snake.head.X == (display.Widths - 1) | snake.head.Y == display.High - 1) status = Status.over;
            foreach (ElementSnake element in snake.body.tail)
            {
                if (element.X == snake.head.X & element.Y == snake.head.Y) status = Status.over;
            }
        }
        private static void OnTimedEvent(object obj, ElapsedEventArgs e)
        {
            CheckCollision();
            CheckStatus();
            display.Refresh(snake);
            snake.Move();
        }
        public static void CheckStatus()
        {
            switch (status)
            {
                case Status.play:
                    break;
                case Status.eat:
                    break;
                case Status.stop:
                    break;
                case Status.over:
                    timer.Enabled = false;
                    Console.WriteLine("GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!");
                    break;
                default:
                    break;
            }
        }
    }
}
