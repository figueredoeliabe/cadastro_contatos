
using cadastro_contatos.Filters;
using Microsoft.AspNetCore.Mvc;

namespace cadastro_contatos.Controllers
{
    [PaginaLogada]
    
    public class RestritoController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
} 