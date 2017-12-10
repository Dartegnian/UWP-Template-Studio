using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace RemiliaScarlet.Services
{
    public interface INavigableTo
    {
        /// <summary>
        /// The event that gets called by the Navigation Service after navigation has completed.
        /// </summary>
        /// <remarks>
        /// This gets called prior to <see cref="Windows.UI.Xaml.Controls.Page.OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs)"/>
        /// </remarks>
        /// <param name="navigationMode">The navigation stack characteristic of the navigation.</param>
        /// <param name="parameter">The parameter passed to the navigation service</param>
        /// <returns>An awaitable Task</returns>
        Task NavigatedTo(NavigationMode navigationMode, object parameter);
    }
}
