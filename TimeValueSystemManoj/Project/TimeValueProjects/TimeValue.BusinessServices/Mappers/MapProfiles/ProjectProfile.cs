using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeValue.BusinessEntities.TimeValue.Master;
using TimeValue.DataModel;

namespace TimeValue.BusinessServices.Mappers.MapProfiles
{
  public  class ProjectProfile : Profile 
    {
        public ProjectProfile()
        {
            // Source:TvMProject and Destination:ProjectEntity 
            CreateMap<Project, ProjectEntity>()
                .ForMember(dest => dest.ClientID , opt => opt.MapFrom(src => src.FkClientId))
                .ForMember(dest => dest.ProjectID , opt => opt.MapFrom(src => src.PkProjectId ))
                .ForMember(dest => dest.ProjectName , opt => opt.MapFrom(src => src.Name));

            // Source:ProjectEntity and Destination:TvMProject 
            CreateMap<ProjectEntity, Project>()
                .ForMember(dest => dest.FkClientId , opt => opt.MapFrom(src => src.ClientID ))
                .ForMember(dest => dest.PkProjectId , opt => opt.MapFrom(src => src.ProjectID  ))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProjectName));
        }
    }
}
