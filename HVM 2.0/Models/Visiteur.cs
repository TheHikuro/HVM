//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HVM_2._0.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Visiteur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Visiteur()
        {
            this.Reserve = new HashSet<Reserve>();
        }

        public Visiteur(int p_id_visiteur, string p_prenom, string p_nom, string p_mail)
        {
            id_Visiteur = p_id_visiteur;
            prenom = p_prenom;
            nom = p_nom;
            mail = p_mail;
        }
    
        public int id_Visiteur { get; set; }
        public string prenom { get; set; }
        public string nom { get; set; }
        public string mail { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reserve> Reserve { get; set; }
    }
}
