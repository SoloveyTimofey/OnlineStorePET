using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDataModels
{
    public interface IPrototype<T>
    {
        public abstract T Clone();
    }
}
