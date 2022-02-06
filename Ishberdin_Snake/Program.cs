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
    class Snake
    {
        public Direction direction;
        public Head head;
        public Body body;
        public Snake()
        {
            head = new Head(11, 11);
            body = new Body();
            body.AddElement(head.X, head.Y + 1);
            body.AddElement(head.X, head.Y + 2);

        }
        public void Move()
        {
            for (int i = body.tail.Count() - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    body.tail[i].X = head.X;
                    body.tail[i].Y = head.Y;
                }
                else
                {
                    body.tail[i].X = body.tail[i - 1].X;
                    body.tail[i].Y = body.tail[i - 1].Y;
                }
            }//движение хвоста
            switch (direction)
            {
                case Direction.up:
                    head.Y -= 1;//движение хвоста
                    break;
                case Direction.left:
                    head.X -= 1;
                    break;
                case Direction.right:
                    head.X += 1;
                    break;
                case Direction.down:
                    head.Y += 1;
                    break;
                default:
                    break;
            }
        }
    }
    class Head : ElementSnake
    {
        public Head(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            _char = "@"[0];
        }
    }

    class Body
    {
        public List<ElementSnake> tail = new List<ElementSnake>();
        public void AddElement(int X, int Y)
        {
            tail.Add(new ElementSnake(X, Y, "#"[0]));
        }
    }
    class ElementSnake
    {
        public int X, Y;
        public char _char;
        public ElementSnake(int X, int Y, char _char)
        {
            this.X = X;
            this.Y = Y;
            this._char = _char;
        }
        public ElementSnake() { }
    }
    enum Status
    {
        play,
        eat,
        stop,
        over,
    }
    enum Direction
    {
        up,
        left,
        right,
        down,
    }
}
