using BlazorApp2.Data;

namespace BlazorApp2.Components.Pages
{
    public partial class Home
    {
        private CurrWeather currWeather;

        protected override void OnInitialized()
        {
            StateContainer.OnChange += UpdateWeather;
            
        }

        private void UpdateWeather()
        {
            currWeather = StateContainer.CurrentWeather;
            Console.WriteLine($"Weather in HomePage updated: {currWeather}"); 
            StateHasChanged(); 
        }
    }
}
