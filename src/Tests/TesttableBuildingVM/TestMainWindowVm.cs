
using NUnit.Framework;

namespace TestTableBuildingVm;

public class Tests
{
    /// <summary>
	/// Класс тестирования <see cref="PluginKompas3DTableApp"/>.
	/// </summary>
	[TestFixture]
    public class TestMainWindowVm
    {
        /// <summary>
        /// Возвращает новый экземпляр класса <see cref="PluginKompas3DTableApp"/>.
        /// </summary>
        private PluginKompas3DTableApp.MainViewModel ViewModel => new PluginKompas3DTableApp.MainViewModel();

        [TestCase(TestName = "Проверка свойства HasErrors — " +
                             "должно вернуться значение типа bool." +
                             " Не должно вызываться исключение")]
        public void TestHasErrors_CorrectGet()
        {
            var viewModel = ViewModel;

            Assert.DoesNotThrow(() =>
            {
                var hasError = viewModel.HasErrors;
            },
                "Вылетело исключение при попытке" +
                $" получения значения свойства {nameof(viewModel.HasErrors)}");
        }
    }
}