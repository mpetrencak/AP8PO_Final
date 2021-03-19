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
using AP8PO_Final;
using AP8PO_Final.Models;
using TheRThemes;

namespace AP8PO_Final.Views
{
    /// <summary>
    /// Interakční logika pro GroupEditView.xaml
    /// </summary>
    public partial class GroupEditView : Window
    {
        MainWindow MainWindow;
        Window Parent;

        public GroupEditView(Window parent, MainWindow mainWindow)
        {

            InitializeComponent();
            Parent = parent;
            MainWindow = mainWindow;
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

        private void BtnGroupBack_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Opravdu se chcete vrátit k přidání zaměstnanců?", "Vrátit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Hide();
                Parent.Show();
            }
            else
            {
                return;
            }


        }

        private void BtnGroupToMenu_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Opravdu se chcete vrátit do menu?", "Vrátit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Hide();
                MainWindow.Show();
            }
            else
            {
                return;
            }

        }


        }

        private void BtnGroupToNext_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
