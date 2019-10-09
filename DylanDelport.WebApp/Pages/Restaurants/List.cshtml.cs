using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DylanDelport.Core;
using DylanDelport.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace DylanDelport.WebApp.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        #region Properties
        public string Message { get; set; }

        public IEnumerable<Restaurant> Restaurants{ get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        #endregion

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {
            //Old school version
            var querystring = HttpContext.Request.QueryString;

            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}