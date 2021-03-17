using System;
using System.Collections.Generic;
using System.Text;
using AP8PO_Final.Enums;

namespace AP8PO_Final.Models
{
    //Studijní obor
    public class Group
    {
        string Abbrevation { get; set; }                //Zkratka oboru
        int Year { get; set; }
        Semester Semester { get; set; }
        int NumberOfStudents { get; set; }
        StudyForm StudyForm { get; set; }
        StudyType StudyType { get; set; }
        Language Language { get; set; }


        public Group(string abbrevation, int year, Semester semester, int numberOfStudents, StudyForm studyForm, StudyType studyType, Language language)
        {
            Abbrevation = abbrevation;
            Year = year;
            Semester = semester;
            NumberOfStudents = numberOfStudents;
            StudyForm = studyForm;
            StudyType = studyType;
            Language = Language;

        }


    }
}
