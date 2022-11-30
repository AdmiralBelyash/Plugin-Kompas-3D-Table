
using NUnit.Framework;

namespace TestTableBuildingVm;

public class Tests
{
    /// <summary>
	/// ����� ������������ <see cref="PluginKompas3DTableApp"/>.
	/// </summary>
	[TestFixture]
    public class TestMainWindowVm
    {
        /// <summary>
        /// ���������� ����� ��������� ������ <see cref="PluginKompas3DTableApp"/>.
        /// </summary>
        private PluginKompas3DTableApp.MainViewModel ViewModel => new PluginKompas3DTableApp.MainViewModel();

        [TestCase(TestName = "�������� �������� HasErrors � " +
                             "������ ��������� �������� ���� bool." +
                             " �� ������ ���������� ����������")]
        public void TestHasErrors_CorrectGet()
        {
            var viewModel = ViewModel;

            Assert.DoesNotThrow(() =>
            {
                var hasError = viewModel.HasErrors;
            },
                "�������� ���������� ��� �������" +
                $" ��������� �������� �������� {nameof(viewModel.HasErrors)}");
        }
    }
}