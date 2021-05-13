using System;
using System.Collections.Generic;
using System.Text;

namespace AP8PO_Final.Models
{
    public class Weights
    {
        //CZ hours
        public double LectureHour { get; private set; } = 1.8;
        public double ExerciseHour { get; private set; } = 1.2;
        public double SemminaHour { get; private set; } = 1.2;
        public double OneCreditGiven { get; private set; } = 0.2;
        public double OneClassifiedCreditGiven { get; private set; } = 0.3;
        public double OneExamGiven { get; private set; } = 0.4;

        //EN hours
        public double LectureHourEN { get; private set; } = 2.4;
        public double ExerciseHourEN { get; private set; } = 1.8;
        public double SemminaHourEN { get; private set; } = 1.8;
        public double OneCreditGivenEN { get; private set; } = 0.2;
        public double OneClassifiedCreditGivenEN { get; private set; } = 0.3;
        public double OneExamGivenEN { get; private set; } = 0.4;


        public Weights()
        {

        }

    }
}
