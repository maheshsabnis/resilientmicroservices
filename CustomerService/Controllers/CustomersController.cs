using CustomerService.Models;
using CustomerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomersRepository _repository;

        public CustomersController(CustomersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public List<Customer> Get() => _repository.GetCustomers();
         
    }
}
