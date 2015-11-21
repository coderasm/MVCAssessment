using System;
using System.Collections.Generic;
using System.Linq;
using Assessment.Data.Models;
using Assessment.Domain.Repositories;

namespace Assessment.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository {

        private static List<CustomerInformation> Customers { get; set; }
        private static int IdCounter = 1;

        public CustomerRepository()
        {
            Customers = new List<CustomerInformation>();
        }

        public Domain.Models.CustomerInformation Select(string name)
        {
            return Customers.Find(c => c.Name.Equals(name)).mapToDomain();
        }

        public Domain.Models.CustomerInformation Select(int id)
        {
            return Customers.Find(c => c.Id.Equals(id)).mapToDomain();
        }

        public List<Domain.Models.CustomerInformation> Select()
        {
            return Customers.Select(cr => cr.mapToDomain()).ToList();
        }

        public void Insert(Domain.Models.CustomerInformation poco)
        {//This will insert a null representative from client side
            Customers.Add(new CustomerInformation
            {//This mapping could be done by another object or third-party library
                City = poco.City, Id = IdCounter, Name = poco.Name, Notes = poco.Notes,
                PhoneNumber = poco.PhoneNumber, StreetName = poco.StreetName,
                StreetNumber = poco.StreetNumber,
                //If representative is null, don't map
                Representative = poco.Representative == null ? null : new CompanyRepresentativeInformation {
                    City = poco.Representative.City, Id = poco.Representative.Id,
                    //If company is null, don't map
                    Company = poco.Representative.Company == null ? null : new Func<Domain.Models.CompanyInformation, CompanyInformation>(company => new CompanyInformation {
                        City = company.City, Id = company.Id,
                        Name = company.Name, StreetName = company.StreetName,
                        StreetNumber = company.StreetNumber
                    })(poco.Representative.Company),
                    Name = poco.Representative.Name, PhoneNumber = poco.Representative.PhoneNumber,
                    StreetName = poco.Representative.StreetName, StreetNumber = poco.Representative.StreetNumber,
                    Title = poco.Representative.Title
                }
            });
            incrementIdCounter();
        }

        private void incrementIdCounter()
        {
            IdCounter++;
        }

        public void Update(Domain.Models.CustomerInformation poco)
        {//This will set representative to null from client side
            Customers.Find(cr => cr.Id.Equals(poco.Id)).mapFromDomain(poco);
        }

        public bool Delete(int id)
        {
            var customerToRemove = Customers.Find(cr => cr.Id.Equals(id));
            return Customers.Remove(customerToRemove);
        }
    }
}
