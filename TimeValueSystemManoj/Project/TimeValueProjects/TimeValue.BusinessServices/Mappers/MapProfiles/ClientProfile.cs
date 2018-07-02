using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TimeValue.DataModel;
using TimeValue.BusinessEntities.TimeValue.Master;

namespace TimeValue.BusinessServices.Mappers.MapProfiles
{
    class ClientProfile : Profile
    {

        public ClientProfile()
        {
            // Source:TvMClient and Destination:ClientEntity 
            CreateMap<Client , ClientEntity>()
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Name ))
                .ForMember(dest => dest.ClientID, opt => opt.MapFrom(src => src.PkClientId ));

            // Source:ClientEntity and Destination:TvMClient 
            CreateMap<ClientEntity, Client>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ClientName))
                .ForMember(dest => dest.PkClientId, opt => opt.MapFrom(src => src.ClientID ));
        }
    }

}
