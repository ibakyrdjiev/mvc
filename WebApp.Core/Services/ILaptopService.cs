using System.Collections.Generic;
using WebApp.Core.Dto;

namespace WebApp.Core.Services
{
    public interface ILaptopService
    {
        List<LaptopDto> GetAllLaptops();

        LaptopDto GetLaptopById(int id);

        void CreateLaptop(LaptopDto laptopModel);

        void EditLaptop(LaptopDto laptopModel);

        void DeleteLaptop(int id);
    }
}