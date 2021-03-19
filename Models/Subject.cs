﻿using System;
using System.Collections.Generic;
using System.Text;
using AP8PO_Final.Enums;

namespace AP8PO_Final.Models
{
    public class Subject
    {
        private string _abbrevation;
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

        

       
    }
}
