using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turismo.Template.Domain.DTO;

namespace Turismo.Template.API.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly IUserService _service;
        public UserControllers (IUserService service)
        {
            _service = service;
        }
        [HttpPost]
        public UserControllers Post(UserDto user)
        {
            return _service.createUser(user);
        }

    }
}
