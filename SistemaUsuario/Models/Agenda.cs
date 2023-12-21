using System;
using System.Collections.Generic;

namespace SistemaUsuario.Models
{
    public partial class Agenda
    {
        public int IdAgenda { get; set; }
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
