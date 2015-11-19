using System.Collections.Generic;
using Assessment.Domain.Models;

namespace Assessment.Domain.Fetchers
{
    class CustomerFetcher {

        public List<CustomerInformation> Customers { get; set; }

        public CustomerInformation Fetch(string name)
        {
            return Customers.Find(c => c.Name.Equals(name));
        }

        public CustomerInformation Fetch(int id)
        {
            return Customers.Find(c => c.Id.Equals(id));
        }
    }
}
