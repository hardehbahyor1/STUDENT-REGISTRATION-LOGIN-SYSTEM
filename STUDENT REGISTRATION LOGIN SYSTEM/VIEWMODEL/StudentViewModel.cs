using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using System;
using System.Collections.Generic;
using System.Text;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL
{
    public class StudentViewModel
    {
        public StudentInfo Student { get; set; }

        public StudentViewModel()
        {
            Student = new StudentInfo();
            Student.Stdnt_ID = $"SDT-{DateTime.Now:yyyyMMddHHmmss}";
        }
        /*
        public int StudentPassword()
        {
            Student = new StudentInfo();
            Random Rand_password = new Random();
            Student.Stdnt_Password = Rand_password.Next(1, 20);
            return Student.Stdnt_Password;
        }// random password generator
        */
        private static Random rand = new Random();
        public void GenerateStudentCredentials()
        {
            if (Student == null) Student = new StudentInfo();

            // Generate ID if needed
            Student.Stdnt_ID = $"STD-{DateTime.Now:yyyyMMddHHmmss}";

            // Generate password
            Student.Stdnt_Password = rand.Next(1000, 9999).ToString();
        }
    }
}