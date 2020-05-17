using System;
using Prism.Mvvm;
using Prism.Navigation;
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
            Location = $"{currentWeatherData.Location.Name}, {currentWeatherData.Location.Region}, {currentWeatherData.Location.Country}";
            Console.WriteLine("Got Weather");
            IsLoading = false;
        }
    }
}