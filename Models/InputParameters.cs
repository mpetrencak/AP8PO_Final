using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AP8PO_Final.Models
{
    [XmlRoot(ElementName = "InputParameters")]
    public class InputParameters
    {
        [XmlElement(ElementName = "Employee")]
        public ObservableCollection<Employee> Employees { get; set; }
        [XmlElement(ElementName = "Group")]
        public ObservableCollection<Group> Groups { get; set; }
        [XmlElement(ElementName = "Subject")]
        public ObservableCollection<Subject> Subjects { get; set; }

        public InputParameters()
        {
            Employees = null;
            Groups = null;
            Subjects = null;
        }

        public InputParameters(ObservableCollection<Employee> employees, ObservableCollection<Group> groups, ObservableCollection<Subject> subjects)
        {
            Employees = employees;
            Groups = groups;
            Subjects = subjects;

        }



    }
}
