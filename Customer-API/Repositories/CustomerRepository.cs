using Customer_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer_API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<IEnumerable<Customer>> GetCustomers(string searchTerm)
        {
            searchTerm = searchTerm.ToLower();
            var customers = await _context.Customers.Where(customer =>
                customer.FirstName.ToLower().Contains(searchTerm) ||
                customer.LastName.ToLower().Contains(searchTerm) ||
                customer.Email.ToLower().Contains(searchTerm)).ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                throw new Exception("Existing customer not found.");
            }
            return customer;
        }

        public async Task<int> CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer.Id;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            var existingCustomer = await _context.Customers.FindAsync(customer.Id);
            if (existingCustomer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            
            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            existingCustomer.UpdateAt = DateTime.UtcNow;

            _context.Entry(existingCustomer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return existingCustomer;
        }

        public async Task<int> DeleteCustomer(int id)
        {
            var customerToDelete = await _context.Customers.FindAsync(id);
            if (customerToDelete != null)
            {
                _context.Customers.Remove(customerToDelete);
            }
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IEnumerable<Customer>> DeleteAllCustomers()
        {
            var customersToDelete = await _context.Customers.ToListAsync();
            foreach (var customerToDelete in customersToDelete)
            {
                _context.Customers.Remove(customerToDelete);
            }
            await _context.SaveChangesAsync();
            return customersToDelete;
        }
    }
}
