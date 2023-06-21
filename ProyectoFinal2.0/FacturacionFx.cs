using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal2._0
{
    public partial class FacturacionFx : Form
    {
        public FacturacionFx()
        {
            InitializeComponent();



        }


        private void checkTarjetaDeCredito_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void FacturacionFx_Load(object sender, EventArgs e)
        {
            fxFormaTarjeta1.BringToFront();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
