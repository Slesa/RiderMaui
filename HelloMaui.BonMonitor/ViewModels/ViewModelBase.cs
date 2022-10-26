using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace HelloMaui.BonMonitor.ViewModels
{
    public abstract class ViewModelBase : BindableBase, IInitialize, INavigatedAware, IPageLifecycleAware
    {
        protected INavigationService _navigationService { get; }
        protected IPageDialogService _pageDialogs { get; }
        protected IDialogService _dialogs { get; }

        protected ViewModelBase(BaseServices baseServices)
        {
            _navigationService = baseServices.NavigationService;
            _pageDialogs = baseServices.PageDialogs;
            _dialogs = baseServices.DialogService;

            Title = Regex.Replace(GetType().Name, "ViewModel", string.Empty);
            Id = Guid.NewGuid().ToString();

            NavigateCommand = new DelegateCommand<string>(OnNavigate);
            ShowPageDialog = new DelegateCommand(OnShowPageDialog);
            ShowDialog = new DelegateCommand(OnShowDialog, () => !string.IsNullOrEmpty(SelectedDialog)).ObservesProperty(() => SelectedDialog);

            Messages = new ObservableCollection<string>();
            AvailableDialogs = baseServices.DialogRegistry.Registrations.Select(x => x.Name).ToList();
            SelectedDialog = AvailableDialogs.FirstOrDefault();
        }

        public string Id { get; }
        public string Title { get; }
        public IEnumerable<string> AvailableDialogs { get; }

        string _selectedDialog;
        public string SelectedDialog
        {
            get => _selectedDialog;
            set => SetProperty(ref _selectedDialog, value);
        }

        public ObservableCollection<string> Messages { get; }
        public DelegateCommand<string> NavigateCommand { get; }
        public DelegateCommand ShowPageDialog { get; }
        public DelegateCommand ShowDialog { get; }

        void OnNavigate(string uri)
        {
            Messages.Add($"OnNavigateCommand: {uri}");
            _navigationService.NavigateAsync(uri)
                .OnNavigationError(ex => Console.WriteLine(ex));
        }

        void OnShowPageDialog()
        {
            Messages.Add("OnShowPageDialog");
            _pageDialogs.DisplayAlertAsync("Message", $"Hello from {Title}. This is a Page Dialog Service Alert!", "Ok");
        }

        void OnShowDialog()
        {
            Messages.Add("OnShowDialog");
            _dialogs.ShowDialog(SelectedDialog, null, DialogCallback);
        }

        void DialogCallback(IDialogResult result) =>
            Messages.Add("Dialog closed");

        public void Initialize(INavigationParameters parameters)
        {
            Messages.Add("ViewModel initialized");
            foreach (var param in parameters.Where(x => x.Key.Contains("messages")))
                Messages.Add(param.Value.ToString());
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            Messages.Add("ViewModel NavigatedFrom");
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Messages.Add("ViewModel NavigatedTo");
        }

        public void OnAppearing()
        {
            Messages.Add("View Appearing");
        }

        public void OnDisappearing()
        {
            Messages.Add("View Disappearing");
        }
    }
}
