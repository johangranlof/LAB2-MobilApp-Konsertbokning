using ConcertMAUI.Models;

namespace ConcertMAUI.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomerAsync();
        Task SaveCustomerAsync(Customer customer, bool isNewCustomer);
        Task DeleteCustomerAsync(Customer customer);
        Task<Customer> GetCustomerByEmailAsync(string email);
    }
}
