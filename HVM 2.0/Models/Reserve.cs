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
    
    public partial class Reserve
    {
        public Reserve() {}
        public Reserve(int p_id_creneau, int p_id_visiteur, int p_id_reserve)
        {
            id_Creneau = p_id_creneau;
            id_Visiteur = p_id_visiteur;
            id_Reserve = p_id_reserve;
        }

        public int id_Creneau { get; set; }
        public int id_Visiteur { get; set; }
        public int id_Reserve { get; set; }
    
        public virtual Creneau Creneau { get; set; }
        public virtual Visiteur Visiteur { get; set; }
    }
}
