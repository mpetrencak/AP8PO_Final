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

namespace AP8PO_Final.ViewModels
{
    public class InputDataViewModel : ViewModelBase
    {
        Window _mainWindow;
        private InputParameters _inputParameters{ get; set; }

        public ObservableCollection<Employee> Employees { get; set; }

        public ObservableCollection<Group> Groups { get; set; }

        public ObservableCollection<Subject> Subjects { get; set; }


        public RelayCommand CommandSave { get; set; }
        public RelayCommand CommandOpen { get; set; }


        /// <summary>
        /// Recive data from main window
        /// </summary>
        /// <param name="mainWindow"></param>
        public InputDataViewModel(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            Employees = new ObservableCollection<Employee>();
            Employees = mainWindow.Employees;

            Groups = new ObservableCollection<Group>();
            Groups = mainWindow.Groups;

            Subjects = new ObservableCollection<Subject>();
            Subjects = mainWindow.Subjects;

            CommandSave = new RelayCommand(Save, CanSave);
            CommandOpen = new RelayCommand(Open, CanOpen);

        }

        /// <summary>
        /// Recive data from inputPerameters
        /// </summary>
        /// <param name="mainWindow"></param>
        /// <param name="inputParameters"></param>
        public InputDataViewModel(MainWindow mainWindow,InputParameters inputParameters)
        {
            _mainWindow = mainWindow;

            Employees = new ObservableCollection<Employee>();
            Employees = inputParameters.Employees;

            Groups = new ObservableCollection<Group>();
            Groups = inputParameters.Groups;

            Subjects = new ObservableCollection<Subject>();
            Subjects = inputParameters.Subjects;

            CommandSave = new RelayCommand(Save, CanSave);
            CommandOpen = new RelayCommand(Open, CanOpen);



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

            Employees = _inputParameters.Employees;
            Groups = _inputParameters.Groups;
            Subjects = _inputParameters.Subjects;       
            


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
