using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Models;
using ProductsService.Services;

namespace ProductsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductsRepository _repository; 

        public ProductsController(ProductsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public List<Product> Get() => _repository.GetProducts(); 
         
    }
}
