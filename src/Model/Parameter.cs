using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Model
{
    /// <summary>
    /// Класс параметра.
    /// </summary>
    public class Parameter : ObservableObject
    {
        #region -- Fields --

        /// <summary>
        /// Текущее значение параметра.
        /// </summary>
        private double _value;

        /// <summary>
        /// Минимальное значение параметра.
        /// </summary>
        private double _minValue;

        /// <summary>
        /// Максимальное значени параметра.
        /// </summary>
        private double _maxValue;

        /// <summary>
        /// Название параметра.
        /// </summary>
        private string _name;

        /// <summary>
        /// Текст ошибки.
        /// </summary>
        private string _errorMessage;

        /// <summary>
        /// Есть ли ошибки у параметра.
        /// </summary>
        private bool _hasError;

        #endregion

        #region -- Properties --

        /// <summary>
        /// Значение параметра.
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (value > _maxValue || value < MinValue || Value < 0)
                {
                    HasError = true;
                }
                else
                {
                    HasError = false;
                }
                SetProperty(ref _value, value);
                OnPropertyChanged(nameof(Value));
            }
        }

        /// <summary>
        /// Минимальное значение параметра.
        /// </summary>
        public double MinValue
        {
            get => _minValue;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                SetProperty(ref _minValue, value);
                OnPropertyChanged(nameof(MinValue));
            }
        }

        /// <summary>
        /// Максимальное значение параметра.
        /// </summary>
        public double MaxValue
        {
            get => _maxValue;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                SetProperty(ref _maxValue, value);
                OnPropertyChanged(nameof(MaxValue));
            }
        }

        /// <summary>
        /// Отображаемое имя параметра.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Сообщение ошибки параметра.
        /// </summary>
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                SetProperty(ref _errorMessage, value);
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        /// <summary>
        /// Есть ли ошибка у параметра.
        /// </summary>
        public bool HasError
        {
            get => _hasError;
            set
            {
                SetProperty(ref _hasError, value);
                OnPropertyChanged(nameof(HasError));
            }
        }

        #endregion
    }
}
