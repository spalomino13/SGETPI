using System;
using System.Collections.Generic;

namespace SGETPI.Model.Models
{
    public partial class Modulos
    {
        public Modulos()
        {
            IdPermisos = new HashSet<Permisos>();
        }

        public Guid IdModulo { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Permisos> IdPermisos { get; set; }
    }
}
