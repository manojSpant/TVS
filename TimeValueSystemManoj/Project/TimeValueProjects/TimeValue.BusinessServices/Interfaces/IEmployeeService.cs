using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeValue.BusinessEntities.TimeValue.Master;

namespace TimeValue.BusinessServices.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeEntity GetEmployeeById(long p_longEmployeeId);
        IEnumerable<EmployeeEntity> GetAllEmployees();
        int CreateEmployee(EmployeeEntity p_objEmployeeEntity);
        bool UpdateEmployee(long p_longEmployeeId, EmployeeEntity p_objEmployeeEntity);
        bool DeleteEmployee(long p_longEmployeeId);
    }
}
