using Demo1.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo1.Business.Interfaces
{
    public interface IColorsService
    {      
        IEnumerable<Colors> GetAll();
        Colors GetById(string id);
        void Save(Colors classification);
        void Update(string id, Colors classification);
        void Delete(string id);

    }
}
