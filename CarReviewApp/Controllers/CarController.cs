using AutoMapper;
using CarReviewApp.Dto;
using CarReviewApp.Interfaces;
using CarReviewApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public CarController(ICarRepository carRepository, 
            IReviewRepository reviewRepository,
            IMapper mapper)
        {
            _carRepository = carRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type =  typeof(IEnumerable<Car>))]
        public IActionResult GetCars()
        {
            var cars = _mapper.Map<List<CarDto>>(_carRepository.GetCars());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cars);
        }

        [HttpGet("{carId}")]
        [ProducesResponseType(200, Type=typeof(Car))]
        [ProducesResponseType(400)]

        public IActionResult GetCar(int carId)
        {
            if (!_carRepository.CarExists(carId))
                return NotFound();

            var cars = _mapper.Map<CarDto>(_carRepository.GetCar(carId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cars);
        }

        [HttpGet("{carId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]

        public IActionResult GetCarRating(int carId)
        {
            if (!_carRepository.CarExists(carId))
                return NotFound();

            var rating = _carRepository.GetCarRating(carId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(rating);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCar([FromQuery] int ownerId, [FromQuery] int categoryId, [FromBody] CarDto carCreate)
        {
            if (carCreate == null)
                return BadRequest(ModelState);

            var cars = _carRepository.GetCars()
                .Where(c => c.Name.Trim().ToUpper() == carCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (cars != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var carMap = _mapper.Map<Car>(carCreate);

            if (!_carRepository.CreateCar(ownerId, categoryId, carMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{carId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCar(int carId, 
            [FromQuery] int ownerId, 
            [FromQuery] int categoryId, [FromBody] CarDto updatedCar)
        {
            if (updatedCar == null)
                return BadRequest(ModelState);

            if (carId != updatedCar.Id)
                return BadRequest(ModelState);

            if (!_carRepository.CarExists(carId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var carMap = _mapper.Map<Car>(updatedCar);

            if (!_carRepository.UpdateCar(ownerId, categoryId, carMap))
            {
                ModelState.AddModelError("", "Something went wrong updating Car");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }

        [HttpDelete("{carId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCar(int carId)
        {
            if (!_carRepository.CarExists(carId))
                return NotFound();

            var reviewsToDelete = _reviewRepository.GetReviewsOfACar(carId);
            var carToDelete = _carRepository.GetCar(carId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(_reviewRepository.DeleteReviews(reviewsToDelete.ToList()))
            {
                ModelState.AddModelError("", "Something went wrong deleting car");
            }

            if (!_carRepository.DeleteCar(carToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting car");
            }

            return Ok("Successfully deleted");
        }

    }
}
