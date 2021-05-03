using System;
using System.Collections.Generic;
using System.Text;
using Turismo.Template.Domain.Commands;
using Turismo.Template.Domain.DTO;

namespace Turismo.Template.Application.Services
{

    internal interface IUserService
    {
        UserService createUser(UserDto user);
    }
    class UserService : IUserService
    {
        private readonly IRepositoryGeneric _repository;
        public UserService(IRepositoryGeneric repository)
        {
            _repository = repository;
        }

        public UserService createUser(UserDto user)
        {
            throw new NotImplementedException();
        }
    }

}
