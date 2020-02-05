using System;
using System.IO;

namespace dir2list.NET
{
    class Program
    {
        public static string path, filename;
        public static string[] fileArray;
        public static int dircount;

        static void Main()
        {
            Console.WriteLine("Welcome to dir2list.NET\n");
            StarProgram();
            
        }
        static void StarProgram()
        {
                 
            Console.WriteLine("Enter Path: ");
            path = Console.ReadLine();
            Console.WriteLine($"Path: {path}");
            ScanPath(path);
            Console.WriteLine("Enter Filename: ");
            filename = Console.ReadLine();
            CreateFile(filename);      
            Console.WriteLine("Write into File");
            WriteInFile(filename, path);
            CheckExit();

        }
        static void ScanPath(string checkpath)
        {
            Console.WriteLine("Scan Path for Directory");
            CheckDir(checkpath);
            dircount = Directory.GetDirectories(checkpath).Length;
            if(dircount == 0)
            {
                Console.WriteLine("No Subfolders");
            }
            else
            {
                Console.WriteLine($"Directories Found: {dircount}");
            }
        }
        static void CheckDir(string checkdir)
        {
            if (!Directory.Exists(checkdir))
            {
                Console.WriteLine("Directory not exists");
                StarProgram();
            }
        }
        static void CreateFile(string filename)
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + filename + ".txt"))
            {
                using StreamWriter sw = File.CreateText(AppDomain.CurrentDomain.BaseDirectory + filename + ".txt");
                string filepath = AppDomain.CurrentDomain.BaseDirectory + filename + ".txt";
                Console.WriteLine("File successfully created");
                Console.WriteLine($"File Path: {filepath}");
            }
        }
        static void WriteInFile(string filename, string path)
        {
            fileArray = Directory.GetDirectories(path);
            using StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + filename + ".txt");
            for (int i = 0; i < fileArray.Length; i++)
            {

                sw.WriteLine(fileArray[i]);
            }
        }
        static void CheckExit()
        {
            Console.WriteLine("Exit Programm ? (y/n)");
            string a = Console.ReadLine();
            if(a == "y")
            {
                Environment.Exit(0);
            }
            else
            {
                StarProgram();
            }
        }
    }
}
