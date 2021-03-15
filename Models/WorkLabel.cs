using System;
using System.Collections.Generic;
using System.Text;
using AP8PO_Final.Enums;

namespace AP8PO_Final.Models
{
    public class WorkLabel
    {
        string Name { get; set; }
        Employee Employee { get; set; }
        Subject Subject { get; set; }
        LabelType LabelType { get; set; }
        int NumberOfStudents { get; set; }
        int NumberOfHours { get; set; }
        int NumberOfWeeks { get; set; }
        Language Language { get; set; }

    }
}
