using Ejercicio_21072021.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_21072021
{
    public partial class Form_ListarOrden : Form
    {
        public Form_ListarOrden()
        {
            InitializeComponent();
        }

        private void Form_ListarOrden_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            try
            {
                dataGridView1.DataSource = PedidoRepo.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas con la base de datos\nConsulte con soporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close(); // cierra el formulario.
            }

        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {


            Form_Ordenes form_Orden = new Form_Ordenes();
            form_Orden.ShowDialog();

            dataGridView1.DataSource = PedidoRepo.Listar();

        }
    }
}
