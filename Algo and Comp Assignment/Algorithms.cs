using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Algorithms
{
    // Sorts in Asceding Order
    public void SortInAscendingOrder(double[] array)
    {
        QuickSort(array);
        void QuickSort(double[] data)
        {
            // Passes the parameters needed for the Sorting algorithm
            QuickSorting(data, 0, data.Length - 1);
        }
        //Sorts in Acesding Order
        void QuickSorting(double[] data, int start, int end)
        {
            int i, j;
            double pivot, temp;
            // Passes the value of the start and end (0 and array.length -1) to i and j
            i = start; j = end;
            //Creates the pivot at the middle of the array 
            pivot = data[(start + end) / 2];

            do
            {   // While  eg data[0] is lower than pivot in the middle of the array , and 0 is lower than end add 1
                while ((data[i] < pivot) && (i < end)) i++;
                //while pivot is lower than the value of data[j] and j is greater than start , decreases j by 1
                while ((pivot < data[j]) && (j > start)) j--;

                //if the value of data[i] is no longer lower than the pivot
                // and the value of data[j] is no longer bigger than the pivot , then now we are able to swap
                if (i <= j)
                {
                    //temp is used as a helper variable to store the value of data[i]
                    temp = data[i];
                    // assigns the value of data[i] to data[j]
                    data[i] = data[j];
                    // passes the value stored in temp to data[j]
                    data[j] = temp;
                    //after the swap is completed , increase i by 1 and decrease j by 1
                    i++;
                    j--;
                }
            } while (i <= j); // ends the loop when i no longer lower or equal to j 

            // Call the fuction recursively with new parameters , in effect splits the array for sorting
            if (start < j) QuickSorting(data, start, j);
            if (i < end) QuickSorting(data, i, end);
        }
    }    
    
    //This method sorts the array in Descending order
    public double[] SortInDescendingOrder(double[] array)
    {   //Gets the array length and middle , this algorithm splits the array exactly in the middle
        int high = array.Length;
        int middle = high / 2;
        // Two temporary lists to store the values of each side , I choose to use Lists as they are more dynamic
        List<double> left = new List<double>();
        List<double> right = new List<double>();

        //This method uses recursion to split the lists, the recursion ends when the array contains only one element
        if (array.Length <= 1) return array;

        //Iterates through the array and adds each half of the array to one the lists
        for (int i = 0; i < high; i++)
        {
            if (i < middle)
            {
                left.Add(array[i]);
            }
            else
            {
                right.Add(array[i]);
            }
        }
        //When the recursion loop is finished ,it returns and store the value of the array into
        //left and right lists 
        left = SortInDescendingOrder(left.ToArray()).ToList();
        right = SortInDescendingOrder(right.ToArray()).ToList();
        //Call the merge method and returns if value 
        return MergeSort(left, right);
    }
    static double[] MergeSort(List<double> left, List<double> right)
    {   // creates a new list to store the result of the Sorting and Merging
        List<double> result = new List<double>();
        // Loops while both of the arrays contains elements
        while (left.Any() && right.Any())
        {   // if the first element of the array 'left' is smaller or equal to the first element of array 'first'
            if (left.First() <= right.First())
            {   //adds the first element of the right array into the result array and removes it from the the array
                result.Add(right.First());
                right.Remove(right.First());
            }
            else
            {   //else add the first element of the left array
                result.Add(left.First());
                left.Remove(left.First());
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

    //Does a linear Search , better when using smaller arrays
    public void SearchLinear(double[] array)
    {   // temporary List to store the indexes
        List<int> temp = new List<int>();
        double lowerCloserValue = 0, upperCloserValue = 0;
        int lowerIndex = 0, upperIndex = 0;
        
        Console.WriteLine("In Order to be searched, the Array will be sorted in Asceding Order ");
        //Sort array in Ascending order
        SortInAscendingOrder(array);

        // While to make sure the question keeps being asked while no valid value is entered
        while (true)
        {
            Console.WriteLine("Please enter a value that you would like to search: ");
            //If input is a valid double
            if (double.TryParse(Console.ReadLine(), out double target))
            {   //Gets Border cases , return a false if value is outside of the array range
                if (!GetBorderCases(array, target)) break;
                
                //iterates through the Array 
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] < target)
                    {
                       //Store lowest closer value and its index
                       lowerCloserValue = array[i];
                       lowerIndex = i;

                    }
                    //if value searched is found , adds to the list
                    else if (array[i] == target)
                    {
                        temp.Add(i);
                    }
                    else if (array[i] > target)
                    {
                        //Store the upper value closer to the target and its index , and ends the loop
                        upperCloserValue = array[i];
                        upperIndex = i;
                        break;
                    }
                }
                // if temp list has any values , then it means the value has been found on at least one index
                if (temp.Any())
                {
                    //Joins every element in the List as a single string , separated by a ','
                    string text = string.Join(',', temp);
                    //Display the indexes
                    Console.WriteLine("Values found at index(es): {0}", text);
                }
                else
                {   //Displays the closest values and its indexes
                    Console.WriteLine("Not Found , the closest values are {0} at index {1} and value {2} at index {3}",lowerCloserValue,lowerIndex,upperCloserValue,upperIndex);
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
    public void SearchBinary(double[] array)
    {
        // Binary Sort needs the array to be sorted , so I call the SortingInAscedingOrder again
        SortInAscendingOrder(array);
        Console.WriteLine("In Order to be searched, the Array will be sorted in Asceding Order ");
        Binary(array);
        static void Binary(double[] array)
        {
            //Gets the input from the user and tries to parse it , if successful stores it into target
            Console.WriteLine("Please indicate the number you would like to search: ");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double target))
                {
                    // Checks wheater the target value isn't outside the array range
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
        }
    }
    //Get the borders cases 
    private static bool GetBorderCases(double[] array, double target)
    {
        // Gets the last element position
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
    // Uses the Merge Part of the MergeSort algorithm modified to merge Arrays
    public double[] MergeArrays(Arrays array1, Arrays array2)
    {
        //return the merged array 
         return Merge(array1.GetArrayValue().ToList(), array2.GetArrayValue().ToList());
        //Using the Merge Portion of the SortMerge Algorithm to merge 2 arrays
        static double[] Merge(List<double> left, List<double> right)
        {   // creates a new list to store the result of the Merging
            List<double> result = new List<double>();
            // Loops while both of the arrays contains elements
            while (left.Any() && right.Any())
            {   // if the first element of the array 'left' is smaller or equal to the first element of array 'first'
                if (left.First() <= right.First())
                {   //adds the first element of the left array into the result array and removes it from the the array
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else
                {   //else add the first element of the right array
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }
            // If any element is left at one of the arrays , the element is then added into Result and removed from array
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
