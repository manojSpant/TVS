using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeValue.BusinessEntities.TimeValue.Master;

namespace TimeValue.BusinessServices.Interfaces
{
   public interface IOrganizationService
    {
        OrganizationEntity GetOrganizationById(long p_longOrganizationId);
        IEnumerable<OrganizationEntity> GetAllOrganizations();
        int CreateOrganization(OrganizationEntity p_objOrganizationEntity);
        bool UpdateOrganization(long p_longOrganizationId, OrganizationEntity p_objOrganizationEntity);
        bool DeleteOrganization(long p_longOrganizationId);

    }
}
