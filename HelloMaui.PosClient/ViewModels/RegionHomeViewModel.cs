namespace HelloMaui.PosClient.ViewModels
{
    internal class RegionHomeViewModel
    {
        INavigationService _navigationService { get; }

        public RegionHomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand<string>(OnNavigate);
        }

        public DelegateCommand<string> NavigateCommand { get; }

        void OnNavigate(string uri)
        {
            _navigationService.NavigateAsync(uri);
        }
    }
}
