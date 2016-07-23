using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/**
 * Author: Dilakshan Packiyanathan
 * StudentNumber: 300843256
 * DateModified: July 22nd, 2016
 */
namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
            Exit();
        }

        public static void Menu()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            const char DELIM = ',';

            int choice = 0;
            while (choice != 2)
            {
                Console.WriteLine("Student Grades");
                Console.WriteLine(" 1) ***************Display Grades****************");
                Console.WriteLine(" 2)**************** Exit************************");
                Console.Write("Please Select from above options --> ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                    choice = 0;
                }
                switch (choice)
                {
                    case 1:
                        gradeTxt(path, DELIM);
                        ShowGrade(path, DELIM);
                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Inavlid selection.\n");
                        break;
                }
            }
        }

        private static void gradeTxt(string path, char DELIM)
        {
            string fileName = "grade.txt";
            string[] firstName = { "Packiyanathan", "Kilinos", "Nathan", "Naidu" };
            string[] lastName = { "Dilakshan", "Nilojan", "Thuva", "Surya" };
            string[] studentID = { "1", "2", "3", "4" };
            string[] subject = { "Science", "Math", "Chemistry", "Biology" };
            string[] grade = { "D", "C", "A", "F" };

            try
            {
                FileStream outFile = new FileStream(path + "\\" + fileName, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);

                for (int i = 0; i < 3; i++)
                {
                    writer.WriteLine(firstName[i] + DELIM + lastName[i] + DELIM + studentID[i] + DELIM + subject[i] + DELIM + grade[i]);
                }
                writer.Close();
                outFile.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error occurred{0}", error.Message);
            }
        }

        public static void ShowGrade(string pathName, char DELIM)
        {
            string fileName;
            string[] fields;
            string fileData = "";
            string firstName;
            string lastName;
            string studentIndex;
            string className;
            string classGrade;

            Console.Write("Enter File Name ");
            fileName = Console.ReadLine();
            Console.WriteLine();

            try
            {
                FileStream inFile = new FileStream(pathName + "\\" + fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);

                fileData = reader.ReadLine();

                while (fileData != null)
                {
                    fields = fileData.Split(DELIM);
                    firstName = fields[0];
                    lastName = fields[1];
                    studentIndex = fields[2];
                    className = fields[3];
                    classGrade = fields[4];

                    Console.WriteLine("{0}, {1}: {2} {3}, {4}", firstName, lastName, studentIndex, className, classGrade);
                    fileData = reader.ReadLine();
                }
                Console.WriteLine();
                reader.Close();
                inFile.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine("Try Again!");
                Console.WriteLine(error.Message);
                Console.WriteLine();
            }
        }
        public static void Exit()
        {
            Console.WriteLine();
            Console.WriteLine("********************************");
            Console.WriteLine("Press any key to exit");
            Console.WriteLine("********************************");
            Console.ReadLine();

        }
    }
}
