using System;
using System.Collections.Generic;

namespace SGETPI.Model.Models
{
    public partial class Departamentos
    {
        public Departamentos()
        {
            UsuariosDepartamentos = new HashSet<UsuariosDepartamentos>();
        }

        public Guid IdDepartamento { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public Guid? IdSupervisor { get; set; }

        public virtual Usuarios? IdSupervisorNavigation { get; set; }
        public virtual ICollection<UsuariosDepartamentos> UsuariosDepartamentos { get; set; }
    }
}
