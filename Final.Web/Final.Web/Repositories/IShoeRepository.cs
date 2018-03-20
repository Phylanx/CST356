using Final.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Web.Repositories
{
    public interface IShoeRepository
    {
        Shoe GetShoe(int id);
        IEnumerable<Shoe> GetUserShoes(String userId);
        void CreateShoe(Shoe shoe);
        void UpdateShoe(Shoe shoe);
        void DeleteShoe(int id);
    }
}