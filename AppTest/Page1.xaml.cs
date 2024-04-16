namespace AppTest;

public partial class Page1 : ContentPage
{
	public Page1()
	{
		InitializeComponent();

    
    }

    public class Dice 
    {
        private int NumberSides { get; set; }

        public Dice() { } 
        public Dice(int numSides) 
        {
            NumberSides = numSides; 
        }

        public int RollDice() 
        {
            int random = new Random().Next(1, NumberSides + 1);
            return random;
        }
    }

    public void OnClicked(object sender, EventArgs e)
    {
        try
        {
            int numberSides = (int)SelectorRolleSide.SelectedItem;

            Dice dice = new Dice(numberSides);

            RandomNumber.Text = dice.RollDice().ToString();

            diceImage.Source = ImageSource.FromFile($"dice_d{numberSides}.png");
        }
        catch
        {
            DisplayAlert("Alert", "Escolha um tipo de dado", "OK");
        }


    }
}