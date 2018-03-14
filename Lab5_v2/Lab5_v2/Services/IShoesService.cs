using Lab5_v2.Data.Entities;
using Lab5_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5_v2.Services
{
    public interface IShoesService
    {
        IEnumerable<ShoesViewModel> GetAllShoesModels();
        IEnumerable<ShoesViewModel> GetAllUserShoes(int userId);
        ShoesViewModel GetShoesModel(int id);
        void SaveShoes(ShoesViewModel shoes);
        void UpdateShoes(ShoesViewModel shoes);
        void DeleteShoes(int id);
    }
}