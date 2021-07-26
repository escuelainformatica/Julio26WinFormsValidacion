using Ejercicio_21072021.BD;
using Ejercicio_21072021.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_21072021.validacion
{
    class PedidoValidacion
    {
        public static void LimpiarTextoValidacion(Form_Ordenes formulario)
        {
            formulario.labelCantidad.Text = "";
            formulario.labelCliente.Text = "";
            formulario.labelProducto.Text = "";
        }

        public static bool ValidarTexto(Pedido ped,Form_Ordenes formulario)
        {
            bool resultado=true;
            var context = new ValidationContext(ped, serviceProvider: null, items: null);
            var listaErrores = new List<ValidationResult>();
            Validator.TryValidateObject(ped, context, listaErrores, true); // para llenar la lista de errores.

            // Validacion personalizada, validamos que hay un stock disponible.
            int stock=ProductoRepo.ObtenerStock(ped.IdProducto);
            if(stock<ped.Cantidad)
            {
                var errorNuevo= new ValidationResult(
                    "Stock no disponible para generar la orden, el stock disponible es "+stock
                    ,new List<string>(){"Cantidad"});
                listaErrores.Add(errorNuevo);
            }


            // MessageBox.Show("Orden no se pudo crear", "Mensaje", MessageBoxButtons.OK);


            ValidationResult errorCantidad = listaErrores
                 .Where(a => a.MemberNames.FirstOrDefault() == "Cantidad")
                 .FirstOrDefault();
            ValidationResult errorCliente = listaErrores
                 .Where(a => a.MemberNames.FirstOrDefault() == "RutCliente")
                 .FirstOrDefault();
            ValidationResult errorProducto = listaErrores
                 .Where(a => a.MemberNames.FirstOrDefault() == "IdProducto")
                 .FirstOrDefault();

            if (errorCantidad != null)
            {
                formulario.labelCantidad.Text = errorCantidad.ErrorMessage;
            }
            if (errorCliente != null)
            {
                formulario.labelCliente.Text = errorCliente.ErrorMessage;
            }
            if (errorProducto != null)
            {
                formulario.labelProducto.Text = errorProducto.ErrorMessage;
            }
            // Si hay mas de un error, entonces falla la validacion.
            if(listaErrores.Count()>0)
            {
                resultado=false;
            } else
            {
                resultado=true;
            }

            return resultado;

        }
    }
}
