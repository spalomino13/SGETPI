using System;
using System.Collections.Generic;

namespace SGETPI.Model.Models
{
    public partial class UsuariosDepartamentos
    {
        public Guid IdUsuario { get; set; }
        public Guid IdDepartamento { get; set; }
        public DateTime FechaAsignacion { get; set; }

        public virtual Departamentos IdDepartamentoNavigation { get; set; } = null!;
        public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
    }
}
