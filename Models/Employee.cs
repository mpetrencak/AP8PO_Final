using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using AP8PO_Final.Enums;

namespace AP8PO_Final.Models
{
    public class Employee
    {
        private string _firstName;
        /// <summary>
        /// Employee's first name
        /// </summary>
        [XmlAttribute("FirstName")]
        public string FirstName
        {
            get
            {
                return _firstName;

            }
            set
            {
                _firstName = value;                

            }
        }



        private string _secondName;
        /// <summary>
        /// Employee's second name
        /// </summary>
        [XmlAttribute("SecondName")]
        public string SecondName
        {
            get
            {
                return _secondName;

            }

            set
            {
                _secondName = value;

            }
        }



        private string _fullName;
        /// <summary>
        /// Employee's full name
        /// </summary>
        [XmlAttribute("FullName")]
        public string FullName
        {
            get
            {
                return _fullName;

            }
            set
            {
                _fullName = value;
            }
        }



        private string _workEmail;
        /// <summary>
        /// Employess work email
        /// </summary>
        [XmlAttribute("WorkEmail")]
        public string WorkEmail
        {
            get
            {
                return _workEmail;
            }
            set 
            {
                _workEmail = value;
            }

        }



        private string _personalEmail;
        /// <summary>
        /// Employee's personal email
        /// </summary>
        [XmlAttribute("PersonalEmail")]
        public string PersonalEmail

        {
            get
            {
                return _personalEmail;
            }
            set
            {
                _personalEmail = value;
            }
        }


        
        private bool _pHdStudent;
        /// <summary>
        /// True or False if employee is PHd student
        /// </summary>
        [XmlAttribute("PHdStudent")]
        public bool PHdStudent
        {
            get
            {
                return _pHdStudent;
            }
            set
            {
                _pHdStudent = value;
            }
        }



        private double _obligation;
        /// <summary>
        /// Value 0 - 1.
        /// 0 for PHd student and agreement workers
        /// </summary>
        [XmlAttribute("Obligation")]
        public double Obligation //uvazek
        {
            get
            {
                return _obligation;
            }
            set
            {
                _obligation = value;
            }
              
        }


        private double _workpoints;
        [XmlAttribute("Workpoints")]
        public double Workpoins
        {
            get
            {
                _workpoints = GetPoints();
                return _workpoints;
            }
            set
            { 
                _workpoints = value;
            }
        }


        /// <summary>
        /// List of work labels
        /// </summary>
        private List<WorkLabel> _workLabels;
        [XmlElement(ElementName ="WorkLabels")]
        public List<WorkLabel> WorkLabels
        {
            get
            {
                return _workLabels;
            }
            set
            {
                _workLabels = value;
            }
        }

















        /// <summary>
        /// Constructor with workLabels
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="fullName"></param>
        /// <param name="workMail"></param>
        /// <param name="personalEmail"></param>
        /// <param name="pHdStudent"></param>
        /// <param name="obligation"></param>
        /// <param name="workLabels"></param>
        public Employee(string firstName, string secondName, string fullName, string workEmail,
                        string personalEmail, bool pHdStudent, double obligation, List<WorkLabel> workLabels)
        {
            FirstName = firstName;
            SecondName = secondName;
            FullName = fullName;
            WorkEmail = workEmail;
            PersonalEmail = personalEmail;
            PHdStudent = pHdStudent;
            Obligation = obligation;
            WorkLabels = workLabels;

        }

        public Employee(Employee employee,WorkLabel workLabel)
        {
            FirstName = employee.FirstName;
            SecondName = employee.SecondName;
            FullName = employee.FullName;
            WorkEmail = employee.WorkEmail;
            PersonalEmail = employee.PersonalEmail;
            PHdStudent = employee.PHdStudent;
            Obligation = employee.Obligation;
            WorkLabels = employee.WorkLabels;
            WorkLabels.Add(workLabel);

        }


        /// <summary>
        /// Cunstructor without worklabels
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="secondName"></param>
        /// <param name="fullName"></param>
        /// <param name="workMail"></param>
        /// <param name="personalEmail"></param>
        /// <param name="pHdStudent"></param>
        /// <param name="obligation"></param>
        public Employee(string firstName, string secondName, string fullName, string workEmail,
                string personalEmail, bool pHdStudent, double obligation)
        {
            FirstName = firstName;
            SecondName = secondName;
            FullName = fullName;
            WorkEmail = workEmail;
            PersonalEmail = personalEmail;
            PHdStudent = pHdStudent;
            Obligation = obligation;
            WorkLabels = new List<WorkLabel>();

        }

        public Employee()
        {            
            FirstName = null;
            SecondName = null;
            FullName = null;
            WorkEmail = null;
            PersonalEmail = null;
            PHdStudent = false;
            Obligation = 0;
            WorkLabels = new List<WorkLabel>();


        }



















        /// <summary>
        /// Get work points for every worklabel..
        /// </summary>
        /// <returns></returns>
        public double GetPoints()
        {
            double result = 0;

            foreach(WorkLabel wrklbl in WorkLabels)
            {
                result += wrklbl.GetPointsPerLabel();

            }

            return result;
        }















        public override string ToString()
        {
            return _fullName;
        }


















    }
}
