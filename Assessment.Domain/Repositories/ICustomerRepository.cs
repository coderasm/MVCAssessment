using Assessment.Domain.Models;

namespace Assessment.Domain.Repositories
{
    public interface ICustomerRepository : IRepository<CustomerInformation>
    {
        CustomerInformation Select(string name);
    }
}
