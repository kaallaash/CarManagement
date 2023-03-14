namespace CarManagement.Models.Car;

public class CarCreateModel
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
}