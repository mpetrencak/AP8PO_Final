using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using AP8PO_Final;
using AP8PO_Final.Models;

namespace AP8PO_Final.ViewModels
{
    public class EmployeeEditViewModel : ViewModelBase
    {
        MainWindow _mainWindow;
        public ObservableCollection<Employee> Employees { get; set; }

        
        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }
            set
            {
                _selectedEmployee = value;
                if(value != null)
                {
                    FirstName = value.FirstName;
                    SecondName = value.SecondName;
                    WorkEmail = value.WorkEmail;
                    PersonalEmail = value.PersonalEmail;
                    PHdStudent = value.PHdStudent;
                    Obligation = value.Obligation;

                }

            }
        }

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
            get
            {
                return _pHdStudent;
            }
            set
            {
                if(value == true)
                {
                    Obligation = 0;
                }
                _pHdStudent = value;
                OnPropertyChange("PHdStudent");

            }

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
        public RelayCommand CommandDeleteSelected { get; set; }





        /// <summary>
        /// Constructon
        /// </summary>
        /// <param name="mainWindow"></param>
        public EmployeeEditViewModel(MainWindow mainWindow)
        {
            CommandAdd = new RelayCommand(Add, CanAdd);
            CommandDeleteSelected = new RelayCommand(Delete, CanDelete);
            _mainWindow = mainWindow;
            Employees = new ObservableCollection<Employee>(_mainWindow.Employees);

        }

        public EmployeeEditViewModel()
        {



        }











        /// <summary>
        /// If returns true, button Delete can be clicked
        /// </summary>
        /// <returns>true if selectedEmployee != null </returns>
        private bool CanDelete()
        {
            if(_selectedEmployee == null)
            {
                return false;
            }
            return true;

        }

        /// <summary>
        /// Delete command for deleting selected Employee
        /// </summary>
        /// <param name="param"></param>
        private void Delete(object param)
        {
            Employees.Remove(_selectedEmployee);

            _mainWindow.Employees.Remove(_selectedEmployee);
            _mainWindow.InputParameters.Employees.Remove(_selectedEmployee);

            _selectedEmployee = null;

            FirstName = String.Empty;
            SecondName = String.Empty;
            WorkEmail = String.Empty;
            PersonalEmail = String.Empty;
            PHdStudent = false;
            Obligation = 0;


        }



        /// <summary>
        /// If returns true. button Add can be clicked
        /// </summary>
        /// <returns>true if firstName secondName workEmail personaEmail are not null </returns>
        private bool CanAdd()
        {
            if(String.IsNullOrWhiteSpace(_firstName) == false && String.IsNullOrWhiteSpace(_secondName) == false &&
               String.IsNullOrWhiteSpace(_workEmail) == false && String.IsNullOrWhiteSpace(_personalEmail) == false)
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// Command for adding Employee to ObservableCollection 
        /// </summary>
        /// <param name="param"></param>
        private void Add(object param)
        {
            Employee newEmployee = new Employee(_firstName, _secondName, _fullName, _workEmail, _personalEmail, _pHdStudent, _obligation);
            Employees.Add(newEmployee);
            _selectedEmployee = newEmployee;


            _mainWindow.Employees.Add(newEmployee);
            _mainWindow.InputParameters.Employees.Add(newEmployee);



            



        }



    }
}
