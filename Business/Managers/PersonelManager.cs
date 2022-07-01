using AppCore.Business.Managers.Bases;
using AppCore.Results;
using AppCore.Results.Bases;
using Business.Models;
using DataAccess.Entities;
using DataAccess.Repositories.Bases;

namespace Business.Managers
{
    public interface IPersonelManager : IManager<PersonelModel, Personel>
    {
        PersonelModel GetById(int id);
    }

    public class PersonelManager : IPersonelManager
    {
        private readonly PersonelRepoBase _personelRepo; 
        private readonly UnvanRepoBase _unvanRepo;

        public PersonelManager(PersonelRepoBase personelRepo, UnvanRepoBase unvanRepo)
        {
            _personelRepo = personelRepo;
            _unvanRepo = unvanRepo;
        }

        public Result Add(PersonelModel model)
        {
            if (_personelRepo.Query().Any(p => p.KimlikNo.ToLower() == model.KimlikNo.ToLower().Trim()))
                return new ErrorResult("Girdiğiniz kimlik no'ya ait kayıt vardır!");
            var entity = new Personel()
            {
                Id = model.Id,
                Adi = model.Adi.Trim()
                // ...
            };
            _personelRepo.Add(entity);
            return new SuccessResult();
        }

        public Result Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _personelRepo.Dispose();
        }

        // personelManager.Query().ToList();
        // personelManager.Query().SinfleOrDefault(m => m.Id == id);
        // personelManager.Query().Skip((sayfaNo - 1) * sayfadakiKayitSayisi).Take(sayfadakiKayitSayisi));
        // personelManager.Queru().OrderBy(p => p.Adi);
        public IQueryable<PersonelModel> Query()
        {
            //return _personelRepo.Query().Include(p => p.Unvan).OrderBy(p => p.Adi).ThenBy(p => p.Soyadi).Select(p => new PersonelModel()
            //{
            //    Adi = p.Adi,
            //    Cinsiyet = p.Cinsiyet,
            //    DogumTarihi = p.DogumTarihi,
            //    Soyadi = p.Soyadi,
            //    Guid = p.Guid,
            //    Id = p.Id,
            //    KimlikNo = p.KimlikNo,
            //    UnvanId = p.UnvanId,
            //    //DogumTarihiDisplay = p.DogumTarihi.HasValue ? p.DogumTarihi.Value.ToString("dd.MM.yyyy") : "",
            //    TamAdiDisplay = p.Adi + " " + p.Soyadi,
            //    UnvanDisplay = p.Unvan.Adi
            //});

            var personelQuery = _personelRepo.Query();
            var unvanQuery = _unvanRepo.Query();
            var query = from p in personelQuery
                        join u in unvanQuery
                        on p.UnvanId equals u.Id
                        //where p.Id == 5
                        //orderby p.Adi, p.Soyadi
                        select new PersonelModel()
                        {
                            Adi = p.Adi,
                            Cinsiyet = p.Cinsiyet,
                            DogumTarihi = p.DogumTarihi,
                            Soyadi = p.Soyadi,
                            Guid = p.Guid,
                            Id = p.Id,
                            KimlikNo = p.KimlikNo,
                            UnvanId = p.UnvanId,
                            Unvan = new UnvanModel()
                            {
                                Id = u.Id,
                                Adi = u.Adi
                            }
                            //DogumTarihiDisplay = p.DogumTarihi.HasValue ? p.DogumTarihi.Value.ToString("dd.MM.yyyy") : "",
                            
                        };
            //query = from p in personelQuery
            //        join u in unvanQuery
            //        on p.UnvanId equals u.Id into unvan
            //        from subUnvan in unvan.DefaultIfEmpty()
            //        select new PersonelModel()
            //        {
            //            Adi = p.Adi,
            //            Cinsiyet = p.Cinsiyet,
            //            DogumTarihi = p.DogumTarihi,
            //            Soyadi = p.Soyadi,
            //            Guid = p.Guid,
            //            Id = p.Id,
            //            KimlikNo = p.KimlikNo,
            //            UnvanId = p.UnvanId,
            //            Unvan = new UnvanModel()
            //            {
            //                Id = subUnvan.Id,
            //                Adi = subUnvan.Adi
            //            }
            //            //DogumTarihiDisplay = p.DogumTarihi.HasValue ? p.DogumTarihi.Value.ToString("dd.MM.yyyy") : "",
            //        };
            return query;
        }

        public Result Update(PersonelModel model)
        {
            throw new NotImplementedException();
        }

        public PersonelModel GetById(int id)
        {
            return Query().SingleOrDefault(p => p.Id == id);
        }
    }
}
