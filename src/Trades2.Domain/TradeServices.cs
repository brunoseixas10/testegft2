using System.Collections.Generic;
using System.Linq;
using Trades2.Domain.Interfaces;
using Trades2.Entities;
using Trades2.Repository.Interfaces;

namespace Trades2.Domain
{
    public sealed class TradeServices : ITradeServices
    {
        private readonly ITradeRepository _tradeRepository;

        public TradeServices(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }

        public void Add(Trade trade)
        {
            _tradeRepository.Add(trade);
        }

        public void Clear()
        {
            _tradeRepository.Clear();
        }

        public IList<string> GetCategories()
        {
            var trades = _tradeRepository.List();
            return trades.ToList().ConvertAll(x => x.GetCategoryName());
        }
    }
}
