//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PermGuide
{
    using System;
    using System.Collections.Generic;
    
    public partial class SightRecord : ContentRecord
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SightRecord()
        {
            this.ExcursionRecord = new HashSet<ExcursionRecord>();
        }
    
        public string Location { get; set; }
        public string Address { get; set; }
    
        public virtual RegionRecord RegionRecord { get; set; }
        public virtual ArticleRecord ArticleRecord { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExcursionRecord> ExcursionRecord { get; set; }
    }
}
