using Customer_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customer_API.Services
{
    public interface ICustomerService
    {
        Task<ServiceResponse<string>> GetCustomers();
        Task<ServiceResponse<string>> GetCustomers(string search);
        Task<ServiceResponse<string>> GetCustomer(int id);
        Task<ServiceResponse<string>> CreateCustomer(Customer customer);
        Task<ServiceResponse<string>> UpdateCustomer(Customer customer);
        Task<ServiceResponse<string>> DeleteCustomer(int id);
        Task<ServiceResponse<string>> DeleteAllCustomers();
    }
}
