using AP2_MedManager.Data;
using AP2_MedManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;




namespace AP2_MedManager.Controllers
{
    public class PatientController : Controller
    {
        // 
        private readonly ApplicationDbContext _dbContext;

        // Controleur, injection de dependance
        public PatientController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: PatientController
        public ActionResult Index()
        {
            return View(_dbContext.Patients);
        }


        [HttpGet]
        public IActionResult Ajouter()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            // verification de la validite du model avec ModelState
            if (ModelState.IsValid)
            {
                _dbContext.Add(patient); // L'ID sera généré automatiquement
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirige vers l'index après la création
            }

            _dbContext.Patients.Add(patient);
            _dbContext.SaveChanges();
            return View("Index", _dbContext.Patients); // retourne la vue Index.cshtml avec la nouvelle liste

        }

        [HttpGet]
        public IActionResult Modifier(int id)
        {
            // Return View au sein de l'action Edit retournera la vue Edit.cshtml
            Patient? intrs = _dbContext.Patients.FirstOrDefault<Patient>(ins => ins.PatientId == id);

            if (intrs != null)
            {
                return View(intrs);
            }

            return NotFound();

        }

        [HttpPost]
        public IActionResult Modifier(Patient patient)
        {
            // verification de la validite du model avec ModelState
            if (!ModelState.IsValid)
            {
                return View(patient);
            }

            _dbContext.Patients.Update(patient);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
