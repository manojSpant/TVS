using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeValue.BusinessEntities.TimeValue.Master;

namespace TimeValue.BusinessServices.Interfaces
{
    public interface ICompanyService
    {
        CompanyEntity GetCompanyById(long p_longCompanyId);
        IEnumerable<CompanyEntity> GetAllCompanys();
        int CreateCompany(CompanyEntity p_objCompanyEntity);
        bool UpdateCompany(long p_longCompanyId, CompanyEntity p_objCompanyEntity);
        bool DeleteCompany(long p_longCompanyId);
    }
}
