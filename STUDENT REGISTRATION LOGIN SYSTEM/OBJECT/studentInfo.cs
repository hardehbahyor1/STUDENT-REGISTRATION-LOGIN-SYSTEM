using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Security.Policy;
using System.Text;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT
{
    public class StudentInfo : INotifyPropertyChanged
    {
        //class information
        private string student_Id = string.Empty; // will be used as student USER_NAME
        private string CurrentClass = string.Empty;
        private string ClassDepartment = string.Empty;

        //personal information
        private string password = string.Empty;
        private string firstname = string.Empty;
        private string lastname = string.Empty;
        private string middlename = string.Empty;
        private DateTime? DOB;
        private string SEX = string.Empty;

        //contact information
        private string resident_Add =string.Empty;
        private string email_add = string.Empty;
        private string mobileNo = string.Empty;
        
        //location information
        private string country = string.Empty;
        private string state = string.Empty;
        private string LGA = string.Empty;

        //parent/guardian information
        private string ParentName = string.Empty;
        private string ParentPhoneNo = string.Empty;
        private string ParentAddress = string.Empty;
        private string ParentCity = string.Empty;
        private string ParentOccupation = string.Empty;

        //hostel Accomodation infromation
        private string hostelname = string.Empty;
        private string blockType = string.Empty;
        private string roomNumber = string.Empty;
        private string bedspaceNumber = string.Empty;

        //health information
        private string BloodGroup = string.Empty;
        private string Allergies = string.Empty;

        //academic information (this contains the list of subjects offered by the student per Class during Session)
        private List <string> subjects = new List<string>();  

        private List<Subject_Score_Grade> Result = new();

        public string Stdnt_ID
        {
            get => student_Id;
            set
            {
                if (student_Id != value)
                {
                    student_Id = value;
                    OnpropertyChanged();
                }
            }
        }
        public string Stdnt_Class
        {
            get => CurrentClass;
            set
            {
                if (CurrentClass != value)
                {
                    CurrentClass = value;
                    OnpropertyChanged();
                }
            }
        }
        public string Stdnt_Department
        {
            get => ClassDepartment;
            set
            {
                if (ClassDepartment != value)
                {
                    ClassDepartment = value;
                    OnpropertyChanged();
                }
            }
        }
        public string Stdnt_Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    OnpropertyChanged();
                }
            }
        }
        public string Fname
        {
            get => firstname;
            set
            {
                if (firstname != value)
                {
                    firstname = value;
                    OnpropertyChanged();

                }
            }
        }
        public string Lname
        {
            get => lastname;
            set
            {
                if (lastname != value)
                {
                    lastname = value;
                    OnpropertyChanged();

                }
            }
        }
        public string Mname
        {
            get => middlename;
            set
            {
                if(middlename != value)
                {
                    middlename = value;
                    OnpropertyChanged();
                }
            }
        }
        public string Residential_Address
        {
            get => resident_Add;
            set
            {
                if (resident_Add != value)
                {
                    resident_Add = value;
                    OnpropertyChanged();
                }
            }
        }
        public string Email
        {
            get => email_add;
            set
            {
                if(email_add != value)
                {
                    email_add = value;
                    OnpropertyChanged();
                }
            }
        }
        public string PhoneNUmber
        {
            get => mobileNo;
            set
            {
                if(mobileNo != value)
                {
                    mobileNo = value;
                    OnpropertyChanged();
                }
            }
        }
        public DateTime ? DateOfBirth
        {
            get => DOB;
            set
            {
                if(DOB != value)
                {
                    DOB = value;
                    OnpropertyChanged();
                }
            }
        }
        public string Gender
        {
            get => SEX;
            set
            {
                if(SEX != value)
                {
                    SEX = value;
                    OnpropertyChanged();
                }
            }
        }
        public string Country
        {
            get => country;
            set
            {
                if(country != value)
                {
                    country = value;
                    OnpropertyChanged();
                }
            }
        }
        public string State
        {
            get => state;
            set
            {
                if(state != value)
                {
                    state = value;
                    OnpropertyChanged();
                }
            }
        }
        public string LocalGovtArea
        {
            get => LGA;
            set
            {
                if(LGA != value)
                {
                    LGA = value;
                    OnpropertyChanged();
                }
            }
        }
        public string ParentFullName
        {
            get => ParentName;
            set
            {
                if(ParentName != value)
                {
                    ParentName = value;
                    OnpropertyChanged();
                }
            }
        }
        public string ParentMobile_No
        {
            get => ParentPhoneNo;
            set
            {
                if(ParentPhoneNo != value)
                {
                    ParentPhoneNo = value;
                    OnpropertyChanged();
                }
            }
        }
        public string ParentResidentialAddress
        {
            get => ParentAddress;
            set
            {
                if(ParentAddress != value)
                {
                    ParentAddress = value;
                    OnpropertyChanged();
                }
            }
        }
        public string ParentJobOccupation
        {
            get => ParentOccupation;
            set
            {
                if(ParentOccupation != value)
                {
                    ParentOccupation = value;
                    OnpropertyChanged();
                }
            }
        }
        public string parentCity
        {
            get => ParentCity;
            set
            {
                if(ParentCity != value)
                {
                    ParentCity = value;
                    OnpropertyChanged();
                }
            }
        }
        public string Hostelname
        {
            get => hostelname;
            set
            {
                if (hostelname != value)
                {
                    hostelname = value;
                    OnpropertyChanged();
                }
            }
        }
        public string Blocktype
        {
            get => blockType;
            set
            {
                if (blockType != value)
                {
                    blockType = value;
                    OnpropertyChanged();
                }
            }
        }
        public string Roomnumber
        {
            get => roomNumber;
            set
            {
                if (roomNumber != value)
                {
                    roomNumber = value;
                    OnpropertyChanged();
                }
            }
        }
        public string BedspaceNumber
        {
            get => bedspaceNumber;
            set
            {
                if (bedspaceNumber != value)
                {
                    bedspaceNumber = value;
                    OnpropertyChanged();
                }
            }
        }
        public string StudentBloodGroup
        {
            get => BloodGroup;
            set
            {
                if(BloodGroup != value)
                {
                    BloodGroup = value;
                    OnpropertyChanged();
                }
            }
        }
        public string StudentAllergies
        {
            get => Allergies;
            set
            {
                if(Allergies != value)
                {
                    Allergies = value;
                    OnpropertyChanged();
                }
            }
        }
        public List<string> Courses
        {
            get => subjects;
            set
            {
                if(subjects != value)
                {
                    subjects = value;
                    OnpropertyChanged();
                }
            }
        }
        public List<Subject_Score_Grade> Student_Results
        {
            get => Result;
            set
            {
                if(Result != value)
                {
                    Result = value;
                    OnpropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnpropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(propertyName));
        }
    }
     public class Subject_Score_Grade
    {
        public string SubjectName { get; set; }
        public int Score { get; set; }
        public string Grade { get; set; }
        public string Remark { get; set; }
       
        public void ComputeGrade()
        {
            if(Score >=70 && Score <= 100)
            {
                Grade = "A";
                Remark = "Excellent";

            }
            else if(Score >=60 && Score <= 69)
            {
                Grade = "B";
                Remark = "Very Good";
            } 
            else if (Score >= 50 && Score <= 59)
            {
                Grade = "C";
                Remark= "Good";
            }
            else if (Score >= 45 && Score <= 49)
            {
                Grade = "D";
                Remark = "PASS";
            }
            else if (Score >= 40 && Score <= 44)
            {
                Grade = "E";
                Remark = "POOR";
            }
            else if (Score >= 0 && Score <= 39)
            {
                Grade = "F";
                Remark = "Fail";
            }
            else
            {
                Grade = "Nill";
                Remark = "ABS";
            }
        }
    } 
}
