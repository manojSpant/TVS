using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeValue.BusinessServices.Mappers.MapProfiles;

namespace TimeValue.BusinessServices.Mappers
{
   public static class MapperConfigurations
    {

        public static void ConfigurationMap()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile(new ClientProfile());
                config.AddProfile(new ProjectProfile());
            });
        }
    }
}
