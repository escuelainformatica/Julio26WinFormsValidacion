using Ejercicio_21072021.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_21072021.Repo
{
    class ClienteRepo
    {
        public static List<Cliente> ListarCliente()
        {
            var resultado = new List<Cliente>();
            using (var contexto = new BasePedido())
            {
                resultado = contexto.Cliente.ToList();
            }
            return resultado;
        }

    }
}
