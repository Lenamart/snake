using Snake.App.Enums;
using Snake.App.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.App.Models.Figures
{
    public class Line : GameObject
    {
        public Line (int x,int y,int length,char symbol,LineType type)
        {
            InitPoints(x,y,length,symbol,type);
        }
        private void InitPoints(int x, int y, int length, char symbol, LineType type)
        {
            switch(type)
            {
                case LineType.Horizontal:
                    while (x <= length)
                    {
                        _points.Add(new Point(x++, y, symbol));
                    }
                    break;
                case LineType.Vertical:
                    while (y <= length)
                    {
                        _points.Add(new Point(x, y++, symbol));
                    }
                    break;

            }
        }
    }
}
