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
using AP8PO_Final.ViewModels;
using TheRThemes;

namespace AP8PO_Final.Views
{
    /// <summary>
    /// Interaction logic for InputDataView.xaml
    /// </summary>
    public partial class InputDataView : Window
    {
        MainWindow _mainWindow;

        public InputDataView(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(this.Activate())
            {

                _mainWindow.Show();
            }

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

        private void ButtonGenerate_Click(object sender, RoutedEventArgs e)
        {
                        

            _mainWindow.WorkLabelEditView = new WorkLabelEditView(this,_mainWindow);
            _mainWindow.WorkLabelEditViewModel = new WorkLabelEditViewModel(_mainWindow);
            _mainWindow.WorkLabelEditView.DataContext = _mainWindow.WorkLabelEditViewModel;
            _mainWindow.WorkLabelEditView.Show();
            Hide();


        }
    }
}
