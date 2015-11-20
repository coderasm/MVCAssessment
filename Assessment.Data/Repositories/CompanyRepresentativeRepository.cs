using System.Collections.Generic;
using System.Linq;
using Assessment.Data.Models;
using Assessment.Domain.Repositories;

namespace Assessment.Data.Repositories
{
    public class CompanyRepresentativeRepository : ICompanyRepresentativeRepository
    {
        private static List<CompanyRepresentativeInformation> CompanyRepresentatives { get; set; }

        public CompanyRepresentativeRepository()
        {
            CompanyRepresentatives = new List<CompanyRepresentativeInformation>();
        }

        public Domain.Models.CompanyRepresentativeInformation Select(string name)
        {
            return CompanyRepresentatives.Find(c => c.Name.Equals(name)).mapToDomain();
        }

        public List<Domain.Models.CompanyRepresentativeInformation> SelectByCompany(int companyId)
        {
            return CompanyRepresentatives.FindAll(c => c.Company.Id.Equals(companyId)).Select(cr => cr.mapToDomain()).ToList();
        }

        public Domain.Models.CompanyRepresentativeInformation Select(int id)
        {
            return CompanyRepresentatives.Find(c => c.Id.Equals(id)).mapToDomain();
        }

        public List<Domain.Models.CompanyRepresentativeInformation> Select()
        {
            return CompanyRepresentatives.Select(cr => cr.mapToDomain()).ToList();
        }

        public void Insert(Domain.Models.CompanyRepresentativeInformation poco)
        {
            CompanyRepresentatives.Add(new CompanyRepresentativeInformation
            {
                City = poco.City, Title = poco.Title,
                Company = new CompanyInformation
                {
                    City = poco.Company.City, Id = poco.Company.Id, Name = poco.Company.Name,
                    StreetName = poco.Company.StreetName, StreetNumber = poco.Company.StreetNumber
                },
                Id = poco.Id, Name = poco.Name, PhoneNumber = poco.PhoneNumber,
                StreetName = poco.StreetName, StreetNumber = poco.StreetNumber
            });
        }

        public void Update(Domain.Models.CompanyRepresentativeInformation poco)
        {
            CompanyRepresentatives.Find(cr => cr.Id.Equals(poco.Id)).mapFromDomain(poco);
        }

        public bool Delete(int id)
        {
            var companyRepresentativeToRemove = CompanyRepresentatives.Find(cr => cr.Id.Equals(id));
            return CompanyRepresentatives.Remove(companyRepresentativeToRemove);
        }
    }
}
