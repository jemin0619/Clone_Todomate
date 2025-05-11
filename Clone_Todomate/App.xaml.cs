using System.Windows;
using Clone_Todomate.Views;

namespace Clone_Todomate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            UserProfileWindow main = new();
            main.Show();
        }
    }

}
