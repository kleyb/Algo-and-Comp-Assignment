using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

    
class Input
{   //Create a varible that will be the 'static' path to look for files
    public static string Path { get; set; } 
    
    //Read all files  
    public double[] ReadFiles()
     {
        string[] arrayAsText;
        string fileName;
        double[] array;
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
            {
                Console.WriteLine("The file you have selected is invalid , please check if you have entered the right with file" +
                    "with a '.txt' extension");
            }
        }
            
    }
}       


