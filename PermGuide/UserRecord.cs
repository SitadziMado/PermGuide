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
    
    public partial class UserRecord
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserRecord()
        {
            this.ReviewRecord = new HashSet<ReviewRecord>();
            this.TimetableRecord = new HashSet<TimetableRecord>();
            this.ExcursionRecord = new HashSet<ExcursionRecord>();
            this.ArticleRecord = new HashSet<ArticleRecord>();
            this.FileRecord = new HashSet<FileRecord>();
        }
    
        public System.Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReviewRecord> ReviewRecord { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimetableRecord> TimetableRecord { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExcursionRecord> ExcursionRecord { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ArticleRecord> ArticleRecord { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileRecord> FileRecord { get; set; }
    }
}
