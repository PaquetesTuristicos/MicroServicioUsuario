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
    [Route("api/Pasajero")]
    [ApiController]
    public class PasajeroControllers : ControllerBase
    {
        private readonly IPasajeroServices _service;
        public PasajeroControllers(IPasajeroServices service)
        {
            _service = service;
        }

        // GET: Pasajeros
        [HttpGet]
        [ProducesResponseType(typeof(List<UserByEmailDto>), StatusCodes.Status200OK)]

        public IActionResult Get([FromQuery] string email)
        {
            try
            {
                return new JsonResult(_service.GetPasajeroByEmail(email)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        // POST: Cargar Pasajero
        [HttpPost]
        public IActionResult Post(PasajeroDto roll)
        {
            try
            {
                return new JsonResult(_service.Create(roll)) { StatusCode = 201 };
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
                return new JsonResult(_service.getId(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public void DeleteId(int id)
        {
            _service.deleteId(id);
        }
    }
}
