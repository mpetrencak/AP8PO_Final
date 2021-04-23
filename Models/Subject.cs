using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using AP8PO_Final.Enums;

namespace AP8PO_Final.Models
{
    public class Subject
    {
        private string _abbrevation;
        [XmlAttribute("Abbrevation")]
        public string Abbrevation
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


        private int _weeks;
        [XmlAttribute("Weeks")]
        public int Weeks
        {
            get
            {
                return _weeks;
            }
            set
            {
                _weeks = value;
            }
        }


        private int _lectureHours;
        [XmlAttribute("LectureHours")]
        public int LectureHours
        {
            get
            {
                return _lectureHours;
            }
            set
            {
                _lectureHours = value;
            }
        }


        private int _exerciseHours;
        [XmlAttribute("ExerciseHours")]
        public int ExerciseHours
        {
            get
            {
                return _exerciseHours;
            }
            set
            {
                _exerciseHours = value;
            }
        }


        private int _semminarHours;
        [XmlAttribute("SemminarHours")]
        public int SemminarHours
        {
            get
            {
                return _semminarHours;
            }
            set
            {
                _semminarHours = value;
            }
        }


        private CourseCompletionType _courseCompletionType;
        [XmlAttribute("CourseCompletionType")]
        public CourseCompletionType CourseCompletionType
        {
            get
            {
                return _courseCompletionType;
            }
            set
            {
                _courseCompletionType = value;
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


        private int _sizeOfGroup;
        [XmlAttribute("SizeOFGroup")]
        public int SizeOfGroup
        {
            get
            {
                return _sizeOfGroup;
            }
            set
            {
                _sizeOfGroup = value;
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































        /// <summary>
        /// Ctor with basic imput parameters
        /// </summary>
        /// <param name="abbrevation"></param>
        /// <param name="weeks"></param>
        /// <param name="lectureHours"></param>
        /// <param name="exerciseHours"></param>
        /// <param name="semminarHours"></param>
        /// <param name="courseCompletionType"></param>
        /// <param name="language"></param>
        /// <param name="sizeOfGroup"></param>
        public Subject(string abbrevation, int weeks, int lectureHours,int exerciseHours, int semminarHours,
                        CourseCompletionType courseCompletionType, Language language, int sizeOfGroup)
        {
            Abbrevation = abbrevation;
            Weeks = weeks;
            LectureHours = lectureHours;
            ExerciseHours = exerciseHours;
            SemminarHours = semminarHours;
            CourseCompletionType = courseCompletionType;
            Language = language;
            SizeOfGroup = sizeOfGroup;

            
        }



        /// <summary>
        /// //Ctor with list of Groups
        /// </summary>
        /// <param name="abbrevation"></param>
        /// <param name="weeks"></param>
        /// <param name="lectureHours"></param>
        /// <param name="exerciseHours"></param>
        /// <param name="semminarHours"></param>
        /// <param name="courseCompletionType"></param>
        /// <param name="language"></param>
        /// <param name="sizeOfGroup"></param>
        /// <param name="groups"></param>
        public Subject(string abbrevation, int weeks, int lectureHours, int exerciseHours, int semminarHours,
                       CourseCompletionType courseCompletionType, Language language, int sizeOfGroup, ObservableCollection<Group> groups)
        {
            Abbrevation = abbrevation;
            Weeks = weeks;
            LectureHours = lectureHours;
            ExerciseHours = exerciseHours;
            SemminarHours = semminarHours;
            CourseCompletionType = courseCompletionType;
            Language = language;
            SizeOfGroup = sizeOfGroup;
            _groupsSrting = String.Empty;

            foreach(Group grp in groups)
            {
                _groupsSrting += grp.ToString();
                _groupsSrting += ", ";

            }


        }

        public Subject()
        {
            Abbrevation = null;
            Weeks = 0;
            LectureHours = 0;
            ExerciseHours = 0;
            SemminarHours = 0;
            CourseCompletionType = 0;
            Language = 0;
            SizeOfGroup = 0;
        }










































        public XmlSchema GetSchema()
        {
            return (null);
        }

        public void ReadXml(XmlReader reader)
        {
            Abbrevation = reader.ReadContentAsString();
            Weeks = Convert.ToInt32(reader.ReadContentAsString());
            LectureHours = Convert.ToInt32(reader.ReadContentAsString());
            ExerciseHours = Convert.ToInt32(reader.ReadContentAsString());
            SemminarHours = Convert.ToInt32(reader.ReadContentAsString());
            CourseCompletionType = (CourseCompletionType)Enum.Parse(typeof(CourseCompletionType), reader.ReadContentAsString());
            Language = (Language)Enum.Parse(typeof(Language), reader.ReadContentAsString());
            SizeOfGroup = Convert.ToInt32(reader.ReadContentAsString());
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(Abbrevation);
            writer.WriteString(Weeks.ToString());
            writer.WriteString(LectureHours.ToString());
            writer.WriteString(ExerciseHours.ToString());
            writer.WriteString(SemminarHours.ToString());
            writer.WriteString(CourseCompletionType.ToString());
            writer.WriteString(Language.ToString());
            writer.WriteString(SizeOfGroup.ToString());
        }
    }
}
