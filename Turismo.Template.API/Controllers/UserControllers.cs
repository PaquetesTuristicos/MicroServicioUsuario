using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turismo.Template.Application.Services;
using Turismo.Template.Domain.DTO;
using Turismo.Template.Domain.Entities;

namespace Turismo.Template.API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly IUserService _service;
        public UserControllers (IUserService service)
        {
            _service = service;
        }

        // GET: Usuarios
        [HttpGet]
        [ProducesResponseType(typeof(List<UserByEmailDto>), StatusCodes.Status200OK)]
        public IActionResult Get([FromQuery] string email)
        {
            try
            {
                return new JsonResult(_service.GetUserByEmail(email)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // POST: Cargar usuario
        // nombre, apelido, email, password
        [HttpPost]
        public User Post(UserDto user)
        {
            return _service.CreateUser(user);
        }

        [HttpGet("{id}")]
        public User GetId(int id)
        {
            return _service.getUserId(id);
        }

        [HttpDelete("{id}")]
        public void DeleteId(int id)
        {
            _service.deleteUserId(id);
        }

    }
}
