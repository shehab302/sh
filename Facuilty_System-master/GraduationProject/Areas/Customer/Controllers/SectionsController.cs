using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace GraduationProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class SectionsController : Controller
    {
        ISectionsRepository _sectionsRepository;

        public SectionsController(ISectionsRepository sectionsRepository)
        {
            _sectionsRepository = sectionsRepository;
        }

        public IActionResult Index()
        {
            var sections = _sectionsRepository.GetAll("Course");
            return View(sections);
        }

        public IActionResult Create()
        {
            var Sections = new Sections();
            return View(Sections);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sections sections)
        {
            if (ModelState.IsValid)
            {
                _sectionsRepository.Add(sections);
                _sectionsRepository.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(sections);
        }

        public IActionResult Edit(int id)
        {
            var sections = _sectionsRepository.GetOne(id);
            if (sections == null)
            {
                return NotFound();
            }
            return View(sections);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Sections section)
        {
            if (ModelState.IsValid)
            {
                _sectionsRepository.Edit(section);
                _sectionsRepository.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(section);
        }

        public IActionResult Delete(int id)
        {
            var section = _sectionsRepository.GetOne(id);
            if (section == null)
            {
                return NotFound();
            }
            return View(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var section = _sectionsRepository.GetOne(id);
            if (section == null)
            {
                return NotFound();
            }
            _sectionsRepository.Delete(section);
            _sectionsRepository.Commit();
            return RedirectToAction(nameof(Index));
        }
    }
}
