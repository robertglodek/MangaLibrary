﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibrary.DataAccess.Entities
{
    public class Role:EntityBase
    {
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
