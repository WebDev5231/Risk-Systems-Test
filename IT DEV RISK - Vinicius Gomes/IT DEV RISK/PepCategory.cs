using IT_DEV_RISK.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_DEV_RISK
{
    public class PepCategory : ITradeCategory
    {
        public string Categorize(ITrade trade, DateTime referenceDate)
        {
            return trade.IsPoliticallyExposed ? "PEP" : null;
        }
    }
}
