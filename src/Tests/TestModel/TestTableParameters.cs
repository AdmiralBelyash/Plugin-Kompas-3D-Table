using Model;
using NUnit.Framework;

namespace TestCore;

/// <summary>
/// ����� ��� ������������ ������ <see cref="Model.TableParameters"/>.
/// </summary>
[TestFixture]
public class TestTableParameters
{
    /// <summary>
    /// ���������� ����� ��������� ������ <see cref="Model.TableParameters"/>.
    /// </summary>
    private TableParameters TableParameters => new TableParameters();

    [TestCase(ParameterType.TableHeight, 1000,
        TestName = "�������� ����������� ���������" +
                         " �������� �������� TableHeight.")]
    [TestCase(ParameterType.TableLength, 1000,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� TableLength.")]
    [TestCase(ParameterType.TableWidth, 1000,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� TableWidth.")]
    [TestCase(ParameterType.TableThickness, 20,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� TableThickness.")]
    [TestCase(ParameterType.TableLegsLengthDistance, 900,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� TableLegsLengthDistance.")]
    [TestCase(ParameterType.TableLegsWidthDistance, 900,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� TableLegsWidthDistance.")]
    [TestCase(ParameterType.TableLengthLegsEdgeDistance, 50,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� TableLengthLegsEdgeDistance.")]
    [TestCase(ParameterType.TableWidthLegsEdgeDistance, 50,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� TableWidthLegsEdgeDistance.")]
    public void TestGetValue_CorrectGetValue(ParameterType parameterType, double value)
    {
        var tableParameters = TableParameters;

        var expected = value;

        tableParameters.TableParameterCollection[parameterType].Value = value;

        var actual = tableParameters.TableParameterCollection[parameterType].Value;

        Assert.AreEqual(expected, actual, "��������� ���������� ��������.");
    }

    [TestCase(ParameterType.TableHeight, 1000,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� TableHeight.")]
    [TestCase(ParameterType.TableLength, 1000,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� TableLength.")]
    [TestCase(ParameterType.TableWidth, 1000,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� TableWidth.")]
    [TestCase(ParameterType.TableThickness, 20,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� TableThickness.")]
    [TestCase(ParameterType.TableLegsLengthDistance, 900,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� TableLegsLengthDistance.")]
    [TestCase(ParameterType.TableLegsWidthDistance, 900,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� TableLegsWidthDistance.")]
    [TestCase(ParameterType.TableLengthLegsEdgeDistance, 50,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� TableLengthLegsEdgeDistance.")]
    [TestCase(ParameterType.TableWidthLegsEdgeDistance, 50,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� TableWidthLegsEdgeDistance.")]
    public void TestSetValue_CorrectSetValue(ParameterType parameterType, double value)
    {
        var tableParameters = TableParameters;

        Assert.DoesNotThrow(() =>
                tableParameters.TableParameterCollection[parameterType].Value = value,
            "������� ��������� ���������� ��������.");
    }

    [TestCase(ParameterType.TableLength, 9.0,
        TestName = "�������� ������������ �������� �������� �������� TableLength," +
                   " �������� ������������." +
                   "  ������ ��������� ����������.")]
    [TestCase(ParameterType.TableLength, 10000.0,
        TestName = "�������� ������������ �������� �������� �������� TableLength," +
                   " �������� �������������." +
                   " ������ ��������� ����������.")]
    [TestCase(ParameterType.TableHeight, 9.0,
        TestName = "�������� ������������ �������� �������� �������� TableHeight," +
                   " �������� ������������." +
                   "  ������ ��������� ����������.")]
    [TestCase(ParameterType.TableHeight, 10000.0,
        TestName = "�������� ������������ �������� �������� �������� TableHeight," +
                   " �������� �������������." +
                   " ������ ��������� ����������.")]
    [TestCase(ParameterType.TableWidth, 9.0,
        TestName = "�������� ������������ �������� �������� �������� TableWidth," +
                   " �������� ������������." +
                   "  ������ ��������� ����������.")]
    [TestCase(ParameterType.TableWidth, 10000.0,
        TestName = "�������� ������������ �������� �������� �������� TableWidth," +
                   " �������� �������������." +
                   " ������ ��������� ����������.")]
    [TestCase(ParameterType.TableLegsLengthDistance, 9.0,
        TestName = "�������� ������������ �������� �������� �������� TableLegsLengthDistance," +
                   " �������� ������������." +
                   "  ������ ��������� ����������.")]
    [TestCase(ParameterType.TableLegsLengthDistance, 10000.0,
        TestName = "�������� ������������ �������� �������� �������� TableLegsLengthDistance," +
                   " �������� �������������." +
                   " ������ ��������� ����������.")]
    [TestCase(ParameterType.TableLegsWidthDistance, 9.0,
        TestName = "�������� ������������ �������� �������� �������� TableLegsWidthDistance," +
                   " �������� ������������." +
                   "  ������ ��������� ����������.")]
    [TestCase(ParameterType.TableLegsWidthDistance, 10000.0,
        TestName = "�������� ������������ �������� �������� �������� TableLegsWidthDistance," +
                   " �������� �������������." +
                   " ������ ��������� ����������.")]
    [TestCase(ParameterType.TableLengthLegsEdgeDistance, -9.0,
        TestName = "�������� ������������ �������� �������� �������� TableLengthLegsEdgeDistance," +
                   " �������� ������������." +
                   "  ������ ��������� ����������.")]
    [TestCase(ParameterType.TableLengthLegsEdgeDistance, 10000.0,
        TestName = "�������� ������������ �������� �������� �������� TableLengthLegsEdgeDistance," +
                   " �������� �������������." +
                   " ������ ��������� ����������.")]
    [TestCase(ParameterType.TableWidthLegsEdgeDistance, -9.0,
        TestName = "�������� ������������ �������� �������� �������� TableWidthLegsEdgeDistance," +
                   " �������� ������������." +
                   "  ������ ��������� ����������.")]
    [TestCase(ParameterType.TableWidthLegsEdgeDistance, 10000.0,
        TestName = "�������� ������������ �������� �������� �������� TableWidthLegsEdgeDistance," +
                   " �������� �������������." +
                   " ������ ��������� ����������.")]
    public void TestSetValue_IncorrectSetValue(ParameterType parameterType, double value)
    {
        var tableParameters = TableParameters;
        tableParameters.TableParameterCollection[parameterType].Value = value;
        Assert.That(tableParameters.TableParameterCollection[parameterType].HasError, Is.EqualTo(true),
            "��������� �������� �� �������� � ��������.");
    }
}