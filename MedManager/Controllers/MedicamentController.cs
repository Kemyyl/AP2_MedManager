using AP2_MedManager.Data;
using AP2_MedManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace AP2_MedManager.Controllers
{
    public class MedicamentController : Controller
    {
         private readonly ApplicationDbContext _dbContext;

         
        public MedicamentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: AllergieControllers
        public ActionResult Index()
        {
            List<Medicament> medicaments = _dbContext.Medicaments.ToList();
            medicaments = _dbContext.Medicaments.ToList();
            return View(medicaments);
        }

        [HttpGet]
        public IActionResult Ajouter()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Ajouter(Medicament medicament)
        {
            if (!ModelState.IsValid)
            {
              return View();
            }

            _dbContext.Medicaments.Add(medicament);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Modifier(int id)
        {
            Medicament medicament = _dbContext.Medicaments.FirstOrDefault(a => a.MedicamentId == id);
            if (medicament == null)
            {
                return NotFound();
            }

            return View(medicament);
        }

        [HttpPost]
        public IActionResult Modifier(Medicament medicament)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }
            _dbContext.Medicaments.Update(medicament);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Supprimer(int id)
        {
            Medicament medicament = _dbContext.Medicaments.FirstOrDefault(a => a.MedicamentId == id);
            if (medicament == null)
            {
            return NotFound();
            }

            return View(medicament);
        }

        [HttpPost, ActionName("Supprimer")]
        public IActionResult SupprimerConfirmed(int id)
        {
            Medicament medicament = _dbContext.Medicaments.FirstOrDefault(a => a.MedicamentId == id);
            if (medicament == null)
            {
            return NotFound();
            }

            _dbContext.Medicaments.Remove(medicament);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}