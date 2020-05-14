using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using zuzudemo.Services.Contracts;
using zuzudemo.Services.Implementations;
using zuzudemo.ViewModels;
using zuzudemo.Views;

namespace zuzudemo
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            // Navigate to First Screen.
            NavigationService.NavigateAsync("/CustomNavigationView/LoginView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register ViewModels for Navigation
            containerRegistry.RegisterForNavigation<CustomNavigationView>();
            containerRegistry.RegisterForNavigation<LoginView, LoginViewModel>();
            containerRegistry.RegisterForNavigation<SignUpView, SignUpViewModel>();
            containerRegistry.RegisterForNavigation<DashboardView, DashboardViewModel>();

            // Register Services for Injection
            containerRegistry.Register<IFirebaseService, FirebaseService>();
            containerRegistry.Register<IWeatherStackService, WeatherStackService>();
        }
    }
}