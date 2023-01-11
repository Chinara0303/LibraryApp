using DomainLayer.Models;
using ServiceLayer.Helpers;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Controllers
{
    internal class LibraryController
    {
        private readonly ILibraryService _libraryService;
        public LibraryController() => _libraryService = new LibraryService();

        public void Create()
        {
            ConsoleColor.Cyan.WriteConsole("Please, enter library name:");
            string libraryName = Console.ReadLine();

            ConsoleColor.Cyan.WriteConsole("Please, enter library seat count:");
            SeatCount: string seatCountStr = Console.ReadLine();
            int seatCount;
            bool IsCorrectSeatCount = int.TryParse(seatCountStr, out seatCount);
            if (IsCorrectSeatCount)
            {
                try
                {
                    Library library = new Library()
                    {
                        Name = libraryName,
                        SeatCount = seatCount
                    };
                    var result = _libraryService.Create(library);
                    ConsoleColor.Green.WriteConsole($"Library id:{result.Id}\nLibrary name:{result.Name}\nLibrary seat count:{result.SeatCount}");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please,enter correct format seat count");
                goto SeatCount;
            }

        }

        public void Delete()
        {
            ConsoleColor.Cyan.WriteConsole("Please,enter library id");
            Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectId = int.TryParse(idStr, out id);
            if (isCorrectId)
            {
                try
                {
                    if (id < 0)
                    {
                        ConsoleColor.Red.WriteConsole("Please,enter correct id");
                        goto Id;
                    }
                    var result = _libraryService.Delete(id);
                    ConsoleColor.Green.WriteConsole($"Library deleted");

                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please,enter correct format id");
                goto Id;
            }
        }
        
    }
}
