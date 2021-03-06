using System.Collections.Generic;
using System.Linq;

namespace Ishberdin_Snake
{
    class Snake
    {
        public Direction direction;
        public Head head;
        public Body body;
        private Display _display;
        public int Speed { get; set; }
        public void Move()
        {
            for (int i = body.tail.Count() - 1; i >= 0; i--)
            {
                if (i == body.tail.Count - 1)
                    _display.Refresh(new ElementGame(body.tail[i].X, body.tail[i].Y, ' '));
                if (i == 0)
                {
                    body.tail[i].X = head.X;
                    body.tail[i].Y = head.Y;
                    _display.Refresh(body.tail[i]);
                }
                else
                {
                    body.tail[i].X = body.tail[i - 1].X;
                    body.tail[i].Y = body.tail[i - 1].Y;
                    _display.Refresh(body.tail[i]);
                }
            }//движение хвоста
            switch (direction)
            {
                case Direction.up:
                    head.Y -= 1;
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
            _display.Refresh(head);
        }

        public Snake(Display display)
        {
            _display = display;
            head = new Head(11, 11);
            body = new Body();
            body.AddElement(head.X, head.Y);
            body.AddElement(head.X, head.Y);
            Speed = 1;
        }

    }
    class Head : ElementGame
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
        public List<ElementGame> tail = new List<ElementGame>();
        public void AddElement(int X, int Y)
        {
            tail.Add(new ElementGame(X, Y, "#"[0]));
        }
        public void AddElement()
        {
            AddElement(tail[tail.Count - 1].X, tail[tail.Count - 1].Y);
        }

    }

    class ElementGame
    {
        public int X, Y;
        protected char _char;
        public char Char { get { return _char; } }
        public ElementGame(int X, int Y, char _char)
        {
            this.X = X;
            this.Y = Y;
            this._char = _char;
        }
        public ElementGame() { }
    }
}

