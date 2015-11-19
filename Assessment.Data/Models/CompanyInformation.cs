
namespace Assessment.Data.Models
{
    public class CompanyInformation : Information
    {
        internal Domain.Models.CompanyInformation mapToDomain()
        {
            return new Domain.Models.CompanyInformation
            {
                City = this.City,
                Id = this.Id,
                Name = this.Name,
                StreetName = this.StreetName,
                StreetNumber = this.StreetNumber
            };
        }
    }
}