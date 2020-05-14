using System;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Essentials;
using zuzudemo.Services.Contracts;

namespace zuzudemo.ViewModels
{
    public class SignUpViewModel : BindableBase
    {
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                SetProperty(ref _username, value);
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                SetProperty(ref _password, value);
            }
        }

        private Placemark placemark;

        private readonly INavigationService _navigationService;
        private readonly IFirebaseService _firebaseService;

        public DelegateCommand SignUpCommand { get; set; }

        public SignUpViewModel(INavigationService navigationService, IFirebaseService firebaseService)
        {
            _navigationService = navigationService;
            _firebaseService = firebaseService;
            SignUpCommand = new DelegateCommand(SignUp);
            GetLocation();
        }

        private async void GetLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);

                    placemark = placemarks?.FirstOrDefault();
                    if (placemark != null)
                    {
                        var geocodeAddress =
                            $"AdminArea:       {placemark.AdminArea}\n" +
                            $"CountryCode:     {placemark.CountryCode}\n" +
                            $"CountryName:     {placemark.CountryName}\n" +
                            $"FeatureName:     {placemark.FeatureName}\n" +
                            $"Locality:        {placemark.Locality}\n" +
                            $"PostalCode:      {placemark.PostalCode}\n" +
                            $"SubAdminArea:    {placemark.SubAdminArea}\n" +
                            $"SubLocality:     {placemark.SubLocality}\n" +
                            $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
                            $"Thoroughfare:    {placemark.Thoroughfare}\n";

                        Console.WriteLine(geocodeAddress);
                    }
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Console.WriteLine(fnsEx.Message);
                //await DisplayAlert("Faild", fnsEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                Console.WriteLine(pEx.Message);
                //await DisplayAlert("Faild", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //await DisplayAlert("Faild", ex.Message, "OK");
            }
        }

        private async void SignUp()
        {
            bool userRegistered = await _firebaseService.AddUser(_username, _password, placemark.Locality);
            if (userRegistered) await _navigationService.GoBackAsync();
        }
    }
}