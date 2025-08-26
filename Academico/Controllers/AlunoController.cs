using Academico.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class AlunoController : Controller
    {
        private static List<Aluno> _aluno = new List<Aluno>();
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
            try
            {
                if (ModelState.IsValid)
                {
                    aluno.AlunoID = _aluno.Select(a => a.AlunoID).DefaultIfEmpty(0).Max() + 1;
                    _aluno.Add(aluno);
                    return RedirectToAction("Index");
                }
                return View(aluno);
            }
            catch
            {

                return View(aluno);

            }

        }

        public IActionResult Edit(int id)
        {
            var aluno = _aluno.FirstOrDefault(a => a.AlunoID == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _aluno.Remove(_aluno.Where(a => a.AlunoID == aluno.AlunoID).First());
                _aluno.Add(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }
        public IActionResult Details(int id)
        {
            var aluno = _aluno.FirstOrDefault(a => a.AlunoID == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }
        public IActionResult Delete(int id)
        {
            var aluno = _aluno.FirstOrDefault(a => a.AlunoID == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmer(int id)
        {
            try
            {
                var aluno = _aluno.FirstOrDefault(a => a.AlunoID == id);
                if (aluno == null)
                {
                    return NotFound();
                }
                _aluno.Remove(aluno);
                return RedirectToAction("Index");
            }
            catch
            {
                
            }
            return View(_aluno);
        }

    }
}
