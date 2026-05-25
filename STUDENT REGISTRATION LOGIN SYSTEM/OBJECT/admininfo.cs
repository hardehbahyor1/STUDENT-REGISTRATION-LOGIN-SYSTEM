using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT
{
    internal class admininfo
    {
        // Class properties
        private string Fname = string.Empty;
        private string Mname = string.Empty;
        private string Lname = string.Empty;

        // locations properties
        private string Country = string.Empty;
        private string State = string.Empty;
        private string LGA = string.Empty;
        private string Residential_Address = string.Empty;

        //Contact Infomation Properties
        private string Mobile_NO = string.Empty;
        private string Email_Address = string.Empty;

        //Qualifications Details Properties
        private string Qualification = string.Empty;
        private string Institution_Attended = string.Empty;
        private DateTime Year_Of_Graduation;
        private string CourseOfStudy = string.Empty;
        
        
        // Appointment Properties
        private string IdentityNo = string.Empty;
        private string Department = string.Empty;        
        private string UserName = string.Empty;
        private int Password;
        private DateTime DateJoined;
        private string Position = string.Empty;


        public string AdminFirstName
        {
            get => Fname;
            set
            {
                if (Fname != value)
                {
                    Fname = value;
                    OnpropertyChanged();
                }
            }
        }

        public string AdminMiddlename
        {
            get => Mname;
            set
            {
                if (Mname != value)
                {
                    Mname = value;
                    OnpropertyChanged();
                }
            }
        }

        public string AdminLastName
        {
            get => Lname;
            set
            {
                if (Lname != value)
                {
                    Lname = value;
                    OnpropertyChanged();
                }
            }
        }

        public string AdminDept
        {
            get => Department;
            set
            {
                if (Department != value)
                {
                    Department = value;
                    OnpropertyChanged();
                }
            }
        }

        public string Admin_ID_No
        {
            get => IdentityNo;
            set
            {
                if (IdentityNo != value)
                {
                    IdentityNo = value;
                    OnpropertyChanged();
                }
            }
        }

        public string AdminUsername
        {
            get => UserName;
            set
            {
                if (UserName != value)
                {
                    UserName = value;
                    OnpropertyChanged();
                }
            }
        }

        public int AdminPassword
        {
            get => Password;
            set
            {
                if (Password != value)
                {
                    Password = value;
                    OnpropertyChanged();
                }
            }
        }

        public DateTime AcountDateCreated
        {
            get => DateJoined;
            set
            {
                if (DateJoined != value)
                {
                    DateJoined = value;
                    OnpropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnpropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Generate Admin_ID
        public void GenrateAdmin_ID()
        {
            Admin_ID_No = $"ADMIN-{DateTime.Now:yyyyMMdd}";

        }
    }
}
