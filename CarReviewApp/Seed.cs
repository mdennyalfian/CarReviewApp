using CarReviewApp.Data;
using CarReviewApp.Models;

namespace CarReviewApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.CarOwners.Any())
            {
                var CarOwners = new List<CarOwner>()
                {
                    new CarOwner()
                    {
                        Car = new Car()
                        {
                            Name = "Honda Civic",
                            ManufactureDate = new DateTime(2021,1,1),
                            CarCategories = new List<CarCategory>()
                            {
                                new CarCategory { Category = new Category() { Name = "Small family"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Honda Civic",Text = "Honda Civic is the best Car", Rating = 4,
                                Reviewer = new Reviewer(){ Name = "Teddy Smith" } },
                                new Review { Title="Honda Civic", Text = "Honda Civic is the best for family", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Taylor Jones" } },
                                new Review { Title="Honda Civic",Text = "Have bad experience with this car", Rating = 1,
                                Reviewer = new Reviewer(){ Name = "Jessica McGregor" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Jack London",
                            Profession = "Doctor",
                            Country = new Country()
                            {
                                Name = "Kanto"
                            }
                        }
                    },
                    new CarOwner()
                    {
                        Car = new Car()
                        {
                            Name = "Toyota Sienna",
                            ManufactureDate = new DateTime(2020,1,1),
                            CarCategories = new List<CarCategory>()
                            {
                                new CarCategory { Category = new Category() { Name = "Large MPV"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Toyota Sienna", Text = "Toyota Sienna my first car", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Teddy Smith" } },
                                new Review { Title= "Toyota Sienna",Text = "Get this car for birthday present", Rating = 3,
                                Reviewer = new Reviewer(){ Name = "Big Jones" } },
                                new Review { Title= "Toyota Sienna", Text = "Model too old", Rating = 1,
                                Reviewer = new Reviewer(){ Name = "Bica Sona" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Harry Potter",
                            Profession = "Businessman",
                            Country = new Country()
                            {
                                Name = "Saffron City"
                            }
                        }
                    },
                                    new CarOwner()
                    {
                        Car = new Car()
                        {
                            Name = "Porsche 911",
                            ManufactureDate = new DateTime(2004,1,1),
                            CarCategories = new List<CarCategory>()
                            {
                                new CarCategory { Category = new Category() { Name = "Sports car"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Porsche 911",Text = "Speed is number one", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Teddy Smith" } },
                                new Review { Title="Porsche 911",Text = "Get from my birthday present", Rating = 4,
                                Reviewer = new Reviewer(){ Name = "Sain Bino" } },
                                new Review { Title="Porsche 911",Text = "Too Expensive", Rating = 1,
                                Reviewer = new Reviewer(){ Name = "Lolora Siene" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Ash Ketchum",
                            Profession = "Farmer",
                            Country = new Country()
                            {
                                Name = "Millet Town"
                            }
                        }
                    }
                };
                dataContext.CarOwners.AddRange(CarOwners);
                dataContext.SaveChanges();
            }
        }
    }
}
