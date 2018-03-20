using Final.UserEntities;
using Final.Web.Models.Entities;
using Final.Web.Repositories;
using System;
using System.Collections.Generic;

namespace Final.Web.Services
{
    public class ShoeService : IShoeService
    {
        private readonly IShoeRepository _repository;
        public ShoeService(IShoeRepository rep)
        {
            _repository = rep;
        }

        public ShoeModel GetShoe(int id)
        {
            return ToModel(_repository.GetShoe(id));
        }
        public IEnumerable<ShoeModel> GetUserShoes(String userId)
        {
            var shoes = new List<ShoeModel>();
            foreach(var shoe in _repository.GetUserShoes(userId))
            {
                shoes.Add(ToModel(shoe));
            }
            return shoes;
        }
        public void CreateShoe(ShoeModel shoe)
        {
            _repository.CreateShoe(ToShoe(shoe));
        }
        public void UpdateShoe(ShoeModel shoe)
        {
            var shoeRecord = _repository.GetShoe(shoe.Id);
            shoeRecord.Color = shoe.Color;
            shoeRecord.Brand = shoe.Brand;
            shoeRecord.Style = shoe.Style;
            shoeRecord.OwnerId = shoe.OwnerId;
            shoeRecord.IsPair = shoe.IsPair;

            _repository.UpdateShoe(shoeRecord);
        }
        public void DeleteShoe(int id)
        {
            _repository.DeleteShoe(id);
        }


        private ShoeModel ToModel(Shoe shoe)
        {
            return new ShoeModel
            {
                Id = shoe.Id,
                Color = shoe.Color,
                Brand = shoe.Brand,
                Style = shoe.Style,
                OwnerId = shoe.OwnerId,
                IsPair = shoe.IsPair
            };
        }
        private Shoe ToShoe(ShoeModel shoe)
        {
            return new Shoe
            {
                Id = shoe.Id,
                Color = shoe.Color,
                Brand = shoe.Brand,
                Style = shoe.Style,
                OwnerId = shoe.OwnerId,
                IsPair = shoe.IsPair
            };
        }

    }
}