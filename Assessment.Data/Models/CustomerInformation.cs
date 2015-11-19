
namespace Assessment.Data.Models
{
    public class CustomerInformation : Information
    {
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        public CompanyRepresentativeInformation Representative { get; set; }

        public Domain.Models.CustomerInformation mapToDomain()
        {
            return new Domain.Models.CustomerInformation
            {
                City = this.City,
                Id = this.Id,
                Name = this.Name,
                Notes = this.Notes,
                PhoneNumber = this.PhoneNumber,
                Representative = this.Representative.mapToDomain(),
                StreetName = this.StreetName,
                StreetNumber = this.StreetNumber
            };
        }
    }
}