using Customer_API.Models;

namespace Customer_API.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<IEnumerable<Customer>> GetCustomers(string search);
        Task<Customer> GetCustomer(int id);
        Task<int> CreateCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<int> DeleteCustomer(int id);
        Task<IEnumerable<Customer>> DeleteAllCustomers();
    }
}
