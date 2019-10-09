using DylanDelport.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DylanDelport.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                // Dummy Data 1
                new Restaurant {
                                Id = 1,
                                Name = "Scott's Pizza",
                                Location = "Maryland",
                                Cuisine = CuisineType.Italian
                },

                // Dummy Data 2
                new Restaurant {
                                Id = 2,
                                Name = "Cinnamon CLub",
                                Location = "London",
                                Cuisine = CuisineType.Mexican
                },

                // Dummy Data 3
                new Restaurant {
                                Id = 3,
                                Name = "La Costa",
                                Location = "California",
                                Cuisine = CuisineType.None
                }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(x => x.Name);
        }
    }
}
