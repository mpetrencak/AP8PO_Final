using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using AP8PO_Final;
using AP8PO_Final.Models;
using AP8PO_Final.Enums;

namespace AP8PO_Final.ViewModels
{
    public class WorkLabelEditViewModel : ViewModelBase
    {
        MainWindow _mainWindow;


        //Observable Collections

        private ObservableCollection<Subject> _subjects;
        public ObservableCollection<Subject> Subjects
        {
            get
            {
                return _subjects;
            }
            set
            {
                _subjects = value;
                OnPropertyChange("Subjects");
            }

        }

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

        private ObservableCollection<WorkLabel> _workLabels;
        public ObservableCollection<WorkLabel> WorkLabels
        {
            get
            {
                return _workLabels;
            }
            set
            {
                _workLabels = value;
                OnPropertyChange("WorkLabels");
            }
        }


        
        //selected worklabel in window
        private WorkLabel _selectedWorkLabel;
        public WorkLabel SelectedWorkLabel
        {
            get
            {
                return _selectedWorkLabel;

            }
            set
            {
                _selectedWorkLabel = value;
                if (value != null)
                {
                    Name = value.Name;
                    LabelTypes = value.LabelTypes;
                    NumberOfHours = value.NumberOfHours;
                    NumberOfStudents = value.NumberOfStudents;
                    NumberOfWeeks = value.NumberOfWeeks;
                    Language = value.Language;
                    Subject = value.Subject;                    
                    Employee = value.Employee;                                      

                }
                OnPropertyChange("SelectedWorkLabel");

            }

        }



        //properites

        private string _name;
        public string Name
        {
            get
            {
                return _name;

            }
            set
            {
                _name = value;
                OnPropertyChange("Name");
            }
        }


        private Employee _employee;
        public Employee Employee
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
                OnPropertyChange("Employee");
            }
        }


        private Subject _subject;
        public Subject Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                _subject = value;
                OnPropertyChange("Subject");
            }
        }


        private LabelType _labelTypes;
        public LabelType LabelTypes
        {
            get
            {
                return _labelTypes;
            }
            set
            {
                _labelTypes = value;
                OnPropertyChange("LabelTypes");
            }
        }


        private int _numberOfStudents;
        public int NumberOfStudents
        {
            get
            {
                return _numberOfStudents;
            }
            set
            {
                _numberOfStudents = value;
                OnPropertyChange("NumberOfStudents");
            }
        }


        private int _numberOfHours;
        public int NumberOfHours
        {
            get
            {
                return _numberOfHours;
            }
            set
            {
                _numberOfHours = value;
                OnPropertyChange("NumberOfHours");
            }

        }


        private int _numberOfWeeks;
        public int NumberOfWeeks
        {
            get 
            {
                return _numberOfWeeks;
            }
            set 
            {
                _numberOfWeeks = value;
                OnPropertyChange("NumberOfWeeks");
            }
        }


        private Language _language;
        public Language Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
                OnPropertyChange("Language");
            }
        }

        private double _workpoints;
        public double Workpoins
        {
            get
            {
                return _workpoints;
            }
            set
            {
                _workpoints = value;
                OnPropertyChange("Workpoints");
            }
        }


        //commands

        public RelayCommand CommandSave { get; set; }




        //ctors

        public WorkLabelEditViewModel(MainWindow mainWindow)
        {
            CommandSave = new RelayCommand(Save, CanSave);
            _mainWindow = mainWindow;
        }













        private bool CanSave()
        {
            return true;

        }

        private void Save(object param)
        {
            

            WorkLabel workLabel = new WorkLabel(_name, _employee, _subject, _labelTypes, _numberOfStudents, _numberOfHours, _numberOfWeeks, _language);
            WorkLabels[WorkLabels.IndexOf(_selectedWorkLabel)] = workLabel;
            SelectedWorkLabel = workLabel;

            //removing worklabel with empty employee and removing that worklabel from Employees
            if(_employee == null)
            {
                foreach (Employee employee in Employees)
                {
                    if (employee.WorkLabels.Contains(workLabel))
                    {
                        employee.WorkLabels.Remove(workLabel);
                    }
                }
            }
            else   //else add worklabel to employee
            {
                Employees[Employees.IndexOf(_employee)].WorkLabels.Add(workLabel);

                Employee newEmployee = new Employee(_employee, workLabel);
                Employees.Add(newEmployee);
                Employees.Remove(_employee);


            }








        }


    }
}
