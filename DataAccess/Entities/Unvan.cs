using AppCore.Records.Bases;

namespace DataAccess.Entities
{
    public class Unvan : KayitBase, IKayitSoftDelete
    {
        public string Adi { get; set; }
        public List<Personel> Personeller { get; set; }
        public bool IsDeleted { get; set; }
    }
}
