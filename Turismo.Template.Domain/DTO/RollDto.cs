using System;
using System.Collections.Generic;
using System.Text;
using Turismo.Template.Domain.Entities;

namespace Turismo.Template.Domain.DTO
{
    public class RollDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<User> Usuarios { get; set; }
    }
}
