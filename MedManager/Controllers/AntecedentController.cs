using AP2_MedManager.Data;
using AP2_MedManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AP2_MedManager.Controllers
{
    [Authorize]
    public class AntecedentController : Controller

    {
        private readonly ApplicationDbContext _dbContext;

        public AntecedentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: AntecedentControllers
        public ActionResult Index()
        {
            List<Antecedent> antecedents = _dbContext.Antecedents.ToList();
            antecedents = _dbContext.Antecedents.ToList();
            return View(antecedents);
        }

        [HttpGet]
        public IActionResult Ajouter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ajouter(Antecedent antecedent)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _dbContext.Antecedents.Add(antecedent);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Modifier(int id)
        {
            Antecedent antecedent = _dbContext.Antecedents.FirstOrDefault(a => a.AntecedentId == id);
            if (antecedent == null)
            {
                return NotFound();
            }

            return View(antecedent);
        }

        [HttpPost]
        public IActionResult Modifier(Antecedent antecedent)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _dbContext.Antecedents.Update(antecedent);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Supprimer(int id)
        {
            Antecedent antecedent = _dbContext.Antecedents.FirstOrDefault(a => a.AntecedentId == id);
            if (antecedent == null)
            {
                return NotFound();
            }

            return View(antecedent);
        }

        [HttpPost, ActionName("Supprimer")]
        public IActionResult SupprimerValider(int id)
        {
            Antecedent antecedent = _dbContext.Antecedents.FirstOrDefault(a => a.AntecedentId == id);
            if (antecedent == null)
            {
                return NotFound();
            }

            _dbContext.Antecedents.Remove(antecedent);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }


}
