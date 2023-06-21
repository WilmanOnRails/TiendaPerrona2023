using API.Dtos;
using Dependencias.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dependencias;

namespace ProyectoFinal2._0.FormsProducts
{
    public partial class CarritoFx : UserControl
    {
        public CarritoFx()
        {
            InitializeComponent();
            
        }

        private void btnCerrarCarrito_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            
            FacturacionFx facturacionFx = new FacturacionFx();
            facturacionFx.ShowDialog();
          
            

        }

        public async Task<IEnumerable<CarritoScheme>> CargarProductos()
        {
            using (var cliente = new HttpClient())
            {
                var result = await cliente.GetAsync("https://localhost:7274/ApiTienda/Carrito");

                if (result.IsSuccessStatusCode)
                {
                    var products = await result.Content.ReadAsStringAsync();

                    return JsonSerializer.Deserialize<IEnumerable<CarritoScheme>>(products);     
                }
                else
                {
                    MessageBox.Show("Fallo en la api xd");
                }
                return null;
            }
        }

        private async void CarritoFx_Load(object sender, EventArgs e)
        {
            Clear();
            setLabels();
            dataGridViewCarrito.DataSource = await CargarProductos();
        }

        private void dataGridViewCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private async void deleteProduct(string str)
        {
            using (var cliente = new HttpClient())
            {
                string porra = string.Format("{0}={1}", "https://localhost:7274/ApiTienda/Carrito/Name?Name",str);
                var result = await cliente.DeleteAsync(porra);

                if (result.IsSuccessStatusCode)
                {
                    MessageBox.Show("Producto Eliminado del carrito con exito");
                    dataGridViewCarrito.DataSource = await CargarProductos();
                    Clear();
                    setLabels();
                }
                else
                {
                    MessageBox.Show("Fallo en la api xd");
                }
            }
        }

        private void Clear()
        {
            dataGridViewCarrito.Rows.Clear();
        }

        private async void setLabels()
        {
            var carritos = await CargarProductos();
            var cant = carritos.Sum(x => x.quantity * x.productPrice);
            var iva = cant * 0.15m;
            lblSubTotal.Text = cant.ToString("C");
            lblSubTotal.Text = iva.ToString("C");
            lblTotal.Text = (iva + cant).ToString("C");
        }

        private void dataGridViewCarrito_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult d = MessageBox.Show("¿Esta seguro que desea eliminar este producto del carrito?","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

           if (d == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridViewCarrito.Rows)
                {
                    if (row.Index == e.RowIndex)
                    {
                        var name = row.Cells[0].Value.ToString();
                        deleteProduct(name);
                    }
                }
            }
        }
    }
}
