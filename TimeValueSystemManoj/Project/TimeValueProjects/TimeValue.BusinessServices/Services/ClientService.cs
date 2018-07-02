using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TimeValue.BusinessEntities.TimeValue.Master;
using TimeValue.BusinessServices.Interfaces;
using TimeValue.DataModel;
using TimeValue.DataModel.UnitOfWork;

namespace TimeValue.BusinessServices.Services
{
    /// <summary>
    /// Offers services for client specific CRUD operations
    /// </summary>
    public class ClientService : IClientService
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor
        /// </summary>
        public ClientService()
        {
            _unitOfWork = new UnitOfWork();
        } 

        /// <summary>
        /// Insert a client.
        /// </summary>
        /// <param name="p_objClientEntity"></param>
        /// <returns></returns>
        public long  CreateClient(ClientEntity p_objClientEntity)
        {
            using (var l_objScope = new TransactionScope())
            {
                var l_objClient = Mapper.Map<ClientEntity, Client>(p_objClientEntity);    

                _unitOfWork.ClientRepository.Insert(l_objClient);
                _unitOfWork.Save();
                l_objScope.Complete();
                return l_objClient.PkClientId ;
            }
        }

        /// <summary>
        /// Delete particular 
        /// </summary>
        /// <param name="p_longClientId"></param>
        /// <returns></returns>
        public bool DeleteClient(long p_longClientId)
        {
            var l_objSuccess = false;
            if (p_longClientId > 0)
            {
                using (var l_objScope = new TransactionScope())
                {
                    var l_objTvMClient = _unitOfWork.ClientRepository.GetByID(p_longClientId);
                    if (l_objTvMClient != null)
                    {
                        _unitOfWork.ClientRepository.Delete(l_objTvMClient);
                        _unitOfWork.Save();
                        l_objScope.Complete();
                        l_objSuccess = true;
                    }
                }
            }
            return l_objSuccess;
        }

        /// <summary>
        /// Get all clients
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ClientEntity> GetAllClients()
        {
            var l_objClient = _unitOfWork.ClientRepository.GetAll().ToList();
            if (l_objClient.Any())
            {                
                var l_objClientEntity = Mapper.Map<List<Client>,List<ClientEntity>>(l_objClient);
                return l_objClientEntity;
            }
            return null;
        }

        /// <summary>
        /// Get Client by Id
        /// </summary>
        /// <param name="p_longClientId"></param>
        /// <returns></returns>
        public ClientEntity GetClientById(long p_longClientId)
        {
            var l_objClient = _unitOfWork.ClientRepository.GetByID(p_longClientId);
            if (l_objClient != null)
            {                
                var l_objClientEntity = Mapper.Map<Client, ClientEntity>(l_objClient);
                return l_objClientEntity;
            }
            return null;
        }

        /// <summary>
        /// Update a client.
        /// </summary>
        /// <param name="p_longClientId"></param>
        /// <param name="p_objClientEntity"></param>
        /// <returns></returns>
        public bool UpdateClient(long p_longClientId, ClientEntity p_objClientEntity)
        {
            var l_boolSuccess = false;
            if (p_objClientEntity != null)
            {
                using (var l_objScope = new TransactionScope())
                {
                    var l_objClient = _unitOfWork.ClientRepository.GetByID(p_longClientId);
                    if (l_objClient != null)
                    {
                        l_objClient = Mapper.Map<ClientEntity, Client>(p_objClientEntity);
                        _unitOfWork.ClientRepository.Update(l_objClient);
                        _unitOfWork.Save();
                        l_objScope.Complete();
                        l_boolSuccess = true;
                    }
                }
            }
            return l_boolSuccess;
        }


    }
}
