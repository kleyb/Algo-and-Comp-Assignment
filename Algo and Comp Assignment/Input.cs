using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

    
class Input
{   //Create a varible that will be the 'static' path to look for files
    private static string Path { get; set; }
    
    public static void GetPath(string path)
    {
        Path = path;
    }
    
    //Read all files  
    public double[] ReadFiles()
    {
        // Create the varible that will be used to store the Array as a text of after being converted 
        string[] arrayAsText;        
        double[] array;
        // The fileName variable will store the name the user has given his File
        string fileName;
        // Use a loop to keep trying to get the right name and extension of the files , the loop ends when the array is returned
        while (true)
        {
            try
            {
                Console.WriteLine("Please indicate the name of the files and extersions (eg 'text.txt'): ");
                fileName = Console.ReadLine();
                //Reads all the lines
                arrayAsText = File.ReadAllLines(Path + fileName);
                //Convert array to double
                array = Array.ConvertAll(arrayAsText, s => double.TryParse(s, out var x) ? x : -1);
                //Return Array
                return array;
            }
            catch (Exception)
            {   // If the use provide the name of a file that doesnt exist or extersion displays an error message 
                Console.WriteLine("The file you have selected is invalid , please check if you have entered the right with file" +
                    "with a '.txt' extension");
            }
        }            
    }
}       


