namespace ConcertMAUI.Services.Interfaces
{
    public interface IRestService<T> where T : class
    {
        Task<List<T>> RefreshDataAsync();
        Task SaveItemAsync(T item, bool isNewItem = false);
        Task DeleteItemAsync(int id);
    }
}

