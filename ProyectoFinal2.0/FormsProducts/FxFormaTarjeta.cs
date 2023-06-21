using Dependencias.Email;
using Dependencias.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Text.Json;
using Dependencias;
using Dependencias.PasswordHandling;

namespace ProyectoFinal2._0.FormsProducts
{
    public partial class FxFormaTarjeta : UserControl
    {
        private Regex rg = new Regex(@"\s+");
        private string nombre;
        private string numeroTarjeta;
        private int codigo;
        private DateTime fechaExp;
        private TimeSpan timeSpan;
        public FxFormaTarjeta()
        {
            InitializeComponent();
        }

        private void btnValidarTarjeta_Click(object sender, EventArgs e)
        {
            if (!verifyFields())
            {
                MessageBox.Show("¡TODOS LOS CAMPOS DEBEN ESTAR LLENOS PARA CONTINUAR CON LA COMPRA!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!validarTarjeta(txtNumeroTarjeta.Text))
            {
                MessageBox.Show("EL NUMERO INGRESADO NO CORRESPONDE A UNA TARJETA VALIDA. POR FAVOR " +
                   "INGRESE UNA TARJETA  VALIDA", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearAll();
                return;
            }

            obtenerDatos();
        }

        private void obtenerDatos()
        {
            if (!validarFecha())
            {
                MessageBox.Show("LA TARJETA INGRESADA SE ENCUENTRA VENCIDA. POR FAVOR " +
                    "INGRESE UNA TARJETA  VALIDA", "Mensaje", MessageBoxButtons.OK);
                clearAll();
                return;
            }

            numeroTarjeta = txtNumeroTarjeta.Text;
            codigo = Int32.Parse(txtCodigoDeSeguridad.Text);
            nombre = txtNombreTitular.Text;
            SendEmail();
            MessageBox.Show("¡El Cobro se ha Realizado Correctamente!. Se le envio una factura a su correo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            clearAll();
        }

        private bool validarFecha()
        {
            try
            {
                Regex r = new Regex(@"(?<mes>\d{2})/(?<año>\d{2})");
                MatchCollection matches = r.Matches(txtExpiracion.Text);

                foreach (Match item in matches)
                {
                    GroupCollection g = item.Groups;

                    fechaExp = DateTime.Parse($"{DateTime.Now.Day}/{g["mes"].Value}/{g["año"].Value}");

                    timeSpan = fechaExp - DateTime.Now.Date;
                }

                return timeSpan.CompareTo(TimeSpan.Zero) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void clearAll()
        {
            txtExpiracion.Clear();
            txtCodigoDeSeguridad.Clear();
            txtNombreTitular.Clear();
            txtNumeroTarjeta.Clear();
        }

        public bool validarTarjeta(String cardNo)
        {
            cardNo = cardNo.Replace("-", "");
            cardNo = eliminarEspacios(cardNo);

            int nDigits = cardNo.Length;

            int nSum = 0;
            bool isSecond = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {

                int d = cardNo[i] - '0';

                if (isSecond == true)
                    d = d * 2;

                nSum += d / 10;
                nSum += d % 10;

                isSecond = !isSecond;
            }
            return (nSum % 10 == 0);
        }

        public string eliminarEspacios(string s)
        {
            return Regex.Replace(s, @"\s+", String.Empty);
        }

        private bool verifyFields()
        {
            if (string.IsNullOrWhiteSpace(txtCodigoDeSeguridad.Text) || string.IsNullOrWhiteSpace(txtExpiracion.Text)
             || string.IsNullOrWhiteSpace(txtNombreTitular.Text) || string.IsNullOrWhiteSpace(txtNumeroTarjeta.Text))
                return false;

            return true;
        }

        private async void SendEmail()
        {
            IEnumerable<CarritoScheme> lst = await GetSchemes();
    

            var au = new Authentication();
            var active = au.ActiveEmail;

            EmailSender sender = new(active);
            sender.fillRows(lst);

            var user = await getActiveUser(active);
            sender.fillHeader(user);

            await sender.SendEmail();
        }

        private void txtNombreTitular_TextChanged(object sender, EventArgs e)
        {

        }

        private async Task<IEnumerable<CarritoScheme>> GetSchemes()
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
                    return null;
                }
            }
        }

        private async Task<UserScheme> getActiveUser(string str)
        {
            using (var cliente = new HttpClient())
            {
                var uri = string.Format("{0}/{1}", "https://localhost:7274/ApiTienda/Users",str);
                var result = await cliente.GetAsync(uri);

                if (result.IsSuccessStatusCode)
                {
                    var user = await result.Content.ReadAsStringAsync();

                    return JsonSerializer.Deserialize<UserScheme>(user);
                }
                else
                {
                    MessageBox.Show("Fallo en la api xd");
                    return null;
                }
            }
        }
    }
}
