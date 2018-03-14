using Lab5_v2.Data.Entities;
using Lab5_v2.Models;
using Lab5_v2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5_v2.Services 
{
    public class ShoesService : IShoesService
    {
        private readonly IShoesRepository _repository;
        public ShoesService(IShoesRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<ShoesViewModel> GetAllShoesModels()
        {
            var shoesModels = new List<ShoesViewModel>();
            foreach(var pair in _repository.GetAllShoes())
            {
                shoesModels.Add(ToShoesModel(pair));
            }
            return shoesModels;
        }
        public ShoesViewModel GetShoesModel(int id)
        {
            return ToShoesModel(_repository.GetShoes(id));
        }
        public void SaveShoes(ShoesViewModel shoes)
        {
            _repository.SaveShoes(ToShoes(shoes));
        }
        public void UpdateShoes(ShoesViewModel shoes)
        {
            _repository.UpdateShoes(ToShoes(shoes));
        }
        public void DeleteShoes(int id)
        {
            _repository.DeleteShoes(id);
        }
        public IEnumerable<ShoesViewModel> GetAllUserShoes(int userId)
        {
            var userShoes = new List<ShoesViewModel>();
            foreach(var pair in _repository.GetAllShoes())
            {
                if (userId == pair.OwnerId)
                {
                    userShoes.Add(ToShoesModel(pair));
                }
            }
            return userShoes;
        }
        private Shoes ToShoes(ShoesViewModel shoes)
        {
            return new Shoes
            {
                Id = shoes.Id,
                Type = shoes.Type,
                Name = shoes.Name,
                Size = shoes.Size,
                Value = shoes.Value,
                OwnerId = shoes.OwnerId
            };
        }

        private ShoesViewModel ToShoesModel(Shoes shoes)
        {
            return new ShoesViewModel
            {
                Id = shoes.Id,
                Type = shoes.Type,
                Name = shoes.Name,
                Size = shoes.Size,
                Value = shoes.Value,
                OwnerId = shoes.OwnerId
            };
        }
    }
}