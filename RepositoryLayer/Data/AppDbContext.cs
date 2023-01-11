using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data
{
    public static class AppDbContext<T> 
    {
        public static List<T> _datas;

        static AppDbContext()
        {
            _datas = new List<T>();
        }
    }
}
