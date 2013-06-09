using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginsCore
{
    /// <summary>
    /// Контейнер констант
    /// </summary>
    public class _Consts
    {
        public enum UserPermissions
        {
            View = 0,
            ViewModify = 1,
            ViewModifyDelete = 2
        }

        public enum UserRoles
        {
            User = 0,
            Moder = 1,
            Admin = 2
        }
    }
}
