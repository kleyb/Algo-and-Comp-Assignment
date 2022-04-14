﻿using System;
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

        List<double> templist = new List<double>();
        List<double> templist2 = new List<double>();

        // While to make sure the question keeps being asked while no valid value is entered
        while (true)
        {
            Console.WriteLine("Please enter a value that you would like to search: ");
            //If input is a valid double
            if (double.TryParse(Console.ReadLine(), out double target))
            {   //iterates through the Array 
                for (int i = 0; i < this.ShareArray.Length; i++)
                {
                    if (this.ShareArray[i] < target)
                    {
                        templist.Add(this.ShareArray[i]);

                    }
                    //if value searched is found , adds to the list
                    else if (this.ShareArray[i] == target)
                    {
                        temp.Add(i);
                    }
                    else if (this.ShareArray[i] > target)
                    {
                        templist2.Add(this.ShareArray[i]);

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
                {
                    if (templist.Count() >= 2)
                    {

                        if (target - templist[^1] > target - templist[^2])
                        {
                            Console.WriteLine("Value Not found , the closest value is: {0}", templist[^2]);
                        }
                        else if (target - templist[^1] < target - templist[^2])
                        {
                            Console.WriteLine("Value Not found , the closest value is: {0}", templist[^1]);
                        }
                    }
                    if (templist2.Count() >= 2)
                    {
                        if (target - templist2[0] > target - templist2[1])
                        {
                            Console.WriteLine("Value Not found , the closest value is: {0}", templist2[0]);
                        }
                        else if (target - templist2[0] < target - templist2[1])
                        {
                            Console.WriteLine("Value Not found , the closest value is: {0}", templist2[1]);
                        }
                    }
                }                
                break;
            }
            else
            {   // Displays when the value to be searched can not be parsed into a double
                Console.WriteLine("You have entered a invalid input. Please make sure to enter only numbers");
            }
        }       
    }
    
    //Does a Binary Search , better with larger ammounts of Data
    public void SearchBinary()
    {
        // Binary Sort needs the array to be sorted , so I call the SortingInAscedingOrder again
        SortInAscedingOrder();
        DisplayArray();
        Binary(this.ShareArray);
        static void Binary(double[] array)
        {
            //Gets the input from the user and tries to parse it , if successful stores it into target
            Console.WriteLine("Please indicate the number you would like to search: ");
            double.TryParse(Console.ReadLine(), out double target);
            
            // Checks wheater the target value inst outside the array range
            //By check if the value isn't smaller than the first element or greater than the last element in the sorted array
            if (GetBorderCases(array, target))
            {   
                // There will be 2 binary searches running , one will get the first occurence of the targeted value
                //The second will get the last occurence of the targeted value
                int left = BinarySearch(array, 0, array.Length - 1, target, true, 0);
                int right = BinarySearch(array, 0, array.Length - 1, target, false, 0);
                
                // Calculated the number of occurences by looking at the difference between indexes 
                int numberOfOccurences = (right - left) + 1;
                
                // The binary searches will return -1 only if the value in not found within the array 
                if (left == -1 || right == -1)
                {
                    Console.WriteLine("Value {0} not Found", target);
                }
                else
                {   // Display the number of occurences of the value and its locations
                    Console.WriteLine("There are {0} occurences of the value {1} , starting at index {2}", numberOfOccurences, target, left);
                }
            }

            static int BinarySearch(double[] array, int left, int right, double target, bool flag, int result)
            {
                if (right < left) return result;

                int middle = (left + right) / 2;

                if (array[middle] == target)
                {
                    result = middle;
                    if (flag)
                    {
                        result = BinarySearch(array, left, middle - 1, target, flag, result);
                        return result;
                    }
                    else
                    {
                        return BinarySearch(array, middle + 1, right, target, flag, result);
                    }
                }
                if (array[middle] < target)
                {
                    if (middle < array.Length - 1 && target < array[middle + 1] && flag == true)
                    {
                        GetBinaryClose(array, middle, middle + 1, target);
                        return -1;
                    }
                    return BinarySearch(array, middle + 1, right, target, flag, result);
                }
                else
                {
                    if (middle > 0 && target > array[middle - 1] && flag == true)
                    {
                        GetBinaryClose(array, middle - 1, middle, target);
                        return -1;
                    }
                    return BinarySearch(array, left, middle - 1, target, flag, result);
                }

            }
            //if value is not found within the array , it then gets and display the closest value 
            static void GetBinaryClose(double[] array, int value, int value2, double target)
            {
                double result = target - array[value];
                double result2 = target - array[value2];
                //Both if statments serve to make the results a positive number
                if (result < 0)
                {
                    result *= -1;
                }
                if (result2 < 0)
                {
                    result2 *= -1;
                }
                //The smaller value counting from the target postion will be displayed
                if (result >= result2)
                {
                    Console.WriteLine("Not Found , closest value is {0} at index {1}", array[value2], value2);
                }
                else
                {
                    Console.WriteLine("Not Found , closest value is {0} at index {1}", array[value], value);
                }

            }
            //Gets border cases eg: if value is lower than the first element of the Array
            static bool GetBorderCases(double[] array, double target)
            {
                // GEts the last element position
                int lastElement = array.Length - 1;
                // if the target is lower than the first element , display message and returns a false
                if (target < array[0])
                {
                    Console.WriteLine("Not Found , closest value is {0} at index {1}", array[0], 0);
                    return false;
                }
                //if target is greater than the last element in the array , displays message and returns a false
                if (target > array[lastElement])
                {
                    Console.WriteLine("Not Found, closest value is {0} at index {1}", array[lastElement], lastElement);
                    return false;
                }
                // if none of the if statments are met , then returns a true
                return true;
            }
        }
    }
}
