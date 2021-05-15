using System;
using System.Collections.Generic;
using System.Text;
using Turismo.Template.Domain.Commands;
using Turismo.Template.Domain.DTO;
using Turismo.Template.Domain.Entities;

namespace Turismo.Template.Application.Services
{
    public interface IMetodoPagoServices
    {
        MetodoPago Create(MetodoPagoDto pago);
        IEnumerable<MetodoPago> getAll();
        MetodoPago getId(int id);
        void deleteId(int id);
    }
    public class MetodoPagoServices : IMetodoPagoServices
    {
        private readonly IRepositoryGeneric _repository;
        public MetodoPagoServices(IRepositoryGeneric repository)
        {
            _repository = repository;
        }
        public MetodoPago Create(MetodoPagoDto pago)
        {
            var entity = new MetodoPago
            {
                Nombre = pago.Nombre,
                
            };
            _repository.Add<MetodoPago>(entity);
            return entity;
        }

        public void deleteId(int id)
        {
            _repository.DeleteBy<MetodoPago>(id);
        
        }

        public IEnumerable<MetodoPago> getAll()
        {
            return _repository.Traer<MetodoPago>();
        }

        public MetodoPago getId(int id)
        {
            return _repository.FindBy<MetodoPago>(id);
        }
    }
}
