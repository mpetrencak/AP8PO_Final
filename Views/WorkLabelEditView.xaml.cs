using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TheRThemes;

namespace AP8PO_Final.Views
{
    /// <summary>
    /// Interaction logic for WorkLabelEditView.xaml
    /// </summary>
    public partial class WorkLabelEditView : Window
    {
        MainWindow MainWindow;
        Window parent;

        public WorkLabelEditView(Window parent, MainWindow mainWindow)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            this.parent = parent;
        }


        private void MenuItemTheme_Click(object sender, RoutedEventArgs e)
        {
            switch (int.Parse(((MenuItem)sender).Uid))
            {
                case 0: ThemesController.SetTheme(ThemesController.ThemeTypes.Light); break;
                case 1: ThemesController.SetTheme(ThemesController.ThemeTypes.ColourfulLight); break;
                case 2: ThemesController.SetTheme(ThemesController.ThemeTypes.Dark); break;
                case 3: ThemesController.SetTheme(ThemesController.ThemeTypes.ColourfulDark); break;
            }
            e.Handled = true;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.IsActive)
            {
                MainWindow.Show();
            }
            else
            {

            }
        }


    }
}
