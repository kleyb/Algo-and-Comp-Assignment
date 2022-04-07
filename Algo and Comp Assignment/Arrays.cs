using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Arrays
{   //Constructor to store the Array values
    private double[] ShareArray { get; set; }
    // Declare a new Sorting Obj , no need to declare it on the methods
    Sorting sorting = new Sorting();
    
    //Gets the Array from the Input class and stores it into ShareArray
    public void GetArray()
    {
        Input array = new Input();
        this.ShareArray = array.ReadFiles();
    }
    //Passes the Array into the method from Input Class that sorts the array in Asceding order
    public void SortInAscedingOrder()
    {
        sorting.QuickSort(this.ShareArray);
    }
    //Passes the array to the method from Input Class that sorts the Array in decending order and stores it on ShareArray
    public void SortInDescendingOrder()
    {
        this.ShareArray = sorting.Sort(this.ShareArray);
    }
    //Display the elements of the array
    public void DisplayArray()
    {   //Loops through the array and displays the elements 
        foreach (var number in this.ShareArray)
        {
            Console.Write("{0} " , number);
        }
    }
    //Display every 10th value from the array statin from index 0
    public void DisplayEvery10()
    {
        Console.WriteLine("Every 10th value: ");
        // Loops for the length of the array 
        for (int i = 0; i < this.ShareArray.Length; i=i+10)
        {
            Console.Write("{0} ",this.ShareArray[i]);
        }
        Console.WriteLine("\b");
    }
    //Does a linear Search , better when using smaller arrays
    public void SearchLinear()
    {   // temporary List to store the indexes
        List<int> temp = new List<int>();
        // While to make sure the question keeps being asked while no valid value is entered
        while (true)
        {
            Console.WriteLine("Please enter a value that you would like to search: ");
            //If input is a valid double
            if (double.TryParse(Console.ReadLine(), out double number))
            {   //iterates through the Array 
                for (int i = 0; i < this.ShareArray.Length; i++)
                {   //if value searched is found , adds to the list
                    if (this.ShareArray[i] == number)
                    {
                        temp.Add(i);
                    }
                }
                // if temp list has any values , then it means the value has been found on at least one index
                if (temp.Any())
                {
                    //Joins every element in the List as a single string , separated by a ','
                    string text = string.Join(',', temp);
                    //Display the indexes
                    Console.WriteLine("Values found at indexes: {0}", text);
                }
                else
                {   //else the value has no been found
                    Console.WriteLine("The value has no been found.");
                }                
                break;
            }
            else
            {   // Displays when the value to be searched can not be parsed into a double
                Console.WriteLine("You have entered a invalid input. Please make sure to enter only numbers");
            }
        }       
    }
}

