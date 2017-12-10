using System;
using RemiliaScarlet.Helpers;
using RemiliaScarlet.Services.Navigation;
using Microsoft.Toolkit.Uwp.Helpers;
using Windows.System.Profile;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using RemiliaScarlet.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RemiliaScarlet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private INavigationService _navigationService;

        public MainPage()
        {
            this.InitializeComponent();
        }

        public void InitializeNavigationService(INavigationService navigationService)
        {
            _navigationService = navigationService;
            // TODO: Hook into Navigation Events for loading screen
            _navigationService.Navigated += NavigationService_Navigated;
        }

        private void NavigationService_Navigated(object sender, EventArgs e)
        {
            var ignored = DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                var nav = SystemNavigationManager.GetForCurrentView();
                nav.AppViewBackButtonVisibility = _navigationService.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
            });
        }

        private void Navview_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                _navigationService.NavigateToSettingsAsync();
                return;
            }

            /* 
            switch (args.InvokedItem as string)
            {
                case "Browse videos":
                    _navigationService.NavigateToPodcastsAsync();
                    break;
                case "Now playing":
                    _navigationService.NavigateToNowPlayingAsync();
                    break;
                case "Favorites":
                    _navigationService.NavigateToFavoritesAsync();
                    break;
                case "Notes":
                    _navigationService.NavigateToNotesAsync();
                    break;
                case "Downloads":
                    _navigationService.NavigateToDownloadsAsync();
                    break;
            }
            */
        }

        private void AppNavFrame_Navigated(object sender, NavigationEventArgs e)
        {
            switch (e.SourcePageType)
            {
                case Type c when e.SourcePageType == typeof(Home):
                    ((NavigationViewItem)navview.MenuItems[0]).IsSelected = true;
                    break;
            }
        }
    }
}
