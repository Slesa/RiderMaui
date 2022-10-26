namespace HelloMaui.ViewModels
{
    internal class RootPageViewModel
    {
        INavigationService _navigationService { get; }

        public RootPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand<string>(OnNavigate);
        }

        public DelegateCommand<string> NavigateCommand { get; }

        void OnNavigate(string uri)
        {
            _navigationService.NavigateAsync(uri)
                .OnNavigationError(ex => Console.WriteLine(ex));
        }
    }
}
