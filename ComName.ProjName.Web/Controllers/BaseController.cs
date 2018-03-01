
using ComName.ProjName.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComName.ProjName.Controllers
{
    public class BaseController : Controller
    {
        public IAppSession AppSession { get; set; } 
    }
}