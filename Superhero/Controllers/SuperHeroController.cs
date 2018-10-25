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

        //======================================================================
        public ActionResult Index()
        {
            List<Super_Heroes> showMeTheJunk = db.Heroes.ToList();
            return View(showMeTheJunk);
        }
        //======================================================================

        [HttpGet]
        public ActionResult Details(int id)
        {
            Super_Heroes showDetails = db.Heroes.Where(x => x.ID == id).SingleOrDefault();
            return View(showDetails);
        }

        [HttpPost]
        public ActionResult Details()
        {
            return View();
        }
        //====================================================================

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "HeroName,AlterEgo,PrimaryAbilty,SecondaryAbility,CatchPhrase")]Super_Heroes superHero)
        {
            try
            {               
                db.Heroes.Add(superHero);              
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //======================================================================

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var editHero = db.Heroes.Where(x => x.ID == id).FirstOrDefault();
            return View(editHero);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "HeroName,AlterEgo,PrimaryAbilty,SecondaryAbility,CatchPhrase")]Super_Heroes superHero, int id)
        {
            try
            {
                var updateHero = db.Heroes.Where(x => x.ID == id).FirstOrDefault();
                updateHero.HeroName = superHero.HeroName;
                updateHero.AlterEgo = superHero.AlterEgo;
                updateHero.PrimaryAbilty = superHero.PrimaryAbilty;
                updateHero.SecondaryAbility = superHero.SecondaryAbility;
                updateHero.CatchPhrase = superHero.CatchPhrase;

                //db.Heros.Where(x => x.ID == id select x).ToList().ForEach(y => y.is_default = false);
                //db.SubmitChanges();
                //db.Heroes.Remove(updateHero);
                //db.Heroes.Add(superHero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //======================================================================

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var showHero = db.Heroes.Where(x => x.ID == id).FirstOrDefault();
            return View(showHero);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([Bind(Include = "HeroName,AlterEgo,PrimaryAbilty,SecondaryAbility,CatchPhrase")]Super_Heroes superHero, int id)
        {
            try
            {
                var removeHero = db.Heroes.Where(x => x.ID == id).FirstOrDefault();
                db.Heroes.Remove(removeHero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //===================================================================
    }
}