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

        private LocationModel locationData;

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
                SetProperty(ref _location, value);
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
            locationData = await _weatherStackService.GetWeatherForLocation(user.Location);
            Location = $"{locationData.Location.Name}, {locationData.Location.Region}, {locationData.Location.Country}";
            Console.WriteLine("Got Weather");
        }
    }
}