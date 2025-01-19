using System;
using System.Collections.Generic;

namespace SGETPI.Model.Models
{
    public partial class Permisos
    {
        public Permisos()
        {
            IdModulos = new HashSet<Modulos>();
            IdRols = new HashSet<Roles>();
        }

        public Guid IdPermiso { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }

        public virtual ICollection<Modulos> IdModulos { get; set; }
        public virtual ICollection<Roles> IdRols { get; set; }
    }
}
