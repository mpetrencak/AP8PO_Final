using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using AP8PO_Final;
using AP8PO_Final.Models;

namespace AP8PO_Final.ViewModels
{
    class EmployeeEditViewModel : ViewModelBase
    {
        public ObservableCollection<Employee> Employees { get; set; }

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;

            }
            set 
            {
                _firstName = value;
                FullName = _firstName + " " + _secondName;
                OnPropertyChange("FirstName");
            } 
        }

        private string _secondName;        
        public string SecondName
        {
            get
            {
                return _secondName;
            }
            set
            {
                _secondName = value;
                FullName = _firstName + " " + _secondName;
                OnPropertyChange("SecondName");
            }
        }

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value;OnPropertyChange("FullName"); }


        }

        private string _workEmail;
        public string WorkEmail
        {
            get { return _workEmail; }
            set { _workEmail = value; OnPropertyChange("WorkEmail"); }


        }

        private string _personalEmail;
        public string PersonalEmail
        {
            get { return _personalEmail; }
            set { _personalEmail = value; OnPropertyChange("PersonalEmail"); }

        }

        private bool _pHdStudent;
        public bool PHdStudent
        {
            get { return _pHdStudent; }
            set { _pHdStudent = value; OnPropertyChange("PHdStudent"); }

        }


        private double _obligation;
        public double Obligation
        {
            get { return _obligation; }
            set
            {
                _obligation = value;
                OnPropertyChange("Obligation");


            }
        }


        public RelayCommand CommandAdd { get; set; }





        public EmployeeEditViewModel()
        {
            CommandAdd = new RelayCommand(Add, CanAdd);
            Employees = new ObservableCollection<Employee>();

        }

        private bool CanAdd()
        {
            if(String.IsNullOrWhiteSpace(_firstName) == false && String.IsNullOrWhiteSpace(_secondName) == false &&
               String.IsNullOrWhiteSpace(_workEmail) == false && String.IsNullOrWhiteSpace(_personalEmail) == false)
            {
                return true;
            }
            return false;

        }

        private void Add(object param)
        {
            Employee newEmployee = new Employee(FirstName, SecondName,FullName, WorkEmail, PersonalEmail, PHdStudent, Obligation);
            Employees.Add(newEmployee);



        }



    }
}
