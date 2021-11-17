using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Interfaces
{
    public interface IUnitOfWork
    {
        ValueTask<int> SaveChanges();
    }
}
