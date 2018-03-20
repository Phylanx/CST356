using Final.Web.Models.Entities;
using System;
using System.Collections.Generic;

namespace Final.Web.Services
{
    public interface IShoeService
    {
        ShoeModel GetShoe(int id);
        IEnumerable<ShoeModel> GetUserShoes(String userId);
        void CreateShoe(ShoeModel shoe);
        void UpdateShoe(ShoeModel shoe);
        void DeleteShoe(int id);
    }
}