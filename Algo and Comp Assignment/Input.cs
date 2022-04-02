using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

    
class Input
{

     public int[] ReadFiles()
     {
        Console.WriteLine("Please indicate the name of the file and extersion (eg 'text.txt'): ");
        string fileName = Console.ReadLine();
        Console.WriteLine(@"Please indicate the path to the file: (eg 'C:\Users\kleybson\Download' ) ");
        string path = Console.ReadLine();
        
        string[] arrayAsText = File.ReadAllLines(path + fileName);
        //Convert array to Int    
        int[] array = Array.ConvertAll(arrayAsText,s => int.TryParse(s,out var x) ? x :-1 );
        return array;
    }
}       


