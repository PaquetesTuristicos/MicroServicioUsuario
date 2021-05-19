using System;
using System.Collections.Generic;
using System.Text;
using Turismo.Template.Domain.Commands;
using Turismo.Template.Domain.DTO;
using Turismo.Template.Domain.Entities;
using Turismo.Template.Domain.Queries;

namespace Turismo.Template.Application.Services
{

    public interface IUserService
    {
        User CreateUser(UserDto user);
        IEnumerable<User> getUser();
        User getUserId(int id);
        void deleteUserId(int id);
        List<UserByEmailDto> GetUserByEmail(string email);
    }
    public class UserService : IUserService
    {
        private readonly IRepositoryGeneric _repository;
        private readonly IUserQuery _query;
        public UserService(IRepositoryGeneric repository, IUserQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public User CreateUser(UserDto user)
        {
            var entity = new User
            {
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Email = user.Email,
                Password = user.Password,
                RollId = user.Roll
            };
            _repository.Add<User>(entity);
            return entity;
        }
        public IEnumerable<User> getUser()
        {
            return _repository.Traer<User>();
        }

        public User getUserId(int id)
        {
            return _repository.FindBy<User>(id);
        }

        public void deleteUserId(int id)
        {
            _repository.DeleteBy<User>(id);
        }

        public List<UserByEmailDto> GetUserByEmail(string email)
        {
            return _query.GetUserByEmail(email);
        }
    }

}
