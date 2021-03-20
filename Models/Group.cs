using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using AP8PO_Final.Enums;

namespace AP8PO_Final.Models
{
    //Studijní obor
    public class Group
    {
        
        private string _abbrevation;
        [XmlAttribute("Abbrevation")]
        public string Abbrevation               //Zkratka oboru
        {
            get
            {
                return _abbrevation;
            }
            set
            {
                _abbrevation = value;
            }

        }




        private int _year;
        [XmlAttribute("Year")]
        public int Year
        {
            get
            {
                return _year;

            }
            set
            {
                _year = value;
            }
        }




        private Semester _semester;
        [XmlAttribute("Semester")]
        public Semester Semester
        {
            get
            {
                return _semester;
            }
            set
            {
                _semester = value;
            }
        }




        private int _numberOfStudents;
        [XmlAttribute("NumberOfStudents")]
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




        private StudyForm _studyForm;
        [XmlAttribute("SudyForm")]
        public StudyForm StudyForm
        {
            get
            {
                return _studyForm;
            }
            set
            {
                _studyForm = value;
            }
        }




        private StudyType _studyType;
        [XmlAttribute("StudyType")]
        public StudyType StudyType
        {
            get
            {
                return _studyType;
            }
            set
            {
                _studyType = value;
            }
        }




        private Language _language;
        [XmlAttribute("Language")]
        public Language Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
            }
        }


        public Group(string abbrevation, int year, Semester semester, int numberOfStudents, StudyForm studyForm, StudyType studyType, Language language)
        {
            Abbrevation = abbrevation;
            Year = year;
            Semester = semester;
            NumberOfStudents = numberOfStudents;
            StudyForm = studyForm;
            StudyType = studyType;
            Language = language;

        }

        public Group()
        {
            Abbrevation = null;
            Year = 0;
            Semester = 0;
            NumberOfStudents = 0;
            StudyForm = 0;
            StudyType = 0;
            Language = 0;

        }

        public XmlSchema GetSchema()
        {
            return (null);
        }

        public void ReadXml(XmlReader reader)
        {
            Abbrevation = reader.ReadContentAsString();
            Year = Convert.ToInt32(reader.ReadContentAsString());
            Semester = (Semester)Enum.Parse(typeof(Semester), reader.ReadContentAsString());
            NumberOfStudents = Convert.ToInt32(reader.ReadContentAsString());
            StudyForm = (StudyForm)Enum.Parse(typeof(StudyForm), reader.ReadContentAsString());
            StudyType = (StudyType)Enum.Parse(typeof(StudyType), reader.ReadContentAsString());
            Language = (Language)Enum.Parse(typeof(Language), reader.ReadContentAsString());

        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(Abbrevation);
            writer.WriteString(Year.ToString());
            writer.WriteString(Semester.ToString());
            writer.WriteString(NumberOfStudents.ToString());
            writer.WriteString(StudyForm.ToString());
            writer.WriteString(StudyType.ToString());
            writer.WriteString(Language.ToString());

        }
    }
}
