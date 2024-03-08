using System.Configuration;
using System.Data;
using System.Windows;
using WorldBuildingTool.ViewModels;
using WorldBuildingTool.Views.Windows;

namespace WorldBuildingTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // ' StartupUri="MainWindow.xaml" ' removed
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow main = new MainWindow() {
                DataContext = new MainWindowViewModel(),
            };
            main.Show();
            base.OnStartup(e);
        }
    }

}
