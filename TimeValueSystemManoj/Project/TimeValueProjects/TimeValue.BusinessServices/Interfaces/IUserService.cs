using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeValue.BusinessServices.Interfaces
{
   public interface IUserService
    {
        long  Authenticate(string userName, string password);
    }
}
