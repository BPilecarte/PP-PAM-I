using Microsoft.Maui.Controls;
using AppTest.ViewModels;

namespace AppTest.Views
{
    public partial class RpgGameView : ContentPage
    {
        public RpgGameView()
        {
            InitializeComponent();
        }

        private void NivelSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (BindingContext is RpgGameViewModel viewModel)
            {
                viewModel.NivelChangedCommand.Execute(e.NewValue);
            }
        }
    }
}
