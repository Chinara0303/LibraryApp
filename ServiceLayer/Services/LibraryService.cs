using DomainLayer.Models;
using RepositoryLayer.Data;
using RepositoryLayer.Repositories;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly LibraryRepository _libraryRepository;
        private int _count = 1;
        public LibraryService() => _libraryRepository = new LibraryRepository();
        public Library Create(Library library)
        {
            library.Id = _count;
            _libraryRepository.Create(library);
            _count++;
            return library;
        }
        public Library Delete(int id)
        {
            Library? res = AppDbContext<Library>._datas.Find(x => x.Id == id);
            _libraryRepository.Delete(res);
            return res;
        }

        public List<Library> GetAll()
        {
            throw new NotImplementedException();
        }

        public Library GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Library> Search(string searchText)
        {
            throw new NotImplementedException();
        }
    }
}
