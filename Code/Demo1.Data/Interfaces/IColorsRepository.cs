using Demo1.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo1.Data.Interfaces
{
    public interface IColorsRepository : IGetAll<Colors>, IGetById<Colors, string>, ISave<Colors>, IUpdate<Colors, string>, IDelete<string>
    {
    }
}
