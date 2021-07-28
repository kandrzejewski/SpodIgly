using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpodIgly.DAL;

namespace SpodIgly.Controllers
{
    public class StoreController : Controller
    {
        private StoreContext _db = new StoreContext();

        // GET: Store
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult List(string genrename)
        {
            var genre = _db.Genres
                .Include("Albums")
                .FirstOrDefault(g => g.Name.ToUpper() == genrename.ToUpper());
            var albums = genre?.Albums.ToList();

            return View(albums);
        }

        [ChildActionOnly]
        public ActionResult GenresMenu()
        {
            var genres = _db.Genres.ToList();

            return PartialView("_GenresMenu", genres);
        }
    }
}