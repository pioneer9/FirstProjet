using FirstProjet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FirstProjet.Controllers
{
    public class UserController : Controller
    {
        DbothmanContext dbothmanContext = new DbothmanContext();

        // GET: UserController
        
        public ActionResult Index()
        {
            
            var user = dbothmanContext.Users.ToList();
            return View(user);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int Id)
        {
            return View(dbothmanContext.Users.Find(Id));
        }
        List<Equipe> ListEquipe()
        {
            var Equipe = dbothmanContext.Equipes.ToList();
            Equipe.Insert(0, new Equipe { Id = -1, NomEquipe = "--please select equipe--" });
            return Equipe;
        }
        // GET: UserController/Create
        public ActionResult Create()
        {
            ViewBag.ListEquipe = ListEquipe();
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                dbothmanContext.Users.Add(user);
                dbothmanContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
       

        // GET: UserController/Edit/5
        public ActionResult Edit(int Id)
        {

            return View(dbothmanContext.Users.Find(Id));
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                dbothmanContext.Entry(User).State= EntityState.Modified;
                dbothmanContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(dbothmanContext.Users.Find(id));
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, IFormCollection collection)
        {
            try
            {
                var user = dbothmanContext.Users.Find(Id);
                dbothmanContext.Remove(user);
                dbothmanContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
