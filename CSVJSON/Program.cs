using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text.Json;
namespace CSVJSON;
class Program
{
    public static void Main()
    {
        //Creating Folder
        if (!Directory.Exists("Folder"))
        {
            System.Console.WriteLine("Creating folder...");
            Directory.CreateDirectory("Folder");
        }
        else
        {
            System.Console.WriteLine("Folder already exist...");
        }
        //Creating csv file
        if (!File.Exists("Folder/data1.csv"))
        {
            System.Console.WriteLine("Creating CSV file...");
            File.Create("Folder/data1.csv").Close();
        }
        else
        {
            System.Console.WriteLine("CSV file already exist...");
        }
        //Creating JSON file
        if (!File.Exists("Folder/data2.json"))
        {
            System.Console.WriteLine("Creating JSON file...");
            File.Create("Folder/data2.json").Close();
        }
        else
        {
            System.Console.WriteLine("JSON file already exist...");
        }

        List<StudentDetails> studentDetails = new List<StudentDetails>();
        studentDetails.Add(new StudentDetails("rakshanaa", "kumar", new DateTime(2002, 09, 10), GenderDetails.Female, 90));
        studentDetails.Add(new StudentDetails("sri", "kumar", new DateTime(2000, 10, 05), GenderDetails.Female, 95));
        WriteCSV(studentDetails);
        ReadCSV(studentDetails);
        WriteJSON(studentDetails);
        ReadJSON(studentDetails);
    }
    public static void WriteCSV(List<StudentDetails> students)
    {
        string [] data = File.ReadAllLines("Folder/data1.csv");
        StreamWriter sw = new StreamWriter("Folder/data1.csv");
        string old = "";
        for(int i=0;i<data.Length-1;i++)
        {
            string line = data[i];
            old+=line+"\n";
        }
        foreach (StudentDetails student in students)
        {
            string line = student.Name + "," + student.FatherName + "," + student.DOB.ToString("dd/MM/yyyy") + "," + student.Gender + "," + student.Mark;
            old+=line+"\n";
        }
        sw.WriteLine(old);
        sw.Close();
    }
    public static void ReadCSV(List<StudentDetails> students)
    {
        List<StudentDetails> studentDetails = new List<StudentDetails>();
        StreamReader sr = new StreamReader("Folder/data1.csv");
        string line = sr.ReadLine();
        while (line != "")
        {
            string[] data = line.Split(",");
            if (data[0] != null)
            {
                StudentDetails student = new StudentDetails(data[0], data[1],DateTime.ParseExact(data[2], "dd/MM/yyyy", null),Enum.Parse<GenderDetails>(data[3]),int.Parse(data[4]));
                studentDetails.Add(student);
            }
            line=sr.ReadLine();
        }
        foreach(StudentDetails details in studentDetails)
        {
            System.Console.Write($"Name : {details.Name}    FatherName : {details.FatherName}    DOB : {details.DOB}    Gender : {details.Gender}    Mark : {details.Mark}");
            System.Console.WriteLine();
        }
        sr.Close();
    }
    public static void WriteJSON(List<StudentDetails> students)
    {
        StreamWriter sw = new StreamWriter("Folder/data2.json");
        var option = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        string data = JsonSerializer.Serialize(students,option);
        sw.WriteLine(data);
        sw.Close();
    }
    public static void ReadJSON(List<StudentDetails> students)
    {
        List<StudentDetails> details = JsonSerializer.Deserialize<List<StudentDetails>>(File.ReadAllText("Folder/data2.json"));
        foreach(StudentDetails student in details)
        {
            System.Console.Write($"Name : {student.Name}    FatherName : {student.FatherName}    DOB : {student.DOB}    Gender : {student.Gender}    Mark : {student.Mark}");
            System.Console.WriteLine();
        }
    }
}