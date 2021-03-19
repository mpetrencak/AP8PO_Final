using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using AP8PO_Final.Enums;
using AP8PO_Final.Models;

namespace AP8PO_Final.ViewModels
{
    public class InputDataViewModel : ViewModelBase
    {
        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Group> Groups { get; set; }
        public ObservableCollection<Subject> Subjects { get; set; }
        


        public InputDataViewModel(MainWindow mainWindow)
        {
            Employees = new ObservableCollection<Employee>();
            Employees = mainWindow.Employees;

            Groups = new ObservableCollection<Group>();
            Groups = mainWindow.Groups;

            Subjects = new ObservableCollection<Subject>();
            Subjects = mainWindow.Subjects;

        }

                
    }
}
