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
    
    public partial class Utilisateur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utilisateur()
        {
            this.Creneau = new HashSet<Creneau>();
            this.Possede = new HashSet<Possede>();
        }

        public Utilisateur(int p_id_patient, string p_prenom, string p_nom, int p_age, string p_login, string p_password, int p_code_visiteur, bool p_administrateur)
        {
            id_patient = p_id_patient;
            prenom = p_prenom;
            nom = p_nom;
            age = p_age;
            login = p_login;
            password = p_password;
            code_visiteur = p_code_visiteur;
            administrateur = p_administrateur;
        }
    
        public int id_patient { get; set; }
        public string prenom { get; set; }
        public string nom { get; set; }
        public Nullable<int> age { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Nullable<int> code_visiteur { get; set; }
        public Nullable<bool> administrateur { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Creneau> Creneau { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Possede> Possede { get; set; }
    }
}
