using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trades2.Entities
{
    public static class TradeExtensions
    {
        private static bool IsHighRisk(this Trade trade)
        {
            return trade.Value > 1000000 && trade.ClientSector == "Private";
        }
        private static bool IsMediumRisk(this Trade trade)
        {
            return trade.Value > 1000000 && trade.ClientSector == "Public";
        }
        private static bool IsLowRisk(this Trade trade)
        {
            return trade.Value < 1000000 && trade.ClientSector == "Public";
        }
        public static string GetCategoryName(this Trade trade)
        {
            return trade.IsHighRisk() ? "HIGHRISK" : trade.IsMediumRisk() ? "MEDIUMRISK" : trade.IsLowRisk() ? "LOWRISK" : "";
        }
    }
}
