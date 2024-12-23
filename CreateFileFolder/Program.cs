using System;
using System.IO;
namespace CreateFileFolder;
class Program
{
    public static void Main()
    {
        string path = @"D:\CreateFileFolder";
        System.Console.WriteLine("Menu :\n    1.Create Folder\n    2.Create File\n    3.Delete Folder\n    4.Delete File");
        int option;
        while (!int.TryParse(Console.ReadLine(), null, out option))
        {
            System.Console.WriteLine("Enter valid option...");
        }
        switch (option)
        {
            case 1:
                {
                    System.Console.WriteLine("Enter folder name : ");
                    string folderName = Console.ReadLine();
                    string folder = path + "/" + folderName;
                    if (!Directory.Exists(folder))
                    {
                        System.Console.WriteLine("Creating Folder...");
                        Directory.CreateDirectory(folder);
                    }
                    else
                    {
                        System.Console.WriteLine("Folder already exists...");
                    }
                    break;
                }
            case 2:
                {
                    Console.WriteLine("Enter filename : ");
                    string fileName = Console.ReadLine();
                    string file = path + "/" + fileName;
                    if (!File.Exists(file))
                    {
                        System.Console.WriteLine("Creating File...");
                        File.Create(file).Close();
                    }
                    else
                    {
                        System.Console.WriteLine("File already exists...");
                    }
                    break;
                }
            case 3:
                {
                    foreach (string folder in Directory.GetDirectories(path))
                    {
                        System.Console.WriteLine(folder);
                    }
                    System.Console.WriteLine("Enter folder name : ");
                    string folderName = Console.ReadLine();
                    // string folder1 = Path.Combine(folderName, path);
                    // if (Directory.Exists(folder1))
                    // {
                    //     System.Console.WriteLine("Deletiing folder...");
                    //     Directory.Delete(folder1);
                    // }
                    foreach (string folder in Directory.GetDirectories(path))
                    {
                        if (folder.Contains(folderName))
                        {
                            System.Console.WriteLine("Deleting Folder...");
                            Directory.Delete(folder);
                        }
                    }
                    break;
                }
            case 4:
                {
                    foreach (string file in Directory.GetFiles(path))
                    {
                        System.Console.WriteLine(file);
                    }
                    System.Console.WriteLine("Enter file name : ");
                    string fileName = Console.ReadLine();
                    foreach (string file in Directory.GetFiles(path))
                    {
                        if (file.Contains(fileName))
                        {
                            System.Console.WriteLine("Deletiing file...");
                            File.Delete(file);
                        }
                    }
                    break;
                }
        }
    }
}