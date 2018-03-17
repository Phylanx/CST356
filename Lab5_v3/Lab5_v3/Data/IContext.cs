using Lab5_v3.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_v3.Data
{
    public interface IContext
    {
        DbSet<User> Users { get; set; }
        DbSet<PC> PCs { get; set; }
    }
}
