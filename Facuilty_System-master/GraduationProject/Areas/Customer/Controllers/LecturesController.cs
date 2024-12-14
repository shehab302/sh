using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace GraduationProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class LecturesController : Controller
    {
            ILecturesRepository _lecturesRepository;

            public LecturesController(ILecturesRepository lecturesRepository)
            {
                _lecturesRepository = lecturesRepository;
            }

            public IActionResult Index()
            {
                var lecture = _lecturesRepository.GetAll("Course");
                return View(lecture);
            }

            public IActionResult Create()
            {
                var lecture = new Lectures();
                return View(lecture);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Lectures lecture)
            {
                if (ModelState.IsValid)
                {
                    _lecturesRepository.Add(lecture);
                    _lecturesRepository.Commit();
                    return RedirectToAction(nameof(Index));
                }
                return View(lecture);
            }

            public IActionResult Edit(int id)
            {
                var lecture = _lecturesRepository.GetOne(id);
                if (lecture == null)
                {
                    return NotFound();
                }
                return View(lecture);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(Lectures lecture)
            {
                if (ModelState.IsValid)
                {
                    _lecturesRepository.Edit(lecture);
                    _lecturesRepository.Commit();
                    return RedirectToAction(nameof(Index));
                }
                return View(lecture);
            }

            public IActionResult Delete(int id)
            {
                var lecture = _lecturesRepository.GetOne(id);
                if (lecture == null)
                {
                    return NotFound();
                }
                return View(lecture);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult DeleteConfirmed(int id)
            {
                var lecture = _lecturesRepository.GetOne(id);
                if (lecture == null)
                {
                    return NotFound();
                }
                _lecturesRepository.Delete(lecture);
                _lecturesRepository.Commit();
                return RedirectToAction(nameof(Index));
            }
    }
}
