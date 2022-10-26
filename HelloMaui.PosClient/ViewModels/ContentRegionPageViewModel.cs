namespace HelloMaui.PosClient.ViewModels
{
    public class ContentRegionPageViewModel : IInitialize
    {
        IRegionManager _regionManager { get; }
        int _count;

        public ContentRegionPageViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(OnNavigate);
        }

        public void Initialize(INavigationParameters parameters)
        {
            _regionManager.RequestNavigate("ContentRegion", "RegionViewA");
        }

        public DelegateCommand<string> NavigateCommand { get; }

        void OnNavigate(string uri)
        {
            var message = $"Hello from Content Region Page ({_count++})";
            _regionManager.RequestNavigate("ContentRegion", uri, new NavigationParameters { { "Message", message } });
        }
    }
}
