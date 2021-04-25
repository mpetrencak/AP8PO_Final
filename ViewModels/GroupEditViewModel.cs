using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using AP8PO_Final.Enums;
using AP8PO_Final.Models;

namespace AP8PO_Final.ViewModels
{
    public class GroupEditViewModel : ViewModelBase
    {
        MainWindow _mainWindow;
        public ObservableCollection<Group> Groups { get; private set; }

        private Group _selectedGroup;
        public Group SelectedGroup
        {
            get
            {
                return _selectedGroup;
            }
            set
            {
                _selectedGroup = value;
                if (value != null) 
                {
                    Abbrevation = value.Abbrevation;
                    Year = value.Year;
                    Semester = value.Semester;
                    NumberOfStudents = value.NumberOfStudents;
                    StudyForm = value.StudyForm;
                    StudyType = value.StudyType;
                    Language = value.Language;
                }
            }
        }


        

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

        private int _year;
        public int Year
        {
            get
            {
                return _year;

            }
            set
            {
                _year = value;
                OnPropertyChange("Year");
            }
        }

        private Semester _semester;
        public Semester Semester
        {
            get
            {
                return _semester;
            }
            set
            {
                _semester = value;
                OnPropertyChange("Semester");
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


        private StudyForm _studyForm;
        public StudyForm StudyForm
        {
            get
            {
                return _studyForm;
            }
            set
            {
                _studyForm = value;
                OnPropertyChange("StudyForm");
            }
        }

        private StudyType _studyType;
        public StudyType StudyType
        {
            get
            {
                return _studyType;
            }
            set
            {
                _studyType = value;
                OnPropertyChange("StudyType");
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


        public RelayCommand CommandAdd { get; set; }
        public RelayCommand CommandDeleteSelected { get; set; }


















        public GroupEditViewModel(MainWindow mainWindow)
        {
            
            CommandAdd = new RelayCommand(Add, CanAdd);
            CommandDeleteSelected = new RelayCommand(Delete, CanDelete);
            _mainWindow = mainWindow;
            Groups = new ObservableCollection<Group>(_mainWindow.Groups);




        }


        private bool CanDelete()
        {
            if (_selectedGroup == null)
            {
                return false;
            }
            return true;

        }


        private void Delete(object param)
        {
            Groups.Remove(_selectedGroup);

            _mainWindow.Groups.Remove(_selectedGroup);
            _mainWindow.InputParameters.Groups.Remove(_selectedGroup);

            _selectedGroup = null;



            Abbrevation = String.Empty;
            Year = 0;
            Semester = Semester.Winter;
            NumberOfStudents = 0;
            StudyForm = StudyForm.FullTime;
            StudyType = StudyType.Bc;
            Language = Language.CZ;




        }















        private bool CanAdd()
        {
            if (String.IsNullOrWhiteSpace(_abbrevation) == false && _year != 0 &&
               _numberOfStudents != 0)
            {
                return true;
            }
            return false;

        }

        private void Add(object param)
        {
            Group newGroup = new Group(_abbrevation,_year,_semester,_numberOfStudents,_studyForm,_studyType,_language);
            Groups.Add(newGroup);
            _selectedGroup = newGroup;


            _mainWindow.Groups.Add(newGroup);
            _mainWindow.InputParameters.Groups.Add(newGroup);


 




        }
    }
}
