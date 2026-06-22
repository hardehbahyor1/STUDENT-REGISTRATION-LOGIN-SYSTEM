using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using System;
using System.Collections.Generic;
using System.Text;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL
{
    internal class AcademicResultModel
    {
        public string Subject_Name { get; private set; }
        public int Subject_Score { get; set;}
        public string Subject_Grade { get; set; }
        public string Subject_Remark { get; set; }
        public double Subject_AVE_Performance { get; set; }

        public static List<StudentInfo> result = new List<StudentInfo>();


        public static void ComputeScore()
        {

        }

        public static void ComputeGrade()
        {

        }

        public static void AveragePerformance()
        {

        }
    }
}
