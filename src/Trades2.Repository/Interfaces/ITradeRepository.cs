using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trades2.Entities;

namespace Trades2.Repository.Interfaces
{
    public interface ITradeRepository
    {
        void Add(Trade trade);
        void Clear();
        IList<Trade> List();
    }
}
