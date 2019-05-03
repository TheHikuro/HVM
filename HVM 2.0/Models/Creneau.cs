namespace HVM_2._0.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Creneau
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        public Creneau()
        {
            this.Reserve1 = new HashSet<Reserve>();
        }

        public Creneau(DateTime p_date)
        {
            date = p_date;
        }
        
    
        public int id_creneau { get; set; }
        public Nullable<System.TimeSpan> heure { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public byte[] disponibilite { get; set; }
        public byte[] reserve { get; set; }
        public Nullable<int> id_patient { get; set; }
        


        public virtual Patient Patient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reserve> Reserve1 { get; set; }

    }
}
