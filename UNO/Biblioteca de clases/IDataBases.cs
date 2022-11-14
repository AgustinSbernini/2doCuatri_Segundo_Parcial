using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_clases
{
    interface IDataBases<T>
    {
        T RecuperarUno(T objeto);

        int CrearNuevo(T objeto);

        int Actualizar(T objeto);


    }
}
