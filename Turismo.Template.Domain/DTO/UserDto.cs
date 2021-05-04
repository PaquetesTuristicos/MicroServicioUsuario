using System;
using System.Collections.Generic;
using System.Text;

namespace Turismo.Template.Domain.DTO
{
    public class UserDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Roll { get; set; }
    }
}
