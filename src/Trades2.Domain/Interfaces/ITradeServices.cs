using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trades2.Entities;

namespace Trades2.Domain.Interfaces
{
    public interface ITradeServices : IGeneric<Trade>
    {
        IList<string> GetCategories();
      
    }
}
