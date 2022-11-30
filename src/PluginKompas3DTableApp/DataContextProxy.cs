using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PluginKompas3DTableApp
{
    public class DataContextProxy : Freezable
    {
        #region Overrides of Freezable

        protected override Freezable CreateInstanceCore()
        {
            return new DataContextProxy();
        }

        #endregion

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

        public static readonly DependencyProperty DataProperty = DependencyProperty.Register("DataSource",
            typeof(object), typeof(DataContextProxy), new UIPropertyMetadata(null));
    }
}