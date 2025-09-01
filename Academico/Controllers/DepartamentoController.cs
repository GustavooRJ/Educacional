using Academico.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class DepartamentoController: Controller
    {
        public static List<Departamento> _departamento = new List<Departamento>();
        public IActionResult Index()
        {
            return View(_departamento);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Departamento departamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    departamento.DepartamentoID = _departamento.Select(d => d.DepartamentoID).DefaultIfEmpty(0).Max() + 1;
                    _departamento.Add(departamento);
                    return RedirectToAction("Index");
                }
                return View(departamento);
            }
            catch
            {
                return View(departamento);
            }
        }
        public IActionResult Edit(int id)
        {
            var departamento = _departamento.FirstOrDefault(d => d.DepartamentoID == id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }
        [HttpPost]
        public IActionResult Edit(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _departamento.Remove(_departamento.Where(d => d.DepartamentoID == departamento.DepartamentoID).First());
                _departamento.Add(departamento);
                return RedirectToAction("Index");
            }
            return View(departamento);
        }
        public IActionResult Details(int id)
        {
            var departamento = _departamento.FirstOrDefault(d => d.DepartamentoID == id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }
        public IActionResult Delete(int id)
        {
            var departamento = _departamento.FirstOrDefault(d => d.DepartamentoID == id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var departamento = _departamento.FirstOrDefault(d => d.DepartamentoID == id);
            if (departamento != null)
            {
                _departamento.Remove(departamento);
            }
            return RedirectToAction("Index");
        }
    }
}

