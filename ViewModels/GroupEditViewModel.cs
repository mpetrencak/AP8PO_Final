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
        MainWindow MainWindow;
        public ObservableCollection<Group> Groups { get; private set; }

        private Group _selectedGroup;


        

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


















        public GroupEditViewModel(MainWindow mainWindow)
        {
            
            CommandAdd = new RelayCommand(Add, CanAdd);
            Groups = new ObservableCollection<Group>();
            MainWindow = mainWindow;

            


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
            MainWindow.Groups.Add(newGroup);

            _selectedGroup = newGroup;
 




        }
    }
}
