using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using System;
using System.Collections.Generic;
using System.Text;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL
{
    public class StudentViewModel
    {
        public StudentInfo Student { get; set; }
        private static Random rand = new Random(); // for password auto generation

        public StudentViewModel()
        {
            Student = new StudentInfo();
            Student.Stdnt_ID = $"SDT-{DateTime.Now:yyyyMMddHHmmss}";
        } // student view model Constructor
        
        public void GenerateStudentCredentials()
        {
            if (Student == null) Student = new StudentInfo();

            // Generate ID if needed
            Student.Stdnt_ID = $"STD-{DateTime.Now:yyyyMMddHHmmss}";

            // Generate password
            Student.Stdnt_Password = rand.Next(1000, 9999).ToString();
        } // method to auto generate student ID_NO & Password
    }
}