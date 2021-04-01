using System;
using System.Collections.Generic;
using Trades2.Entities;
using Trades2.Repository.Interfaces;

namespace Trades2.Repository
{
    public sealed class TradeRepository : ITradeRepository
    {
        public TradeRepository()
        {
            DatabaseMock.portfolio = new List<Trade>();
        }

        public void Add(Trade trade)
        {
            DatabaseMock.portfolio.Add(trade);
        }

        public void Clear()
        {
            DatabaseMock.portfolio.Clear();
        }

        public IList<Trade> List()
        {
            return DatabaseMock.portfolio;
        }
    }
}
