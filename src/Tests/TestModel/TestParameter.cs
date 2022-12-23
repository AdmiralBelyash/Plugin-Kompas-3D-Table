using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using NUnit.Framework;

namespace TestCore;
/// <summary>
/// Класс для тестирования класса <see cref="Parameter"/>.
/// </summary>
[TestFixture]
public class TestParameter
{
    [TestCase(TestName = "Проверка ввода параметров")]
    public void TestParameter_SetCorrectValues()
    {
        var parameter = new Parameter();
        parameter.Name = "Test";
        parameter.MinValue = 10;
        parameter.MaxValue = 12;
        Assert.That(parameter.MinValue,
            Is.EqualTo(10),
            "Негативное значение превратилось в ноль.");
        Assert.That(parameter.MaxValue,
            Is.EqualTo(12),
            "Негативное значение превратилось в ноль.");
        Assert.That(parameter.Name,
            Is.EqualTo("Test"),
            "Присвоилось корректное имя");
        Assert.That(parameter.ErrorMessage,
            Is.EqualTo(null),
            "Ошибок нет");
    }

    [TestCase(TestName = "Проверка ввода негативного значения")]
    public void TestNegativeValueToZero_InCorrectValue()
    {
        var parameter = new Parameter();
        parameter.Name = "Test";
        parameter.MinValue = -10;
        parameter.MaxValue = -10;
        Assert.That(parameter.MinValue,
                    Is.EqualTo(0),
                    "Негативное значение превратилось в ноль.");
        Assert.That(parameter.MaxValue,
            Is.EqualTo(0),
            "Негативное значение превратилось в ноль.");
    }
}
