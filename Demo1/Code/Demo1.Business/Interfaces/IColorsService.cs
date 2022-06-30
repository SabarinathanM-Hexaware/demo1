using Demo1.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo1.Business.Interfaces
{
    public interface IColorsService
    {      
        IEnumerable<Colors> GetAll();
        Colors Save(Colors classification);
        Colors Update(string id, Colors classification);
        bool Delete(string id);

    }
}
