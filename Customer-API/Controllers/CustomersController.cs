using Azure;
using Customer_API.Models;
using Customer_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }
        protected ObjectResult JsonResult(string message, object? data = null, int statusCode = StatusCodes.Status200OK)
        {
            return StatusCode(statusCode, new APIResponse
            {
                Success = statusCode == StatusCodes.Status200OK,
                Message = message,
                Data = data
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers([FromQuery] string searchString = "")
        {
            var response = await _service.GetCustomers(searchString);
            if (response.Successful)
            {
                return JsonResult("success", response.Data);
            }
            else return JsonResult(response.Error, null, StatusCodes.Status400BadRequest);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var response = await _service.GetCustomer(id);

            if (response.Successful)
            {
                return JsonResult("success", response.Data);
            }
            else return JsonResult(response.Error, null, StatusCodes.Status400BadRequest);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            var response = await _service.CreateCustomer(customer);

            if (response.Successful)
            {
                return JsonResult("success", customer.Id, StatusCodes.Status201Created);
            }
            return JsonResult(response.Error, null, StatusCodes.Status400BadRequest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            var response = await _service.UpdateCustomer(customer);

            if (response.Successful)
            {
                return JsonResult("success", response.Data, StatusCodes.Status200OK);
            }
            return JsonResult(response.Error, null, StatusCodes.Status400BadRequest);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var response = await _service.DeleteCustomer(id);

            if (response.Successful)
            {
                return JsonResult("success", id, StatusCodes.Status200OK);
            }
            return JsonResult(response.Error, null, StatusCodes.Status400BadRequest);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllCustomer()
        {
            var response = await _service.DeleteAllCustomers();

            if (response.Successful)
            {
                return JsonResult("success", response.Data, StatusCodes.Status200OK);
            }
            return JsonResult(response.Error, null, StatusCodes.Status400BadRequest);
        }
    }
}
