
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to the Shares Searching and Sorting Application");

Input input = new Input();
int[] share1 = input.ReadFiles();
int[] share2 = input.ReadFiles();
int[] share3 = input.ReadFiles();

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