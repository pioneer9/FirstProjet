using System;
using System.Collections.Generic;

namespace FirstProjet.Models
{
    public partial class Equipe
    {
        public Equipe()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? NomEquipe { get; set; }
        public int? IdProjet { get; set; }

        public virtual Projet? IdProjetNavigation { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
