
namespace Assessment.Data.Models
{
    public class CompanyRepresentativeInformation : Information
    {
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public CompanyInformation Company { get; set; }

        internal Domain.Models.CompanyRepresentativeInformation mapToDomain()
        {
            return new Domain.Models.CompanyRepresentativeInformation
            {
                Title = Title, PhoneNumber = PhoneNumber,
                //Don't map if null
                Company = Company == null ? null : Company.mapToDomain(), City = City,
                Id = Id, Name = Name, StreetName = StreetName,
                StreetNumber = StreetNumber
            };
        }

        internal CompanyRepresentativeInformation mapFromDomain(Domain.Models.CompanyRepresentativeInformation poco)
        {//This mapping could be done by another object or third-party library.
         //Updating current state, could have treated immutably.
            Id = poco.Id;
            Name = poco.Name;
            Title = poco.Title;
            PhoneNumber = poco.PhoneNumber;
            Company = new CompanyInformation
            {
                City = poco.City, Id = poco.Id, Name = poco.Name,
                StreetName = poco.StreetName, StreetNumber = poco.StreetNumber
            };
            StreetName = poco.StreetName;
            StreetNumber = poco.StreetNumber;
            return this;
        }
    }
}