using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using AP8PO_Final.Enums;
using AP8PO_Final.Models;
using System.IO;
using Microsoft.Win32;
using System.Windows;
using System.Xml.Serialization;
using AP8PO_Final;


namespace AP8PO_Final.ViewModels
{
    
    public class InputDataViewModel : ViewModelBase
    {
        MainWindow _mainWindow;
        private InputParameters _inputParameters{ get; set; }



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

        //worklabels
        private ObservableCollection<WorkLabel> _workLabels;




        public RelayCommand CommandSave { get; set; }
        public RelayCommand CommandOpen { get; set; }
        public RelayCommand CommandGenerate { get; set; }


        /// <summary>
        /// Recive data from main window
        /// </summary>
        /// <param name="mainWindow"></param>
        public InputDataViewModel(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;

            Employees = new ObservableCollection<Employee>(_mainWindow.Employees);
            Groups = new ObservableCollection<Group>(_mainWindow.Groups);
            Subjects = new ObservableCollection<Subject>(_mainWindow.Subjects);


            CommandSave = new RelayCommand(Save, CanSave);
            CommandOpen = new RelayCommand(Open, CanOpen);
            CommandGenerate = new RelayCommand(Generate, CanGenerate);

        }

        /// <summary>
        /// Recive data from inputPerameters
        /// </summary>
        /// <param name="mainWindow"></param>
        /// <param name="inputParameters"></param>
        public InputDataViewModel(MainWindow mainWindow,InputParameters inputParameters)
        {
            _mainWindow = mainWindow;

            Employees = new ObservableCollection<Employee>(inputParameters.Employees);
            Groups = new ObservableCollection<Group>(inputParameters.Groups);
            Subjects = new ObservableCollection<Subject>(inputParameters.Subjects);

            CommandSave = new RelayCommand(Save, CanSave);
            CommandOpen = new RelayCommand(Open, CanOpen);
            CommandGenerate = new RelayCommand(Generate, CanGenerate);

        }







        private bool CanGenerate()
        {
            return true;
        }

        private void Generate(object param)
        {

            _workLabels = new ObservableCollection<WorkLabel>();
            WorkLabel wrklbl;





            foreach (Subject sub in Subjects)
            {
                int id = 1;

                //Lecture worklabels
                if (sub.LectureHours > 0)
                {
                    wrklbl = new WorkLabel(sub, LabelType.Lecture,id++);
                    _workLabels.Add(wrklbl);
                }


                //Exercise worklabels
                if (sub.ExerciseHours > 0)
                {
                    int numberofExercises = sub.GetNumberOfExesices();
                    for (int i = 0; i < numberofExercises; i++)
                    {
                        wrklbl = new WorkLabel(sub, LabelType.Exercise,id++);
                        _workLabels.Add(wrklbl);
                    }
                }


                //Semminar worklabels
                if (sub.SemminarHours > 0)
                {
                    wrklbl = new WorkLabel(sub, LabelType.Seminar,id++);
                    _workLabels.Add(wrklbl);

                }


                //classified credit worklabels
                if(sub.CourseCompletionType == CourseCompletionType.ClassifiedCredit)
                {
                    wrklbl = new WorkLabel(sub, LabelType.ClassifiedCredit,id++);
                    _workLabels.Add(wrklbl);

                }
                else    //exam worklabels + credit
                {
                    wrklbl = new WorkLabel(sub, LabelType.Credit,id++);
                    _workLabels.Add(wrklbl);
                    wrklbl = new WorkLabel(sub, LabelType.Exam,id++);
                    _workLabels.Add(wrklbl);
                }
            }


            _mainWindow.WorkLabels = new ObservableCollection<WorkLabel>(_workLabels);
            
            _mainWindow.WorkLabelEditViewModel.WorkLabels = new ObservableCollection<WorkLabel>(_workLabels);
            _mainWindow.WorkLabelEditViewModel.Employees = new ObservableCollection<Employee>(_employees);
            _mainWindow.WorkLabelEditViewModel.Employees.Add(new Employee());
            _mainWindow.WorkLabelEditViewModel.Subjects = new ObservableCollection<Subject>(_subjects);
            







        }




        private bool CanOpen()
        {
            return true;
        }

        private void Open(object param)
        {
            string path = String.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML-File | *.xml";
            var result = openFileDialog.ShowDialog();

            if(result == true)
            {
                path = openFileDialog.FileName;
            }
            else
            {
                return;
            }

            _inputParameters = new InputParameters();
            _inputParameters = DeserializeToObject<InputParameters>(path);

            _mainWindow.InputParameters = _inputParameters;



            Employees = new ObservableCollection<Employee>(_inputParameters.Employees);
            Groups = new ObservableCollection<Group>(_inputParameters.Groups);
            Subjects = new ObservableCollection<Subject>(_inputParameters.Subjects);

            _mainWindow.Employees = new ObservableCollection<Employee>(_inputParameters.Employees);
            _mainWindow.Groups = new ObservableCollection<Group>(_inputParameters.Groups);
            _mainWindow.Subjects = new ObservableCollection<Subject>(_inputParameters.Subjects);
            


        }



        private bool CanSave()
        {

            return true;

        }

        private void Save(object param)
        {
            string path = String.Empty;


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML-File | *.xml";
            var result = saveFileDialog.ShowDialog();

            if(result == true)
            {
                path = saveFileDialog.FileName;
            }
            else
            {
                return;
            }

            InputParameters inputParameters = new InputParameters(Employees, Groups, Subjects);
            SerializeToXml(inputParameters, path);
        }

        public static void SerializeToXml<T>(T anyobject, string xmlFilePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(anyobject.GetType());

            using (StreamWriter writer = new StreamWriter(xmlFilePath))
            {
                xmlSerializer.Serialize(writer, anyobject);
            }
        }

        public T DeserializeToObject<T>(string filepath) where T : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (StreamReader sr = new StreamReader(filepath))
            {
                return (T)ser.Deserialize(sr);
            }
        }


    }
}
