
using System.Collections.Generic;
using Assessment.Domain.Models;

namespace Assessment.Domain.Fetchers
{
    class CompanyRepresentativeFetcher
    {
        public List<CompanyRepresentativeInformation> CompanyRepresentatives { get; set; }

        public CompanyRepresentativeInformation Fetch(string name)
        {
            return CompanyRepresentatives.Find(c => c.Name.Equals(name));
        }

        public CompanyRepresentativeInformation Fetch(int id)
        {
            return CompanyRepresentatives.Find(c => c.Id.Equals(id));
        }

        public CompanyRepresentativeInformation FetchByCompany(int companyId)
        {
            return CompanyRepresentatives.Find(c => c.Company.Id.Equals(companyId));
        }
    }
}
