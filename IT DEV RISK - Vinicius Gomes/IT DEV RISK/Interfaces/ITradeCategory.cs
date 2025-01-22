using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_DEV_RISK.Interfaces
{
    public interface ITradeCategory
    {
        string Categorize(ITrade trade, DateTime referenceDate);
    }
}
