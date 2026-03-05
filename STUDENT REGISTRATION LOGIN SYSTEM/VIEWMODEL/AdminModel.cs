using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL
{
    internal class AdminModel : INotifyPropertyChanged
    {
        // Class properties
        private string Fname = string.Empty;
        private string Mname = string.Empty;
        private string Lname = string.Empty;
        private string Department = string.Empty;
        private string IdentityNo = string.Empty; 
        private string UserName = string.Empty;
        private int Password;
        private DateTime DateCreated;


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
                if(Mname != value)
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
                if(Lname != value)
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
            get => DateCreated;
            set
            {
                if(DateCreated != value)
                {
                    DateCreated = value;
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
