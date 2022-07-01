using Business.Managers;
using Business.Models;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mvc.Controllers
{
    public class PersonellerController : Controller
    {
        // Add service injections here
        private readonly IPersonelManager _personelService;
        private readonly IUnvanManager _unvanManager;

        public PersonellerController(IPersonelManager personelService, IUnvanManager unvanManager)
        {
            _personelService = personelService;
            _unvanManager = unvanManager;
        }

        // GET: Personeller
        public IActionResult Index()
        {
            List<PersonelModel> personelList = _personelService.Query().ToList(); // TODO: Add get list service logic here
            return View(personelList);
        }

        // GET: Personeller/Details/5
        public IActionResult Details(int id)
        {
            PersonelModel personel = _personelService.GetById(id); // TODO: Add get item service logic here
            if (personel == null)
            {
                return NotFound();
            }
            return View(personel);
        }

        // GET: Personeller/Create
        public IActionResult Create()
        {
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["UnvanId"] = new SelectList(_unvanManager.GetList(), "Id", "Adi");
            return View();
        }

        // POST: Personeller/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PersonelModel personel)
        {
            if (ModelState.IsValid)
            {
                var result = _personelService.Add(personel);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["UnvanId"] = new SelectList(_unvanManager.GetList(), "Id", "Adi");
            return View(personel);
        }

        // GET: Personeller/Edit/5
        public IActionResult Edit(int id)
        {
            Personel personel = null; // TODO: Add get item service logic here
            if (personel == null)
            {
                return NotFound();
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["UnvanId"] = new SelectList(null, "Id", "Id", personel.UnvanId);
            return View(personel);
        }

        // POST: Personeller/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Personel personel)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update service logic here
                return RedirectToAction(nameof(Index));
            }
            // Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewData["UnvanId"] = new SelectList(null, "Id", "Id", personel.UnvanId);
            return View(personel);
        }

        // GET: Personeller/Delete/5
        public IActionResult Delete(int id)
        {
            Personel personel = null; // TODO: Add get item service logic here
            if (personel == null)
            {
                return NotFound();
            }
            return View(personel);
        }

        // POST: Personeller/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            return RedirectToAction(nameof(Index));
        }
	}
}
