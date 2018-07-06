using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeValue.BusinessEntities.TimeValue.Master;

namespace TimeValue.BusinessServices.Interfaces
{
    /// <summary>
    /// Client Service Contract
    /// </summary>
    public interface IClientService
    {
        ClientEntity GetClientById(long p_longClientId);
        IEnumerable<ClientEntity> GetAllClients();
        long  CreateClient(ClientEntity p_objClientEntity);
        bool UpdateClient(long  p_longClientId, ClientEntity p_objClientEntity);
        bool DeleteClient(long p_longClientId);
    }
}
