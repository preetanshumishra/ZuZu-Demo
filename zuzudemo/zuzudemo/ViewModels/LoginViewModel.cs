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
            var user = await _firebaseService.GetUser(_username);
            if (user != null)
            {
                var navParam = new NavigationParameters();
                navParam.Add("User", user);
                await _navigationService.NavigateAsync("DashboardView", navParam);
            }
            else
            {
                GotoSignUp();
            }
        }

        private async void GotoSignUp()
        {
            await _navigationService.NavigateAsync("SignUpView");
        }
    }
}