using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeValue.BusinessEntities.TimeValue.Master;
using TimeValue.BusinessServices.Interfaces;

namespace TimeValue.BusinessServices.Services
{
    public class CompanyService : ICompanyService
    {
        public int CreateCompany(CompanyEntity p_objCompanyEntity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCompany(long p_longCompanyId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompanyEntity> GetAllCompanys()
        {
            throw new NotImplementedException();
        }

        public CompanyEntity GetCompanyById(long p_longCompanyId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCompany(long p_longCompanyId, CompanyEntity p_objCompanyEntity)
        {
            throw new NotImplementedException();
        }
    }
}
