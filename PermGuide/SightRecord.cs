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
        public System.Data.Entity.Spatial.DbGeography Location { get; set; }
        public string Address { get; set; }
    
        public virtual RegionRecord RegionRecord { get; set; }
        public virtual ArticleRecord ArticleRecord { get; set; }
        public virtual ExcursionRecord ExcursionRecord { get; set; }
    }
}
