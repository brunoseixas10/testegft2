using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trades2.Application.Interfaces;
using Trades2.Domain.Interfaces;
using Trades2.Entities;

namespace Trades2.Application
{
    public sealed class TradeApp : ITradeApp
    {
        private readonly ITradeServices _tradeServices;

        public TradeApp(ITradeServices tradeServices)
        {
            _tradeServices = tradeServices;
        }

        public void Add(Trade trade)
        {
            _tradeServices.Add(trade);
        }

        public IList<string> GetCategories()
        {
            return _tradeServices.GetCategories();
        }
    }
}
