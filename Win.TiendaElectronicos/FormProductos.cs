using BL.Tecnologia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.TiendaElectronicos
{
    public partial class FormProductos : Form
    {
        ProductosBL Productos;

        public FormProductos()
        {
            InitializeComponent();

            Productos = new ProductosBL();

            listaProductosBindingSource.DataSource = Productos.ObtenerProductos();
        }

        private void listaProductosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

            listaProductosBindingSource.EndEdit();
            var producto = (Producto)listaProductosBindingSource.Current;

            var Resultado = Productos.GuardarProducto(producto);

            if(Resultado.Correcto == true)
            {
                listaProductosBindingSource.ResetBindings(false);
                HabilitarDeshabilitar(true);
            }
            else
            {
                MessageBox.Show(Resultado.Incorrecto);
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            Productos.AgregarProducto();
            listaProductosBindingSource.MoveLast();

            HabilitarDeshabilitar(false);
        }

        private void HabilitarDeshabilitar(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;


            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;

            toolStripButton1.Visible = !valor;

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

           
            if(codigoTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea Elminar Este Producto ?", "Eliminar", MessageBoxButtons.YesNo);
                if(resultado == DialogResult.Yes)
                {
                    var codigo = Convert.ToInt32(codigoTextBox.Text);
                    Eliminar(codigo);
                }
                
            }
        }

        private void Eliminar(int codigo)
        {
            var Codigo = Convert.ToInt32(codigoTextBox.Text);
            var Resultado = Productos.Eliminar(codigo);

            if (Resultado == true)
            {
                listaProductosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Error al Eliminar Producto");
            }
        
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            HabilitarDeshabilitar(true);
            Eliminar(0);
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {

        }
    }
}
