using System;
using System.Collections.Generic;
using System.Text;
using AP8PO_Final.Enums;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AP8PO_Final.Models
{
    public class WorkLabel
    {
        private string _name;
        [XmlAttribute("Name")]
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
             
        }

        private Employee _employee;
        [XmlElement(ElementName ="Employee")]
        public Employee Employee 
        {
            get
            {
                return _employee;
            }
            set 
            {
                _employee = value;
            }
        }
        public string EmployeeString
        {
            get
            {
                return _employee?.ToString();
            }
        
        }



        private Subject _subject;
        [XmlElement(ElementName = "Subject")]
        public Subject Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                _subject = value;
            }
        }
        public string SubjectString
        {
           get
            {
                return _subject.ToString();
            }

        }


        private LabelType _labeltypes;
        [XmlAttribute("LabelTypes")]
        public LabelType LabelTypes
        {
            get
            {
                return _labeltypes;
            }

            set
            {
                _labeltypes = value;
            }
                
        }


        private int _numberOfStudents;
        [XmlAttribute("NumOfStudents")]
        public int NumberOfStudents
        {
            get
            {
                return _numberOfStudents;
            }
            set
            {
                _numberOfStudents = value;
            } 
        }



        private int _numberOfHours;
        [XmlAttribute("NumOfHours")]
        public int NumberOfHours
        {
            get
            {
                return _numberOfHours;
            }
            set
            {
                _numberOfHours = value;

            }
        }


        private int _numberOfWeeks;
        [XmlAttribute("NumOfWeeks")]
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

        private Language _langueage;
        [XmlAttribute("Language")]
        public Language Language
        {
            get
            {
                return _langueage;
            }
            set
            {
                _langueage = value;
            }
        
        }
                

        /// <summary>
        /// Basic ctor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="employee"></param>
        /// <param name="subject"></param>
        /// <param name="labelType"></param>
        /// <param name="numberOfStudents"></param>
        /// <param name="numberOfHours"></param>
        /// <param name="numberOfWeeks"></param>
        /// <param name="language"></param>
        public WorkLabel(string name, Employee employee, Subject subject, LabelType labelType,
            int numberOfStudents, int numberOfHours, int numberOfWeeks, Language language)
        {
            Name = name;
            Employee = employee;
            Subject = subject;
            LabelTypes = labelType;
            NumberOfStudents = numberOfStudents;
            NumberOfHours = numberOfHours;
            NumberOfWeeks = numberOfWeeks;
            Language = language;

        }

        public int GetWeeks()
        {
            Subject.Groups.ToString();
            foreach(Group grp in Subject.Groups)
            {
                if(grp.StudyForm == StudyForm.FullTime)
                {
                    return 14;
                }
            }

            return 1;



        }






        public WorkLabel(Subject subject,LabelType labelType,int number)
        {
            Name = subject.ToString() + number.ToString();
            Employee = null;
            Subject = subject;
            LabelTypes = labelType;
            NumberOfStudents = subject.GetStudents();


            switch(labelType)
            {
                case LabelType.Seminar:
                    NumberOfHours = subject.SemminarHours;
                    break;
                case LabelType.Exercise:
                    NumberOfHours = subject.ExerciseHours;
                    break;
                case LabelType.Lecture:
                    NumberOfHours = subject.LectureHours;
                    break;
                default:
                    NumberOfHours = 0;
                    break;
            }


            NumberOfWeeks = GetWeeks();
            Language = subject.Language;


            


        }


        /// <summary>
        /// Empty ctor
        /// </summary>
        public WorkLabel()
        {
                
        }





        /// <summary>
        /// Returns workpoints for WorkLabel
        /// </summary>
        /// <returns></returns>
        public double GetPointsPerLabel()
        {
            return 0;
        }

        public override string ToString()
        {
            return _name;
        }







    }
}
