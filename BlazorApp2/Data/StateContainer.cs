
namespace BlazorApp2.Data
{
    public class StateContainer
    {
        public char TempUnit { get; private set; } = 'C';
        public CurrWeather CurrentWeather { get; private set; }

        public event Action OnChange;

        public void ChangeTempUnit(char unit)
        {
            TempUnit = unit;
            OnChange?.Invoke();
        }

        public string FormatTemperature(double tempInKelvin)
        {
            double temp;
            switch (TempUnit)
            {
                case 'C':
                    temp = tempInKelvin - 273.15;
                    break;
                case 'F':
                    temp = (tempInKelvin - 273.15) * 9 / 5 + 32;
                    break;
                case 'K':
                default:
                    temp = tempInKelvin;
                    break;
            }
            return string.Format("{0:F2}", temp);
        }

        public void SetWeather(CurrWeather newWeather)
        {
            CurrentWeather = newWeather;
            OnChange?.Invoke();
        }


            //So, OnChange?.Invoke(); is saying “if OnChange is not null, call Invoke to trigger the event”.
            //This will cause all methods that are subscribed to the OnChange event to be called.
            //If OnChange is null (i.e., if no methods are subscribed to the event), nothing happens and no exception is thrown. 
            //This is a common pattern for triggering events in C#.
       
    }
}

