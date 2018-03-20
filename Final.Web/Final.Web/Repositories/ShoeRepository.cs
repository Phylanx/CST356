using Final.UserEntities;
using Final.Web.Models;
using System;
using System.Collections.Generic;

namespace Final.Web.Repositories
{
    public class ShoeRepository : IShoeRepository
    {
        private readonly ApplicationDbContext _db;
        public ShoeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Shoe GetShoe(int id)
        {
            return _db.Shoes.Find(id);
        }
        public IEnumerable<Shoe> GetUserShoes(String userId)
        {
            var shoePile = new List<Shoe>();
            foreach(var shoe in _db.Shoes)
            {
                if (shoe.OwnerId == userId) shoePile.Add(shoe);
            }
            return shoePile;
        }
        public void CreateShoe(Shoe shoe)
        {
            _db.Shoes.Add(shoe);
            _db.SaveChanges();
        }
        public void UpdateShoe(Shoe shoe)
        {
            _db.SaveChanges();
        }
        public void DeleteShoe(int id)
        {
            var shoe = _db.Shoes.Find(id);
            if (shoe == null) return;
            _db.Shoes.Remove(shoe);
            _db.SaveChanges();
        }
    }
}