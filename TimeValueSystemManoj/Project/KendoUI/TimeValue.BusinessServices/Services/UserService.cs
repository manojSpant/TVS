using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeValue.BusinessServices.Interfaces;
using TimeValue.DataModel.UnitOfWork;

namespace TimeValue.BusinessServices.Services
{
   public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public UserService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Public constructor.
        /// </summary>
        public UserService()
        {
            _unitOfWork = new UnitOfWork ();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public long Authenticate(string userName, string password)
        {
            var user = _unitOfWork.UserRepository.Get(u => u.UserName == userName && u.Password == password);
            if (user != null && user.PkUserId > 0)
            {
                return user.PkUserId;
            }
            return 0;
        }
    }
}
