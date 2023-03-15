using CarManagement.BLL.Interfaces;
using CarManagement.DAL.Interfaces;
using CarManagement.Models.Car;

namespace CarManagement.BLL.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(
        ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<IEnumerable<CarModel>> GetAllAsync()
    {
        return await _carRepository.GetAllAsync();
    }

    public async Task<IEnumerable<CarModel>> GetSomeAsync(int selectionEdge1, int selectionEdge2)
    {
        int skip, take;

        if (selectionEdge1 > selectionEdge2)
        {
            skip = selectionEdge2 - 1;
            take = selectionEdge1 - selectionEdge2 + 1;
        }
        else
        {
            skip = selectionEdge1 - 1;
            take = selectionEdge2 - selectionEdge1 + 1;
        }

        return await _carRepository.GetSomeAsync(skip, take);
    }

    public async Task<CarModel> GetByIdAsync(int id)
    {
        return await _carRepository.GetByIdAsync(id);
    }

    public async Task<int> CreateAsync(CarCreateModel car)
    {
        return await _carRepository.CreateAsync(car);
    }

    public async Task<bool> UpdateAsync(int id, CarUpdateModel car)
    {
        return await _carRepository.UpdateAsync(id, car);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _carRepository.DeleteAsync(id);
    }
}