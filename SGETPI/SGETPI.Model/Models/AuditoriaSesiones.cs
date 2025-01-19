using System;
using System.Collections.Generic;

namespace SGETPI.Model.Models
{
    public partial class AuditoriaSesiones
    {
        public Guid IdAuditoria { get; set; }
        public Guid IdUsuario { get; set; }
        public string IpAcceso { get; set; } = null!;
        public string Navegador { get; set; } = null!;
        public DateTime FechaAcceso { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; } = null!;
    }
}
