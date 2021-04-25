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
    /// Interakční logika pro EmployeeEditView.xaml
    /// </summary>
    public partial class EmployeeEditView : Window
    {
        MainWindow _mainWindow;
        Window _parent;


        public GroupEditView GroupEditView { get; set; }



        /// <summary>
        /// </summary>
        /// <param name="mainWindow"></param>
        public EmployeeEditView(Window parent,MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _parent = parent;
            


        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(this.IsActive)
            {
                _mainWindow.Show();
            }
            else
            {
                //GroupEditView.Close();
            }



 
        }
        /*
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
        */


        private void BtnEmployeeToMenu_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Opravdu se chcete vrátit do menu?","Vrátit",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Hide();
                _mainWindow.Show();
            }
            else
            {
                return;
            }

        }

        private void BtnEmployeeToNext_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.GroupEditViewModel = new GroupEditViewModel(_mainWindow);
            _mainWindow.GroupEditView = new GroupEditView(this, _mainWindow);
            _mainWindow.GroupEditView.DataContext = _mainWindow.GroupEditViewModel;
            _mainWindow.GroupEditView.Show();

            Hide();
            

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

        private void BtnEmployeeBack_Click(object sender, RoutedEventArgs e)
        {
            _parent.Show();
            Hide();

        }
    }
}
