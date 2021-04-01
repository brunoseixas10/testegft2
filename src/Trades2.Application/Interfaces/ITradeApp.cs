using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trades2.Entities;

namespace Trades2.Application.Interfaces
{
    public interface ITradeApp
    {
        IList<string> GetCategories();
        void Add(Trade trade);
    }
}
