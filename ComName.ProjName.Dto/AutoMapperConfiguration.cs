using AutoMapper;
using AutoMapper.Attributes;
using ComName.ProjName.Dto;
using System.Collections.Generic;

namespace ComName.ProjName.Dto
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Configure(IList<Profile> profiles = null){

            Mapper.Initialize(config => {
                typeof(Dto).Assembly.MapTypes(config);
                config.AddProfile<DtoToEntityMappingProfile>();
                config.AddProfile<EntityToDtoMappingProfile>();
                if(profiles!=null)
                foreach (var profile in profiles)
                {
                    config.AddProfile(profile);
                }
            });
            return Mapper.Instance;
        }

    }
}
