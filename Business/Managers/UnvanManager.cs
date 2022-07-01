using AppCore.Business.Managers.Bases;
using AppCore.Results.Bases;
using Business.Models;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.Repositories.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers
{
    public interface IUnvanManager
    {
        List<UnvanModel> GetList();
    }

    public class UnvanManager : IUnvanManager
    {
        private readonly UnvanRepoBase _unvanRepo;

        public UnvanManager(UnvanRepoBase unvanRepo)
        {
            _unvanRepo = unvanRepo;
        }

        public List<UnvanModel> GetList()
        {
            return _unvanRepo.Query().OrderBy(u => u.Adi).Select(u => new UnvanModel()
            {
                Id = u.Id,
                Adi = u.Adi
            }).ToList();
        }
    }
}
