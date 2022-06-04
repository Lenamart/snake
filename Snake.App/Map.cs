using Snake.App.Infrastructure;
using Snake.App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.App
{
    public class Map
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public List<GameObject> Walls { get; set; }
        private FoodGenerator FoodGenerator;
        public Point Food { get; set; }


        public Map(string name, int height, int width, List<GameObject> walls)
        {
            Name = name;
            Height = height;
            Width = width;
            Walls = walls;
            FoodGenerator = new FoodGenerator(Height, Width, '^');
        }

        public void FoodGenerate()
        {
            Food = FoodGenerator.Generate();
            Food.Draw();
        }

        public void Drow()
        {
            foreach (GameObject figure in Walls)
            {
                figure.Draw();
            }

        }

        public bool IsHit(GameObject gameObject)
        {
            foreach(GameObject go in Walls)
            {
                if (go.IsHit(gameObject))
                {
                    return true;
                }
            }
            return false;
            
        }
    }
}
