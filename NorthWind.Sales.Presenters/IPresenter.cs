using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Sales.Presenters
{
    public interface IPresenter<FormatDataType>
    {
        public FormatDataType Content { get; }
    }
}
