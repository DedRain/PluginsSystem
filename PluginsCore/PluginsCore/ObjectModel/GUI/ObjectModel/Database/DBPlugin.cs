//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PluginsSystem.ObjectModel.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class DBPlugin
    {
        public DBPlugin()
        {
            this.DBUsersPermisions = new HashSet<DBUsersPermision>();
        }
    
        public System.Guid ID { get; set; }
        public Nullable<System.Guid> Owner { get; set; }
        public bool IsActive { get; set; }
        public string AssemblyInfo { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<DBUsersPermision> DBUsersPermisions { get; set; }
    }
}
