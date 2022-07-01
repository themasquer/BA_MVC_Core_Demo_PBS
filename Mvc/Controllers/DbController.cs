using AppCore.Enums;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class DbController : Controller
    {
        private readonly Db _db;

        public DbController(Db db)
        {
            _db = db;
        }

        public IActionResult Seed()
        {
            var unvanlar = _db.Unvanlar.ToList();
            _db.Unvanlar.RemoveRange(unvanlar);

            _db.Unvanlar.Add(new Unvan()
            {
                Guid = Guid.NewGuid(),
                Adi = "Yazılım Geliştirici",
                Personeller = new List<Personel>()
                {
                    new Personel()
                    {
                        Guid = Guid.NewGuid(),
                        Adi = "Çağıl",
                        Soyadi = "Alsaç",
                        Cinsiyet = Cinsiyet.Erkek,
                        DogumTarihi = new DateTime(1980, 5, 27),
                        KimlikNo = "12345678901"
                    },
                    new Personel()
                    {
                        Guid = Guid.NewGuid(),
                        Adi = "Leo",
                        Soyadi = "Alsaç",
                        Cinsiyet = Cinsiyet.Erkek,
                        DogumTarihi = new DateTime(2014, 6, 20),
                        KimlikNo = "98765432109"
                    }
                }
            });

            _db.Unvanlar.Add(new Unvan()
            {
                Guid = Guid.NewGuid(),
                Adi = "Bilgi İşlem Uzmanı",
                Personeller = new List<Personel>()
                {
                    new Personel()
                    {
                        Guid = Guid.NewGuid(),
                        Adi = "Yasemin",
                        Soyadi = "Akyol",
                        Cinsiyet = Cinsiyet.Kadın,
                        DogumTarihi = new DateTime(1994, 9, 15),
                        KimlikNo = "11122233344"
                    },
                    new Personel()
                    {
                        Guid = Guid.NewGuid(),
                        Adi = "Can",
                        Soyadi = "Tan",
                        Cinsiyet = Cinsiyet.Erkek,
                        DogumTarihi = new DateTime(2000, 7, 9),
                        KimlikNo = "99988877766"
                    },
                    new Personel()
                    {
                        Guid = Guid.NewGuid(),
                        Adi = "Fatih",
                        Soyadi = "Altan",
                        Cinsiyet = Cinsiyet.Erkek,
                        DogumTarihi = new DateTime(1995, 11, 12),
                        KimlikNo = "55544466611"
                    }
                }
            });

            _db.SaveChanges();

            return Content("İlk veriler başarıyla oluşturuldu.");
        }
    }
}
