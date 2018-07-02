using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeValue.BusinessEntities.TimeValue.Master;
using TimeValue.BusinessServices.Interfaces;

namespace TimeValue.BusinessServices.Services
{
    public class EmployeeService : IEmployeeService
    {
        public int CreateEmployee(EmployeeEntity p_objEmployeeEntity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(long p_longEmployeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeEntity> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public EmployeeEntity GetEmployeeById(long p_longEmployeeId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmployee(long p_longEmployeeId, EmployeeEntity p_objEmployeeEntity)
        {
            throw new NotImplementedException();
        }
    }
}
