using CarManagement.DAL.Model;
using CarManagement.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.DAL.Interfaces;

public interface ICarRepository
{
    Task<IEnumerable<CarModel>> GetAllAsync();
    Task<IEnumerable<CarModel>> GetSomeAsync(int skip, int take);
    Task<CarModel> GetByIdAsync(int id);
    Task<int> CreateAsync(CarCreateModel car);
    Task<bool> UpdateAsync(CarUpdateModel car);
    Task<bool> DeleteAsync(int id);
}