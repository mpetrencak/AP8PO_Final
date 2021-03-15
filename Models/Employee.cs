using System;
using System.Collections.Generic;
using System.Text;
using AP8PO_Final.Enums;

namespace AP8PO_Final.Models
{
    public class Employee
    {
        string FirstName { get; set; }
        string SecondName { get; set; }
        string FullName { get; set; }
        string WorkEmail { get; set; }
        string PersonalEmail { get; set; }
        bool PHdStudent { get; set; }
        double obligation { get; set; }

    }
}
