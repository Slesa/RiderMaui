using HelloMaui.BonMonitor.ViewModels;
using HelloMaui.BonMonitor.Views;
using HelloMaui.BonMonitor.Dialogs;

namespace HelloMaui.BonMonitor
{
    public class BonMonitorModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry container)
        {
            container.RegisterDialog<LoginDialog, LoginViewModel>();
            container.RegisterForNavigation<ViewA, ViewAViewModel>();
            container.RegisterForNavigation<ViewB, ViewBViewModel>();
            container.RegisterForNavigation<ViewC, ViewCViewModel>();
            container.RegisterForNavigation<ViewD, ViewDViewModel>();
        }
    }
}
