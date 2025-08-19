using Academico.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class AlunoController : Controller
    {
        private static List<Aluno> _aluno =  new List<Aluno>();
        public IActionResult Index()
        {
            
            return View(_aluno);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Aluno aluno)
        {
           _aluno.Add(aluno);
            return RedirectToAction("Index");
        }
    }
}
