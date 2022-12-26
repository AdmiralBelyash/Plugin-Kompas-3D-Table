using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PluginKompas3DTableApp
{
    /// <summary>
    /// Вспомогательный класс для привязки свойств.
    /// </summary>
    public class DataContextProxy : Freezable
    {
        #region Overrides of Freezable

        /// <summary>
        /// Переопределение коструктора.
        /// </summary>
        /// <returns></returns>
        protected override Freezable CreateInstanceCore()
        {
            return new DataContextProxy();
        }

        #endregion

        /// <summary>
        /// Источник данных.
        /// </summary>
        public object DataSource
        {
            get
            {
                return (object)GetValue(DataProperty);
            }
            set
            {
                SetValue(DataProperty, value);
            }
        }

        /// <summary>
        /// Регистрация источника данных.
        /// </summary>
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register("DataSource",
            typeof(object), typeof(DataContextProxy), new UIPropertyMetadata(null));
    }
}