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
    
    public partial class Reserve
    {
        public int id_Creneau { get; set; }
        public int id_Visiteur { get; set; }
        public int id_test { get; set; }
    
        public virtual Creneau Creneau { get; set; }
        public virtual Visiteur Visiteur { get; set; }
    }
}
