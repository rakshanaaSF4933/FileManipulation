using System;
using System.IO;
namespace ReadWrite;
class Program
{
    public static void Main()
    {
        if(!Directory.Exists("Testing"))
        {
            Directory.CreateDirectory("Testing");
        }
        else
        {
            System.Console.WriteLine("Folder already found...");
        }
        if(!File.Exists("Testing/Hello.txt"))
        {
            File.Create("Testing/Hello.txt").Close();
        }
        else
        {
            System.Console.WriteLine("File already exist...");
        }
        System.Console.WriteLine("Menu :\n    1.Read File\n    2.Write File");
        int option;
        while(!int.TryParse(Console.ReadLine(),null,out option))
        {
            System.Console.WriteLine("Enter valid option...");
        }
        switch(option)
        {
            case 1:
            {
                StreamReader sr = new StreamReader("Testing/Hello.txt");
                string data=sr.ReadLine();
                while(data!=null)
                {
                    System.Console.WriteLine(data);
                    data=sr.ReadLine();
                }
                sr.Close();
                break;
            }
            case 2:
            {
                string [] contents = File.ReadAllLines("Testing/Hello.txt");
                StreamWriter sw = new StreamWriter("Testing/Hello.txt");
                Console.WriteLine("Enter Line : ");
                string line = Console.ReadLine();
                string old = "";
                foreach(string data in contents)
                {
                    old+=data+"\n";
                }
                sw.WriteLine(old+line);
                sw.Close();
                break;
            }
        }
    }
}