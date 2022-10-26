using Prism.Common;

namespace HelloMaui.PosClient.ViewModels
{
    public abstract class RegionViewModelBase : BindableBase, IRegionAware, IPageLifecycleAware
    {
        protected RegionViewModelBase(INavigationService navigationService, IPageAccessor pageAccessor)
        {
            _navigationService = navigationService;
            _pageAccessor = pageAccessor;
        }

        protected string Name => GetType().Name.Replace("ViewModel", string.Empty);
        protected INavigationService _navigationService { get; }
        protected IPageAccessor _pageAccessor { get; }
        protected IRegionNavigationService? _regionNavigation { get; private set; }

        public bool IsNavigationTarget(INavigationContext context) => context.NavigatedName() == Name;

        string? _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        int _viewCount;
        public int ViewCount
        {
            get => _viewCount;
            set => SetProperty(ref _viewCount, value);
        }

        public string? PageName => _pageAccessor.Page?.GetType()?.Name;

        public void OnNavigatedFrom(INavigationContext context)
        {
        }

        public void OnNavigatedTo(INavigationContext context)
        {
            if (context.Parameters.ContainsKey(nameof(Message)))
                Message = context.Parameters.GetValue<string>(nameof(Message));

            _regionNavigation = context.NavigationService;
            ViewCount = context.NavigationService.Region.Views.Count();
        }

        public void OnAppearing()
        {
            RaisePropertyChanged(nameof(PageName));
        }

        public void OnDisappearing()
        {
        }
    }
}
