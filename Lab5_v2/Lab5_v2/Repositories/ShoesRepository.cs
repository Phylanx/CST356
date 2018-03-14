using Lab5_v2.Data;
using Lab5_v2.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5_v2.Repositories
{
    public class ShoesRepository : IShoesRepository
    {
        private readonly AppDbContext _db;

        public ShoesRepository(AppDbContext context)
        {
            _db = context;
        }
        public Shoes GetShoes(int id)
        {
            return _db.Shoes.Find(id);
        }
        public IEnumerable<Shoes> GetAllShoes()
        {
            return _db.Shoes;
        }
        public void SaveShoes(Shoes shoes)
        {
            _db.Shoes.Add(shoes);
            _db.SaveChanges();
        }
        public void UpdateShoes(Shoes shoes)
        {
            var ShoesToUpdate = _db.Shoes.Find(shoes.Id);
            ShoesToUpdate.Type = shoes.Type;
            ShoesToUpdate.Name = shoes.Name;
            ShoesToUpdate.Size = shoes.Size;
            ShoesToUpdate.Value = shoes.Value;
            ShoesToUpdate.OwnerId = shoes.OwnerId;
            _db.SaveChanges();
        }
        public void DeleteShoes(int id)
        {
            _db.Shoes.Remove( _db.Shoes.Find(id) );
            _db.SaveChanges();
        }
    }
}