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
    [Route("api/MetodoPago")]
    [ApiController]
    public class MetodoPagoControllers : ControllerBase
    {
        private readonly IMetodoPagoServices _service;

        public MetodoPagoControllers(IMetodoPagoServices service)
        {
            _service = service;
        }

        // GET: Empleados
        [HttpGet]
        public IEnumerable<MetodoPago> Get()
        {
            return _service.getAll();

        }
        // POST: Cargar Empleado
        [HttpPost]
        public IActionResult Post(MetodoPagoDto pago)
        {
            try
            {
                return new JsonResult(_service.Create(pago)) { StatusCode = 201 };
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
