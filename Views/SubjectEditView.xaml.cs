using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SubjectEditView.xaml
    /// </summary>
    public partial class SubjectEditView : Window
    {
        MainWindow _mainWindow;
        Window _parent;

        //selected groups from UI
        ObservableCollection<Group> _groups;



        public SubjectEditView(Window parent, MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _parent = parent;




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

        private void BtnSubjectToNext_Click(object sender, RoutedEventArgs e)
        {

            _mainWindow.InputParameters = new InputParameters(_mainWindow.Employees, _mainWindow.Groups, _mainWindow.Subjects);          

            _mainWindow.InputDataViewModel = new InputDataViewModel(_mainWindow, _mainWindow.InputParameters);
            _mainWindow.InputDataView = new InputDataView(_mainWindow);
            _mainWindow.InputDataView.DataContext = _mainWindow.InputDataViewModel;
            _mainWindow.InputDataView.Show();        
         
            Hide();

        }

        private void BtnSubjectToMenu_Click(object sender, RoutedEventArgs e)
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

            }





        }

        private void BtnSubjectBack_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            _parent.Show();

        }

        private void LstBoxGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox _sender = (ListBox)sender;

            var selectedItems = _sender.SelectedItems;

            _groups = new ObservableCollection<Group>();
             
            foreach(var item in selectedItems)
            {
                _groups.Add((Group)item);
            }
        }


        private void BtnAddSubject_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.SubjectEditViewModel.SelectedGroups = _groups;

        }

        private void BtnSubjectBack_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
