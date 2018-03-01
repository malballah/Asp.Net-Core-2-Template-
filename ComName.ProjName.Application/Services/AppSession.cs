using System;
using System.Collections.Generic;
using System.Text;
using ComName.ProjName.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ComName.ProjName.Abstraction;

namespace ComName.ProjName.Application.Services
{
    public class AppSession : ApplicationService,IAppSession
    {
        private readonly IHttpContextAccessor _context;
        private readonly UserManager<AppUser> _userManager;
        private AppUser _user;

        public AppSession(IHttpContextAccessor context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public AppUser User {
            get {
                if (_user == null)
                    _user = _userManager.Users.SingleOrDefault(item => item.UserName == _context.HttpContext.User.Identity.Name);
                return _user;
            }
        }

    }
}
