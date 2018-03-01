using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ComName.ProjName.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using ComName.ProjName.Application.Services;
using ComName.ProjName.Dto;
using ComName.ProjName.Abstraction;
using ComName.ProjName.Domain;

namespace ComName.ProjName.Controllers
{
    [Authorize]
    public class ExampleController : Controller
    {
        private readonly IAppSession _appSession;
        private readonly IMapper _mapper;
        private readonly IDbService<AppUser> _appUserService;

        public ExampleController(IAppSession appSession,IMapper mapper,IDbService<AppUser> appUserService)
        {
            _appSession = appSession;
            _mapper = mapper;
            _appUserService = appUserService;
        }
        public string Index()
        {
            var userDto = _mapper.Map<UserDto>(_appSession.User);
            return userDto.UserName;
            //or of you want to get a specific user with it's username 
            var user = _appUserService.FindBy(item => item.UserName == "admin").FirstOrDefault();
            if (user != null)
            {
                var userDto_ = _mapper.Map<UserDto>(user);
                return userDto_.UserName;
            }
            return "Not found";
        }
    }
}
