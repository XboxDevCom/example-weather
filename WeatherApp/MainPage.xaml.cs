using WeatherApp.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace WeatherApp
{
    /// <summary>
    /// Hauptseite der Wetter-App.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly WeatherService _weatherService;

        public MainPage()
        {
            this.InitializeComponent();
            _weatherService = new WeatherService();
        }

        /// <summary>
        /// Wird aufgerufen, wenn zur Seite navigiert wird. Füllt die Stadt-Auswahl.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CitySelector.ItemsSource = _weatherService.GetAvailableCities();
            if (CitySelector.Items.Count > 0)
            {
                CitySelector.SelectedIndex = 0;
            }

            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// Wird beim Klick auf die Abruf-Schaltfläche aufgerufen.
        /// Lädt asynchron die Wetterdaten für die ausgewählte Stadt.
        /// </summary>
        private async void FetchButton_Click(object sender, RoutedEventArgs e)
        {
            if (CitySelector.SelectedItem == null)
            {
                ShowError("Bitte wählen Sie eine Stadt aus.");
                return;
            }

            string city = CitySelector.SelectedItem.ToString();

            FetchButton.IsEnabled = false;
            LoadingIndicator.IsActive = true;
            LoadingIndicator.Visibility = Visibility.Visible;
            ErrorText.Visibility = Visibility.Collapsed;
            WeatherPanel.Visibility = Visibility.Collapsed;

            try
            {
                WeatherData data = await _weatherService.GetWeatherAsync(city);
                DisplayWeather(data);
            }
            catch (System.Exception ex)
            {
                ShowError("Fehler beim Abrufen der Wetterdaten: " + ex.Message);
            }
            finally
            {
                LoadingIndicator.IsActive = false;
                LoadingIndicator.Visibility = Visibility.Collapsed;
                FetchButton.IsEnabled = true;
            }
        }

        /// <summary>
        /// Zeigt die übergebenen Wetterdaten auf der Benutzeroberfläche an.
        /// </summary>
        /// <param name="data">Die anzuzeigenden Wetterdaten.</param>
        private void DisplayWeather(WeatherData data)
        {
            CityText.Text = data.CityName;
            IconText.Text = data.IconData;
            TempText.Text = data.Temperature + " °C";
            DescriptionText.Text = data.Description;
            MinTempText.Text = "Min. Temperatur: " + data.MinTemperature + " °C";
            MaxTempText.Text = "Max. Temperatur: " + data.MaxTemperature + " °C";
            HumidityText.Text = "Luftfeuchtigkeit: " + data.Humidity + " %";
            WindText.Text = "Windgeschwindigkeit: " + data.WindSpeed + " m/s";

            WeatherPanel.Visibility = Visibility.Visible;
            ErrorText.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Zeigt eine Fehlermeldung an und verbirgt das Wetterpanel.
        /// </summary>
        /// <param name="message">Die anzuzeigende Fehlermeldung.</param>
        private void ShowError(string message)
        {
            ErrorText.Text = message;
            ErrorText.Visibility = Visibility.Visible;
            WeatherPanel.Visibility = Visibility.Collapsed;
        }
    }
}
