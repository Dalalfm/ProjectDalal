using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Linq;

class Project
{
    //Variables
    public static int id;
    public static string name;
    public static string claass;
    public static string section;
    static void Main(string[] args)
    {
       
        Console.WriteLine("****************************************");
        Console.WriteLine("Welcome to Rainbow School Storing System!");
        Console.WriteLine("*****************************************");
        Console.WriteLine("Add New Data or Update By Inserting ID:");
        //Readings of user
        id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Name:");
        name = Console.ReadLine();
        Console.WriteLine("Class:");
        claass = Console.ReadLine();
        Console.WriteLine("Section:");
        section = Console.ReadLine();
        //Start file editing
        RunFile();
    }
    public static void RunFile()
    {
        //Add the file to directory and choosing it
        string dir = Directory.GetCurrentDirectory();
        string filename = "TheData.txt";
        if (File.Exists(filename))
        {
            //Checking the file
            string[] check = File.ReadAllLines(filename);
            if (check.Contains("ID: " + id))
            {
                for (int i = 0; i < check.Length; i++)
                {
                    //Check if ID exist 
                    if (check[i].Contains("ID: " + id))
                    {
                        //Replacing old data with new ones
                        check[i + 1] = "Name: " + name;
                        check[i + 2] = "Class: " + claass;
                        check[i + 3] = "Section: " + section;

                        using (StreamWriter sw = File.CreateText(filename))
                        {
                            //Writing each line again with edited data
                            foreach (string line in check)
                            {
                                sw.WriteLine(line);
                            }
                        }
                        Console.WriteLine("Data Edited!");

                    }
                }
            }
            else
            {
                //If the ID doesn't exists, this will write a new user and its data
                using (StreamWriter sw = File.AppendText(filename))
                {
                    sw.WriteLine("ID: " + id);
                    sw.WriteLine("Name: " + name);
                    sw.WriteLine("Class: " + claass);
                    sw.WriteLine("Section: " + section);
                    sw.WriteLine("----------------------");
                }
                Console.WriteLine("Data Added!");
            }
        }

        else
        {
            File.CreateText(filename);
        }


    }
}