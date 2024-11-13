using AP2_MedManager.Data;
using AP2_MedManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedManager.Controllers
{
    public class AllergieController : Controller
    {
         private readonly ApplicationDbContext _dbContext;

         
        public AllergieController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: AllergieControllers
        public ActionResult Index()
        {
            List<Allergie> allergies = _dbContext.Allergies.ToList();
            allergies = _dbContext.Allergies.ToList();
            return View(allergies);
        }

        [HttpGet]
        public IActionResult Ajouter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ajouter(Allergie allergie)
        {
            if (!ModelState.IsValid)
            {
              return View();
            }

            _dbContext.Allergies.Add(allergie);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Modifier(int id)
        {
            Allergie allergie = _dbContext.Allergies.FirstOrDefault(a => a.AllergieId == id);
            if (allergie == null)
            {
                return NotFound();
            }

            return View(allergie);
        }

        [HttpPost]
        public IActionResult Modifier(Allergie allergie)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _dbContext.Allergies.Update(allergie);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Supprimer(int id)
        {
            Allergie allergie = _dbContext.Allergies.FirstOrDefault(a => a.AllergieId == id);
            if (allergie == null)
            {
                return NotFound();
            }

       return View(allergie);
        }

        [HttpPost , ActionName("Supprimer")]
        public IActionResult SupprimerConfirmed(int id)
        {
            Allergie allergie = _dbContext.Allergies.FirstOrDefault(a => a.AllergieId == id);
            if (allergie == null)
            {
                return NotFound();
            }

            _dbContext.Allergies.Remove(allergie);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
