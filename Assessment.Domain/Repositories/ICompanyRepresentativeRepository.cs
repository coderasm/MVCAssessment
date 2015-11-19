using System.Collections.Generic;
using Assessment.Domain.Models;

namespace Assessment.Domain.Repositories
{
    public interface ICompanyRepresentativeRepository : IRepository<CompanyRepresentativeInformation>
    {
        CompanyRepresentativeInformation Select(string name);
        List<CompanyRepresentativeInformation> SelectByCompany(int companyId);
    }
}
