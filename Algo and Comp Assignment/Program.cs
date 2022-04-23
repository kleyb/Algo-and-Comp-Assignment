
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to the Shares Searching and Sorting Application");
while (true)
{
    Console.WriteLine(@"Please indicate the path to the file: (eg 'C:\Users\kleybson\Download' ) ");
    string path = Console.ReadLine();

    if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
    {
        Console.WriteLine(@"You have not entered a Path. "
        + @"Please enter your Path (eg 'C:\Users\kleybson\Download' ) and confirm ");
        Console.WriteLine();
        continue;
    }
    Console.WriteLine("Please confirm the path for your file , your won't be able to change it later ," +
        " your path currently is: {0} , enter 'Yes' to confirm or anything else to change it", path);
    if (Console.ReadLine().ToUpper() == "YES")
    {
        Input.GetPath(path);
        break;
    }
}

Console.WriteLine("Analyses of 256 length Files: \n");
Arrays share_1_256 = new Arrays();
Arrays share_2_256 = new Arrays();
Arrays share_3_256 = new Arrays();

SortingAndDisplaying256(share_1_256);
SortingAndDisplaying256(share_2_256);
SortingAndDisplaying256(share_3_256);

Console.WriteLine("Analyses of 2048 length Files: \n");

Arrays share_1_2048 = new Arrays();
Arrays share_2_2048 = new Arrays();
Arrays share_3_2048 = new Arrays();

SortingAndDisplaying2048(share_1_2048);
SortingAndDisplaying2048(share_2_2048);
SortingAndDisplaying2048(share_3_2048);

//Step 5
static void SortingAndDisplaying2048(Arrays array)
{
    Algorithms algorithms = new Algorithms();
    Input readFiles = new Input();

    array.SetArray(readFiles.ReadFiles());
    Console.WriteLine("Displaying Usorted Array");
    array.DisplayArray();
    algorithms.SortInAscendingOrder(array.GetArrayValue());
    Console.WriteLine("Displaying Sorted Array in Ascending Order");
    array.DisplayArray();
    array.SetArray(algorithms.SortInDescendingOrder(array.GetArrayValue()));
    Console.WriteLine("Displaying Sorted Array is Descending Order");
    array.DisplayArray();
    array.DisplayEvery50();
    algorithms.SearchBinary(array.GetArrayValue());
}

// Steps 1 to 4
static void SortingAndDisplaying256(Arrays array)
{
    Algorithms algorithms = new Algorithms();
    Input readFiles = new Input();

    array.SetArray(readFiles.ReadFiles());
    Console.WriteLine("Displaying Usorted Array");
    array.DisplayArray();
    algorithms.SortInAscendingOrder(array.GetArrayValue());
    Console.WriteLine("Displaying Sorted Array in Ascending Order");
    array.DisplayArray();
    array.SetArray(algorithms.SortInDescendingOrder(array.GetArrayValue()));
    Console.WriteLine("Displaying Sorted Array is Descending Order");
    array.DisplayArray();
    array.DisplayEvery10();
    algorithms.SearchLinear(array.GetArrayValue());
}

//Step 6
Algorithms algorithms = new Algorithms();
Arrays mergedArrays_256 = new Arrays();
Arrays mergedArrays_2048 = new Arrays();
Console.WriteLine("Merging Arrays: share_1_256 & share_3_256");
mergedArrays_256.SetArray(algorithms.MergeArrays(share_1_256, share_3_256));
mergedArrays_256.DisplayArray();
// Step 6.5
SortingAndDisplaying256(mergedArrays_256);

Console.WriteLine("Merging Arrays: share_1_2048 & share_3_2048");
mergedArrays_2048.SetArray(algorithms.MergeArrays(share_1_2048, share_3_2048));
mergedArrays_2048.DisplayArray();
//Step7
SortingAndDisplaying2048(mergedArrays_2048);