using System;
using System.Collections.Generic;
using System.Text;

namespace Turismo.Template.Domain.Entities
{
    public class User
    {

        public Guid UserId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid RollId {get;set;}
    }
}
