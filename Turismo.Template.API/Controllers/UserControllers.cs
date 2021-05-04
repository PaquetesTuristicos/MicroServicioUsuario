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
    [Route("api/controller")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly IUserService _service;
        public UserControllers (IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public User Get(UserDto user)
        {

            var entity = new User
            {

            };
            return entity;
        }

        [HttpPost]
        public User Post(UserDto user)
        {
            return _service.CreateUser(user);
        }
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _service.getUser();
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
