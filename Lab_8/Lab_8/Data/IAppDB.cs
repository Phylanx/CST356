using Lab_8.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8.Data
{
    public interface IAppDB
    {
        DbSet<User> Users { get; set; }
        DbSet<Job> Jobs { get; set; }
    }
}
