namespace AdvancedTesting
{
    // 285. Fakes and Stubs.
    // A "Stub" provides canned answers to calls during a test. 
    // A "Fake" is a working implementation (like an In-Memory DB) but simplified.

    public interface IWeatherService { string GetForecast(string site); }

    public class WeatherStub : IWeatherService
    {
        // Canned response: Always returns Sunny regardless of input
        public string GetForecast(string site) => "Sunny";
    }

    public class SiteLogic
    {
        private readonly IWeatherService _weather;
        public SiteLogic(IWeatherService weather) => _weather = weather;
        public bool ShouldPourConcrete() => _weather.GetForecast("SiteA") == "Sunny";
    }
}