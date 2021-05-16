using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Turismo.Template.Domain.Queries;

namespace Turismo.Template.AccessData.Queries
{
    public class EmpleadoQuery : IEmpleadoQuery
    {
        private readonly IDbConnection _connection;
        private readonly Compiler _sqlKataCompiler;

        public EmpleadoQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            _connection = connection;
            _sqlKataCompiler = sqlKataCompiler;
        }
    }
}
