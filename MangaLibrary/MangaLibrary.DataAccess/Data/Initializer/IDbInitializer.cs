using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.Data.Initializer
{
    public interface IDbInitializer
    {
        Task InitializeAsync();
    }
}
