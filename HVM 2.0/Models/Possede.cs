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
    
    public partial class Possede
    {
        public int id_Patient { get; set; }
        public int id_chambre { get; set; }
        public int id_possede { get; set; }
    
        public virtual Chambre Chambre { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
    }
}
