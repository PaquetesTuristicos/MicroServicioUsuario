using System;
using System.Collections.Generic;
using System.Text;
using Turismo.Template.Domain.Commands;
using Turismo.Template.Domain.DTO;
using Turismo.Template.Domain.Entities;

namespace Turismo.Template.Application.Services
{
    public interface IEmpleadoServices
    {
        Empleado Create(EmpleadoDto empleado);
        IEnumerable<Empleado> getAll();
        Empleado getId(int id);
        void deleteId(int id);
    }
    public class EmpleadoServices : IEmpleadoServices
    {
        private readonly IRepositoryGeneric _repository;
        public EmpleadoServices(IRepositoryGeneric repository)
        {
            _repository = repository;
        }
        public Empleado Create(EmpleadoDto empleado)
        {
            var entity = new Empleado
            {
                Dni = empleado.Dni,
                Telefono = empleado.Telefono,
                FechaNacimiento = empleado.FechaNacimiento,
                Sueldo = empleado.Sueldo,
                Legajo = empleado.Legajo,
                UserId = empleado.UserId,

            };
            _repository.Add<Empleado>(entity);
            return entity;
        }

        public void deleteId(int id)
        {
            _repository.DeleteBy<Empleado>(id);
        }

        public IEnumerable<Empleado> getAll()
        {
            return _repository.Traer<Empleado>();
        }

        public Empleado getId(int id)
        {
            return _repository.FindBy<Empleado>(id);
        }
    }
}
