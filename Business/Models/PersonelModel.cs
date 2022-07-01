using AppCore.Enums;
using AppCore.Records.Bases;
using DataAccess.Entities;

namespace Business.Models
{
    public class PersonelModel : KayitBase
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KimlikNo { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public int UnvanId { get; set; }

        public UnvanModel Unvan  { get; set; }

        public string DogumTarihiDisplay => DogumTarihi.HasValue ? DogumTarihi.Value.ToString("dd.MM.yyyy") : "";
        public string TamAdiDisplay => Adi + " " + Soyadi;

        public string UnvanDisplay => Unvan.Adi;

    }
}
