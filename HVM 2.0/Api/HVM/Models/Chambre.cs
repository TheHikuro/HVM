//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HVM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Chambre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chambre()
        {
            this.Possede = new HashSet<Possede>();
        }
    
        public int id_chambre { get; set; }
        public Nullable<int> numero { get; set; }
        public Nullable<int> etage { get; set; }
        public string batiment { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Possede> Possede { get; set; }
    }
}
