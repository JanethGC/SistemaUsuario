using System;
using System.Collections.Generic;

namespace SistemaUsuario.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Agenda = new HashSet<Agenda>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdPersona { get; set; }
        public string? Cedula { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public int? Edad { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }

        public virtual ICollection<Agenda> Agenda { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
