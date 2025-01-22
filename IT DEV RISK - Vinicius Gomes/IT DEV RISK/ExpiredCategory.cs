using IT_DEV_RISK.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_DEV_RISK
{
    public class ExpiredCategory : ITradeCategory
    {
        public string Categorize(ITrade trade, DateTime referenceDate)
        {
            return (referenceDate.Subtract(trade.NextPaymentDate).Days > 30) ? "EXPIRED" : null;
        }
    }
}
