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
            //instantiating the database db
        }

        //======================================================================
        public ActionResult Index()
        {
            //Index view uses the LIST template, so we need to convert the hero object into a list.
            var showMeTheJunk = db.Heroes.ToList();
            return View(showMeTheJunk);
        }
        //======================================================================

        [HttpGet]
        public ActionResult Details(int id)
        {
            var showDetails = db.Heroes.Where(x => x.ID == id).SingleOrDefault();
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
        //The Bind attribute is another important security mechanism that keeps hackers from over-posting data to your model. 
        //Over-posting is done through HTML manipulation in which a malicious user can set a value to a model property that a developer didn’t expect

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
            //populating properties of the Hero for review before making changes. 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //The basic purpose of ValidateAntiForgeryToken attribute is to prevent cross-site request forgery attacks.
        public ActionResult Edit([Bind(Include = "HeroName,AlterEgo,PrimaryAbilty,SecondaryAbility,CatchPhrase")]Super_Heroes superHero, int id)
        {
            try
            {
                var updateHero = db.Heroes.Where(x => x.ID == id).FirstOrDefault();

                //Assigning existing or updated values of Hero's properties to matching Hero in database. 
                updateHero.HeroName = superHero.HeroName;
                updateHero.AlterEgo = superHero.AlterEgo;
                updateHero.PrimaryAbilty = superHero.PrimaryAbilty;
                updateHero.SecondaryAbility = superHero.SecondaryAbility;
                updateHero.CatchPhrase = superHero.CatchPhrase;
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
            //Populating properties of the Hero to be deleted
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