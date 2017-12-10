namespace RemiliaScarlet.Services.Navigation
{
    public interface IPageWithViewModel<T>
        where T : class
    {
        T ViewModel { get; set; }

        void UpdateBindings();
    }
}
