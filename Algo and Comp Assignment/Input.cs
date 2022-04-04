using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

    
class Input
{   //Create a varible that will be the 'standard' path to look for files
    private string Path { get; set; } 
    
    //Get the path from the user and passes it to Path
    public void GetPath()
    {
        Console.WriteLine(@"Please indicate the path to the files: (eg 'C:\Users\kleybson\Download' ) ");
        string path = Console.ReadLine();
        this.Path = path;
    }

     public double[] ReadFiles()
     {
        //string path = Console.ReadLine();
        Console.WriteLine("Please indicate the name of the files and extersions (eg 'text.txt'): ");
        string fileName = Console.ReadLine();
        
        
        string[] arrayAsText = File.ReadAllLines(this.Path + fileName);
        //Convert array to Int    
        double[] array = Array.ConvertAll(arrayAsText,s => double.TryParse(s,out var x) ? x :-1 );
        return array;
    }
}       


