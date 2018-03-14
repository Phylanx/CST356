using Lab5_v2.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab5_v2.Data
{
    public interface IAppContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Shoes> Shoes { get; set; }
    }
}