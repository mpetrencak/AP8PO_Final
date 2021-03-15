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

namespace AP8PO_Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeEditView employeeEditView;
        MainWindow mainWindow;

        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            employeeEditView = new EmployeeEditView();
            employeeEditView.Show();
            mainWindow.Close();

            


        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
