﻿using System;
using System.Collections.Generic;
using System.Text;
using AP8PO_Final.Enums;

namespace AP8PO_Final.Models
{
    //Studijní obor
    public class Group
    {
        private string _abbrevation;
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


    }
}
