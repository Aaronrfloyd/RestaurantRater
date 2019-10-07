using RestaurantRaiderMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRaiderMVC.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _db = new RestaurantDbContext();
        // GET: Restaurant
        public ActionResult Index()
        {
            return View(_db.Restaurants.ToList());
        }
        //GET: Restuarant / Create
        public ActionResult Create()
        {
            return View();
        }
        //POST: Restuarant / Create
        [HttpPost]
        public ActionResult Create(Restaurant restuarant)
        {
            if (ModelState.IsValid)
            {
                _db.Restaurants.Add(restuarant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restuarant);
        }
        //GET: Restaurant / Delete / {ID}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaraunt = _db.Restaurants.Find(id);
            if (restaraunt == null)
            {
                return HttpNotFound();
            }
            return View(restaraunt);
        }
        //POST: Restuarant / Delete / {id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Restaurant restaurant = _db.Restaurants.Find(id);
            _db.Restaurants.Remove(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Restaurant/ Edit / {ID}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaraunt = _db.Restaurants.Find(id);
            if (restaraunt == null)
            {
                return HttpNotFound();
            }
            return View(restaraunt);
        }
        //POST: Resturant / edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(restaurant).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(restaurant);
        }


        public ActionResult Details(int? id)
        {
            Restaurant restaurant = _db.Restaurants.Find(id);   
            return View(restaurant);
        }

    }

}