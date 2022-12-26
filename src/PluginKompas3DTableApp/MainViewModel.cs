using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KompasApi;
using Model;

namespace PluginKompas3DTableApp
{
    /// <summary>
    /// Модель представления. Связь модели и отображения.
    /// </summary>
    public class MainViewModel : ObservableObject
    {
        #region -- Fields --

        private TableParameters _tableParameters;

        private bool _hasErrors;

        #endregion

        #region -- Properties --

        /// <summary>
        /// Параметры стола.
        /// </summary>
        public TableParameters TableParameters
        {
            get => _tableParameters;
            set
            {
                SetProperty(ref _tableParameters, value);
                OnPropertyChanged(nameof(TableParameters));
            }
        }

        /// <summary>
        /// Есть ли ошибки в параметрах стола.
        /// </summary>
        public bool HasErrors
        {
            get => _hasErrors;
            set
            {
                SetProperty(ref _hasErrors, value);
                OnPropertyChanged(nameof(HasErrors));
            }
        }


        #endregion

        #region -- Commands --

        /// <summary>
        /// Обновление параметров стола.
        /// </summary>
        public RelayCommand UpdateParametersCommand => new RelayCommand(() =>
        {
            TableParameters.UpdateValues();
        });

        public RelayCommand SetMinimumValuesCommand => new RelayCommand(() =>
        {
            TableParameters.SetMinimumValues();
        });
        public RelayCommand SetMaximumValuesCommand => new RelayCommand(() =>
        {
            TableParameters.SetMaximumValues();
        });

        public RelayCommand SetAverageValuesCommand => new RelayCommand(() =>
        {
            TableParameters.SetAverageValues();
        });

        /// <summary>
        /// Построение стола.
        /// </summary>
        public RelayCommand BuildCommand => new RelayCommand(async () =>
        {
            if (!TableParameters.TableParameterCollection.All(x => x.Value.HasError))
            {
                TableBuilder builder = new TableBuilder();
                IWrapper api = new KompasWrapper();
                await Task.Run(() => builder.BuildTable(TableParameters, api));
            }
        });

        /// <summary>
        /// Проверка параметров на ошибки.
        /// </summary>
        public RelayCommand CheckErrors => new RelayCommand(() =>
        {
            if (TableParameters.TableParameterCollection.Any(x => x.Value.HasError))
            {
                HasErrors = true;
            }
            else
            {
                HasErrors = false;
            }
        });

        #endregion

        #region -- Constructors --

        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainViewModel()
        {
            TableParameters = new TableParameters();
        }

        #endregion
    }
}
