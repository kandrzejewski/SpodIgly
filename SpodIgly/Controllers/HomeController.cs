using SpodIgly.DAL;
using SpodIgly.Models;
using SpodIgly.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpodIgly.Controllers
{
    public class HomeController : Controller
    {
        private readonly StoreContext _db = new StoreContext();
        
        // GET: Home
        public ActionResult Index()
        {
            var genres = _db.Genres
                .ToList();
            var newArrivals = _db.Albums
                .Where(a => !a.IsHidden)
                .OrderByDescending(a => a.DateAdded)
                .Take(3)
                .ToList();
            var bestsellers = _db.Albums
                .Where(a => !a.IsHidden && a.IsBestseller)
                .OrderBy(g => Guid.NewGuid())
                .Take(3)
                .ToList();

            var model = new HomeViewModel()
            {
                Bestsellers = bestsellers,
                Genres = genres,
                NewArrivals = newArrivals
            };

            return View(model);
        }

        public ActionResult StaticContent(string viewname)
        {
            return View(viewname);
        }
    }
}