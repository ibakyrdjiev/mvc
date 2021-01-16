using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Core;
using WebApp.Core.Dto;
using WebApp.Core.Entities;
using WebApp.Core.Services;

namespace WebApp.Services
{
    public class LaptopService : ILaptopService
    {
        private IRepository<Laptop> laptopRepository;

        public LaptopService(IRepository<Laptop> laptopRepository)
        {
            this.laptopRepository = laptopRepository;
        }

        public void CreateLaptop(LaptopDto laptopModel)
        {
            var entity = this.laptopRepository.Add(new Laptop()
            {
                Description = laptopModel.Description,
                IsDeleted = false,
                Make = laptopModel.Make,
                Model = laptopModel.Model,
                Price = laptopModel.Price
            });

            this.laptopRepository.Save();
        }

        public void DeleteLaptop(int id)
        {
            this.laptopRepository.Delete(id);
            this.laptopRepository.Save();
        }

        public void EditLaptop(LaptopDto laptopModel)
        {
            var current = this.laptopRepository.GetById(laptopModel.Id);
            if (current == null)
            {
                throw new ApplicationException("Laptop does not exist");
            }

            current.Description = laptopModel.Description;
            current.Price = laptopModel.Price;
            current.Make = laptopModel.Make;
            current.Model = laptopModel.Model;

            this.laptopRepository.Update(current);
            this.laptopRepository.Save();
        }

        public List<LaptopDto> GetAllLaptops()
        {
            var result = this.laptopRepository.GetAllAsQueryable()
                .Where(l => l.IsDeleted == false)
                .Select(l => new LaptopDto()
                {
                    Description = l.Description,
                    Make = l.Make,
                    Model = l.Model,
                    Price = l.Price,
                    Id = l.Id
                }).ToList();

            return result;
        }

        public LaptopDto GetLaptopById(int id)
        {
            var entity = this.laptopRepository.GetById(id);
            var dto = new LaptopDto()
            {
                Description = entity.Description,
                Make = entity.Make,
                Model = entity.Model,
                Price = entity.Price,
                Id = entity.Id
            };

            return dto;
        }
    }
}