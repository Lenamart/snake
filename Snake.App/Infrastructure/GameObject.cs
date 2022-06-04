using Snake.App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.App.Infrastructure
{
    public abstract class GameObject
    {
        protected List<Point> _points;

        public GameObject()
        {
            _points = new List<Point>();
        }
        public void Draw()
        {
            foreach (Point point in _points)
            {
                point.Draw();
            }
        }

        public bool IsHit(Point point)
        {
            foreach (Point p in _points )
            {
                if (p.IsHit(point))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsHit(GameObject gameObject)
        {
            foreach (Point p in _points)
            {
                if (gameObject.IsHit(p))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
