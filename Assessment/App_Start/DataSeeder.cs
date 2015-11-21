using System;
using Assessment.Domain.Models;
using Assessment.Domain.Repositories;

namespace Assessment
{
    public class DataSeeder
    {
        private static readonly string[] representativePhoneNumbers = { "7142358945", "7144568215", "9515684931", "9092648921" };
        private static readonly string[] customerPhoneNumbers = { "9156327458", "5628956341", "9515684931", "9092648921" };
        private static readonly int[] customerStreetNumbers = { 12598, 89653, 45368, 13857 };
        private static readonly int[] representativeStreetNumbers = { 45689, 23859, 12597, 35849};
        private static readonly int[] companyStreetNumbers = { 56234, 45125, 89542, 63524 };

        public static void seed(ICustomerRepository repository)
        {
            for (var i = 1; i < 5; i++)
            {
                repository.Insert(new CustomerInformation
                {
                    Id = i, City = "CustomerCity" + i, Name = "CustomerName" + i, Notes = "CustomerNotes" + i,
                    Representative = new CompanyRepresentativeInformation {
                        Id = i, City = "RepresentativeCity" + i,
                        Company = new CompanyInformation {
                            Id = i, City = "CompanyCity" + i, Name = "CompanyName" + i,
                            StreetName = "CompanyStreetName" + i, StreetNumber = companyStreetNumbers[i-1]
                        },
                        Name = "RepresentativeName" + i, PhoneNumber = representativePhoneNumbers[i-1], Title = "RepresentativeTitle" + i,
                        StreetName = "RepresentativeStreetName" + i, StreetNumber = representativeStreetNumbers[i-1]
                    },
                    StreetName = "CustomerStreetName" + i, StreetNumber = customerStreetNumbers[i-1], PhoneNumber = customerPhoneNumbers[i-1]
                });
            }
        }
    }
}