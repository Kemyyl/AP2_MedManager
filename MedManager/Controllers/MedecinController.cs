using AP2_MedManager.Data;
using  AP2_MedManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AP2_MedManager.Controllers

{
    public class MedecinController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public MedecinController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            return View(_dbContext.Medecins);
        }

        [HttpGet]
        public IActionResult Ajouter()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Medecin medecin)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(medecin);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            _dbContext.Medecins.Add(medecin);
            _dbContext.SaveChanges();
            return View("Index", _dbContext.Medecins);
        }

        [HttpGet]
        public IActionResult Modifier(int id)
        {

            // Return View au sein de l'action Edit retournera la vue Edit.cshtml
            Medecin? intrs = _dbContext.Medecins.FirstOrDefault<Medecin>(ins => ins.MedecinId == id);

            if (intrs != null)
            {
                return View(intrs);
            }

            return NotFound();

        }

        [HttpPost]
        public IActionResult Modifier(Medecin medecin)
        {
            // verification de la validite du model avec ModelState
            if (!ModelState.IsValid)
            {
                return View();
            }

            Medecin? instr = _dbContext.Medecins.FirstOrDefault<Medecin>(ins => ins.MedecinId == medecin.MedecinId);

            if (instr != null)
            {
                instr.Nom_m = medecin.Nom_m;
                instr.Prenom_m = medecin.Prenom_m;
                instr.Role = medecin.Role;

                _dbContext.SaveChanges();

                // return View("Index", _dbContext.Instructors);
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        private bool MedecinExists(int id)
        {
            return _dbContext.Medecins.Any(m => m.MedecinId == id);
        }

         [HttpGet]
        public IActionResult Supprimer(int Id)
        {
            // On recherche l'instructeur à supprimer avec l'id fourni en paramètre
            Medecin? instr = _dbContext.Medecins.FirstOrDefault<Medecin>(ins => ins.MedecinId == Id);

            if (instr != null) // Si l'instructeur est trouvé
            {
                return View(instr); // On retourne la vue Delete.cshtml avec l'instructeur à supprimer
            }
            // Si l'instructeur n'est pas trouvé on retourne une erreur 404
            return NotFound();
            //return View();
        }

        [HttpPost, ActionName("Supprimer")]
        public IActionResult SupprimerValider(int MedecinId)

        {
            // On recherche l'instructeur à supprimer avec l'id fourni en paramètre
            Medecin? instr = _dbContext.Medecins.FirstOrDefault<Medecin>(ins => ins.MedecinId == MedecinId);


            if (instr != null) // Si l'instructeur est trouvé
            {
                _dbContext.Medecins.Remove(instr); // On le supprime de la liste
                _dbContext.SaveChanges(); // On sauvegarde les modifications
                // return View("Index", _dbContext.Instructors); // On retourne la vue Index.cshtml avec la nouvelle liste
                return RedirectToAction("Index");
            }
            // Si l'instructeur n'est pas trouvé on retourne une erreur 404
            return NotFound();
        }
    }
}