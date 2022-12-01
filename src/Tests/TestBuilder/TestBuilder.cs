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

    [TestCase(TestName = "Тестирование построения корректного стола.")]
    public void TestBuildTable_DoesNotThrowException()
    {
        var tableBuilder = TableBuilder;
        var testApiService = TestApiService;
        var tableParameters = TableParameters;

        Assert.DoesNotThrow(() => tableBuilder.BuildTable(tableParameters, testApiService), "Произошла ошибка при построении.");
        Assert.IsTrue(testApiService.IsCreateDocument, "Документ не создан.");
        Assert.IsTrue(testApiService.IsCreateNewSketch, "Ни один эскиз не создан.");
        Assert.IsTrue(testApiService.IsCreatePoint, "Ни одна точка не создана.");
        Assert.IsTrue(testApiService.IsExtrude, "Ни одного выдавливания не выполнено.");
    }
}