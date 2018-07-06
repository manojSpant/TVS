using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeValue.BusinessEntities.TimeValue.Auth;
using TimeValue.BusinessServices.Interfaces;
using System.Configuration;
using TimeValue.DataModel.UnitOfWork;
using TimeValue.DataModel;

namespace TimeValue.BusinessServices.Services
{
    public class TokenService : ITokenService
    {
        #region Private member variables.
        private readonly UnitOfWork _unitOfWork;
        #endregion

        #region Public constructor.
        /// <summary>
        /// Public constructor.
        /// </summary>
        public TokenService()
        {
            _unitOfWork = new  UnitOfWork();
        }
        #endregion

        /// <summary>
        /// This function is use to Delete the Token on the bases of userId.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool DeleteByUserId(long userId)
        {
            _unitOfWork.TokenRepository.Delete(x => x.FkUserId == userId);
            _unitOfWork.Save();

            var isNotDeleted = _unitOfWork.TokenRepository.GetMany(x => x.FkUserId == userId).Any();
            return !isNotDeleted;
        }

        /// <summary>
        /// Creating AuthToken with the help of GUID and save it into DB with IssueOn and ExpiresOn datatime 
        /// and return TokenEntity.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public TokenEntity GenerateToken(long userId)
        {

            string token = Guid.NewGuid().ToString();
            DateTime issuedOn = DateTime.Now;
            DateTime expiredOn = DateTime.Now.AddSeconds(
                                              Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
            var tokendomain = new Token
            {
                FkUserId = userId,
                AuthToken = token,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn
            };

            _unitOfWork.TokenRepository.Insert(tokendomain);
            _unitOfWork.Save();
            var tokenModel = new TokenEntity()
            {
                UserId = userId,
                IssuedOn = issuedOn,
                ExpiresOn = expiredOn,
                AuthToken = token
            };

            return tokenModel;
        }

        /// <summary>
        /// Delete the data from Token table on the bases of AuthToken.
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public bool Kill(string tokenId)
        {
            _unitOfWork.TokenRepository.Delete(x => x.AuthToken == tokenId);
            _unitOfWork.Save();
            var isNotDeleted = _unitOfWork.TokenRepository.GetMany(x => x.AuthToken == tokenId).Any();
            if (isNotDeleted) { return false; }
            return true;
        }

        /// <summary>
        /// This function is use to validate the AuthToken from Token table. 
        /// </summary>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public bool ValidateToken(string tokenId)
        {
            var token = _unitOfWork.TokenRepository.Get(t => t.AuthToken == tokenId && t.ExpiresOn > DateTime.Now);
            if (token != null && !(DateTime.Now > token.ExpiresOn))
            {
                
                token.ExpiresOn = token.ExpiresOn.Value.AddSeconds(
                                                                    Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
                _unitOfWork.TokenRepository.Update(token);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }
    }
}
