using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.ApplicationServices.API.Domain
{
    public class ErrorModel
    {
        public ErrorModel(string error,string? description=null)
        {
            this.Error = error;
            this.Description = description;
        }
        public string Error { get; init; }

        public string? Description { get; init; }

        public override string ToString()
        {
            return $"Error:{this.Error}, Description:{this.Description}";
        }
    }
}
