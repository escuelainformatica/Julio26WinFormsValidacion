using Ejercicio_21072021.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_21072021.Repo
{
    class ProductoRepo
    {
        public static List<Producto> ListarProducto()
        {
            var resultado = new List<Producto>();
            using (var contexto = new BasePedido())
            {
                resultado = contexto.Producto.ToList();
            }
            return resultado;
        }
        public static int ObtenerStock(int? idProducto)
        {
            int resultado=0;
            using (var contexto = new BasePedido())
            {
                try { 
                    resultado= (int)contexto
                        .Producto
                        .First( p=>p.IdProducto==idProducto) 
                        .Stock;
                    // FirstOrDefault si el idproducto no esta, devuelve null
                    // First si el idproducto no esta, genera un error
                }
                catch (Exception ex)
                {
                    resultado=0;
                }
            }
            return resultado;
        }


    }
}
