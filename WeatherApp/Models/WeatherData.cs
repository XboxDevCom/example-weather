namespace WeatherApp.Models
{
    /// <summary>
    /// Repräsentiert die Wetterdaten für eine bestimmte Stadt.
    /// </summary>
    public sealed class WeatherData
    {
        /// <summary>
        /// Ruft den Namen der Stadt ab oder legt diesen fest.
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Ruft die aktuelle Temperatur in Grad Celsius ab oder legt diese fest.
        /// </summary>
        public double Temperature { get; set; }

        /// <summary>
        /// Ruft die Wetterbeschreibung ab oder legt diese fest (z. B. "Klarer Himmel").
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ruft die Luftfeuchtigkeit in Prozent ab oder legt diese fest.
        /// </summary>
        public int Humidity { get; set; }

        /// <summary>
        /// Ruft die Windgeschwindigkeit in Metern pro Sekunde ab oder legt diese fest.
        /// </summary>
        public double WindSpeed { get; set; }

        /// <summary>
        /// Ruft das Wetter-Symbol oder Emoji ab oder legt dieses fest.
        /// </summary>
        public string IconData { get; set; }

        /// <summary>
        /// Ruft die minimale Temperatur in Grad Celsius ab oder legt diese fest.
        /// </summary>
        public double MinTemperature { get; set; }

        /// <summary>
        /// Ruft die maximale Temperatur in Grad Celsius ab oder legt diese fest.
        /// </summary>
        public double MaxTemperature { get; set; }
    }
}
