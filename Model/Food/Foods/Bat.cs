namespace SnakeProgram.Model.Food.Foods
{
    public class Bat : Food
    {
        private const int CALORIES = 5;
        private const char FOOD_SYMBOL = 'b';

        public Bat()
            : base(CALORIES, FOOD_SYMBOL)
        {
        }
    }
}