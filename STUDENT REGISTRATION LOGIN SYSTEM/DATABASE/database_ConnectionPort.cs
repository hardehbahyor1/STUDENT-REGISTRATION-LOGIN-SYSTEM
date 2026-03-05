using STUDENT_REGISTRATION_LOGIN_SYSTEM.OBJECT;
using STUDENT_REGISTRATION_LOGIN_SYSTEM.VIEWMODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace STUDENT_REGISTRATION_LOGIN_SYSTEM.DATABASE
{
    class database_ConnectionPort
    {
        private static readonly string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StudentList.json");
        
        //Retrieve information from the Database
        public static List<StudentInfo> LoadData()
        {
            if(!File.Exists(filepath))
                return [];
            string JsonFIle = File.ReadAllText(filepath);

            if(string.IsNullOrEmpty(JsonFIle))
                return new List<StudentInfo>();
            return JsonSerializer.Deserialize<List<StudentInfo>>(JsonFIle) ?? [];
        }

        //SAVE information from the Database
        public static void SaveData(StudentInfo student)
        {
            try
            {
                MessageBox.Show($"Saving to:\n{filepath}");
                var _save_Data = LoadData();
                _save_Data.Add(student);
                var formatstyle = new JsonSerializerOptions
                {
                    WriteIndented = true,
                }; // this is used for formatting, i.e the way the information should be structured in the .json file
                string json = JsonSerializer.Serialize(_save_Data, formatstyle);
                File.WriteAllText(filepath, json);
            }
            catch(Exception e)
            {
                MessageBox.Show($"Error Saving: \n {e.Message}");
            }
            
        }
            
    }
}
