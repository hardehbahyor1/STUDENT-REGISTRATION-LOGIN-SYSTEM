using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.PAGES.Admin_UC_Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL
{
    public class AdminViewmodel: INotifyPropertyChanged
    {
        public Admininfo admin { get; set; }
        public ObservableCollection<Admininfo> staffList { get; set; }
        static Random AdminID = new Random(); // auto generate Admin Staff ID NO
        static Random AdminPsswrd = new Random();

        
        public AdminViewmodel()
        {
            admin = new Admininfo();
        }// constructor

        public void Generate_StaffID()
        {
            admin.AdminPassword = AdminPsswrd.Next(1000, 9999).ToString();
            int ID_randomNUmber = AdminID.Next(1000, 9999);
            this.admin.Admin_ID_No = $"STF-{admin.AdminDept}/{DateTime.UtcNow.Year}/{ID_randomNUmber}";
        }//logic CODE for Staff ID 


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnpropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //STAFF DASHBOARD ANALYSIS
    }
}