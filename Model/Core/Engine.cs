namespace SnakeProgram.Model.Core
{
    using System;
    using Global;
    using System.Threading;
    using SnakeProgram.Enums;
    using SnakeProgram.Contracts;
    using SnakeProgram.Model.Food;
    using SnakeProgram.Model.Snake;
    using SnakeProgram.Coordinates;
    using System.Collections.Generic;
    using SnakeProgram.Model.Factory;
    using SnakeProgram.ConsoleCustomise;

    public class Engine : IEngine
    {
        private KeyValuePair<Food, Coordinate> currentFood;

        public void Run()
        {
            DrawManager.Draw(Global.SYMBOL, Snake.Body);

            ConsoleWindow.CustomizeConsole();

            while (true)
            {
                Thread.Sleep(50);

                if (Console.KeyAvailable) ChangeDirection();

                DrawManager.Draw(Global.SYMBOL, Snake.Body);

                RemoveFoot();

                Snake.Move();

                if ( this.currentFood.Key == null && this.currentFood.Value == null) this.currentFood = FoodFactory.GenerateFood();

                if (Snake.Head.X == this.currentFood.Value.X && Snake.Head.Y == this.currentFood.Value.Y)
                {
                    Snake.Eat(this.currentFood.Value, this.currentFood.Key);
                    this.currentFood = new KeyValuePair<Food, Coordinate>(null, null);
                }
            }
        }

        private void ChangeDirection()
        {
            ConsoleKeyInfo keyinfo = Console.ReadKey();

            if (Global.CURR_DIRECTION != Direction.Left && keyinfo.Key == ConsoleKey.RightArrow)
            {
                Global.CURR_DIRECTION = Direction.Right;
            }
            else if (Global.CURR_DIRECTION != Direction.Right && keyinfo.Key == ConsoleKey.LeftArrow)
            {
                Global.CURR_DIRECTION = Direction.Left;
            }
            else if (Global.CURR_DIRECTION != Direction.Up && keyinfo.Key == ConsoleKey.DownArrow)
            {
                Global.CURR_DIRECTION = Direction.Down;
            }
            else if (Global.CURR_DIRECTION != Direction.Down && keyinfo.Key == ConsoleKey.UpArrow)
            {
                Global.CURR_DIRECTION = Direction.Up;
            }
        }

        private void RemoveFoot()
        {
            Console.SetCursorPosition(Snake.Foot.X, Snake.Foot.Y);
            Console.Write(" ");
        }
    }
}