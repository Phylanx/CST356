using Lab5_v2.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5_v2.Repositories
{
    public interface IShoesRepository
    {
        Shoes GetShoes(int id);
        IEnumerable<Shoes> GetAllShoes();
        void SaveShoes(Shoes shoes);
        void UpdateShoes(Shoes shoes);
        void DeleteShoes(int id);
    }
}