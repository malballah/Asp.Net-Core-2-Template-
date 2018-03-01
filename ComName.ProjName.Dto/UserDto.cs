using AutoMapper.Attributes;
using ComName.ProjName.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComName.ProjName.Dto
{
    [MapsTo(typeof(AppUser))]
    public class UserDto: Dto
    {
        public string UserName { get; set; }
    }
}
