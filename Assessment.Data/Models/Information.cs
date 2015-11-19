
namespace Assessment.Data.Models
{
    public abstract class Information
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
    }
}