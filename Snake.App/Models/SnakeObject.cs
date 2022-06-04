using Snake.App.Enums;
using Snake.App.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake.App.Models
{
    public class SnakeObject : GameObject
    {
        private Point _head;
        private Point _tail;
        private MoveDirection _direction;

        public SnakeObject(Point tail,int length,MoveDirection direction)
        {
            _tail = tail;
            _direction = direction;
           
            Init(length);
        }

        public void Init(int length)
        {
            _points.Add(_tail);

            for (int i = 1;i < length;i++)
            {
                Point point = (Point)_points.Last().Clone();
                point.Move(1, _direction);
                _points.Add(point);
            }

            _head = _points.Last();
        }

        public void Move()
        {
            DeleteTail();
            AddHead();

            _head.Draw();
        }

        private void DeleteTail()
        {
            _points.Remove(_tail);
            _tail.Delete();
            _tail = _points[0];
        }

        private void AddHead()
        {
            _head = (Point)_head.Clone();
            _head.Move(1, _direction);
            _points.Add(_head);
        }

        public void HandleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    {
                        if (_direction == MoveDirection.Down)
                        {
                            return;
                        }
                        _direction = MoveDirection.Up;
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        if (_direction == MoveDirection.Up)
                        {
                            return;
                        }
                        _direction = MoveDirection.Down;
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        if (_direction == MoveDirection.Right)
                        {
                            return;
                        }
                        _direction = MoveDirection.Left;
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        if (_direction == MoveDirection.Left)
                        {
                            return;
                        }
                        _direction = MoveDirection.Right;
                        break;
                    }
            }
        }

        public bool IsHitTail()
        {
            Point nextHead = GetNextHead();
            return IsHit(nextHead);
        }
        
        private Point GetNextHead()
        {
            Point nextHead = (Point)_head.Clone();
            nextHead.Move(1, _direction);
            return nextHead;

        }

        public bool IsEatFood(Point food)
        {
            Point nextHead = GetNextHead();
            
            if (nextHead.IsHit(food))
            {
                food.Symbol = nextHead.Symbol;
                _points.Add(food);
                return true;
            }
            return false;
        }
    }
}
