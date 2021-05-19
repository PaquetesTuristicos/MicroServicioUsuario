using System;
using System.Collections.Generic;
using System.Text;
using Turismo.Template.Domain.Commands;
using Turismo.Template.Domain.DTO;
using Turismo.Template.Domain.Entities;
using Turismo.Template.Domain.Queries;

namespace Turismo.Template.Application.Services
{
    public interface IRollServices
    {
        IEnumerable<Roll> getAll();
        Roll getId(int id);
    }
    public class RollServices : IRollServices
    {
        private readonly IRepositoryGeneric _repository;
        private readonly IUserQuery _query;
        public RollServices(IRepositoryGeneric repository, IUserQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public IEnumerable<Roll> getAll()
        {
            return _repository.Traer<Roll>();
        }

        public Roll getId(int id)
        {
            return _repository.FindBy<Roll>(id);
        }
    }
}
