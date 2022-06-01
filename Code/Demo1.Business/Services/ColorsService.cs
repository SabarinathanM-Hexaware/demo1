using Demo1.Business.Interfaces;
using Demo1.Data.Interfaces;
using Demo1.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
        
        public Colors GetById(string id)
        {
            return _ColorsRepository.GetById(id);
        }

        public void Save(Colors Colors)
        {
             _ColorsRepository.Save(Colors);
        }

        public void Update(string id, Colors Colors)
        {
            _ColorsRepository.Update(id, Colors);
        }

        public void Delete(string id)
        {
            _ColorsRepository.Delete(id);
        }

    }
}
