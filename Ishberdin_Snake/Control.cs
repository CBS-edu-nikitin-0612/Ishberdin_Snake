using System;
using System.Threading;

namespace Ishberdin_Snake
{
    class Control
    {
        private bool _enable = false;
        private Snake _snake;
        private Status _status;
        public void Start()
        {
            _enable = true;
            Thread thread = new Thread(Manage);
            thread.Start();
        }
        public void Stop()
        {
            _enable = false;
        }
        private void Manage()
        {
            ConsoleKey key;
            while (_enable)
            {
                Console.CursorVisible = false;
                key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.W:
                        _snake.direction = Direction.up;
                        break;
                    case ConsoleKey.A:
                        _snake.direction = Direction.left;
                        break;
                    case ConsoleKey.S:
                        _snake.direction = Direction.down;
                        break;
                    case ConsoleKey.D:
                        _snake.direction = Direction.right;
                        break;
                    case ConsoleKey.Escape:
                        _status = Status.stop;
                        break;
                    default:
                        break;
                }
            }
        }
        public Control(Snake snake, Status status)
        {
            _snake = snake;
            _status = status;
        }
    }
}
