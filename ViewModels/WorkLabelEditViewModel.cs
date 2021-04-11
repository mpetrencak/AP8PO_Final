using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using AP8PO_Final;
using AP8PO_Final.Models;


namespace AP8PO_Final.ViewModels
{
    class WorkLabelEditViewModel : ViewModelBase
    {

        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get
            {
                return _employees;

            }

            set
            {
                _employees = value;
                OnPropertyChange("Employees");

            }
        }


    }
}
