using Microsoft.Maui.Controls;
using System;

namespace AppTest
{
    public partial class DicePage : ContentPage
    {
        public DicePage()
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
                return new Random().Next(1, NumberSides + 1);
            }
        }

        public void OnClicked(object sender, EventArgs e)
        {

            try
            {
                int numberSides = (int)SelectorRolleSide.SelectedItem;
                int quantity = (int)SelectorSide.SelectedItem;

                Dice dice = new Dice(numberSides);

                string resultString = "";
                int total = 0;

                for (int i = 0; i < quantity; i++)
                {
                    int roll = dice.RollDice();
                    total += roll;
                    resultString += $"Dado {i + 1} = {roll}";

                    if (i < quantity - 1)
                        resultString += ", ";
                }

                RollInfoLabel.Text = $"Foram jogados {quantity} dado(s) de {numberSides} lado(s)";
                RandomNumber.Text = resultString;
                TotalLabel.Text = $"Resultado final: {total}";

                diceImage.Source = ImageSource.FromFile($"dice_d{numberSides}.png");
            }
            catch
            {
                DisplayAlert("Alert", "Escolha um tipo de dado para iniciar!", "OK");
            }
        }
    }
}
