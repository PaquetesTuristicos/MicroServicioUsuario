using System;
using System.Collections.Generic;
using System.Text;
using Turismo.Template.Domain.Commands;

namespace Turismo.Template.Application.Services
{

    internal interface IUserService
    {
    }
    class UserService : IUserService
    {
        private readonly IRepositoryGeneric _repository;
        public UserService(IRepositoryGeneric repository)
        {
            _repository = repository;
        }
    }

}
