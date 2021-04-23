using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using AP8PO_Final.Enums;
using AP8PO_Final.Models;

namespace AP8PO_Final.ViewModels
{
    public class SubjectEditViewModel :ViewModelBase
    {
        MainWindow MainWindow;

        public ObservableCollection<Subject> Subjects { get; private set; }

        public ObservableCollection<Group> SelectedGroups { get; set; }




        private string _abbrevation;
        public string Abbrevation
        {
            get
            {
                return _abbrevation;

            }
            set
            {
                _abbrevation = value;
                OnPropertyChange("Abbrevation");
            }
        }

        private int _weeks;
        public int Weeks
        {
            get
            {
                return _weeks;
            }
            set
            {
                _weeks = value;
                OnPropertyChange("Weeks");
            }
        }

        private int _lectureHours;
        public int LectureHours
        {
            get
            {
                return _lectureHours;
            }
            set
            {
                _lectureHours = value;
                OnPropertyChange("LectureHours");
            }
        }

        private int _exerciseHours;
        public int ExerciseHours
        {
            get
            { 
                return _exerciseHours;
            }
            set 
            { 
                _exerciseHours = value;
                OnPropertyChange("ExerciseHours");
            }
        }


        private int _semminarHours;
        public int SemminarHours
        {
            get
            {
                return _semminarHours;
            }
            set
            {
                _semminarHours = value;
                OnPropertyChange("SemminarHours");
            }
        }


        private CourseCompletionType _courseCompletionType;
        public CourseCompletionType CourseCompletionType
        {
            get
            {
                return _courseCompletionType;
            }
            set
            {
                _courseCompletionType = value;
                OnPropertyChange("CourseCompletionType");
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

        private int _sizeOfGroup;
        public int SizeOfGroup
        {
            get
            {
                return _sizeOfGroup;
            }
            set
            {
                _sizeOfGroup = value;
                OnPropertyChange("SizeOfGroup");
            }
        }

        private ObservableCollection<Group> _groups;
        public ObservableCollection<Group> Groups
        { 
            get 
            {
                return _groups; 
                    
            } 
            set 
            {
                _groups = value;
                OnPropertyChange("Groups");
            }
        }







        public RelayCommand CommandAdd { get; set; }
        public RelayCommand CommandListBoxChange { get; set; }


        public SubjectEditViewModel(MainWindow mainWindow)
        {
            CommandAdd = new RelayCommand(Add, CanAdd);
            CommandListBoxChange = new RelayCommand(Change, CanChange);
            Subjects = new ObservableCollection<Subject>();
            MainWindow = mainWindow;



        }

        private void Change(object param)
        {

        }


        private bool CanChange()
        {
            return true;

        }



        private bool CanAdd()
        {
            if(String.IsNullOrWhiteSpace(_abbrevation) == false && _weeks !=0 && _sizeOfGroup != 0)
            {
                return true;
            }
            return false;
        }

        private void Add(object param)
        {



            Subject newSubject = new Subject(_abbrevation, _weeks, _lectureHours, _exerciseHours, _semminarHours, _courseCompletionType, _language, _sizeOfGroup, SelectedGroups);

            MainWindow.Subjects.Add(newSubject);
            Subjects.Add(newSubject);




        }







    }
}
