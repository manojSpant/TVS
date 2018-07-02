using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeValue.BusinessEntities.TimeValue.Master;
using TimeValue.BusinessServices.Interfaces;
using TimeValue.DataModel;
using TimeValue.DataModel.UnitOfWork;

namespace TimeValue.BusinessServices.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly UnitOfWork _unitOfWork;

        public OrganizationService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public int CreateOrganization(OrganizationEntity p_objOrganizationEntity)
        {


            throw new NotImplementedException();
        }

        public bool DeleteOrganization(long p_longOrganizationId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrganizationEntity> GetAllOrganizations()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This function is use to get the Organization Model on the bases of Organization ID
        /// </summary>
        /// <param name="p_longOrganizationId"></param>
        /// <returns></returns>
        public OrganizationEntity GetOrganizationById(long p_longOrganizationId)
        {

            try
            {
                // Collect the Organization data from MOrganizationRepository "MOrganization table" on the bases of PKMOrganizationID filed. 
                var l_objOrganization = _unitOfWork.OrganizationRepository.GetByID(p_longOrganizationId);

                // Check for null
                if (l_objOrganization != null)
                {
                    
                    // Create a map for types TvMOrganization and OrganizationEntity.
                    Mapper.Initialize(cfg => cfg.CreateMap<Organization, OrganizationEntity>());
                    //Map the records of the TvMOrganization into OrganizationEntity
                    var l_objOrganizationModel = Mapper.Map<OrganizationEntity>(l_objOrganization);
                    return l_objOrganizationModel;
                    
                }

                return null ;

            }           

            catch(Exception ex)
            {
                throw new NotImplementedException();
            }

            finally
            {
                
            }

        }

        public bool UpdateOrganization(long p_longOrganizationId, OrganizationEntity p_objOrganizationEntity)
        {
            throw new NotImplementedException();
        }
    }
}
