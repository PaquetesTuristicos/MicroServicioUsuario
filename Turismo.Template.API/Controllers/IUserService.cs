using Turismo.Template.Domain.DTO;

namespace Turismo.Template.API.Controllers
{
    public interface IUserService
    {
        UserControllers createUser(UserDto user);
    }
}