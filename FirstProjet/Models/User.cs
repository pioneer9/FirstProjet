using System;
using System.Collections.Generic;

namespace FirstProjet.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Sexe { get; set; }
        public int? Tel { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Type { get; set; }
        public string? DateEmbauche { get; set; }
        public string? Fonctionnalite { get; set; }
        public int? IdEquipe { get; set; }

        public virtual Equipe? IdEquipeNavigation { get; set; }
    }
}
