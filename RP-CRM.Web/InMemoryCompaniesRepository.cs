using System.Collections.Generic;
using System.Linq;
using RP_CRM.Data;

namespace RP_CRM.Web
{
    public interface IInMemoryCompaniesRepository
    {
        IEnumerable<Company> GetAllCompanies();
    }
    
    public class InMemoryCompaniesRepository : IInMemoryCompaniesRepository
    {
        private readonly IEnumerable<string> _companiesNames = new List<string>()
        {
            "Сбербанк", "Яндекс", "Luxoft"
        };
        
        public IEnumerable<Company> GetAllCompanies()
        {
            return _companiesNames
                .Select(companyName => new Company(companyName));
        }
    }
}