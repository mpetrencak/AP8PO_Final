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
        MainWindow _mainWindow;

        public ObservableCollection<Subject> Subjects { get; private set; }

        private Subject _selectedSubject;
        public Subject SelectedSubject
        {
            get
            {
                return _selectedSubject;
            }
            set
            {
                _selectedSubject = value;
                if(value != null)
                {
                    Abbrevation = value.Abbrevation;
                    Weeks = value.Weeks;
                    LectureHours = value.LectureHours;
                    ExerciseHours = value.ExerciseHours;
                    SemminarHours = value.SemminarHours;
                    CourseCompletionType = value.CourseCompletionType;
                    Language = value.Language;
                    SizeOfGroup = value.SizeOfGroup;


                }
            }
        }

        /// <summary>
        /// Selected items from listbox
        /// </summary>
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

        private string _groupsSrting;
        /// <summary>
        /// String contains names of all groups separated with ,
        /// </summary>
        public string GroupsString
        {
            get
            {
                return _groupsSrting;
            }
            set
            {
                _groupsSrting = value;
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
                //OnPropertyChange("Groups");
            }
        }









        public RelayCommand CommandDeleteSelected { get; set; }
        public RelayCommand CommandAdd { get; set; }
        public RelayCommand CommandListBoxChange { get; set; }


        public SubjectEditViewModel(MainWindow mainWindow)
        {
            CommandDeleteSelected = new RelayCommand(Delete, CanDelete);
            CommandAdd = new RelayCommand(Add, CanAdd);
            CommandListBoxChange = new RelayCommand(Change, CanChange);

            _mainWindow = mainWindow;
            Subjects = new ObservableCollection<Subject>(_mainWindow.Subjects);
            Groups = new ObservableCollection<Group>(_mainWindow.Groups);




        }



        private bool CanDelete()
        {
            if (_selectedSubject == null)
            {
                return false;
            }
            return true;

        }


        private void Delete(object param)
        {
            Subjects.Remove(_selectedSubject);

            _mainWindow.Subjects.Remove(_selectedSubject);
            _mainWindow.InputParameters.Subjects.Remove(_selectedSubject);
            _selectedSubject = null;

            Abbrevation = String.Empty;
            Weeks = 14;
            LectureHours = 0;
            ExerciseHours = 0;
            SemminarHours = 0;
            CourseCompletionType = CourseCompletionType.Exam;
            SizeOfGroup = 0;
            Language = Language.CZ;


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
            Subjects.Add(newSubject);
            _selectedSubject = newSubject;


            _mainWindow.Subjects.Add(newSubject);
            _mainWindow.InputParameters.Subjects.Add(newSubject);





        }







    }
}
