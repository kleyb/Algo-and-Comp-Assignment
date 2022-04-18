
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to the Shares Searching and Sorting Application");

Arrays share_1_256 = new Arrays();
Arrays share_2_256 = new Arrays();
Arrays share_3_256 = new Arrays();

SortingAndDisplaying(share_1_256);
//SortingAndDisplaying(share_2_256);
//SortingAndDisplaying(share_3_256);

//share_1_256.SearchLinear();
share_1_256.SearchBinary();

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
// Steps 1 & 2
static void SortingAndDisplaying(Arrays array)
{
    array.GetArray();
    array.SortInAscedingOrder();
    array.SortInDescendingOrder();
    array.DisplayArray();
    array.DisplayEvery10();
}