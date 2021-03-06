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
    /// Interakční logika pro GroupEditView.xaml
    /// </summary>
    public partial class GroupEditView : Window
    {
        MainWindow _mainWindow;
        Window _parent;

        public SubjectEditView SubjectEditView { get; set; }
        //SubjectEditViewModel SubjectEditViewModel;

        public GroupEditView(Window parent, MainWindow mainWindow)
        {

            InitializeComponent();
            _parent = parent;
            _mainWindow = mainWindow;
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

            Hide();
            _parent.Show();



        }

        private void BtnGroupToMenu_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Opravdu se chcete vrátit do menu?", "Vrátit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Hide();
                _mainWindow.Show();
            }
            else
            {
                return;
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.IsActive)
            {
                _mainWindow.Show();
            }
            else
            {
                //SubjectEditView.Close();
            }





        }




        private void BtnGroupToNext_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.SubjectEditViewModel = new SubjectEditViewModel(_mainWindow);
            _mainWindow.SubjectEditView = new SubjectEditView(this, _mainWindow);
            _mainWindow.SubjectEditView.DataContext = _mainWindow.SubjectEditViewModel;
            _mainWindow.SubjectEditView.Show();


            Hide();


        }

    }
}
