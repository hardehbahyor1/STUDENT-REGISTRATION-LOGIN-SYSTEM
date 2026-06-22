using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT
{
    public class Admininfo : INotifyPropertyChanged
    {
        // Personal Details properties
        private string Fname = string.Empty;
        private string Mname = string.Empty;
        private string Lname = string.Empty;
        private string Gender = string.Empty;
        private string NationalID = string.Empty;
        private DateTime? DOB;
        private string MaritalStatus = string.Empty;
        private string Religion = string.Empty;

        //Contact & locations properties
        private string Country = string.Empty;
        private string State = string.Empty;
        private string LGA = string.Empty;
        private string Residential_Address = string.Empty;
        private string Mobile_NO = string.Empty;
        private string Email_Address = string.Empty;

        //Next Of Kin Information
        private string kin_name = string.Empty;
        private string Kin_relationship = string.Empty;
        private string kin_mobileNO = string.Empty;
        private string kin_nationality = string.Empty;
        private string kin_address = string.Empty;
        private string kin_Email = string.Empty;

        //Qualifications Details Properties
        private string Qualification = string.Empty;
        private string Institution_Attended = string.Empty;
        private DateTime? Year_Of_Graduation;
        private string CourseOfStudy = string.Empty;

        // Appointment Properties
        private string IdentityNo = string.Empty;
        private string Department = string.Empty;
        private string EmploymentType = string.Empty;
        private DateTime? DateEmployed;
        private string Position = string.Empty;

        //Account Properties
        private string Password = string.Empty;


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

        public string AdminGender
        {
            get => Gender;
            set
            {
                if(Gender != value)
                {
                    Gender = value;
                    OnpropertyChanged();
                }
            }
        }
        public string National_ID
        {
            get => NationalID;
            set
            {
                if (NationalID != value)
                {
                    NationalID = value;
                    OnpropertyChanged();
                }
            }
        }
        public DateTime? AdminDOB
        {
            get => DOB;
            set
            {
                if (DOB != value)
                {
                    DOB = value;
                    OnpropertyChanged();
                }
            }
        }
        public string AdminMaritalStatus
        {
            get => MaritalStatus;
            set
            {
                if (MaritalStatus != value)
                {
                    MaritalStatus = value;
                    OnpropertyChanged();
                }
            }
        }
        public string AdminReligion
        {
            get => Religion;
            set
            {
                if(Religion != value)
                {
                    Religion = value;
                    OnpropertyChanged();
                }
            }
        }
        public string AdminCountry
        {
            get => Country;
            set
            {
                if(Country != value)
                {
                    Country = value;
                    OnpropertyChanged();
                }
            }
        }

        public string AdminState
        {
            get => State;
            set
            {
                if (State != value)
                {
                    State = value;
                    OnpropertyChanged();
                }
            }
        }

        public string AdminLGA
        {
            get => LGA;
            set
            {
                if (LGA != value)
                {
                    LGA= value;
                    OnpropertyChanged();
                }
            }
        }

        public string Admin_ResidentialAddress
        {
            get => Residential_Address;
            set
            {
                if(Residential_Address != value)
                {
                    Residential_Address = value;
                    OnpropertyChanged();
                }
            }
        }

        public string AdminMobile_No
        {
            get =>Mobile_NO;
            set
            {
                if (Mobile_NO != value)
                {
                    Mobile_NO = value;
                    OnpropertyChanged();
                }
            }
        }

        public string AdminEmail
        {
            get => Email_Address;
            set
            {
                if(Email_Address != value)
                {
                    Email_Address = value;
                    OnpropertyChanged();
                }
            }
        }
        public string NextOfKin_Name
        {
            get => kin_name;
            set
            {
                if(kin_name != value)
                {
                    kin_name = value;
                    OnpropertyChanged();
                }
            }
        }

        public string NextOfKin_Relationship
        {
            get => Kin_relationship;
            set
            {
                if(Kin_relationship != value)
                {
                    Kin_relationship = value;
                    OnpropertyChanged();
                }
            }
        }

        public string NextOfKin_Mobile
        {
            get => kin_mobileNO;
            set
            {
                if(kin_mobileNO != value)
                {
                    kin_mobileNO = value;
                    OnpropertyChanged();
                }
            }
        }
        public string NextOfKin_Nationality
        {
            get => kin_nationality;
            set
            {
                if(kin_nationality != value)
                {
                    kin_nationality = value;
                    OnpropertyChanged();
                }
            }
        }
        public string NextOfKin_Address
        {
            get => kin_address;
            set
            {
                if(kin_address != value)
                {
                    kin_address = value;
                    OnpropertyChanged();
                }
            }
        }
        public string NextOfKin_email
        {
            get => kin_Email;
            set
            {
                if(kin_Email != value)
                {
                    kin_Email = value;
                    OnpropertyChanged();
                }
            }
        }

        public string Admin_InstitutionAttended
        {
            get => Institution_Attended;
            set
            {
                if(Institution_Attended != value)
                {
                    Institution_Attended = value;
                    OnpropertyChanged();
                }
            }
        }

        public string AdminCourseOfStudy
        {
            get => CourseOfStudy;
            set
            {
                if(CourseOfStudy != value)
                {
                    CourseOfStudy = value;
                    OnpropertyChanged();
                }
            }
        }
        public DateTime? AdminYearOfGraduation
        {
            get => Year_Of_Graduation;
            set
            {
                if (Year_Of_Graduation != value)
                {
                    Year_Of_Graduation = value;
                    OnpropertyChanged();
                }
            }
        }
        public string AdminQualification
        {
            get => Qualification;
            set
            {
                if (Qualification != value)
                {
                    Qualification = value;
                    OnpropertyChanged();
                }
            }
        }
        //ID-NO, DEPT, DATEJOINED, POSITION==ROLE
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
        public string AdminDept
        {
            get => Department;
            set
            {
                if(Department!= value)
                {
                    Department = value;
                    OnpropertyChanged();
                }
            }
        }
        public string AdminROle
        {
            get => Position;
            set
            {
                if (Position != value)
                {
                    Position = value;
                    OnpropertyChanged();
                }
            }
        }

        public string employmentType
        {
            get => EmploymentType;
            set
            {
                if(EmploymentType != value)
                {
                    EmploymentType = value;
                    OnpropertyChanged();
                }
            }
        }
        public string AdminPassword
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
        public DateTime? Admin_DateEmployed
        {
            get => DateEmployed;
            set
            {
                if (DateEmployed != value)
                {
                    DateEmployed = value;
                    OnpropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnpropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
