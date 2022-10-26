using HelloMaui.PosClient.ViewModels;
using HelloMaui.PosClient.Views;
using Prism.Ioc;

namespace HelloMaui.PosClient
{
    public class PosClientModule : IModule
    {
        public void OnInitialized(IContainerProvider container)
        {
            var regionManager = container.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", "RegionViewA");
        }

        public void RegisterTypes(IContainerRegistry container)
        {
            container
                .RegisterForNavigation<ContentRegionPage>()
                .RegisterForNavigation<RegionHome, RegionHomeViewModel>()
                .RegisterForNavigation<DefaultViewNamedPage>()
                .RegisterForNavigation<DefaultViewInstancePage>()
                .RegisterForNavigation<DefaultViewTypePage>()
                .RegisterForRegionNavigation<RegionViewA, RegionViewAViewModel>()
                .RegisterForRegionNavigation<RegionViewB, RegionViewBViewModel>()
                .RegisterForRegionNavigation<RegionViewC, RegionViewCViewModel>();
        }
    }
}
