namespace HelloMaui.BonMonitor.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(OnLogin);
        }

        public string Title => "What's your name?";

        string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public DelegateCommand LoginCommand { get; }
        public DialogCloseEvent RequestClose { get; set; }

        bool _canClose;
        public bool CanCloseDialog() => _canClose;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        void OnLogin()
        {
            _canClose = true;
            RequestClose.Invoke();
        }
    }
}
