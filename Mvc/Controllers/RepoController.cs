using AppCore.Enums;
using DataAccess.Entities;
using DataAccess.Repositories.Bases;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class RepoController : Controller
    {
        private readonly PersonelRepoBase _personelRepo;
        private readonly UnvanRepoBase _unvanRepo;

        public RepoController(PersonelRepoBase personelRepo, UnvanRepoBase unvanRepo)
        {
            _personelRepo = personelRepo;
            _unvanRepo = unvanRepo;
        }

        public IActionResult Add()
        {
            var personel = new Personel()
            {
                Adi = "Test Ad 1",
                Soyadi = "Test Soyad 2",
                UnvanId = 1,
                Cinsiyet = Cinsiyet.Kadın
            };
            var result = _personelRepo.Add(personel);
            return Content($"{result.IsSuccessful} - {result.Message}");
        }

        public IActionResult Delete()
        {
            var result = _unvanRepo.Delete(u => u.Id == 1);
            

            result = _personelRepo.Delete(p => p.Id == 1);

            return Content($"{result.IsSuccessful} - {result.Message}");
        }
    }
}
