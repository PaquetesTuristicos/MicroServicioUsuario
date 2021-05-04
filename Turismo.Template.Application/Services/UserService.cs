using System;
using System.Collections.Generic;
using System.Text;
using Turismo.Template.Domain.Commands;
using Turismo.Template.Domain.DTO;
using Turismo.Template.Domain.Entities;


namespace Turismo.Template.Application.Services
{

    public interface IUserService
    {
        User CreateUser(UserDto user);
        IEnumerable<User> getUser();
        User getUserId(int id);
        void deleteUserId(int id);
    }
    public class UserService : IUserService
    {
        private readonly IRepositoryGeneric _repository;
        public UserService(IRepositoryGeneric repository)
        {
            _repository = repository;
        }

        public User CreateUser(UserDto user)
        {
            var entity = new User
            {
                UserId = Guid.NewGuid(),
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
    }

}
