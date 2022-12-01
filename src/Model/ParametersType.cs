using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model;
/// <summary>
/// Перечисление параметров стола.
/// </summary>
public enum ParameterType
{
    TableLength,

    TableHeight,

    TableWidth,

    TableThickness,

    TableLegsWidthDistance,

    TableLegsLengthDistance,

    TableWidthLegsEdgeDistance,

    TableLengthLegsEdgeDistance,
}