using System.Linq;
using System.Windows;
using CV19.Services;

namespace CV19
{
    public partial class App : Application
    {
        public static bool IsDesignMode { get; private set; } = true;

        protected override void OnStartup(StartupEventArgs e)
        {
            IsDesignMode = false;
            base.OnStartup(e);

            var servce_test = new DataService();

            var countries = servce_test.GetData().ToArray(); 
        }
    }
}
