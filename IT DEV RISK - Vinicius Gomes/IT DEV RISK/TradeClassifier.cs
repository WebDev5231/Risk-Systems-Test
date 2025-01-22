using IT_DEV_RISK.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_DEV_RISK
{
    public class TradeClassifier
    {
        private readonly List<ITradeCategory> _categories;

        public TradeClassifier()
        {
            _categories = new List<ITradeCategory>
        {
            new ExpiredCategory(),
            new HighRiskCategory(),
            new MediumRiskCategory(),
            new PepCategory()
        };
        }

        public string ClassifyTrade(ITrade trade, DateTime referenceDate)
        {
            foreach (var category in _categories)
            {
                string result = category.Categorize(trade, referenceDate);
                if (!string.IsNullOrEmpty(result))
                    return result; // Retorna a primeira categoria encontrada
            }

            return "UNCATEGORIZED"; // Caso o trade não se encaixe em nenhuma regra
        }
    }
}