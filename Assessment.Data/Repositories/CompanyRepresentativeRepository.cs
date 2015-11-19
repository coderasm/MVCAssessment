using System.Collections.Generic;
using System.Linq;
using Assessment.Data.Models;
using Assessment.Domain.Repositories;

namespace Assessment.Data.Repositories
{
    class CompanyRepresentativeRepository : ICompanyRepresentativeRepository
    {
        public List<CompanyRepresentativeInformation> CompanyRepresentatives { get; set; }

        public CompanyRepresentativeInformation FetchByCompany(int companyId)
        {
            return CompanyRepresentatives.Find(c => c.Company.Id.Equals(companyId));
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

        public bool Insert(Domain.Models.CompanyRepresentativeInformation poco)
        {
            CompanyRepresentatives.Add(new CompanyRepresentativeInformation
            {
                City = poco.City,
                Company = new CompanyInformation
                {
                    City = poco.Company.City, Id = poco.Company.Id, Name = poco.Company.Name,
                    StreetName = poco.Company.StreetName, StreetNumber = poco.Company.StreetNumber
                },
                Id = poco.Id, Name = poco.Name, PhoneNumber = poco.PhoneNumber,
                StreetName = poco.StreetName, StreetNumber = poco.StreetNumber
            });
        }

        public bool Update(Domain.Models.CompanyRepresentativeInformation poco)
        {
            var ccr = CompanyRepresentatives.FindAll(cr => cr.Id.Equals(poco.Id));

        }

        public bool Delete(int id)
        {
            CompanyRepresentatives.re
        }
    }
}
