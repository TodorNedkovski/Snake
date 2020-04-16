namespace SnakeProgram.Model.Core
{
    using System;
    using SnakeProgram.Coordinates;
    using System.Collections.Generic;

    public static class DrawManager
    {
        public static void Draw(char symbol, IReadOnlyList<Coordinate> coordinates)
        {
            for (int i = 0; i < coordinates.Count; i++)
            {
                Console.SetCursorPosition(coordinates[i].X, coordinates[i].Y);
                Console.Write(symbol);
            }
        }
    }
}