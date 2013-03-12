using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginsCore
{
    /// <summary>
    /// Результат применения настроек
    /// </summary>
    public struct ValidationResult
    {
        private bool _Result;
        /// <summary>
        /// Результат
        /// </summary>
        public bool Result
        {
            get { return _Result; }
            set { _Result = value; }
        }

        private string _Message;
        /// <summary>
        /// Информация об ошибках
        /// </summary>
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
    }
}
