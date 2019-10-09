using DylanDelport.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DylanDelport.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
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
                                Name = "Cinnamon Club",
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

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            var _name = string.IsNullOrEmpty(name) ? "" : name.ToLower();
            return restaurants.Where(y => y.Name.ToLower().StartsWith(_name)).OrderBy(x => x.Name);
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(x => x.Id == id);
        }
    }
}
