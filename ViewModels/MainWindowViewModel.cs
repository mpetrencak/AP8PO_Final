using AP8PO_Final.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AP8PO_Final.ViewModels 
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {

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

            if (result == true)
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

    }
}
