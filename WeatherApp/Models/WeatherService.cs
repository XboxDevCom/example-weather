using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    /// <summary>
    /// Stellt Wetterdaten für eine ausgewählte Stadt bereit.
    /// In einer realen Anwendung würde diese Klasse eine HTTP-API wie
    /// OpenWeatherMap über <c>Windows.Web.Http.HttpClient</c> aufrufen.
    /// Da dieses Tutorial ohne einen echten API-Schlüssel ausgeliefert wird,
    /// werden die Wetterdaten hier simuliert, um das asynchrone Muster zu demonstrieren.
    /// </summary>
    public sealed class WeatherService
    {
        private static readonly string[] Cities = { "Berlin", "Hamburg", "München", "Köln", "Frankfurt" };
        private static readonly string[] Descriptions = { "Klarer Himmel", "Bewölkt", "Regen", "Schnee", "Nebel" };
        private static readonly string[] Icons = { "☀️", "☁️", "🌧️", "❄️", "🌫️" };
        private static readonly Random Random = new Random();

        /// <summary>
        /// Ruft die Wetterdaten für die angegebene Stadt asynchron ab.
        /// </summary>
        /// <param name="city">Der Name der Stadt.</param>
        /// <returns>Eine <see cref="Task{WeatherData}"/> mit den Wetterdaten.</returns>
        public async Task<WeatherData> GetWeatherAsync(string city)
        {
            await Task.Delay(1000);

            int conditionIndex = Random.Next(Descriptions.Length);
            double temperature = Math.Round(Random.NextDouble() * 25 + 5, 1);

            return new WeatherData
            {
                CityName = city,
                Temperature = temperature,
                Description = Descriptions[conditionIndex],
                Humidity = Random.Next(30, 91),
                WindSpeed = Math.Round(Random.NextDouble() * 15, 1),
                IconData = Icons[conditionIndex],
                MinTemperature = Math.Round(temperature - Random.NextDouble() * 5, 1),
                MaxTemperature = Math.Round(temperature + Random.NextDouble() * 5, 1)
            };
        }

        /// <summary>
        /// Gibt die Liste der verfügbaren Städte zurück.
        /// </summary>
        /// <returns>Eine Liste mit Stadtnamen.</returns>
        public List<string> GetAvailableCities()
        {
            return new List<string>(Cities);
        }
    }
}
