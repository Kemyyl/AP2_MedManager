using System.Security.Claims;
using AP2_MedManager.Data;
using AP2_MedManager.Models;
using AP2_MedManager.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AP2_MedManager.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<Medecin> _userManager;

    private readonly SignInManager<Medecin> _signInManager; 
    public AccountController(SignInManager<Medecin> signInManager, UserManager<Medecin> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.HideNavBar = true;
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        
    
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }

        


        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var medecin = new Medecin { UserName = model.UserName, Email = model.Email, Role = "DefaultRole" };
            var result = await _userManager.CreateAsync(medecin, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(medecin, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }
}