namespace CustomerService.Models
{
    public class CustomersDb:List<Customer>
    {
        public CustomersDb()
        {
            Add(new Customer() { CustomerId = 10001, CustomerName = "Mahesh Kumar", Phone = 11111 });
            Add(new Customer() { CustomerId = 10002, CustomerName = "Manish Kumar", Phone = 21111 });
            Add(new Customer() { CustomerId = 10003, CustomerName = "Mohan Kumar", Phone = 31111 });
            Add(new Customer() { CustomerId = 10004, CustomerName = "Makarand Kumar", Phone = 41111 });
            Add(new Customer() { CustomerId = 10005, CustomerName = "Madhav Kumar", Phone = 51111 });
            Add(new Customer() { CustomerId = 10006, CustomerName = "Mukesh Kumar", Phone = 61111 });
            Add(new Customer() { CustomerId = 10007, CustomerName = "Manohar Kumar", Phone = 71111 });
            Add(new Customer() { CustomerId = 10008, CustomerName = "Manas Kumar", Phone = 81111 });
            Add(new Customer() { CustomerId = 10009, CustomerName = "Mihir Kumar", Phone = 91111 });
            Add(new Customer() { CustomerId = 10010, CustomerName = "Manoj Kumar", Phone = 10111 });
        }
    }
}
