using CarManagement.Models.Car;

namespace CarManagement.DAL.Interfaces;

public interface ICarRepository
{
    Task<IEnumerable<CarModel>> GetAllAsync();
    Task<IEnumerable<CarModel>> GetSomeAsync(int skip, int take);
    Task<CarModel> GetByIdAsync(int id);
    Task<int> CreateAsync(CarCreateModel car);
    Task<bool> UpdateAsync(int id, CarUpdateModel car);
    Task<bool> DeleteAsync(int id);
}