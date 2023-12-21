using System;
using System.Collections.Generic;

namespace SistemaUsuario.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Agenda = new HashSet<Agenda>();
        }

        public int IdUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Contraseña { get; set; }
        public int IdPersona { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        public virtual ICollection<Agenda> Agenda { get; set; }
    }
}
