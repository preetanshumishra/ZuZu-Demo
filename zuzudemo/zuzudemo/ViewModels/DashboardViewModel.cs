using System;
using System.Linq;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using zuzudemo.Models;
using zuzudemo.Services.Contracts;

namespace zuzudemo.ViewModels
{
    public class DashboardViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IFirebaseService _firebaseService;
        private readonly IWeatherStackService _weatherStackService;

        private WeatherModel currentWeatherData;
        private WeatherModel forecastWeatherData;

        private string _location;
        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                RaisePropertyChanged(nameof(Location));
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                RaisePropertyChanged(nameof(IsLoading));
            }
        }

        private string _currentIcon;
        public string CurrentIcon
        {
            get
            {
                return _currentIcon;
            }
            set
            {
                _currentIcon = value;
                RaisePropertyChanged(nameof(CurrentIcon));
            }
        }

        private string _localTime;
        public string LocalTime
        {
            get
            {
                return _localTime;
            }
            set
            {
                _localTime = value;
                RaisePropertyChanged(nameof(LocalTime));
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }

        private string _temperature;
        public string Temperature
        {
            get
            {
                return _temperature;
            }
            set
            {
                _temperature = value;
                RaisePropertyChanged(nameof(Temperature));
            }
        }

        private string _humidity;
        public string Humidity
        {
            get
            {
                return _humidity;
            }
            set
            {
                _humidity = value;
                RaisePropertyChanged(nameof(Humidity));
            }
        }

        private string _feelsLike;
        public string FeelsLike
        {
            get
            {
                return _feelsLike;
            }
            set
            {
                _feelsLike = value;
                RaisePropertyChanged(nameof(FeelsLike));
            }
        }

        private Color _backgroundColor;
        public Color BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set
            {
                _backgroundColor = value;
                RaisePropertyChanged(nameof(BackgroundColor));
            }
        }

        public DashboardViewModel(INavigationService navigationService, IFirebaseService firebaseService, IWeatherStackService weatherStackService)
        {
            _navigationService = navigationService;
            _firebaseService = firebaseService;
            _weatherStackService = weatherStackService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            GetUserAndLocation(parameters.GetValue<UserModel>("User"));
        }

        private async void GetUserAndLocation(UserModel user)
        {
            IsLoading = true;
            currentWeatherData = await _weatherStackService.GetCurrentWeatherForLocation(user.Location);
            forecastWeatherData = await _weatherStackService.GetForecastWeatherForLocation("Chanhassen", "4");
            Location = $"{currentWeatherData.Location.Name}, {currentWeatherData.Location.Region}";
            CurrentIcon = currentWeatherData.Current.WeatherIcons.FirstOrDefault();
            LocalTime = currentWeatherData.Location.Localtime;
            Description = currentWeatherData.Current.WeatherDescriptions.FirstOrDefault();
            Temperature = currentWeatherData.Current.Temperature.ToString() + "C";
            Humidity = "Humidity" + currentWeatherData.Current.Humidity.ToString() + "%";
            FeelsLike = "Feels like " + currentWeatherData.Current.Feelslike.ToString() + "C";
            BackgroundColor = Color.LightBlue;
            Console.WriteLine("Got Weather");
            IsLoading = false;
        }
    }
}