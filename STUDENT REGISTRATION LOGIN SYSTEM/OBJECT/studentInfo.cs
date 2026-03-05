using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT
{
    public class StudentInfo : INotifyPropertyChanged
    {
        private string student_Id = string.Empty; // will be used as student USER_NAME
        private int password;
        private string firstname = string.Empty;
        private string lastname = string.Empty;
        private string middlename = string.Empty;
        private string resident_Add =string.Empty;
        private string email_add = string.Empty;
        private string mobileNo = string.Empty;
        private DateTime ? DOB;
        private string SEX = string.Empty;
        private string country = string.Empty;
        private string state = string.Empty;
        private string LGA = string.Empty;
        
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

        public int Stdnt_Password
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
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnpropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(propertyName));
        }
    }
}
