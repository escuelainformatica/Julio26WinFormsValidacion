using Ejercicio_21072021.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_21072021.Repo
{
    class PedidoRepo
    {
        /// <summary>
        /// Cuando se inserta un pedido, es necesario reducir el stock.
        /// </summary>
        /// <param name="pedido"></param>
        public static void Insertar(Pedido pedido)
        {
            using (var contexto = new BasePedido())
            {   
                contexto.Pedido.Add(pedido);

                // REDUCIENDO EL STOCK
                // este objeto producto es un objeto dentro del contexto
                Producto producto=contexto.Producto.Find(pedido.IdProducto);
                producto.Stock=producto.Stock-pedido.Cantidad;

                contexto.SaveChanges(); // se guarda todos los elementos agregados o modificados.
            }
        }



        public static List<Pedido> Listar()
        {
            var resultado = new List<Pedido>();
            using (var contexto = new BasePedido())
            {
                resultado = contexto.Pedido.ToList();
            }
            return resultado;
        }


   }
}
