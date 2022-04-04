
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to the Shares Searching and Sorting Application");

Input input = new Input();
input.GetPath();
double[] share1 = input.ReadFiles();
double[] share2 = input.ReadFiles();
double[] share3 = input.ReadFiles();

Console.WriteLine("This program will sort your arrays in acesding and descending order and display the 10th elements." +
    "At the end you will have more options to sort and search your arrays. Please press enter to continue");
Console.ReadKey();

Sorting sorting = new Sorting();
sorting.QuickSort(share1);
sorting.QuickSort(share2);
sorting.QuickSort(share3);


Console.WriteLine("Please select one of the options: ");
Console.WriteLine(" 1 for sorting in acesding order");
Console.WriteLine(" 2 for sorting in descending order");
Console.WriteLine(" 3 to Search");
Console.WriteLine(" 4 to Merge and Sort");

while (true)
{
    if (Console.ReadLine() == "1")
    {

    }
    else if (Console.ReadLine() == "2")
    {

    }
    else if (Console.ReadLine() == "3")
    {

    }
    else if (Console.ReadLine() == "4")
    {

    }
    else
    {
        Console.WriteLine();
    }
}