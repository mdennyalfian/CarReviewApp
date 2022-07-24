using CarReviewApp.Data;
using CarReviewApp.Interfaces;
using CarReviewApp.Models;

namespace CarReviewApp.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;
        public CarRepository(DataContext context)
        {
            _context = context;
        }        

        public Car GetCar(int id)
        {
            return _context.Cars.Where(p => p.Id == id).FirstOrDefault();
        }

        public Car GetCar(string name)
        {
            return _context.Cars.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetCarRating(int carId)
        {
            var review = _context.Reviews.Where(p => p.Car.Id == carId);
        
            if(review.Count() <= 0)
                return 0;

            return ((decimal)review.Sum(r=> r.Rating) / review.Count());
        }        

        public ICollection<Car> GetCars()
        {
            return _context.Cars.OrderBy(p => p.Id).ToList();
        }

        public bool CarExists(int carId)
        {
            return _context.Cars.Any(p => p.Id == carId);
        }

        public bool CreateCar(int ownerId, int categoryId, Car car)
        {
            var carOwnerEntity = _context.Owners.Where(a => a.Id == ownerId).FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var carOwner = new CarOwner()
            {
                Owner = carOwnerEntity,
                Car = car,
            };

            _context.Add(carOwner);

            var carCategory = new CarCategory()
            {
                Category = category,
                Car = car,
            };

            _context.Add(carCategory);

            _context.Add(car);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCar(int ownerId, int categoryId, Car car)
        {
            _context.Update(car);
            return Save();
        }

        public bool DeleteCar(Car car)
        {
            _context.Remove(car);
            return Save();
        }
    }
}
