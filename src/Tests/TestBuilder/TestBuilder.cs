using System.Collections.Immutable;
using Builder;
using CommonTestClass;
using Model;
using NUnit.Framework;

namespace TestBuilder;

/// <summary>
/// ����� ������������ <see cref="Builder.TableBuilder"/>.
/// </summary>
[TestFixture]
public class TestTableBuilder
{
    /// <summary>
    /// ���������� ����� ��������� ������ <see cref="TestApiService"/>.
    /// </summary>
    private TestApiService TestApiService => new TestApiService();

    /// <summary>
    /// ���������� ����� ��������� ������ <see cref="TableParameters"/>.
    /// </summary>
    private TableParameters TableParameters => new TableParameters();

    /// <summary>
    /// ���������� ����� ��������� ������ <see cref="Builder.TableBuilder"/>.
    /// </summary>
    private TableBuilder TableBuilder => new TableBuilder();

    [TestCase(TestName = "������������ ���������� ����������� �����.")]
    public void TestBuildTable_DoesNotThrowException()
    {
        var tableBuilder = TableBuilder;
        var testApiService = TestApiService;
        var tableParameters = TableParameters;

        Assert.DoesNotThrow(() => tableBuilder.BuildTable(tableParameters, testApiService), "��������� ������ ��� ����������.");
        Assert.IsTrue(testApiService.IsCreateDocument, "�������� �� ������.");
        Assert.IsTrue(testApiService.IsCreateNewSketch, "�� ���� ����� �� ������.");
        Assert.IsTrue(testApiService.IsCreatePoint, "�� ���� ����� �� �������.");
        Assert.IsTrue(testApiService.IsExtrude, "�� ������ ������������ �� ���������.");
    }
}