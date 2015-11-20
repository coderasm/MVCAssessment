using System;

namespace Assessment.Data.Models
{
    public class CustomerInformation : Information
    {
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        public CompanyRepresentativeInformation Representative { get; set; }

        internal Domain.Models.CustomerInformation mapToDomain()
        {
            return new Domain.Models.CustomerInformation
            {
                City = City,
                Id = Id,
                Name = Name,
                Notes = Notes,
                PhoneNumber = PhoneNumber,
                //Don't map if null
                Representative = Representative == null ? null : Representative.mapToDomain(),
                StreetName = StreetName,
                StreetNumber = StreetNumber
            };
        }

        internal void mapFromDomain(Domain.Models.CustomerInformation poco)
        {//This mapping could be done by another object or third-party library.
         //Updating current state, could have treated immutably.
            City = poco.City;
            Id = poco.Id;
            Name = poco.Name;
            Notes = poco.Notes;
            PhoneNumber = poco.PhoneNumber;
            StreetName = poco.StreetName;
            StreetNumber = poco.StreetNumber;
            if (poco.Representative == null) return;//Don't null the representative
            Representative = new CompanyRepresentativeInformation {
                City = poco.Representative.City, Id = poco.Representative.Id,
                Company = new Func<Domain.Models.CompanyInformation, CompanyInformation>(company => new CompanyInformation {
                    City = company.City, Id = company.Id,
                    Name = company.Name, StreetName = company.StreetName,
                    StreetNumber = company.StreetNumber
                })(poco.Representative.Company),
                Name = poco.Representative.Name, PhoneNumber = poco.Representative.PhoneNumber,
                StreetName = poco.Representative.StreetName, StreetNumber = poco.Representative.StreetNumber,
                Title = poco.Representative.Title
            };
        }
    }
}