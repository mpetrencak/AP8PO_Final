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
        //Models collesctions

        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Group> Groups { get; set; }
        public ObservableCollection<Subject> Subjects { get; set; }
        public ObservableCollection<WorkLabel> WorkLabels { get; set; }
        public InputParameters InputParameters { get; set; }



        //Views and Viewmodels

        public EmployeeEditView EmployeeEditView { get; set; }
        public EmployeeEditViewModel EmployeeEditViewModel { get; set; }

       
        public GroupEditView GroupEditView { get; set; }
        public GroupEditViewModel GroupEditViewModel { get;set; }


        public SubjectEditView SubjectEditView { get; set; }
        public SubjectEditViewModel SubjectEditViewModel { get; set; }


        public InputDataView InputDataView { get; set; }
        public InputDataViewModel InputDataViewModel { get; set; }


        public WorkLabelEditView WorkLabelEditView { get; set; }
        public WorkLabelEditViewModel WorkLabelEditViewModel { get; set; }





        public MainWindow()
        {
            InitializeComponent();

            //Models
            Employees = new ObservableCollection<Employee>();
            Groups = new ObservableCollection<Group>();
            Subjects = new ObservableCollection<Subject>();
            WorkLabels = new ObservableCollection<WorkLabel>();
            InputParameters = new InputParameters();
            

        }


        /// <summary>
        /// Opening employee edit window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            EmployeeEditViewModel = new EmployeeEditViewModel(this);
            EmployeeEditView = new EmployeeEditView(this,this);
            EmployeeEditView.DataContext = EmployeeEditViewModel;
            EmployeeEditView.Show();

            Hide();          


        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {

            InputDataViewModel = new InputDataViewModel(this);
            InputDataView = new InputDataView(this);
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
