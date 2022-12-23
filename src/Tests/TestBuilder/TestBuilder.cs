using System.Collections.Immutable;
using Builder;
using CommonTestClass;
using Model;
using NUnit.Framework;

namespace TestBuilder;

/// <summary>
/// Класс тестирования <see cref="Builder.TableBuilder"/>.
/// </summary>
[TestFixture]
public class TestTableBuilder
{
    /// <summary>
    /// Возвращает новый экземпляр класса <see cref="TestApiService"/>.
    /// </summary>
    private TestApiService TestApiService => new TestApiService();

    /// <summary>
    /// Возвращает новый экземпляр класса <see cref="TableParameters"/>.
    /// </summary>
    private TableParameters TableParameters => new TableParameters();

    /// <summary>
    /// Возвращает новый экземпляр класса <see cref="Builder.TableBuilder"/>.
    /// </summary>
    private TableBuilder TableBuilder => new TableBuilder();

    [TestCase(TestName = "Тестирование построения корректного стола без закруглений.")]
    public void TestBuildTable_DoesNotThrowException()
    {
        var tableBuilder = TableBuilder;
        var testApiService = TestApiService;
        var tableParameters = TableParameters;

        Assert.DoesNotThrow(() => tableBuilder.BuildTable(tableParameters, testApiService), "Не произошла ошибка при построении.");
        Assert.IsTrue(testApiService.IsCreateDocument, "Документ создан.");
        Assert.IsTrue(testApiService.IsCreateNewSketch, "Эскиз создан.");
        Assert.IsTrue(testApiService.IsCreatePoint, "Точка создана.");
        Assert.IsTrue(testApiService.IsExtrude, "Выдавливание выполнено.");
        Assert.IsTrue(testApiService.IsCreateRectangle, "Прямоугольник создан.");
        Assert.IsFalse(testApiService.IsRounded, "Скругление углов выполнено.");
    }

    [TestCase(TestName = "Тестирование построения корректного стола со закруглений.")]
    public void TestBuildTable_DoesNotThrowExceptionWithRound()
    {
        var tableBuilder = TableBuilder;
        var testApiService = TestApiService;
        var tableParameters = TableParameters;
        tableParameters.TableParameterCollection[ParameterType.TableCornerRadius].Value = 0.5;

        Assert.DoesNotThrow(() => tableBuilder.BuildTable(tableParameters, testApiService), "Не произошла ошибка при построении.");
        Assert.IsTrue(testApiService.IsCreateDocument, "Документ создан.");
        Assert.IsTrue(testApiService.IsCreateNewSketch, "Эскиз создан.");
        Assert.IsTrue(testApiService.IsCreatePoint, "Точка создана.");
        Assert.IsTrue(testApiService.IsExtrude, "Выдавливание выполнено.");
        Assert.IsTrue(testApiService.IsCreateRectangle, "Прямоугольник создан.");
        Assert.IsTrue(testApiService.IsRounded, "Скругление углов выполнено.");
    }
}