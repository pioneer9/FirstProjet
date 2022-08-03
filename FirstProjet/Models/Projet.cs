using System;
using System.Collections.Generic;

namespace FirstProjet.Models
{
    public partial class Projet
    {
        public Projet()
        {
            Equipes = new HashSet<Equipe>();
        }

        public int Id { get; set; }
        public string? Nom { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public string? Etat { get; set; }

        public virtual ICollection<Equipe> Equipes { get; set; }
    }
}
