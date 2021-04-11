using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using AP8PO_Final.Views;
using AP8PO_Final.Models;
using TheRThemes;
using AP8PO_Final.ViewModels;
using System.Collections.ObjectModel;

namespace AP8PO_Final
{
    /// <summary>
    /// Interaction logic for _mainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Group> Groups { get; set; }
        public ObservableCollection<Subject> Subjects { get; set; }





        EmployeeEditView EmployeeEditView;
        public EmployeeEditViewModel EmployeeEditViewModel { get; private set; }
       
        GroupEditView GroupEditView;
        public GroupEditViewModel GroupEditViewModel { get; private set; }

        SubjectEditView SubjectEditView;
        public SubjectEditViewModel SubjectEditViewModel { get; private set; }



        public InputDataView InputDataView { get; set; }
        public InputDataViewModel InputDataViewModel { get; set; }



        public MainWindow()
        {
            InitializeComponent();

            Employees = new ObservableCollection<Employee>();
            Groups = new ObservableCollection<Group>();
            Subjects = new ObservableCollection<Subject>();

            
            EmployeeEditViewModel = new EmployeeEditViewModel(this);
            GroupEditViewModel = new GroupEditViewModel(this);
            SubjectEditViewModel = new SubjectEditViewModel(this);
  

            InputDataView = new InputDataView(this);
            EmployeeEditView = new EmployeeEditView(this);
            GroupEditView = new GroupEditView(EmployeeEditView, this);
            SubjectEditView = new SubjectEditView(GroupEditView, this);

            InputDataView.DataContext = InputDataViewModel;
            EmployeeEditView.DataContext = EmployeeEditViewModel;
            GroupEditView.DataContext = GroupEditViewModel;
            SubjectEditView.DataContext = SubjectEditViewModel;

            //setting child window
            EmployeeEditView.GroupEditView = GroupEditView;
            GroupEditView.SubjectEditView = SubjectEditView;
            SubjectEditView.InputDataView = InputDataView;

        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {       
           
            EmployeeEditView.Show();
            Hide();          


        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            InputDataViewModel = new InputDataViewModel(this);
            InputDataView.DataContext = InputDataViewModel;


            InputDataView.Show();
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

        private void Window_Closed(object sender, EventArgs e)
        {
            if(EmployeeEditView != null)
            {
                EmployeeEditView.Close();
            }

            if(InputDataView != null)
            {
                InputDataView.Close();
            }

        }

    }
}
