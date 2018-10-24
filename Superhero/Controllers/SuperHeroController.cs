using Superhero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Superhero.Controllers
{
    public class SuperHeroController : Controller
    {
        public ApplicationDbContext db;

        public SuperHeroController()
        {
            db = new ApplicationDbContext();
        }
        // GET: SuperHero
        public ActionResult Index()
        {
            List<Super_Heroes> superHeroes = new List<Super_Heroes>();
            //List<Super_Heroes> showMeTheJunk = db.Heroes.Select(x => x).ToList();
            List<Super_Heroes> showMeTheJunk = db.Heroes.ToList();

            return View(showMeTheJunk);
        }

        // GET: SuperHero/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            Super_Heroes superHero = new Super_Heroes();
            Super_Heroes showDetails = db.Heroes.Where(x => x.ID == id).Single();
            return View(showDetails);
        }

        [HttpPost]
        public ActionResult Details()
        {
            return View();
        }

        // GET: SuperHero/Create
        [HttpGet]
        public ActionResult Create()
        {
            //Super_Heroes superHero = new Super_Heroes();
            //db.Heroes.Add(superHero);

            return View();
        }

        // POST: SuperHero/Create
        [HttpPost]
        public ActionResult Create(Super_Heroes superHero)
        {
            try
            {

                //Super_Heroes superHero = new Super_Heroes();
                db.Heroes.Add(superHero);
              
                db.SaveChanges();
                //return View("Index");
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        public ActionResult Edit(Super_Heroes superHero, int id)
        {
            try
            {
                Super_Heroes updateHero = db.Heroes.Where(x => x.ID == id).FirstOrDefault();
                db.Heroes.Add(updateHero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        public ActionResult Delete(Super_Heroes superHero, int id)
        {
            try
            {
                Super_Heroes removeHero = db.Heroes.Where(x => x.ID == id).FirstOrDefault();
                db.Heroes.Remove(removeHero);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }









    }
}