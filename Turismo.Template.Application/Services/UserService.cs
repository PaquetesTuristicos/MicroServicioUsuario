using System;
using System.Collections.Generic;
using System.Text;
using Turismo.Template.Domain.Commands;
using Turismo.Template.Domain.DTO;

namespace Turismo.Template.Application.Services
{

    public interface IUserService
    {
        User createUser(UserDto user);
    }
    public class UserService : IUserService
    {
        private readonly IRepositoryGeneric _repository;
        public UserService(IRepositoryGeneric repository)
        {
            _repository = repository;
        }

        public User createUser(UserDto user)
        {
            throw new NotImplementedException();
        }
    }

}
