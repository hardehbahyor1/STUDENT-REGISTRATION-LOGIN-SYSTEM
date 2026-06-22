using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using System.Text.Json;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.DATABASE
{
    class Database_ConnectionPort
    {
        private static readonly string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StudentList.json"); // for student
        private static readonly string filepath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StaffList_DataBase.json"); // for staff
        private static readonly string deletedStaffDatabase = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Delected Staff Record"); // for deleted Staff

        //Retrieve information from the Database
        public static List<StudentInfo> LoadData()
        {
            if (!File.Exists(filepath))
                return new List<StudentInfo>();

            string JsonFIle = File.ReadAllText(filepath);

            if (string.IsNullOrEmpty(JsonFIle))
                return new List<StudentInfo>();

            return JsonSerializer.Deserialize<List<StudentInfo>>(JsonFIle) ?? new List<StudentInfo>();
        }

        //SAVE information from the Database
        public static void SaveData(StudentInfo student)
        {
            try
            {
               // MessageBox.Show($"Saving to:\n{filepath}");
                var _save_Data = LoadData();
                _save_Data.Add(student);
                var formatstyle = new JsonSerializerOptions
                {
                    WriteIndented = true,
                }; // this is used for formatting, i.e the way the information should be structured in the .json file

                string json = JsonSerializer.Serialize(_save_Data, formatstyle);
                File.WriteAllText(filepath, json);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error Saving: \n {e.Message}");
            }

        }

        public static void UpdateStudent(StudentInfo updatedStudent)
        {
            var students = LoadData();

            var index = students.FindIndex(s => s.Stdnt_ID == updatedStudent.Stdnt_ID);

            if (index != -1)
            {
                students[index] = updatedStudent;
            }
            else
            {
                MessageBox.Show("Student not found for update.");
                return;
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(filepath, JsonSerializer.Serialize(students, options));
        }


        /*
                ADMIN CRUD LOGIC DEVELOPMENT
         */
        public static List<Admininfo> RetrieveAdminData()
        {
            string AdminDatabase_Directory = filepath2;
            if (!File.Exists(AdminDatabase_Directory))
                return new List<Admininfo>();

            string RetrievedData = File.ReadAllText(AdminDatabase_Directory);

            if (string.IsNullOrEmpty(RetrievedData))
                return new List<Admininfo>();

            return JsonSerializer.Deserialize<List<Admininfo>>(RetrievedData) ?? new List<Admininfo>();
        }

        public static void SaveAdminData( Admininfo admin)
        {
            try
            {
                var _AcceptRetrievedAdmin_Data = RetrieveAdminData();
                _AcceptRetrievedAdmin_Data.Add(admin);

                var formatstyle = new JsonSerializerOptions
                {
                    WriteIndented = true,
                }; // this is used for formatting, i.e the way the information should be structured in the .json file

                string json = JsonSerializer.Serialize(_AcceptRetrievedAdmin_Data, formatstyle);
                File.WriteAllText(filepath2, json);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error Saving: \n {e.Message}");
            }
        }

        public static void DeletedStaff()
        {
            if (!File.Exists(deletedStaffDatabase))
            {
                MessageBox.Show("Error Establishing Connection", "Information", MessageBoxButton.RetryCancel, MessageBoxImage.Exclamation);
                return;
            }


        }
    }
}