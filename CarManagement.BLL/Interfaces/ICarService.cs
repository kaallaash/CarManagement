using CarManagement.Models.Car;

namespace CarManagement.BLL.Interfaces;

public interface ICarService
{
    Task<IEnumerable<CarModel>> GetAllAsync();
    Task<IEnumerable<CarModel>> GetSomeAsync(int selectionEdge1, int selectionEdge2);
    Task<CarModel> GetByIdAsync(int id);
    Task<int> CreateAsync(CarCreateModel car);
    Task<bool> UpdateAsync(int id, CarUpdateModel car);
    Task<bool> DeleteAsync(int id);
}
