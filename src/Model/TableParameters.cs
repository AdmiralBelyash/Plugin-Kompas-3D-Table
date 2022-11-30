using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Model;
public class TableParameters : ObservableObject
{
    #region -- Fields --

    private Dictionary<ParameterType, Parameter> _tableParameterCollection;


    #endregion

    #region -- Properties --

    /// <summary>
    /// Словарь параметров.
    /// </summary>
    public Dictionary<ParameterType, Parameter> TableParameterCollection
    {
        get => _tableParameterCollection;
        set
        {
            SetProperty(ref _tableParameterCollection, value);
            OnPropertyChanged(nameof(TableParameterCollection));
        }
    }

    #endregion

    #region -- Constructors --

    /// <summary>
    /// Конструктор.
    /// </summary>
    public TableParameters()
    {
        TableParameterCollection = new Dictionary<ParameterType, Parameter>();
        SetDefaultValues();
    }

    #endregion

    #region -- Public Methods --

    /// <summary>
    /// Установить значения поумолчанию
    /// </summary>
    public void SetDefaultValues()
    {
        TableParameterCollection.Clear();
        TableParameterCollection.Add(ParameterType.TableLength,
            new()
            {
                Name = "Длинна стола L, мм:",
                MinValue = 300,
                MaxValue = 2000,
                Value = 300,
                ErrorMessage = $"Ошибка параметра не входит в диапазон"
            });
        TableParameterCollection.Add(ParameterType.TableHeight,
            new()
            {
                Name = "Высота стола H, мм:",
                MinValue = 300,
                MaxValue = 1200,
                Value = 300,
                ErrorMessage = "Ошибка параметра не входит в диапазон"
            });
        TableParameterCollection.Add(ParameterType.TableWidth,
            new()
            {
                Name = "Ширина стола W, мм:",
                MinValue = 300,
                MaxValue = 2000,
                Value = 300,
                ErrorMessage = "Ошибка параметра не входит в диапазон"
            });
        TableParameterCollection.Add(ParameterType.TableThickness,
            new()
            {
                Name = "Толщина столешницы K, мм:",
                MinValue = 10,
                MaxValue = 50,
                Value = 10,
                ErrorMessage = "Ошибка параметра не входит в диапазон"
            });

        TableParameterCollection.Add(
            ParameterType.TableLegsWidthDistance,
            new()
            {
                Name = "Расстояние между ножками стола по ширине w1, мм:",
                MinValue = TableParameterCollection[ParameterType.TableWidth].Value - 10,
                MaxValue = TableParameterCollection[ParameterType.TableWidth].Value - 10,
                Value = TableParameterCollection[ParameterType.TableWidth].Value - 10,
                ErrorMessage = "Ошибка параметра не входит в диапазон"
            }
        );

        TableParameterCollection.Add(
            ParameterType.TableLegsLengthDistance,
            new()
            {
                Name = "Расстояние между ножками стола по длине w2, мм:",
                MinValue = TableParameterCollection[ParameterType.TableLength].Value - 10,
                MaxValue = TableParameterCollection[ParameterType.TableLength].Value - 10,
                Value = TableParameterCollection[ParameterType.TableLength].Value - 10,
                ErrorMessage = "Ошибка параметра не входит в диапазон"
            }
        );

        TableParameterCollection.Add(
            ParameterType.TableLengthLegsEdgeDistance,
            new()
            {
                Name = "Расстояние от края стола по длине v1, мм:",
                MinValue = 0,
                MaxValue = TableParameterCollection[ParameterType.TableLength].Value
                           - TableParameterCollection[ParameterType.TableLegsLengthDistance].Value,
                Value = TableParameterCollection[ParameterType.TableLength].Value
                        - TableParameterCollection[ParameterType.TableLegsLengthDistance].Value,
                ErrorMessage = "Ошибка параметра не входит в диапазон"
            }
        );

        TableParameterCollection.Add(
            ParameterType.TableWidthLegsEdgeDistance,
            new()
            {
                Name = "Расстояние от края стола по ширине v2, мм:",
                MinValue = 0,
                MaxValue = TableParameterCollection[ParameterType.TableWidth].Value
                           - TableParameterCollection[ParameterType.TableLegsWidthDistance].Value,
                Value = TableParameterCollection[ParameterType.TableWidth].Value
                        - TableParameterCollection[ParameterType.TableLegsWidthDistance].Value,
                ErrorMessage = "Ошибка параметра не входит в диапазон"
            }
        );

    }

    public double GetLegsWidth()
    {
        return Math.Abs((TableParameterCollection[ParameterType.TableWidth].Value -
                         TableParameterCollection[ParameterType.TableLegsWidthDistance].Value -
                         2 * TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value) / 2);
    }

    /// <summary>
    /// Обновить зависимые параметры стеллажа.
    /// </summary>
    public void UpdateValues()
    {
        TableParameterCollection[ParameterType.TableLegsWidthDistance].MinValue =
            TableParameterCollection[ParameterType.TableWidth].Value / 2 - 10;
        TableParameterCollection[ParameterType.TableLegsWidthDistance].MaxValue =
            TableParameterCollection[ParameterType.TableWidth].Value - 10;
        TableParameterCollection[ParameterType.TableLegsWidthDistance].Value =
            TableParameterCollection[ParameterType.TableLegsWidthDistance].Value;

        TableParameterCollection[ParameterType.TableLegsLengthDistance].MinValue =
            TableParameterCollection[ParameterType.TableLength].Value / 2 - 10;
        TableParameterCollection[ParameterType.TableLegsLengthDistance].MaxValue =
            TableParameterCollection[ParameterType.TableLength].Value - 10;
        TableParameterCollection[ParameterType.TableLegsLengthDistance].Value =
            TableParameterCollection[ParameterType.TableLegsLengthDistance].Value;

        TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].MaxValue =
            TableParameterCollection[ParameterType.TableLength].Value
            - TableParameterCollection[ParameterType.TableLegsLengthDistance].Value;
        TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value =
            TableParameterCollection[ParameterType.TableLength].Value
            - TableParameterCollection[ParameterType.TableLegsLengthDistance].Value;

        TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].MaxValue =
            TableParameterCollection[ParameterType.TableWidth].Value
            - TableParameterCollection[ParameterType.TableLegsWidthDistance].Value;
        TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value =
            TableParameterCollection[ParameterType.TableWidth].Value
            - TableParameterCollection[ParameterType.TableLegsWidthDistance].Value;

    }

    /// <summary>
    /// Установить значения поумолчанию
    /// </summary>
    public void SetMinimumValues()
    {
        TableParameterCollection[ParameterType.TableLength].Value = 300;
        TableParameterCollection[ParameterType.TableHeight].Value = 300;
        TableParameterCollection[ParameterType.TableWidth].Value = 300;
        TableParameterCollection[ParameterType.TableThickness].Value = 10;
        TableParameterCollection[ParameterType.TableLegsWidthDistance].Value =
            TableParameterCollection[ParameterType.TableLegsWidthDistance].MaxValue;
        TableParameterCollection[ParameterType.TableLegsLengthDistance].Value =
            TableParameterCollection[ParameterType.TableLegsLengthDistance].MaxValue;
        UpdateValues();
    }
    /// <summary>
    /// Установить значения поумолчанию
    /// </summary>
    public void SetAverageValues()
    {
        TableParameterCollection[ParameterType.TableLength].Value = 1000;
        TableParameterCollection[ParameterType.TableHeight].Value = 600;
        TableParameterCollection[ParameterType.TableWidth].Value = 1000;
        TableParameterCollection[ParameterType.TableThickness].Value = 20;
        TableParameterCollection[ParameterType.TableLegsWidthDistance].Value =
            TableParameterCollection[ParameterType.TableLegsWidthDistance].MaxValue;
        TableParameterCollection[ParameterType.TableLegsLengthDistance].Value =
            TableParameterCollection[ParameterType.TableLegsLengthDistance].MaxValue;
        UpdateValues();
    }


    /// <summary>
    /// Установить значения поумолчанию
    /// </summary>
    public void SetMaximumValues()
    {
        TableParameterCollection[ParameterType.TableLength].Value = 2000;
        TableParameterCollection[ParameterType.TableHeight].Value = 1200;
        TableParameterCollection[ParameterType.TableWidth].Value = 2000;
        TableParameterCollection[ParameterType.TableThickness].Value = 50;
        TableParameterCollection[ParameterType.TableLegsWidthDistance].Value =
            TableParameterCollection[ParameterType.TableLegsWidthDistance].MaxValue;
        TableParameterCollection[ParameterType.TableLegsLengthDistance].Value =
            TableParameterCollection[ParameterType.TableLegsLengthDistance].MaxValue;
        UpdateValues();
    }

    #endregion
}
