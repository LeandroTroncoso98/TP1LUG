using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public interface IAltaModificable<T>
    {
        bool Modificar(T t);
        bool Alta(T t);
    }
}
