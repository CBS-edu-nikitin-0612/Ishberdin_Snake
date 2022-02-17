using System;
using System.Threading;

namespace Ishberdin_Snake
{
    class Game
    {
        private bool _colWall;
        private bool _colFood;
        public Display Display { get; set; }
        public Snake Snake { get; set; }
        public Food Food { get; set; }
        public Status status;
        public Control Control { get; set; }
        public void Start()
        {
            Display = new Display(22, 22);
            Snake = new Snake(Display);
            Food = new Food(Display, Snake);
            Control = new Control(Snake, status);
            Food.Create();
            Display.Refresh(Snake, Food);
            Control.Start();

            while (status == Status.play)
            {
                Snake.Move();
                _colWall = CheckCollisionLet();
                _colFood = CheckCollisionFood();
                if (_colWall)
                {
                    status = Status.stop;
                    CheckStatus();
                }
                if (_colFood)
                {
                    status = Status.eat;
                    if (Snake.Speed < 50)
                    {
                        Snake.Speed += 1;
                    }
                }
                CheckStatus();
                Thread.Sleep((int)((1.0 / Snake.Speed) * 1000));
            }

        }
        public bool CheckCollisionLet()
        {
            if ((Snake.head.X == 0) | (Snake.head.Y == 0) | Snake.head.X == (Display.Settings.Widths - 1) | Snake.head.Y == Display.Settings.High - 1) return true;
            foreach (ElementGame element in Snake.body.tail)
            {
                if (element.X == Snake.head.X & element.Y == Snake.head.Y) return true;
            }
            return false;
        }
        public bool CheckCollisionFood()
        {
            if ((Snake.head.X == Food.X) & (Snake.head.Y == Food.Y)) return true;
            return false;
        }

        // private static void OnTimedEvent(object obj, ElapsedEventArgs e)
        // {
        //     CheckCollision();
        //     CheckStatus();
        //     snake.Move();
        //     Display.Settings.Refresh(snake, food);
        // }
        public void CheckStatus()
        {
            switch (status)
            {
                case Status.play:
                    break;
                case Status.eat:
                    Food.Create();
                    Snake.body.AddElement();
                    status = Status.play;
                    break;
                case Status.stop:
                    //timer.Enabled = false;
                    Control.Stop();
                    Console.Clear();
                    Console.WriteLine("GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!GAME OVER!");
                    Thread.Sleep(1000);
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }
    }
}