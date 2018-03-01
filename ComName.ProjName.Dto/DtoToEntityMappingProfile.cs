using AutoMapper;
using ComName.ProjName.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComName.ProjName.Dto
{
    class DtoToEntityMappingProfile : Profile
    { public override string ProfileName => "DtoToEntityMappingProfile";
        public DtoToEntityMappingProfile()
        {
            ConfigureFromEfToModel();
        }
        private void ConfigureFromEfToModel()
        {
           // CreateMap<UserDto,AppUser >();
                //.IgnoreAllNonExisting();
        }
    }
}