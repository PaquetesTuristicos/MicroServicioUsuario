using Microsoft.AspNetCore.Cors;
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
        public IActionResult Post(UserDto user)
        {
            try
            {
                return new JsonResult(_service.CreateUser(user)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {

            try
            {
                return new JsonResult(_service.getUserId(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteId(int id)
        {
            try
            {
                var user = _service.getUserId(id);
                if (user != null)
                {
                    _service.deleteUserId(id);
                    return new JsonResult(user) { StatusCode = 200 };
                }
                else
                {
                    return new JsonResult(user) { StatusCode = 404 };
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

    }
}
