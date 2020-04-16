namespace SnakeProgram.Model.Food.Foods
{
    public class Egg : Food
    {
        private const int CALORIES = 3;
        private const char FOOD_SYMBOL = 'e';

        public Egg()
            : base(CALORIES, FOOD_SYMBOL)
        {
        }
    }
}