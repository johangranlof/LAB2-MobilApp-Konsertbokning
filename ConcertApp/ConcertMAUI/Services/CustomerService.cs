using ConcertMAUI.Models;
using ConcertMAUI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertMAUI.Services
{
    public class CustomerService : ICustomerService
    {
        IRestService<Customer> _restService;

        public CustomerService(IRestService<Customer> restService)
        {
            _restService = restService;
        }

        public Task<List<Customer>> GetCustomerAsync()
        {
            return _restService.RefreshDataAsync();
        }

        public Task SaveCustomerAsync(Customer customer, bool isNewItem = false)
        {
            return _restService.SaveItemAsync(customer, isNewItem);
        }

        public Task DeleteCustomerAsync(Customer customer)
        {
            return _restService.DeleteItemAsync(customer.Id);
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            var customers = await _restService.RefreshDataAsync();
            return customers.FirstOrDefault(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
    }
}
