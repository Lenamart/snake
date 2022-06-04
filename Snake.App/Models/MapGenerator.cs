using Snake.App.Enums;
using Snake.App.Infrastructure;
using Snake.App.Models.Figures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.App.Models
{
   public class MapGenerator
    {
        public Map Generate(MapType type,int height,int width)
        {
            Map map = null;
            switch (type)
            {
                case MapType.Box:
                    map = GenerateBox(height, width);

                    break;
            }
            return map;
        }

        private Map GenerateBox(int height, int width)
        {
            Line upLine = new Line(0, 0, width, '#', LineType.Horizontal);
            Line downLine = new Line(0, height, width, '#', LineType.Horizontal);

            Line leftLine = new Line(0, 0, height, '#', LineType.Vertical);
            Line rightLine = new Line(width, 0, height, '#', LineType.Vertical);

            List<GameObject> figures = new List<GameObject>()
            {
                upLine,
                downLine,
                leftLine,
                rightLine
            };

            Map map = new Map("box", height, width, figures);
            return map;
        }
    }
}
