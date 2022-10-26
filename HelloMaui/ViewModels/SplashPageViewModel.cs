namespace HelloMaui.ViewModels
{
    internal class SplashPageViewModel : IPageLifecycleAware
    {
        INavigationService _navigationService { get; }

        public SplashPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnAppearing()
        {
            _navigationService.CreateBuilder()
                .AddSegment<RootPageViewModel>()
                .Navigate();
        }

        public void OnDisappearing()
        {
        }
    }
}
