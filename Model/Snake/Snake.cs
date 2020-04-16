namespace SnakeProgram.Model.Snake
{
    using Global;
    using System.Linq;
    using SnakeProgram.Enums;
    using SnakeProgram.Model.Food;
    using SnakeProgram.Coordinates;
    using System.Collections.Generic;

    public static class Snake
    {
        private static List<Coordinate> body = new List<Coordinate>()
        {
            new Coordinate(0, 0),
            new Coordinate(1, 0),
            new Coordinate(2, 0),
            new Coordinate(3, 0),
            new Coordinate(4, 0),
            new Coordinate(5, 0)
        };

        public static void Eat(Coordinate foodCoordinate, Food snakeFood)
        {
            for (int i = 0; i < snakeFood.Calories; i++)
            {
                body.Add(foodCoordinate);
            }

            Length += snakeFood.Calories;
        }

        public static void Move()
        {
            var foot = body.First();

            Coordinate coordinateToMoveTo = Head;

            if (Global.CURR_DIRECTION == Direction.Right)
            {
                coordinateToMoveTo = new Coordinate(Head.X + 1, Head.Y);
            }
            else if (Global.CURR_DIRECTION == Direction.Left)
            {
                coordinateToMoveTo = new Coordinate(Head.X - 1, Head.Y);
            }
            else if (Global.CURR_DIRECTION == Direction.Up)
            {
                coordinateToMoveTo = new Coordinate(Head.X, Head.Y - 1);
            }
            else if (Global.CURR_DIRECTION == Direction.Down)
            {
                coordinateToMoveTo = new Coordinate(Head.X, Head.Y + 1);
            }

            body.Remove(foot);
            body.Add(coordinateToMoveTo);
        }

        public static IReadOnlyList<Coordinate> Body => body.AsReadOnly();

        public static Coordinate Head => body.Last();

        public static Coordinate Foot => body.First();

        public static int Length { get; private set; }
    }
}