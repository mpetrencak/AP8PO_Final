using System;
using System.Collections.Generic;
using System.Text;
using AP8PO_Final.Enums;

namespace AP8PO_Final.Models
{
    public class Employee
    {
        /// <summary>
        /// Employee's first name
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Employee's second name
        /// </summary>
        string SecondName { get; set; }

        /// <summary>
        /// Employee's full name
        /// </summary>
        string FullName { get; set; }

        /// <summary>
        /// Employess work email
        /// </summary>
        string WorkEmail { get; set; }

        /// <summary>
        /// Employee's personal email
        /// </summary>
        string PersonalEmail { get; set; }

        /// <summary>
        /// True of False if employee is PHd student
        /// </summary>
        bool PHdStudent { get; set; }

        /// <summary>
        /// Value 0 - 1.
        /// 0 for PHd student and agreement workers
        /// </summary>
        double Obligation { get; set; }             //uvazek

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
