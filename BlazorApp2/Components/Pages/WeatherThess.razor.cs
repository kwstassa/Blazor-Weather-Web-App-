using BlazorApp2.Data;
using System.Text.Json;

namespace BlazorApp2.Components.Pages
{
    public partial class WeatherThess
    {
        private CurrWeather currWeatherThess;
        string url;

        protected override async Task OnInitializedAsync()
        {
            StateContainer.OnChange += StateHasChanged;
         

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?lat=40.6&lon=22.9&appid=45aa6a6193d66bea741d8403e2f687d4");
            var jsonResult = await response.Content.ReadAsStringAsync();

            currWeatherThess = JsonSerializer.Deserialize<CurrWeather>(jsonResult);
            

            url = $"https://openweathermap.org/img/wn/{currWeatherThess.weather[0].icon}@2x.png"; 
            Console.WriteLine(url);
            
        }
    }



   // StateContainer.OnChange += StateHasChanged;: This line is subscribing the StateHasChanged method to the OnChange event of the StateContainer.
   // Whenever the OnChange event is triggered, the StateHasChanged method will be called.
   //This method is typically used in Blazor components to signal that the state has changed and the component needs to re-render.


}
