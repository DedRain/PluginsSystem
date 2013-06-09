using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PluginsCore
{
    /// <summary>
    /// Обертка над Lazy[IPlugin]
    /// </summary>
    public class PluginObject
    {
        private bool __init_Active;
        private bool _Active = true;
        /// <summary>
        /// Признак активности плагина
        /// </summary>
        public bool Active
        {
            get
            {
                if (!__init_Active)
                {
                    //чтение из базы
                    __init_Active = true;
                }
                return _Active;
            }
        }

        private IPlugin _Plugin;
        /// <summary>
        /// Плагин
        /// </summary>
        public IPlugin Plugin
        {
            get { return _Plugin; }
            private set { _Plugin = value; }
        }

        public PluginObject(IPlugin plugin)
        {

            if (plugin == null)
            {
                string errorText = string.Format("Ошибка: Не передан аргумент Lazy<IPlugin>");
                throw new Exception(errorText);
            }
            this._Plugin = plugin;
        }

        //аргументом передать юзера, для определения прав
        /// <summary>
        /// Активация плагина в базе
        /// </summary>
        /// <returns>Результат активации</returns>
        bool Activate()
        {
            //Активация плагина в базе
            return false;
        }
    }
}
