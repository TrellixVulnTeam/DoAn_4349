using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    private static string folderName = "Database";
    private static string fileName = "Database.csv";
    private static string separator = ",";
    private static string[] header = new string[5] {
                "Tốc độ tập chân",
                "Tốc độ tập tay",
                "Moment",
                "Độ chính xác",
                "Trợ lực"};
    private static string Timeheader = "Thời gian";
#region Interaction
    public static void AddtoFile(string[] strings)
    {
        CheckPath();
        Checkfile();
        using (StreamWriter sw = File.AppendText(Getfile()))
        {
            string finalString = "";
            finalString += GetTime() + separator;
            for (int i = 0; i < strings.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += separator;
                }
                finalString += strings[i];
            }
            sw.WriteLine(finalString);
        }
    }
    public static void CreateFile()
    {
        CheckPath();
        using (StreamWriter sw = File.CreateText(Getfile()))
        {
            string finalString = "";
            finalString += Timeheader + separator;
            for (int i = 0; i < header.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += separator;
                }
                finalString += header[i];
            }
            sw.WriteLine(finalString);
        }

    }
    #endregion

#region Operation
    static void CheckPath()
    {
        string dir = GetPath();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }
    static void Checkfile()
    {
        string file = Getfile();
        if(!File.Exists(file))
        {
            CreateFile();
        }    
    }
#endregion

#region Queris
    static string GetPath()
    {
        return Application.dataPath + "/" + folderName;
    }
    static string Getfile()
    {
        return GetPath() + "/" + fileName;
    }    
    static string GetTime()
    {
        return System.DateTime.Now.ToString();
    }
#endregion
}