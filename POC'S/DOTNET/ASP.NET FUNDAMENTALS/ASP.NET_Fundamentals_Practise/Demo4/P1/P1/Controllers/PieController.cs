using Microsoft.AspNetCore.Mvc;
using P1.Models;

namespace P1.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController (IPieRepository pieRepository,ICategoryRepository categoryRepository)
        {
            _pieRepository=pieRepository;
            _categoryRepository=categoryRepository;
        }
        
        public IActionResult List()
        {
            ViewBag.Message = "HAI EVERYONE WELCOME TO FINT ";
            ViewData["Status"] = "SUCCESSFULL";
            return View(_pieRepository.AllPies);
        }
    }
}
