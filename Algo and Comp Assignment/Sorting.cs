using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Sorting
{
    // Gets the Array from the user
    public void QuickSort(double[] data)
    {
        // Passes the parameters needed for the Sorting algorithm
        QuickSort(data, 0, data.Length - 1);
    }
    //Sorts in Acesding Order
    private void QuickSort(double[] data, int start, int end)
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
        if (start < j) QuickSort(data, start, j);
        if (i < end) QuickSort(data, i, end);
    }

    // Sort Array in Descending Order
    public double[] Sort(double[] array)
    {
        int low = 0;
        int high = array.Length;

        int n = high - low + 1;
        int middle = low + n / 2;

        List<double> left = new List<double>();
        List<double> right = new List<double>();


        if (array.Length <= 1) return array;

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
        Console.WriteLine();
        left = Sort(left.ToArray()).ToList();


        right = Sort(right.ToArray()).ToList();

        array = Merge(left, right);
        return array;

    }
    private static double[] Merge(List<double> left, List<double> right)
    {
        List<double> result = new List<double>();

        while (left.Any() && right.Any())
        {
            if (left.First() <= right.First())
            {
                result.Add(right.First());
                right.Remove(right.First());
            }
            else
            {
                result.Add(left.First());
                left.Remove(left.First());
            }
        }
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

        return result.ToArray();
    }

}