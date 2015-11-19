
namespace Assessment.Data.Models
{
    public class CompanyRepresentativeInformation : Information
    {
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public CompanyInformation Company { get; set; }

        public Domain.Models.CompanyRepresentativeInformation mapToDomain()
        {
            return new Domain.Models.CompanyRepresentativeInformation
            {
                Title = this.Title,
                PhoneNumber = this.PhoneNumber,
                Company = this.Company.mapToDomain()
            };
        }

        public bool mapFromDomain(Domain.Models.CompanyInformation poco)
        {
            this.Title = p
        }
    }
}