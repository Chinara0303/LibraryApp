using LibraryApp.Controllers;
using ServiceLayer.Helpers;

LibraryController libraryController = new();
while (true)
{
    GetConsole();
    Option: string optionStr = Console.ReadLine();
    int selectedOption;
    bool isOptionNum = int.TryParse(optionStr, out selectedOption);
    if (isOptionNum)
    {
        switch (selectedOption)
        {
            case 1:
                libraryController.Create();
                break;
            case 2:
                Console.WriteLine("get all");
                break;
            case 3:
                libraryController.Delete();
                break;
            default:
                ConsoleColor.Red.WriteConsole("Please, enter correct option");
                break;
        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Please, enter correct format option");
        goto Option;
    }
}

static void GetConsole()
{
   ConsoleColor.Cyan.WriteConsole("Please, choose one option");
   ConsoleColor.Cyan.WriteConsole("Library option: 1-Create, 2-Get All, 3-Delete");
}