﻿using System;
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


        public ObservableCollection<Group> SelectedGroups { get; set; }





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




        public RelayCommand CommandSave { get; set; }



        public WorkLabelEditViewModel(MainWindow mainWindow)
        {
            CommandSave = new RelayCommand(Save, CanSave);
            _mainWindow = mainWindow;

            /*
            Group grp = new Group("SWI",2020,Semester.Summer,100,StudyForm.FullTime,StudyType.Bc,Language.CZ);
            ObservableCollection<Group> grps = new ObservableCollection<Group>();
            grps.Add(grp);

            Subject sub = new Subject("AP8PO",14,2,2,2,CourseCompletionType.Exam,Language.CZ,11,grps);
            WorkLabel workLabel = new WorkLabel(sub,LabelType.Exercise,1);
            _workLabels = new ObservableCollection<WorkLabel>();
            _workLabels.Add(workLabel);
            */

        }

        private bool CanSave()
        {
            return true;

        }

        private void Save(object param)
        {
            //WorkLabel workLabel = new WorkLabel(_selectedWorkLabel, _employee);
            WorkLabel workLabel = new WorkLabel(_name, _employee, _subject, _labelTypes, _numberOfStudents, _numberOfHours, _numberOfWeeks, _language) ;
            WorkLabels[WorkLabels.IndexOf(_selectedWorkLabel)] = workLabel;
            SelectedWorkLabel = workLabel;


        }


    }
}
