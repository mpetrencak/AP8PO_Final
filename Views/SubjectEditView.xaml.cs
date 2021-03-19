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
    /// Interaction logic for SubjectEditView.xaml
    /// </summary>
    public partial class SubjectEditView : Window
    {
        MainWindow MainWindow;
        Window parent;

        EmployeeEditViewModel EmployeeEditViewModel;
        GroupEditViewModel GroupEditViewModel;
        SubjectEditViewModel SubjectEditViewModel;

        

        //child
        public InputDataView InputDataView { get; set; }

        /*
        public SubjectEditView(Window parent, MainWindow mainWindow, EmployeeEditViewModel employeeEditViewModel, GroupEditViewModel groupEditViewModel,SubjectEditViewModel subjectEditViewModel)
        {
            InitializeComponent();
            MainWindow = mainWindow;
            this.parent= parent;

            EmployeeEditViewModel = employeeEditViewModel;
            GroupEditViewModel = groupEditViewModel;
            SubjectEditViewModel = subjectEditViewModel;
        }

        */
        public SubjectEditView(Window parent, MainWindow mainWindow)
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

        private void BtnSubjectToNext_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.InputDataViewModel = new InputDataViewModel(MainWindow);
            MainWindow.InputDataView.DataContext = MainWindow.InputDataViewModel;
                

            InputDataView.Show();
            Hide();

        }

        private void BtnSubjectToMenu_Click(object sender, RoutedEventArgs e)
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

        private void BtnSubjectBack_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            parent.Show();

        }

    }
}
