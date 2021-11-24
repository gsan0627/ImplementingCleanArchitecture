using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.UseCasesPorts.Common
{
    public interface IPorts<T>
    {
        Task Handle(T dto);
    }

    public interface IPorts
    {
        Task Handle();
    }
}