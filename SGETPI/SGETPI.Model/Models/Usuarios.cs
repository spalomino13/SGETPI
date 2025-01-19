using System;
using System.Collections.Generic;

namespace SGETPI.Model.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            AuditoriaSesiones = new HashSet<AuditoriaSesiones>();
            Departamentos = new HashSet<Departamentos>();
            Sesiones = new HashSet<Sesiones>();
            UsuariosDepartamentos = new HashSet<UsuariosDepartamentos>();
        }

        public Guid IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Telefono { get; set; }
        public string Password { get; set; } = null!;
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string? TipoUsuario { get; set; }
        public Guid? IdRol { get; set; }

        public virtual Roles? IdRolNavigation { get; set; }
        public virtual ICollection<AuditoriaSesiones> AuditoriaSesiones { get; set; }
        public virtual ICollection<Departamentos> Departamentos { get; set; }
        public virtual ICollection<Sesiones> Sesiones { get; set; }
        public virtual ICollection<UsuariosDepartamentos> UsuariosDepartamentos { get; set; }
    }
}
