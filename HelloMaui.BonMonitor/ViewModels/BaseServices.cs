namespace HelloMaui.BonMonitor.ViewModels
{
    public class BaseServices
    {
        public BaseServices(
            INavigationService navigationService,
            IPageDialogService pageDialogs,
            IDialogService dialogService,
            IDialogViewRegistry dialogRegistry)
        {
            NavigationService = navigationService;
            PageDialogs = pageDialogs;
            DialogService = dialogService;
            DialogRegistry = dialogRegistry;
        }

        public INavigationService NavigationService { get; }
        public IPageDialogService PageDialogs { get; }
        public IDialogService DialogService { get; }
        public IDialogViewRegistry DialogRegistry {get; }
    }
}
