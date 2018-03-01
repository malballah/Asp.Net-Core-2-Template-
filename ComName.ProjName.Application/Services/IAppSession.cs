using ComName.ProjName.Abstraction;
using ComName.ProjName.Domain;

namespace ComName.ProjName.Application.Services
{
    public interface IAppSession:IApplicationService
    {
        AppUser User { get; }
    }
}