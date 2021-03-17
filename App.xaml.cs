using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AP8PO_Final.ViewModels;
using AP8PO_Final.Views;

namespace AP8PO_Final
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            MainWindow window = new MainWindow();
            window.DataContext = mainWindowViewModel;

            window.Show();
            


        }
    }
}
