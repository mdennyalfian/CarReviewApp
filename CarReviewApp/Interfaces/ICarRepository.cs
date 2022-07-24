using CarReviewApp.Models;

namespace CarReviewApp.Interfaces
{
    public interface ICarRepository
    {
        ICollection<Car> GetCars();
        Car GetCar(int id);
        Car GetCar(string name);
        decimal GetCarRating(int carId);
        bool CarExists(int carId);
        bool CreateCar(int ownerId, int categoryId, Car car);
        bool UpdateCar(int ownerId, int categoryId, Car car);
        bool DeleteCar(Car car);
        bool Save();
    }
}
