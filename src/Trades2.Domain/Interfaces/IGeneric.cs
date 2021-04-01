using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trades2.Domain.Interfaces
{
    public interface IGeneric<T> where T : new()
    {
        void Add(T obj);
        void Clear();
    }
}
