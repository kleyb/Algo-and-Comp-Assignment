using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Arrays
{   //Constructor to store the Array values
    private double[] ShareArray { get; set; }

    // Declare a new Sorting Obj , no need to declare it on the methods
    private Sorting sorting = new Sorting();
    
    //Gets the Array from the Input class and stores it into ShareArray
    public void GetArray()
    {
        Input array = new Input();
        ShareArray = array.ReadFiles();
    }
    //Passes the Array into the method from Input Class that sorts the array in Asceding order
    public void SortInAscedingOrder()
    {
        sorting.QuickSort(ShareArray);
    }
    //Passes the array to the method from Input Class that sorts the Array in decending order and stores it on ShareArray
    public void SortInDescendingOrder()
    {
        ShareArray = sorting.Sort(ShareArray);
    }
    //Display the elements of the array
    public void DisplayArray()
    {   //Loops through the array and displays the elements 
        foreach (var number in ShareArray)
        {
            Console.Write("{0} " , number);
        }
        Console.WriteLine("\n");
    }
    //Displays every 10th value from the array statin from index 0
    public void DisplayEvery10()
    {
        Console.WriteLine("Every 10th value: ");
        // Loops for the length of the array 
        for (int i = 0; i < ShareArray.Length; i=i+10)
        {
            Console.Write("{0} ",ShareArray[i]);
        }
        Console.WriteLine("\n");
    }
    //Displays every 50th element 
    public void DisplayEvery50()
    {
        Console.WriteLine("Every 50th value: ");
        // Loops for the length of the array 
        for (int i = 0; i < ShareArray.Length; i = i + 50)
        {
            Console.Write("{0} ", ShareArray[i]);
        }
        Console.WriteLine("\n");
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
                for (int i = 0; i < ShareArray.Length; i++)
                {
                    if (ShareArray[i] < target)
                    {
                        templist.Add(ShareArray[i]);

                    }
                    //if value searched is found , adds to the list
                    else if (ShareArray[i] == target)
                    {
                        temp.Add(i);
                    }
                    else if (ShareArray[i] > target)
                    {
                        templist2.Add(ShareArray[i]);

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
        Binary(ShareArray);
        static void Binary(double[] array)
        {
            //Gets the input from the user and tries to parse it , if successful stores it into target
            Console.WriteLine("Please indicate the number you would like to search: ");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double target))
                {
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
                    break;
                }
                else
                {
                    Console.WriteLine("You have entered a invalid value , please make sure you can entered only numbers");
                }
            }
            // Performs the Binary search with finding the closest value if value in not outside the borders (range) of the Array
            static int BinarySearch(double[] array, int left, int right, double target, bool flag, int result)
            {   // if the right pointer is greater than the left then returns the result 
                if (right < left) return result;

                // finds the middle point of the array
                int middle = (left + right) / 2;

                //if the array middle is equal to target , then it has found the value it was looking for 
                //eg. an array [1,2,3,4,5] the middle point will be 3 , if 3 is what is being looking for , if will be found
                if (array[middle] == target)
                {
                    // stores the middle index into result
                    result = middle;
                    // Now if will split the array in half , to find all occurences 
                    // the first portion will look into the leftmost location
                    //while the else part will look inot the rightmost location of the value
                    if (flag)
                    {
                        //it will keep running until if finds the leftmost then it will return
                        result = BinarySearch(array, left, middle - 1, target, flag, result);
                        return result;
                    }
                    else
                    {   //runs until if finds the rightmost location then returns 
                        return BinarySearch(array, middle + 1, right, target, flag, result);
                    }
                }
                //if the value at the middle of the array is lower than the target , the it need to look into
                //right side of the array starting from middle 
                if (array[middle] < target)
                {
                    //if the target in greater than middle but lower than the next value after middle ,
                    //it means it is located between both numbers ,the value is not in the array 
                    //gets the closest value
                    if (middle < array.Length - 1 && target < array[middle + 1] && flag == true)
                    {
                        GetBinaryClose(array, middle, middle + 1, target);
                        //after displaying the closer value , returns -1 to indicate it is not found 
                        return -1;
                    }
                    return BinarySearch(array, middle + 1, right, target, flag, result);
                }
                //else runs if the value at middle of the array is greater than the target 
                //search the array starting from left until middle -1
                else
                {   // if target is lower than middle but greated than middle -1 , means it is located between both values
                    // the value is not found in this array , so display the closest 
                    if (middle > 0 && target > array[middle - 1] && flag == true)
                    {
                        GetBinaryClose(array, middle - 1, middle, target);
                        //returns -1 to indicate the value isnt found
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

    public void MergeArrays(Arrays array1 , Arrays array2)
    {
        array1.SortInAscedingOrder();
        array2.SortInAscedingOrder();
        ShareArray = Merge(array1.ShareArray.ToList(), array2.ShareArray.ToList());

        static double[] Merge(List<double> left, List<double> right)
        {   // creates a new list to store the result of the Sorting and Merging
            List<double> result = new List<double>();
            // Loops while both of the arrays contains elements
            while (left.Any() && right.Any())
            {   // if the first element of the array 'left' is smaller or equal to the first element of array 'first'
                if (left.First() <= right.First())
                {   //adds the first element of the right array into the result array and removes it from the the array
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else
                {   //else add the first element of the left array
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }
            // If any element is left at one of the array , the element is then added into result and removed 
            while (left.Any())
            {
                result.Add(left.First());
                left.Remove(left.First());
            }
            while (right.Any())
            {
                result.Add(right.First());
                right.Remove(right.First());
            }
            // Coverts result into an array and returns it 
            return result.ToArray();
        }
    }
}   


