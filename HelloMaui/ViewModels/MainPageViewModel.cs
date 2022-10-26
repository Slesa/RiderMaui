using System;
using Prism.Commands;
using Prism.Navigation;

namespace HelloMaui.ViewModels
{
    internal class MainPageViewModel
    {
        INavigationService _navigationService { get; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand<string>(OnNavigateCommand);
        }

        public DelegateCommand<string> NavigateCommand { get; }

        void OnNavigateCommand(string uri)
        {
            _navigationService.NavigateAsync(uri)
                .OnNavigationError(ex => Console.WriteLine(ex));
        }
    }
}
