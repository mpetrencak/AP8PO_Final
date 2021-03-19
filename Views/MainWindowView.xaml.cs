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
using TheRThemes;
using AP8PO_Final.ViewModels;

namespace AP8PO_Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        EmployeeEditView EmployeeEditView;
        EmployeeEditViewModel EmployeeEditViewModel;

        /*
        GroupEditView GroupEditView;
        GroupEditViewModel GroupEditViewModel;

        SubjectEditView SubjectEditView;
        SubjectEditViewModel subjectEditViewModel;
        */


        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            
            

            EmployeeEditViewModel = new EmployeeEditViewModel();
            EmployeeEditView = new EmployeeEditView(this);
            EmployeeEditView.DataContext = EmployeeEditViewModel;




            EmployeeEditView.Show();
            Hide();

            


        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {

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
            this.ReleaseAllTouchCaptures();
            EmployeeEditView.Close();
        }
    }
}
