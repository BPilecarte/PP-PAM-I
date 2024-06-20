namespace AppTest.Models
{
    public class DiceGameModel
    {
        private int NumberSides { get; set; }

        public DiceGameModel(int numSides)
        {
            NumberSides = numSides;
        }

        public int RollDice()
        {
            return new Random().Next(1, NumberSides + 1);
        }
    }
}

