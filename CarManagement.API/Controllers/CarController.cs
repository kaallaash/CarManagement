using CarManagement.BLL.Interfaces;
using CarManagement.Models.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CarController : Controller
{
    private readonly ICarService _carService;

    public CarController(
        ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<IEnumerable<CarModel>> GetAll(
    )
    {
        return await _carService.GetAllAsync();
    }
    
    [HttpGet("parameters")]
    public async Task<IEnumerable<CarModel>> GetSome([FromQuery] int selectionEdge1, [FromQuery] int selectionEdge2)
    {
        return await _carService.GetSomeAsync(selectionEdge1, selectionEdge2);
    }

    [HttpGet("{id}")]
    public async Task<CarModel> GetById(int id)
    {
        return await _carService.GetByIdAsync(id);
    }
    
    [HttpPost]
    public async Task<int> Create(
        [FromBody] CarCreateModel carCreateModel)
    {
        return await _carService.CreateAsync(carCreateModel);
    }

    [HttpPut("{id}")]
    public async Task<bool> Update(int id,
        [FromBody] CarUpdateModel carUpdateModel)
    {
        return await _carService.UpdateAsync(id, carUpdateModel);
    }

    [HttpDelete("{id}")]
    public async Task<bool> Delete(int id)
    {
        return await _carService.DeleteAsync(id);
    }
}