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
    
    public partial class TimetableRecord
    {
        public System.Guid Id { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string Activities { get; set; }
    
        public virtual UserRecord UserRecord { get; set; }
    }
}