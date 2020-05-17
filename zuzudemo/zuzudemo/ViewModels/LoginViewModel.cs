using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using zuzudemo.Services.Contracts;

namespace zuzudemo.ViewModels
{
    public class LoginViewModel : BindableBase
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
                RaisePropertyChanged(nameof(Username));
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
                RaisePropertyChanged(nameof(Password));
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

        private readonly INavigationService _navigationService;
        private readonly IFirebaseService _firebaseService;

        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand SignUpCommand { get; set; }

        public LoginViewModel(INavigationService navigationService, IFirebaseService firebaseService)
        {
            _navigationService = navigationService;
            _firebaseService = firebaseService;
            LoginCommand = new DelegateCommand(Login);
            SignUpCommand = new DelegateCommand(GotoSignUp);
        }

        private async void Login()
        {
            IsLoading = true;
            var user = await _firebaseService.GetUser(_username.ToLower());
            if (user != null && user.Password == _password.ToLower())
            {
                var navParam = new NavigationParameters();
                navParam.Add("User", user);
                await _navigationService.NavigateAsync("DashboardView", navParam);
            }
            else
            {
                GotoSignUp();
            }
            IsLoading = false;
        }

        private async void GotoSignUp()
        {
            IsLoading = true;
            await _navigationService.NavigateAsync("SignUpView");
            IsLoading = false;
        }
    }
}