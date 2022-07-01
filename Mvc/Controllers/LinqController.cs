using AppCore.Enums;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Mvc.Controllers
{
    public class LinqController : Controller
    {
        private readonly Db _db;

        public LinqController(Db db)
        {
            _db = db;
        }

        public IActionResult ToList()
        {
            //var list = new List<Personel>();
            //foreach (var p in _db.Personeller)
            //{
            //    list.Add(p);
            //}

            List<Personel> list = _db.Personeller.Include(p => p.Unvan).ToList();
            return View(list);
        }

        public IActionResult Single()
        {
            Personel item;
            
            item = _db.Personeller.Include(p => p.Unvan).First(p => p.Id == 1);
            item = _db.Personeller.Include(p => p.Unvan).FirstOrDefault(p => p.Soyadi == "Alsaç" && p.Cinsiyet == Cinsiyet.Erkek);

            item = _db.Personeller.Include(p => p.Unvan).Last(p => p.Id == 1);
            item = _db.Personeller.Include(p => p.Unvan).LastOrDefault(p => p.Soyadi == "Alsaç" || p.UnvanId == 2);

            item = _db.Personeller.Include(p => p.Unvan).Single(p => p.Id == 1);
            item = _db.Personeller.Include(p => p.Unvan).SingleOrDefault(p => p.KimlikNo == "12345678901");

            item = _db.Personeller.Find(1);

            return View(item);
        }

        public IActionResult Where()
        {
            List<Personel> list = _db.Personeller.Include(p => p.Unvan).Where(p => p.Cinsiyet == Cinsiyet.Erkek && p.DogumTarihi >= DateTime.Parse("01.01.1980 00:00:00", new CultureInfo("tr-TR")) && p.DogumTarihi <= DateTime.Parse("31.12.1999 23:59:59", new CultureInfo("tr-TR"))).ToList();

            return View(list);
        }

        public IActionResult Any() // All
        {
            Personel personel = _db.Personeller.SingleOrDefault(p => p.KimlikNo == "12345678901");
            if (personel == null)
            {
                return Content("Personel eklenebilir.");
            }
            else
            {
                return Content("Personel eklenemez.");
            }

            if (_db.Personeller.Any(p => p.KimlikNo == "12345678901") && personel.Id != 1)
            {
                return Content("Personel güncellenemez.");
            }
            return Content("Personel güncellenebilir.");
        }
    }
}
