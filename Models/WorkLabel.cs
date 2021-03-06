using System;
using System.Collections.Generic;
using System.Text;
using AP8PO_Final.Enums;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

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


        /// <summary>
        /// number of hours per week
        /// </summary>
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

        public WorkLabel(WorkLabel workLabel, Employee employee)
        {
            Name = workLabel.Name;
            Employee = employee;
            Subject = workLabel.Subject;
            LabelTypes = workLabel.LabelTypes;
            NumberOfStudents = workLabel.NumberOfStudents;
            NumberOfHours = workLabel.NumberOfHours;
            NumberOfWeeks = workLabel.NumberOfWeeks;
            Language = workLabel.Language;
            
        }

        /// <summary>
        /// Ctor for generating new worklabels
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="labelType"></param>
        /// <param name="number"></param>
        public WorkLabel(Subject subject,LabelType labelType,int? number)
        {
            if(number == null)
            {
                if(labelType == LabelType.Lecture)
                {
                    Name = subject.ToString() + "pre";
                }
                if(labelType == LabelType.Exam)
                {
                    Name = subject.ToString() + "zk";
                }

            }
            else
            {
                Name = subject.ToString() + number.ToString();
            }

            Employee = null;
            Subject = subject;
            LabelTypes = labelType;
            NumberOfStudents = subject.SizeOfGroup;


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
        /// Generate all possible worklabels
        /// </summary>
        /// <param name="Subjects">List of subjects</param>
        /// <returns>List of worklabels</returns>
        public static ObservableCollection<WorkLabel> GenerateWorkLabels(ObservableCollection<Subject> Subjects)
        {
            ObservableCollection<WorkLabel> _workLabels = new ObservableCollection<WorkLabel>();
            WorkLabel wrklbl;

            foreach (Subject sub in Subjects)
            {
                int id = 1;

                //Lecture worklabels
                if (sub.LectureHours > 0)
                {
                    wrklbl = new WorkLabel(sub, LabelType.Lecture, null);
                    _workLabels.Add(wrklbl);

                    if(sub.CourseCompletionType == CourseCompletionType.Exam)
                    {
                        wrklbl = new WorkLabel(sub, LabelType.Exam, null);
                        _workLabels.Add(wrklbl);

                    }
                }


                //Exercise worklabels
                if (sub.ExerciseHours > 0)
                {
                    int numberofExercises = sub.GetNumberOfExesices();
                    for (int i = 0; i < numberofExercises; i++)
                    {
                        wrklbl = new WorkLabel(sub, LabelType.Exercise, id++);
                        _workLabels.Add(wrklbl);
                    }
                }


                //Semminar worklabels
                if (sub.SemminarHours > 0)
                {
                    wrklbl = new WorkLabel(sub, LabelType.Seminar, id++);
                    _workLabels.Add(wrklbl);

                }
            }


            return _workLabels;
        }




        public int GetWeeks()
        {
            Subject.Groups.ToString();
            foreach (Group grp in Subject.Groups)
            {
                if (grp.StudyForm == StudyForm.FullTime)
                {
                    return 14;
                }
            }
            return 1;
        }






        /// <summary>
        /// Returns workpoints for WorkLabel
        /// </summary>
        /// <returns></returns>
        public double GetPointsPerLabel()
        {
            double result = 0;

            switch (_labeltypes)
            {
                case LabelType.Lecture:
                    result +=  _numberOfHours * _numberOfWeeks * Weights.LectureHour;

                    if(_subject.CourseCompletionType == CourseCompletionType.Exam)
                    {
                        result += _numberOfStudents * Weights.OneExamGiven;
                    }
                    break;

                case LabelType.Exercise:
                    result += _numberOfHours * _numberOfWeeks * Weights.ExerciseHour;

                    if(_subject.CourseCompletionType == CourseCompletionType.Credit)
                    {
                        result += _numberOfStudents * Weights.OneCreditGiven;
                    }
                    if(_subject.CourseCompletionType == CourseCompletionType.ClassifiedCredit)
                    {
                        result += _numberOfStudents * Weights.OneClassifiedCreditGiven;
                    }
                    break;

                    //pokud neni cviko ale jen seminar zapocty a klasaky zadava vedouci seminare
                case LabelType.Seminar:
                    result += _numberOfHours * _numberOfWeeks * Weights.SemminaHour;

                    if(_subject.ExerciseHours == 0)
                    {
                        if (_subject.CourseCompletionType == CourseCompletionType.Credit)
                        {
                            result += _numberOfStudents * Weights.OneCreditGiven;
                        }
                        if (_subject.CourseCompletionType == CourseCompletionType.ClassifiedCredit)
                        {
                            result += _numberOfStudents * Weights.OneClassifiedCreditGiven;
                        }

                    }
                    break;
            }

            return result;
        }































        public override string ToString()
        {
            return _name;
        }

    }
}
