using AppCore.Enums;
using AppCore.Records.Bases;

namespace DataAccess.Entities
{
    public class Personel : KayitBase
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KimlikNo { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public int UnvanId { get; set; }
        public Unvan Unvan { get; set; }
    }
}
