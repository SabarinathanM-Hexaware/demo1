using Demo1.Business.Interfaces;
using Demo1.Data.Interfaces;
using Demo1.Entities.Entities;
using System.Collections.Generic;

namespace Demo1.Business.Services
{
    public class ColorsService : IColorsService
    {
        IColorsRepository _ColorsRepository;

        public ColorsService(IColorsRepository ColorsRepository)
        {
           this._ColorsRepository = ColorsRepository;
        }
        public IEnumerable<Colors> GetAll()
        {
            return _ColorsRepository.GetAll();
        }

        public bool Save(Colors Colors)
        {
             return _ColorsRepository.Save(Colors);
        }

        public Colors Update(string id, Colors Colors)
        {
            return _ColorsRepository.Update(id, Colors);
        }

        public bool Delete(string id)
        {
            return _ColorsRepository.Delete(id);
        }

    }
}
