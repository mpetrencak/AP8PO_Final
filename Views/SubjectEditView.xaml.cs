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

        EmployeeEditViewModel _employeeEditViewModel;
        GroupEditViewModel _groupEditViewModel;
        SubjectEditViewModel _subjectEditViewModel;
        InputParameters _inputParameters;

        ObservableCollection<Group> _groups;





        //child
        InputDataView _inputDataView;

        /*
        public SubjectEditView(Window _parent, _mainWindow mainWindow, EmployeeEditViewModel employeeEditViewModel, GroupEditViewModel groupEditViewModel,SubjectEditViewModel subjectEditViewModel)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            this._parent= _parent;

            EmployeeEditViewModel = employeeEditViewModel;
            GroupEditViewModel = groupEditViewModel;
            SubjectEditViewModel = subjectEditViewModel;
        }

        */
        public SubjectEditView(Window parent, MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _employeeEditViewModel = _mainWindow.EmployeeEditViewModel;
            _groupEditViewModel = _mainWindow.GroupEditViewModel;
            _subjectEditViewModel = _mainWindow.SubjectEditViewModel;

            _subjectEditViewModel.Groups = _mainWindow.Groups;

            _parent = parent;

            _inputDataView = _mainWindow.InputDataView;

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

            _inputParameters = new InputParameters(_employeeEditViewModel.Employees, _groupEditViewModel.Groups, _subjectEditViewModel.Subjects);
            _mainWindow.InputDataViewModel = new InputDataViewModel(_mainWindow, _inputParameters);
            _mainWindow.InputDataView.DataContext = _mainWindow.InputDataViewModel;
            

            _inputDataView = new InputDataView(_mainWindow);
            _inputDataView.DataContext = _mainWindow.InputDataViewModel;
            _inputDataView.Show();


                
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
            System.Windows.Controls.ListBox _sender = (System.Windows.Controls.ListBox)sender;

            var v = _sender.SelectedItems;

            _groups = new ObservableCollection<Group>();
             
            foreach(var item in v)
            {
                _groups.Add((Group)item);
            }
        }


        private void BtnAddSubject_Click(object sender, RoutedEventArgs e)
        {
            _subjectEditViewModel.SelectedGroups = _groups;

        }

    }
}
