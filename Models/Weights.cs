using System;
using System.Collections.Generic;
using System.Text;

namespace AP8PO_Final.Models
{
    public static class Weights
    {
        //CZ hours
        public static double LectureHour { get; private set; } = 1.8;
        public static double ExerciseHour { get; private set; } = 1.2;
        public static double SemminaHour { get; private set; } = 1.2;
        public static double OneCreditGiven { get; private set; } = 0.2;
        public static double OneClassifiedCreditGiven { get; private set; } = 0.3;
        public static double OneExamGiven { get; private set; } = 0.4;

        //EN hours
        public static double LectureHourEN { get; private set; } = 2.4;
        public static double ExerciseHourEN { get; private set; } = 1.8;
        public static double SemminaHourEN { get; private set; } = 1.8;
        public static double OneCreditGivenEN { get; private set; } = 0.2;
        public static double OneClassifiedCreditGivenEN { get; private set; } = 0.3;
        public static double OneExamGivenEN { get; private set; } = 0.4;



    }
}
