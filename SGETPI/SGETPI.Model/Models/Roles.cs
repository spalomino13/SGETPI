using System;
using System.Collections.Generic;

namespace SGETPI.Model.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Usuarios = new HashSet<Usuarios>();
            IdPermisos = new HashSet<Permisos>();
        }

        public Guid IdRol { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }

        public virtual ICollection<Permisos> IdPermisos { get; set; }
    }
}
