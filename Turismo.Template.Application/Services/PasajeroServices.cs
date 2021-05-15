using System;
using System.Collections.Generic;
using System.Text;
using Turismo.Template.Domain.Commands;
using Turismo.Template.Domain.DTO;
using Turismo.Template.Domain.Entities;

namespace Turismo.Template.Application.Services
{
    public interface IPasajeroServices
    {
        Pasajero Create(PasajeroDto pasajero);
        IEnumerable<Pasajero> getAll();
        Pasajero getId(int id);
        void deleteId(int id);
    }
    public class PasajeroServices : IPasajeroServices
    {
        private readonly IRepositoryGeneric _repository;
        public PasajeroServices(IRepositoryGeneric repository)
        {
            _repository = repository;
        }
        public Pasajero Create(PasajeroDto pasajero)
        {
            var entity = new Pasajero
            {
                Dni = pasajero.Dni,
                Telefono = pasajero.Telefono,
                FechaNacimiento = pasajero.FechaNacimiento,
                UserId = pasajero.UserId,

            };
            _repository.Add<Pasajero>(entity);
            return entity;
        }

        public void deleteId(int id)
        {
            _repository.DeleteBy<Pasajero>(id);
        }

        public IEnumerable<Pasajero> getAll()
        {
            return _repository.Traer<Pasajero>();
        }

        public Pasajero getId(int id)
        {
            return _repository.FindBy<Pasajero>(id);
        }
    }
}
