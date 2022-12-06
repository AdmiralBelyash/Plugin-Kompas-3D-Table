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
    /// Установить значения по-умолчанию.
    /// </summary>
    public void SetDefaultValues()
    {
        TableParameterCollection.Clear();
        TableParameterCollection.Add(ParameterType.TableLength,
            new()
            {
                Name = "Table length L, mm:",
                MinValue = 300,
                MaxValue = 2000,
                Value = 300,
                ErrorMessage = $"Parameter error. Value not in range"
            });
        TableParameterCollection.Add(ParameterType.TableHeight,
            new()
            {
                Name = "Table Height H, mm:",
                MinValue = 300,
                MaxValue = 1200,
                Value = 300,
                ErrorMessage = "Parameter error. Value not in range"
            });
        TableParameterCollection.Add(ParameterType.TableWidth,
            new()
            {
                Name = "Table Width W, mm:",
                MinValue = 300,
                MaxValue = 2000,
                Value = 300,
                ErrorMessage = "Parameter error. Value not in range"
            });
        TableParameterCollection.Add(ParameterType.TableThickness,
            new()
            {
                Name = "Tabletop Thickness K, mm:",
                MinValue = 10,
                MaxValue = 50,
                Value = 10,
                ErrorMessage = "Parameter error. Value not in range"
            });

        TableParameterCollection.Add(
            ParameterType.TableLegsWidthDistance,
            new()
            {
                Name = "Table Legs Width Distance w1, mm:",
                MinValue = TableParameterCollection[ParameterType.TableWidth].Value - 10,
                MaxValue = TableParameterCollection[ParameterType.TableWidth].Value - 10,
                Value = TableParameterCollection[ParameterType.TableWidth].Value - 10,
                ErrorMessage = "Parameter error. Value not in range"
            }
        );

        TableParameterCollection.Add(
            ParameterType.TableLegsLengthDistance,
            new()
            {
                Name = "Table Legs Length Distance w2, mm:",
                MinValue = TableParameterCollection[ParameterType.TableLength].Value - 10,
                MaxValue = TableParameterCollection[ParameterType.TableLength].Value - 10,
                Value = TableParameterCollection[ParameterType.TableLength].Value - 10,
                ErrorMessage = "Parameter error. Value not in range"
            }
        );

        TableParameterCollection.Add(
            ParameterType.TableLengthLegsEdgeDistance,
            new()
            {
                Name = "Table Length Legs Edge Distance v1, mm:",
                MinValue = 0,
                MaxValue = TableParameterCollection[ParameterType.TableLength].Value
                           - TableParameterCollection[ParameterType.TableLegsLengthDistance].Value,
                Value = TableParameterCollection[ParameterType.TableLength].Value
                        - TableParameterCollection[ParameterType.TableLegsLengthDistance].Value,
                ErrorMessage = "Parameter error. Value not in range"
            }
        );

        TableParameterCollection.Add(
            ParameterType.TableWidthLegsEdgeDistance,
            new()
            {
                Name = "Table Width Legs Edge Distance v2, mm:",
                MinValue = 0,
                MaxValue = TableParameterCollection[ParameterType.TableWidth].Value
                           - TableParameterCollection[ParameterType.TableLegsWidthDistance].Value,
                Value = TableParameterCollection[ParameterType.TableWidth].Value
                        - TableParameterCollection[ParameterType.TableLegsWidthDistance].Value,
                ErrorMessage = "Parameter error. Value not in range"
            }
        );
        TableParameterCollection.Add(
            ParameterType.TableCornerRadius,
            new()
            {
                Name = "Table Corner Radius Fillet, mm:",
                MinValue = 0,
                MaxValue = 2 * ((TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value 
                            + TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value) / 2),
                Value = 0,
                ErrorMessage = "Parameter error. Value not in range"
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
    /// Обновление зависимых параметров стола.
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
        TableParameterCollection[ParameterType.TableCornerRadius].MaxValue =
            2 * ((TableParameterCollection[ParameterType.TableLengthLegsEdgeDistance].Value 
                  + TableParameterCollection[ParameterType.TableWidthLegsEdgeDistance].Value) / 2);


    }

    /// <summary>
    /// Установить минимальные параметры.
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
    /// Установить средние значения.
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
    /// Установить максимамльные значения.
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
