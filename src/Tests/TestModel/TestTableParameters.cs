using Model;
using NUnit.Framework;

namespace TestCore;

/// <summary>
/// Класс для тестирования класса <see cref="Model.TableParameters"/>.
/// </summary>
[TestFixture]
public class TestTableParameters
{
    /// <summary>
    /// Возвращает новый экземпляр класса <see cref="Model.TableParameters"/>.
    /// </summary>
    private TableParameters TableParameters => new TableParameters();

    [TestCase(ParameterType.TableHeight, 1000,
        TestName = "Проверка корректного получения" +
                         " значения свойства TableHeight.")]
    [TestCase(ParameterType.TableLength, 1000,
        TestName = "Проверка корректного получения" +
                   " значения свойства TableLength.")]
    [TestCase(ParameterType.TableWidth, 1000,
        TestName = "Проверка корректного получения" +
                   " значения свойства TableWidth.")]
    [TestCase(ParameterType.TableThickness, 20,
        TestName = "Проверка корректного получения" +
                   " значения свойства TableThickness.")]
    [TestCase(ParameterType.TableLegsLengthDistance, 900,
        TestName = "Проверка корректного получения" +
                   " значения свойства TableLegsLengthDistance.")]
    [TestCase(ParameterType.TableLegsWidthDistance, 900,
        TestName = "Проверка корректного получения" +
                   " значения свойства TableLegsWidthDistance.")]
    [TestCase(ParameterType.TableLengthLegsEdgeDistance, 50,
        TestName = "Проверка корректного получения" +
                   " значения свойства TableLengthLegsEdgeDistance.")]
    [TestCase(ParameterType.TableWidthLegsEdgeDistance, 50,
        TestName = "Проверка корректного получения" +
                   " значения свойства TableWidthLegsEdgeDistance.")]
    public void TestGetValue_CorrectGetValue(ParameterType parameterType, double value)
    {
        var tableParameters = TableParameters;

        var expected = value;

        tableParameters.TableParameterCollection[parameterType].Value = value;

        var actual = tableParameters.TableParameterCollection[parameterType].Value;

        Assert.AreEqual(expected, actual, "Вернулось корректное значение.");
    }

    [TestCase(ParameterType.TableHeight, 1000,
        TestName = "Проверка корректного получения" +
                   " значения свойства TableHeight.")]
    [TestCase(ParameterType.TableLength, 1000,
        TestName = "Проверка корректного получения" +
                   " значения свойства TableLength.")]
    [TestCase(ParameterType.TableWidth, 1000,
        TestName = "Проверка корректного получения" +
                   " значения свойства TableWidth.")]
    [TestCase(ParameterType.TableThickness, 20,
        TestName = "Проверка корректного получения" +
                   " значения свойства TableThickness.")]
    [TestCase(ParameterType.TableLegsLengthDistance, 900,
        TestName = "Проверка корректного получения" +
                   " значения свойства TableLegsLengthDistance.")]
    [TestCase(ParameterType.TableLegsWidthDistance, 900,
        TestName = "Проверка корректного получения" +
                   " значения свойства TableLegsWidthDistance.")]
    [TestCase(ParameterType.TableLengthLegsEdgeDistance, 50,
        TestName = "Проверка корректного получения" +
                   " значения свойства TableLengthLegsEdgeDistance.")]
    [TestCase(ParameterType.TableWidthLegsEdgeDistance, 50,
        TestName = "Проверка корректного получения" +
                   " значения свойства TableWidthLegsEdgeDistance.")]
    public void TestSetValue_CorrectSetValue(ParameterType parameterType, double value)
    {
        var tableParameters = TableParameters;

        Assert.DoesNotThrow(() =>
                tableParameters.TableParameterCollection[parameterType].Value = value,
            "Удалось присвоить корректное значение.");
    }

    [TestCase(ParameterType.TableLength, 9.0,
        TestName = "Проверка некорректной передачи значения свойства TableLength," +
                   " меньшему минимальному." +
                   "  Должно выбросить исключение.")]
    [TestCase(ParameterType.TableLength, 10000.0,
        TestName = "Проверка некорректной передачи значения свойства TableLength," +
                   " большему максимальному." +
                   " Должно выбросить исключение.")]
    [TestCase(ParameterType.TableHeight, 9.0,
        TestName = "Проверка некорректной передачи значения свойства TableHeight," +
                   " меньшему минимальному." +
                   "  Должно выбросить исключение.")]
    [TestCase(ParameterType.TableHeight, 10000.0,
        TestName = "Проверка некорректной передачи значения свойства TableHeight," +
                   " большему максимальному." +
                   " Должно выбросить исключение.")]
    [TestCase(ParameterType.TableWidth, 9.0,
        TestName = "Проверка некорректной передачи значения свойства TableWidth," +
                   " меньшему минимальному." +
                   "  Должно выбросить исключение.")]
    [TestCase(ParameterType.TableWidth, 10000.0,
        TestName = "Проверка некорректной передачи значения свойства TableWidth," +
                   " большему максимальному." +
                   " Должно выбросить исключение.")]
    [TestCase(ParameterType.TableLegsLengthDistance, 9.0,
        TestName = "Проверка некорректной передачи значения свойства TableLegsLengthDistance," +
                   " меньшему минимальному." +
                   "  Должно выбросить исключение.")]
    [TestCase(ParameterType.TableLegsLengthDistance, 10000.0,
        TestName = "Проверка некорректной передачи значения свойства TableLegsLengthDistance," +
                   " большему максимальному." +
                   " Должно выбросить исключение.")]
    [TestCase(ParameterType.TableLegsWidthDistance, 9.0,
        TestName = "Проверка некорректной передачи значения свойства TableLegsWidthDistance," +
                   " меньшему минимальному." +
                   "  Должно выбросить исключение.")]
    [TestCase(ParameterType.TableLegsWidthDistance, 10000.0,
        TestName = "Проверка некорректной передачи значения свойства TableLegsWidthDistance," +
                   " большему максимальному." +
                   " Должно выбросить исключение.")]
    [TestCase(ParameterType.TableLengthLegsEdgeDistance, -9.0,
        TestName = "Проверка некорректной передачи значения свойства TableLengthLegsEdgeDistance," +
                   " меньшему минимальному." +
                   "  Должно выбросить исключение.")]
    [TestCase(ParameterType.TableLengthLegsEdgeDistance, 10000.0,
        TestName = "Проверка некорректной передачи значения свойства TableLengthLegsEdgeDistance," +
                   " большему максимальному." +
                   " Должно выбросить исключение.")]
    [TestCase(ParameterType.TableWidthLegsEdgeDistance, -9.0,
        TestName = "Проверка некорректной передачи значения свойства TableWidthLegsEdgeDistance," +
                   " меньшему минимальному." +
                   "  Должно выбросить исключение.")]
    [TestCase(ParameterType.TableWidthLegsEdgeDistance, 10000.0,
        TestName = "Проверка некорректной передачи значения свойства TableWidthLegsEdgeDistance," +
                   " большему максимальному." +
                   " Должно выбросить исключение.")]
    public void TestSetValue_IncorrectSetValue(ParameterType parameterType, double value)
    {
        var tableParameters = TableParameters;
        tableParameters.TableParameterCollection[parameterType].Value = value;
        Assert.That(tableParameters.TableParameterCollection[parameterType].HasError, Is.EqualTo(true),
            "Присвоило значение не входящие в диапазон.");
    }
}