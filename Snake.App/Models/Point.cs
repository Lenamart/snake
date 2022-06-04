using Snake.App.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.App.Models
{
    public class Point : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }

        public Point(int x,int y, char symbol)
        {
            this.X = x;
            this.Y = y;
            this.Symbol = symbol;
        }

        public Point(Point point)
        {
            this.Symbol = point.Symbol;
            this.X = point.X;
            this.Y = point.Y;
        }

        /// <summary>
        /// Перемещение
        /// </summary>
        /// <param name="count">Кол-во</param>
        /// <param name="moveDirection">Направление движения</param>
        public void Move(int count, MoveDirection moveDirection)
        {
            switch(moveDirection)
            {
                case MoveDirection.Up:
                    Y -= count;
                    break;

                case MoveDirection.Down:
                    Y += count;
                    break;

                case MoveDirection.Left:
                    X -= count;
                    break;

                case MoveDirection.Right:
                    X += count;
                    break;
            }
        }

        /// <summary>
        /// рисование точки
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }

        /// <summary>
        /// удаляет точку
        /// </summary>
        public void Delete()
        {
            Symbol = ' ';
            Draw();
        }

        /// <summary>
        /// проверка соприкасаются ли точки
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool IsHit (Point point) 
        {
            return point.X == X && point.Y == Y;
        }

        public object Clone()
        {
            return new Point(X, Y, Symbol);
        }
    }
}
