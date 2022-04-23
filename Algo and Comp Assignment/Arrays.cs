using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Arrays
{   //Constructor to store the Array
    private double[] FileArray { get; set; }
    
    //Gets the Array from the Input class and stores it into FileArray
    public void SetArray(double[] array )
    {
        FileArray = array;
    }
    //Returns the array values
    public double[] GetArrayValue()
    {
        return FileArray;
    }
    
    public void DisplayArray()// in Order to show the User the current state of the Array
    {   //Loops through the array and displays the elements 
        foreach (var number in FileArray)
        {
            Console.Write("{0} " , number);
        }
        Console.WriteLine("\n");
    }
    //Displays every 10th value from the array stating from index 0
    public void DisplayEvery10()
    {
        Console.WriteLine("Every 10th value: ");
        // Loops for the length of the array 
        for (int i = 0; i < FileArray.Length; i=i+10)
        {
            Console.Write("{0} ",FileArray[i]);
        }
        Console.WriteLine("\n");
    }
    //Displays every 50th element from the array starting from index 0
    public void DisplayEvery50()
    {
        Console.WriteLine("Every 50th value: ");
        // Loops for the length of the array 
        for (int i = 0; i < FileArray.Length; i = i + 50)
        {
            Console.Write("{0} ", FileArray[i]);
        }
        Console.WriteLine("\n");
    }   
}   


