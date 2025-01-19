using System;
using System.Collections.Generic;

namespace SGETPI.Model.Models
{
    public partial class Sesiones
    {
        public Guid IdSesion { get; set; }
        public Guid IdUsuario { get; set; }
        public string Token { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaExpiracion { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
    }
}
