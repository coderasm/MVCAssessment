
namespace Assessment.Domain.Models
{
    public class CustomerInformation : Information
    {
        public string PhoneNumber { get; set; }
        public string Notes { get; set; }
        public CompanyRepresentativeInformation Representative { get; set; }
    }
}