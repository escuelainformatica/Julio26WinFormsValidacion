using Ejercicio_21072021.BD;
using Ejercicio_21072021.Fachada;
using Ejercicio_21072021.Repo;
using Ejercicio_21072021.validacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_21072021
{
    public partial class Form_Ordenes : Form
    {


        public Form_Ordenes()
        {
            InitializeComponent();
        }


        private void Form_Ordenes_Load(object sender, EventArgs e)
        {
            try
            {
                // throw new Exception("error de prueba");
                var clientes = ClienteRepo.ListarCliente();
                clientes.Insert(0, new Cliente { RutCliente = null, Nombre = "--Seleccione Cliente--" });

                cmb_cliente.DataSource = clientes;

                var productos = ProductoRepo.ListarProducto();
                productos.Insert(0, new Producto { IdProducto = 0, Nombre = "--Seleccione Producto--" });

                cmb_producto.DataSource = productos;
            }
            catch (Exception ex)
            {

            }
        }
        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            Pedido ped = null; // no esta definida.
            PedidoValidacion.LimpiarTextoValidacion(this);

            try
            {
                ped = PedidoFachada.FactoryForm(this); // leo los datos desde la pantalla
            }
            catch (FormatException ex)
            {
                // Aqui se captura solo los errores de formato
                MessageBox.Show("Orden no se pudo crear, datos incorrecto", "Mensaje", MessageBoxButtons.OK);
                return; // fin de la funcion

            }
            catch (Exception ex)
            {
                // Aqui se captura cualquier error.
            }
            bool esCorrecto = PedidoValidacion.ValidarTexto(ped, this); // valido el pedido.
            if (esCorrecto)
            {
                try
                {

                    PedidoRepo.Insertar(ped);
                    MessageBox.Show("Orden Creada", "Mensaje", MessageBoxButtons.OK);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al ingresar la orden en la base de datos.\nPor favor, revise los datos ingresados\nSi el problema continua, consulte con soporte."
                        , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }        
        }




    }
}
