﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishberdin_Snake
{
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
}
