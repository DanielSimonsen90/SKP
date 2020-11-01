using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dancord.Classes.Base
{
    interface IManager<T>
    {
        T Create(string name, Permission[] permissions);
        T Delete(T item);
    }
}
