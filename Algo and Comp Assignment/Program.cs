
// See https://aka.ms/new-console-template for more information

//Created by Kleybson Sousa , using Visual studio 2022 .Net 6.0

//Displays message of welcome to the user
Console.WriteLine("Welcome to the Shares Searching and Sorting Application");

//Using a while loop to create a defensive code in case the user enters a invalid input
while (true)
{
    //Request a path and assigns it to the 'path' variable
    Console.WriteLine(@"Please indicate the path to the file: (eg 'C:\Users\kleybson\Download' ) ");
    string path = Console.ReadLine();

    //if the path is null,empty or a white space it is a invalid input , displays error message and begins the loop again
    if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
    {
        Console.WriteLine(@"You have not entered a Path. "
        + @"Please enter your Path (eg 'C:\Users\kleybson\Download' ) and confirm ");
        Console.WriteLine();
        continue;
    }
    //Request a confirmation of choice by the user as the path will not be altered  during the program
    Console.WriteLine("Please confirm the path for your file , your won't be able to change it later ," +
        " your path currently is: {0} , enter 'Yes' to confirm or anything else to change it", path);
    //if the user confirms the choice , it passes into the Input.Get method and breaks the loop
    if (Console.ReadLine().ToUpper() == "YES")
    {
        Input.GetPath(path);
        break;
    }
}
// The first 3 analyses are of the files with a length of 256 
//Creat a new Arrays Obj for each 256 length file
Console.WriteLine("Analyses of 256 length Files: \n");
Arrays share_1_256 = new Arrays();
Arrays share_2_256 = new Arrays();
Arrays share_3_256 = new Arrays();

//Uses the function to execute the analyses with all 3 files
// * steps 1 to 4*
SortingAndDisplaying256(share_1_256,true);
SortingAndDisplaying256(share_2_256,true);
SortingAndDisplaying256(share_3_256,true);

//From this moment the program handles the analyses of the files with 2048 length
Console.WriteLine("Analyses of 2048 length Files: \n");
// create a obj for each array 
Arrays share_1_2048 = new Arrays();
Arrays share_2_2048 = new Arrays();
Arrays share_3_2048 = new Arrays();

//Uses a different function to execute the analyses of the 2048 length arrays
SortingAndDisplaying2048(share_1_2048,true);
SortingAndDisplaying2048(share_2_2048,true);
SortingAndDisplaying2048(share_3_2048,true);

// Steps 1 to 4
//Using a function to execute the steps 
//Decided to use a function to executive these tasks as they are repetitive and so I try to implment DRY ( Don't Repeat Yourself) principle 
// The function takes the array and a bool , the bool will be use to make sure the program doesn't ask for an array when a Merged array is being used 
static void SortingAndDisplaying256(Arrays array, bool flag)
{
    // Creat an Algorithms Obj and input , in order to use their methods
    Algorithms algorithms = new Algorithms();
    Input readFiles = new Input();
    // if flag is true , meaning its not a Merged array , it sets the array values by calling the Input obj method 'ReadFiles' which reads the files,
    // and returns a double Array 
    if (flag) array.SetArray(readFiles.ReadFiles());
    //Displays to the User the Unsorted Array , in order to help on the analyses
    Console.WriteLine("Displaying Usorted Array");
    array.DisplayArray();
    // Sorts the Array in Asceding Order and Displays to the user
    algorithms.SortInAscendingOrder(array.GetArrayValue());
    Console.WriteLine("Displaying Sorted Array in Ascending Order");
    array.DisplayArray();
    //Sets the Array in Descending Order and Displays to the User
    array.SetArray(algorithms.SortInDescendingOrder(array.GetArrayValue()));
    Console.WriteLine("Displaying Sorted Array is Descending Order");
    array.DisplayArray();
    // Displays every 10th element in the array
    array.DisplayEvery10();
    //Does a Linear Search
    algorithms.SearchLinear(array.GetArrayValue());
}

//Step 5
//This function is very similar with the previous on , the only difference is at DisplayEvery50 instead of DisplayEvery10 and it does a Binary Search Instead of Linear
// Again decided to have a funtion to abide by the DRY principle
static void SortingAndDisplaying2048(Arrays array,bool flag)
{
    // Creat an Algorithms Obj and input , to use their methods
    Algorithms algorithms = new Algorithms();
    Input readFiles = new Input();
    //if not a merged array executes
    if (flag) array.SetArray(readFiles.ReadFiles());
    //Display the User the Unsorted Array
    Console.WriteLine("Displaying Usorted Array");
    array.DisplayArray();
    //Sortis in Ascending Order and Displays to the User
    algorithms.SortInAscendingOrder(array.GetArrayValue());
    Console.WriteLine("Displaying Sorted Array in Ascending Order");
    array.DisplayArray();
    //Sorts in Descending Order and Displays to the User
    array.SetArray(algorithms.SortInDescendingOrder(array.GetArrayValue()));
    Console.WriteLine("Displaying Sorted Array is Descending Order");
    array.DisplayArray();
    //Display evry 50th element in the Array
    array.DisplayEvery50();
    //Sorts the Array in Asceding Order and Does a Binary Search
    algorithms.SearchBinary(array.GetArrayValue());
}

//Step 6
//Creates a new algorithms obj and 2 new Arrays obj
Algorithms algorithms = new Algorithms();
Arrays mergedArrays_256 = new Arrays();
Arrays mergedArrays_2048 = new Arrays();

//Displays to User the message that now the merging will Occur 
Console.WriteLine("Merging Arrays: share_1_256 & share_3_256");
// Set the value of the new Merged array by using the Algorithms method 'MergeArrays' passing both arrays that are to be merged 
//The method 'MergeArrays' is a version of the Merge method of the 'MergeSort' Algorithm modified 
mergedArrays_256.SetArray(algorithms.MergeArrays(share_1_256, share_3_256));
// Displays the Unsorted Merged Array
Console.WriteLine("Displaying the Usorted Merged Array");
mergedArrays_256.DisplayArray();

// Step 6.5
// Performs steps 2 to 4 on the merged array , passing false as one of its parameters , meaning it doesnt need get a value
SortingAndDisplaying256(mergedArrays_256,false);

// Displays a messege to the user that now the 2048 length arrays will be analysed 
Console.WriteLine("Merging Arrays: share_1_2048 & share_3_2048");
// Gets the value of the Array by merging 2 arrays using the MergeArrays method
mergedArrays_2048.SetArray(algorithms.MergeArrays(share_1_2048, share_3_2048));
//Display the Unsorted Arrays to the user
Console.WriteLine("Displaying the Usorted Merged Array ");
mergedArrays_2048.DisplayArray();

//Step7
//Executes steps 2  to 4 ( or step 5) on the new array
SortingAndDisplaying2048(mergedArrays_2048,false);