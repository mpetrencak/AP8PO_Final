using System;
using System.Collections.Generic;
using System.Text;
using AP8PO_Final.Enums;

namespace AP8PO_Final.Models
{
    public class Employee
    {
        private string _firstName;
        /// <summary>
        /// Employee's first name
        /// </summary>
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
        /// True of False if employee is PHd student
        /// </summary>
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

        /// <summary>
        /// List of work labels
        /// </summary>
        List<WorkLabel> WorkLabels { get; set; }


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

        }

    }
}
