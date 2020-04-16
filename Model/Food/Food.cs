namespace SnakeProgram.Model.Food
{
    public abstract class Food
    {
        public Food(int calories, char foodSymbol)
        {
            this.Calories = calories;
            this.Symbol = foodSymbol;
        }

        public int Calories { get; private set; }

        public char Symbol { get; private set; }
    }
}