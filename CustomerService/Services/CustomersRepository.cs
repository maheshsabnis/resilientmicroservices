using CustomerService.Models;

namespace CustomerService.Services
{
    public class CustomersRepository
    {
        CustomersDb _db;

        public CustomersRepository()
        {
            _db = new CustomersDb();    
        }

        public List<Customer> GetCustomers() => _db;
    }
}
