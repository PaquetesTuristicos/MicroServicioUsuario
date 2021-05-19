using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Turismo.Template.Domain.DTO;
using Turismo.Template.Domain.Queries;

namespace Turismo.Template.AccessData.Queries
{
    public class PasajeroQuery : IPasajeroQuery
    {
        private readonly IDbConnection _connection;
        private readonly Compiler _SqlKataCompiler;

        public PasajeroQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            _connection = connection;
            _SqlKataCompiler = sqlKataCompiler;
        }

        public List<PasajeroByEmailDto> GetPasajeroByEmail(string email)
        {
            var db = new QueryFactory(_connection, _SqlKataCompiler);

            var users = db.Query("Users")
                .Select()
                .Join("Pasajeros", "Pasajeros.UserID", "Users.UserID")
                .When(!string.IsNullOrWhiteSpace(email), q => q.WhereLike("Users.Email", $"%{email}%"));
            var usersresult = users.Get<UserByEmailDto>();

            List<PasajeroByEmailDto> result = new List<PasajeroByEmailDto>();
            foreach (var c in usersresult)
            {
                var roles = db.Query("Roles")
                .Select("RollId", "Nombre", "Descripcion")
                .Where("RollId", "=", c.RollId)
                .FirstOrDefault<RollByEmailDto>();

                var pasajero = db.Query("Pasajeros")
                    .Select("Pasajeros.Dni", "Pasajeros.Telefono", "Pasajeros.FechaNacimiento", "Pasajeros.UserID")
                    .Where("UserId", "=", c.UserId)
                    .FirstOrDefault<EmpleadoByEmailDto>();
                result.Add(
                          new PasajeroByEmailDto
                          {
                              Dni = pasajero.Dni,
                              Telefono = pasajero.Telefono,
                              FechaNacimiento = pasajero.FechaNacimiento,
                              UserId = pasajero.UserId,
                              User = usersresult.ToList(),
                              Roll = roles
                          });
            }

            return result.ToList();
        }
    }
}
