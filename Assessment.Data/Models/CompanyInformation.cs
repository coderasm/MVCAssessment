
namespace Assessment.Data.Models
{
    public class CompanyInformation : Information
    {
        internal Domain.Models.CompanyInformation mapToDomain()
        {
            return new Domain.Models.CompanyInformation
            {
                City = City,
                Id = Id,
                Name = Name,
                StreetName = StreetName,
                StreetNumber = StreetNumber
            };
        }
    }
}