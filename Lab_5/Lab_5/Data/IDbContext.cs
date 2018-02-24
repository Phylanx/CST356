using Lab_5.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab_5.Data
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<PC> PCs { get; set; }

        void SaveContextChanges();
    }
}