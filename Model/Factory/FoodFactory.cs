namespace SnakeProgram.Model.Factory
{
    using System;
    using System.Linq;
    using System.Reflection;
    using SnakeProgram.Model.Food;
    using SnakeProgram.Coordinates;
    using System.Collections.Generic;

    public static class FoodFactory
    {
        public static KeyValuePair<Food, Coordinate> GenerateFood()
        {
            var random = new Random();

            var food = GetRandomFood(random);

            int x = random.Next(0, Console.WindowWidth);
            int y = random.Next(0, Console.WindowHeight);

            Console.SetCursorPosition(x, y);
            Console.Write(food.Symbol);

            return new KeyValuePair<Food, Coordinate>(food, new Coordinate(x, y));
        }

        private static Food GetRandomFood(Random random)
        {
            var snakeFood = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.BaseType == typeof(Food))
                .ToArray();

            int foodIndex = random.Next(0, snakeFood.Length - 1);

            return Activator.CreateInstance(snakeFood[foodIndex]) as Food;
        }
    }
}
