using System.Collections.ObjectModel;
using System.Windows.Input;
using AppTest.Models;
using Newtonsoft.Json.Linq;



namespace AppTest.ViewModels
{
    public class SpellsViewModel : BindableObject
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private ObservableCollection<SpellsModel> _spells;
        private string _selectedSchool;
        private int _selectedLevel;

        public ObservableCollection<SpellsModel> Spells
        {
            get => _spells;
            set
            {
                _spells = value;
                OnPropertyChanged();
            }
        }

        public string SelectedSchool
        {
            get => _selectedSchool;
            set
            {
                _selectedSchool = value;
                OnPropertyChanged();
            }
        }

        public int SelectedLevel
        {
            get => _selectedLevel;
            set
            {
                _selectedLevel = value;
                OnPropertyChanged();
            }
        }

        public ICommand FilterCommand { get; }

        public SpellsViewModel()
        {
            FilterCommand = new Command(async () => await FilterSpellsAsync());
            LoadSpellsAsync();
        }

        private async Task LoadSpellsAsync()
        {
            var response = await _httpClient.GetStringAsync("https://www.dnd5eapi.co/api/spells");
            var json = JObject.Parse(response)["results"];
            var spells = json.ToObject<ObservableCollection<SpellsModel>>();
            Spells = spells;
        }

        private async Task FilterSpellsAsync()
        {
            var url = $"https://www.dnd5eapi.co/api/spells?level={SelectedLevel}&school={SelectedSchool}";
            var response = await _httpClient.GetStringAsync(url);
            var json = JObject.Parse(response)["results"];
            var spells = json.ToObject<ObservableCollection<SpellsModel>>();
            Spells = spells;
        }
    }
}
