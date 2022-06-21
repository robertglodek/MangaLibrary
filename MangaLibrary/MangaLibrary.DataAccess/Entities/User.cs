using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.Entities
{
    public class User:EntityBase
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
