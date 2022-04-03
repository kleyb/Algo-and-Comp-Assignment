using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Sorting
{
    //Sorts in Acesding Order
    public void QuickSort(double[] data)
    {
        QuickSort(data, 0, data.Length - 1);
    }


    private void QuickSort(double[] data, int left, int right)
    {
        int i, j;
        double pivot, temp;
        i = left; j = right;
        pivot = data[(left + right) / 2];

        do
        {
            while ((data[i] < pivot) && (i < right)) i++;
            while ((pivot < data[j]) && (j > left)) j--;

            if (i <= j)
            {
                temp = data[i];
                data[i] = data[j];
                data[j] = temp;
                i++;
                j--;
            }
        } while (i <= j);

        if (left < j) QuickSort(data, left, j);

        if (i < right) QuickSort(data, i, right);
    }
}

