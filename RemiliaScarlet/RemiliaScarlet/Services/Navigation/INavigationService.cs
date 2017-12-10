using System;
using System.Threading.Tasks;

namespace RemiliaScarlet.Services.Navigation
{
    public interface INavigationService
    {
        event EventHandler<bool> IsNavigatingChanged;

        event EventHandler Navigated;

        bool CanGoBack { get; }

        bool IsNavigating { get; }

        Task NavigateToSettingsAsync();

        Task GoBackAsync();
    }
}
