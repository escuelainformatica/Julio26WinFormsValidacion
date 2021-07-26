using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_21072021.BD;
using System.Windows.Forms;

namespace Ejercicio_21072021.Fachada
{
    class PedidoFachada
    {
        public static Pedido FactoryForm(Form_Ordenes form_orden)
        {
            Pedido ped = new Pedido();
            ped.RutCliente = ((Cliente)form_orden.cmb_cliente.SelectedItem).RutCliente;
            ped.IdProducto = ((Producto)form_orden.cmb_producto.SelectedItem).IdProducto;
            /*int cantidad=-1;
            bool cantidadCorrecta = int.TryParse(form_orden.txt_cantidad.Text, out cantidad);
            if(cantidadCorrecta) { 
                ped.Cantidad = cantidad;
            } else
            {
                ped.Cantidad=-1;
            }*/
            try { 
                ped.Cantidad = Convert.ToInt32(form_orden.txt_cantidad.Text);
            } catch(Exception)
            {
                ped.Cantidad=-1;
            }


            return ped;
        }
    }
}
