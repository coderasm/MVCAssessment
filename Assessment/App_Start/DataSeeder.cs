using Assessment.Domain.Models;
using Assessment.Domain.Repositories;

namespace Assessment
{
    public class DataSeeder
    {
        public static void seed(ICustomerRepository repository)
        {
            for (var i = 1; i < 6; i++)
            {
                repository.Insert(new CustomerInformation
                {
                    Id = i, City = "CustomerCity" + i, Name = "CustomerName" + i, Notes = "CustomerNotes" + i,
                    Representative = new CompanyRepresentativeInformation {
                        Id = i, City = "RepresentativeCity" + i,
                        Company = new CompanyInformation {
                            Id = i, City = "CompanyCity" + i, Name = "CompanyName" + i,
                            StreetName = "CompanyStreetName" + i, StreetNumber = i + 3452
                        },
                        Name = "RepresentativeName" + i, PhoneNumber = "RepresentativePhone" + i, Title = "RepresentativeTitle" + i,
                        StreetName = "RepresentativeStreetName" + i, StreetNumber = i + 4567
                    },
                    StreetName = "CustomerStreetName" + i, StreetNumber = i + 5634, PhoneNumber = "CustomerPhoneNumber" + i
                });
            }
        }
    }
}