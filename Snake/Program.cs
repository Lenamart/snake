using Snake.App;
using Snake.App.Models;
using Snake.App.Models.Figures;
using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point(3,6,'*');
            SnakeObject snake = new SnakeObject(point, 8, App.Enums.MoveDirection.Right);
            snake.Draw();


            MapGenerator generator = new MapGenerator();
            Map map = generator.Generate(App.Enums.MapType.Box,50,100);
            map.Drow();
            map.FoodGenerate();

            Console.SetWindowSize(40, 45);

            while (true)
            {
                if (snake.IsHitTail() || map.IsHit(snake))
                {
                    break;
                }
                
                if (snake.IsEatFood(map.Food))
                {
                    map.FoodGenerate();
                }

                snake.Move();
                Thread.Sleep(100);

                
                if (Console.KeyAvailable)
                {
                    snake.HandleKey(Console.ReadKey().Key);
                }
            }

        }
    }
}
