using Prism.Events;
using Xamarin.Forms;

namespace zuzudemo.Views
{
    public class CustomNavigationView : NavigationPage
    {
        IEventAggregator _eventAggregator;
        public CustomNavigationView(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Subscribe to events
            _eventAggregator.GetEvent<PubSubEvent>().Subscribe(PerformAction);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // Unsubscribe from event
            _eventAggregator.GetEvent<PubSubEvent>().Unsubscribe(PerformAction);
        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        private void PerformAction()
        {
            // Perform some action
        }
    }
}
