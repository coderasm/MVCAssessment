namespace Assessment.Domain.Models
{
    public class CompanyRepresentativeInformation : Information
    {
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public CompanyInformation Company { get; set; }
    }
}