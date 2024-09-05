using Customer_API.Models;
using Customer_API.Repositories;
using System.Text.Json;

namespace Customer_API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse<string>> GetCustomers()
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var customers = await _repository.GetCustomers("");
                response.Data = JsonSerializer.Serialize(customers);
            }
            catch (Exception ex)
            {
                response.Error = $"Exception while getting customers. Reason: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<string>> GetCustomers(string search)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var customers = await _repository.GetCustomers(search);
                response.Data = JsonSerializer.Serialize(customers);
            }
            catch (Exception ex)
            {
                response.Error = $"Exception while getting customers. Reason: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<string>> GetCustomer(int id)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var customer = await _repository.GetCustomer(id);
                response.Data = JsonSerializer.Serialize(customer);
            }
            catch (Exception ex)
            {
                response.Error = $"Exception while getting a customer information. Reason: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<string>> CreateCustomer(Customer customer)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var id = await _repository.CreateCustomer(customer);
                response.Data = JsonSerializer.Serialize(id);
            }
            catch (Exception ex)
            {
                response.Error = $"Exception while creating a new customer. Reason: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<string>> UpdateCustomer(Customer customer)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var updatedCustomer = await _repository.UpdateCustomer(customer);
                response.Data = JsonSerializer.Serialize(updatedCustomer);
            }
            catch (Exception ex)
            {
                response.Error = $"Exception while updating the customer. Reason: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<string>> DeleteCustomer(int id)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var deletedId = await _repository.DeleteCustomer(id);
                response.Data = JsonSerializer.Serialize(deletedId);
            }
            catch (Exception ex)
            {
                response.Error = $"Exception while deleting a customer. Reason: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<string>> DeleteAllCustomers()
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            try
            {
                var customers = await _repository.DeleteAllCustomers();
                response.Data = JsonSerializer.Serialize(customers);
            }
            catch (Exception ex)
            {
                response.Error = $"Exception while deleting all data. Reason: {ex.Message}";
            }
            return response;
        }
    }
}
