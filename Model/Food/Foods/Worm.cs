namespace SnakeProgram.Model.Food.Foods
{
    public class Worm : Food
    {
        private const int CALORIES = 1;
        private const char FOOD_SYMBOL = 'w';

        public Worm()
            : base(CALORIES, FOOD_SYMBOL)
        {
        }
    }
}