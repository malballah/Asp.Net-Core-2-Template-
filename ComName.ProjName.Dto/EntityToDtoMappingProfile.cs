using AutoMapper;
using ComName.ProjName.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComName.ProjName.Dto
{
    class EntityToDtoMappingProfile:Profile
    { public override string ProfileName => "EntityToDtoMappingProfile";
        public EntityToDtoMappingProfile()
        {
            ConfigureFromEfToModel();
        }
        private void ConfigureFromEfToModel()
        {
            //CreateMap<AppUser, UserDto>();
                //.IgnoreAllNonExisting();
        }
    }
}