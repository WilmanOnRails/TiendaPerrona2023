using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dependencias;
using System.Text.Json;
using Dependencias.Model;
using System.Text.RegularExpressions;

namespace ProyectoFinal2._0
{
    public partial class MasterPanel : UserControl
    {
        public MasterPanel()
        {
            InitializeComponent();
        }
        APPFx main = new APPFx(1);

        public void Listener(object? sender, EventArgs e)
        {
            var panelss = Controls.OfType<Panel>();
            foreach (Panel panel in panelss)
            {
                for (int i = 1; i <= 12; i++)
                {
                    if (("panel" + i.ToString()) == panel.Name)
                        panel.Visible = true;
                }
            }
            switch (main.getID)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.cpu1;
                    pictureBox2.Image = Properties.Resources.cpu2;
                    pictureBox3.Image = Properties.Resources.cpu3;
                    pictureBox4.Image = Properties.Resources.cpu4;
                    pictureBox5.Image = Properties.Resources.cpu5;
                    pictureBox6.Image = Properties.Resources.cpu6;
                    pictureBox7.Image = Properties.Resources.cpu7;
                    pictureBox8.Image = Properties.Resources.cpu8;
                    pictureBox9.Image = Properties.Resources.cpu9;
                    pictureBox10.Image = Properties.Resources.cpu10;
                    pictureBox11.Image = Properties.Resources.cpu11;
                    pictureBox12.Image = Properties.Resources.cpu12;
                    using (HttpClient client = new HttpClient())
                    {
                        var response = client.GetAsync($"https://localhost:7274/ApiTienda/Products/{main.getID}").Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var output = response.Content.ReadAsStringAsync().Result;
                            List<ProductScheme> productScheme = JsonSerializer.Deserialize<List<ProductScheme>>(output);

                            var panels = Controls.OfType<Panel>();
                            //LblNames cpus
                            foreach (var panel in panels)
                            {
                                var lst = panel.Controls.OfType<Label>().ToList();
                                foreach (var label in lst)
                                {
                                    for (int i = 1; i <= 12; i++)
                                    {

                                        if (("lblName" + i.ToString()) == label.Name)
                                            label.Text = productScheme[i - 1].productName;
                                        //lblDesc cpus
                                        if (("lblDesc" + i.ToString()) == label.Name)
                                            label.Text = productScheme[i - 1].productDescription;
                                        //lblPrice Cpus
                                        if (("lblPrice" + i.ToString()) == label.Name)
                                            label.Text = "$ " + Convert.ToString(productScheme[i - 1].productPrice);
                                    }
                                }
                                //ComboBox Cpu
                                var cbolst = panel.Controls.OfType<ComboBox>().ToList();
                                foreach (ComboBox cbo in cbolst)
                                {
                                    cbo.Items.Clear();
                                    for (int i = 1; i <= 12; i++)
                                    {
                                        if ("cboProcesador" + i.ToString() == cbo.Name)
                                        {
                                            for (int j = 1; j <= productScheme[i - 1].productStock; j++)
                                            {
                                                cbo.Items.Add(j.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.Placa1;
                    pictureBox2.Image = Properties.Resources.Placa2;
                    pictureBox3.Image = Properties.Resources.Placa3;
                    pictureBox4.Image = Properties.Resources.Placa4;
                    pictureBox5.Image = Properties.Resources.Placa5;

                    using (HttpClient client = new HttpClient())
                    {
                        var response = client.GetAsync($"https://localhost:7274/ApiTienda/Products/{main.getID}").Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var output = response.Content.ReadAsStringAsync().Result;
                            List<ProductScheme> productScheme = JsonSerializer.Deserialize<List<ProductScheme>>(output);
                            //ocultar panel sin ocupar

                            var panels = Controls.OfType<Panel>();
                            foreach (Panel panel in panels)
                            {
                                for (int i = 6; i <= 12; i++)
                                {
                                    if (("panel" + i.ToString()) == panel.Name)
                                        panel.Visible = false;
                                }
                            }

                            //LblNames cpus
                            foreach (var panel in panels)
                            {
                                var lst = panel.Controls.OfType<Label>().ToList();
                                foreach (var label in lst)
                                {
                                    for (int i = 1; i <= 5; i++)
                                    {

                                        if (("lblName" + i.ToString()) == label.Name)
                                            label.Text = productScheme[i - 1].productName;
                                        //lblDesc cpus
                                        if (("lblDesc" + i.ToString()) == label.Name)
                                            label.Text = productScheme[i - 1].productDescription;
                                        //lblPrice Cpus
                                        if (("lblPrice" + i.ToString()) == label.Name)
                                            label.Text = "$ " + Convert.ToString(productScheme[i - 1].productPrice);
                                    }
                                }
                                //ComboBox Cpu
                                var cbolst = panel.Controls.OfType<ComboBox>().ToList();
                                foreach (ComboBox cbo in cbolst)
                                {
                                    cbo.Items.Clear();
                                    for (int i = 1; i <= 5; i++)
                                    {
                                        if ("cboProcesador" + i.ToString() == cbo.Name)
                                        {
                                            for (int j = 1; j <= productScheme[i - 1].productStock; j++)
                                            {
                                                cbo.Items.Add(j.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.Ram1;
                    pictureBox2.Image = Properties.Resources.Ram2;
                    pictureBox3.Image = Properties.Resources.Ram3;
                    pictureBox4.Image = Properties.Resources.Ram4;
                    pictureBox5.Image = Properties.Resources.Ram5;
                    pictureBox6.Image = Properties.Resources.Ram6;

                    using (HttpClient client = new HttpClient())
                    {
                        var response = client.GetAsync($"https://localhost:7274/ApiTienda/Products/{main.getID}").Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var output = response.Content.ReadAsStringAsync().Result;
                            List<ProductScheme> productScheme = JsonSerializer.Deserialize<List<ProductScheme>>(output);
                            //ocultar panel sin ocupar

                            var panels = Controls.OfType<Panel>();
                            foreach (Panel panel in panels)
                            {
                                for (int i = 7; i <= 12; i++)
                                {
                                    if (("panel" + i.ToString()) == panel.Name)
                                        panel.Visible = false;
                                }
                            }

                            //LblNames cpus
                            foreach (var panel in panels)
                            {
                                var lst = panel.Controls.OfType<Label>().ToList();
                                foreach (var label in lst)
                                {
                                    for (int i = 1; i <= 6; i++)
                                    {

                                        if (("lblName" + i.ToString()) == label.Name)
                                            label.Text = productScheme[i - 1].productName;
                                        //lblDesc cpus
                                        if (("lblDesc" + i.ToString()) == label.Name)
                                            label.Text = productScheme[i - 1].productDescription;
                                        //lblPrice Cpus
                                        if (("lblPrice" + i.ToString()) == label.Name)
                                            label.Text = "$ " + Convert.ToString(productScheme[i - 1].productPrice);
                                    }
                                }
                                //ComboBox Cpu
                                var cbolst = panel.Controls.OfType<ComboBox>().ToList();
                                foreach (ComboBox cbo in cbolst)
                                {
                                    cbo.Items.Clear();
                                    for (int i = 1; i <= 6; i++)
                                    {
                                        if ("cboProcesador" + i.ToString() == cbo.Name)
                                        {
                                            for (int j = 1; j <= productScheme[i - 1].productStock; j++)
                                            {
                                                cbo.Items.Add(j.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources.Gpu1;
                    pictureBox2.Image = Properties.Resources.Gpu2;
                    pictureBox3.Image = Properties.Resources.Gpu3;
                    pictureBox4.Image = Properties.Resources.Gpu4;
                    pictureBox5.Image = Properties.Resources.Gpu5;

                    using (HttpClient client = new HttpClient())
                    {
                        var response = client.GetAsync($"https://localhost:7274/ApiTienda/Products/{main.getID}").Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var output = response.Content.ReadAsStringAsync().Result;
                            List<ProductScheme> productScheme = JsonSerializer.Deserialize<List<ProductScheme>>(output);
                            //ocultar panel sin ocupar

                            var panels = Controls.OfType<Panel>();
                            foreach (Panel panel in panels)
                            {
                                for (int i = 6; i <= 12; i++)
                                {
                                    if (("panel" + i.ToString()) == panel.Name)
                                        panel.Visible = false;
                                }
                            }

                            //LblNames cpus
                            foreach (var panel in panels)
                            {
                                var lst = panel.Controls.OfType<Label>().ToList();
                                foreach (var label in lst)
                                {
                                    for (int i = 1; i <= 5; i++)
                                    {

                                        if (("lblName" + i.ToString()) == label.Name)
                                            label.Text = productScheme[i - 1].productName;
                                        //lblDesc cpus
                                        if (("lblDesc" + i.ToString()) == label.Name)
                                            label.Text = productScheme[i - 1].productDescription;
                                        //lblPrice Cpus
                                        if (("lblPrice" + i.ToString()) == label.Name)
                                            label.Text = "$ " + Convert.ToString(productScheme[i - 1].productPrice);
                                    }
                                }
                                //ComboBox Cpu
                                var cbolst = panel.Controls.OfType<ComboBox>().ToList();
                                foreach (ComboBox cbo in cbolst)
                                {
                                    cbo.Items.Clear();
                                    for (int i = 1; i <= 5; i++)
                                    {
                                        if ("cboProcesador" + i.ToString() == cbo.Name)
                                        {
                                            for (int j = 1; j <= productScheme[i - 1].productStock; j++)
                                            {
                                                cbo.Items.Add(j.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 5:
                    pictureBox1.Image = Properties.Resources.Fuente1;
                    pictureBox2.Image = Properties.Resources.Fuente2;
                    pictureBox3.Image = Properties.Resources.Fuente3;
                    pictureBox4.Image = Properties.Resources.Fuente4;
                    pictureBox5.Image = Properties.Resources.Fuente5;


                    using (HttpClient client = new HttpClient())
                    {
                        var response = client.GetAsync($"https://localhost:7274/ApiTienda/Products/{main.getID}").Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var output = response.Content.ReadAsStringAsync().Result;
                            List<ProductScheme> productScheme = JsonSerializer.Deserialize<List<ProductScheme>>(output);
                            //ocultar panel sin ocupar

                            var panels = Controls.OfType<Panel>();
                            foreach (Panel panel in panels)
                            {
                                for (int i = 6; i <= 12; i++)
                                {
                                    if (("panel" + i.ToString()) == panel.Name)
                                        panel.Visible = false;
                                }
                            }

                            //LblNames cpus
                            foreach (var panel in panels)
                            {
                                var lst = panel.Controls.OfType<Label>().ToList();
                                foreach (var label in lst)
                                {
                                    for (int i = 1; i <= 5; i++)
                                    {

                                        if (("lblName" + i.ToString()) == label.Name)
                                            label.Text = productScheme[i - 1].productName;
                                        //lblDesc cpus
                                        if (("lblDesc" + i.ToString()) == label.Name)
                                            label.Text = productScheme[i - 1].productDescription;
                                        //lblPrice Cpus
                                        if (("lblPrice" + i.ToString()) == label.Name)
                                            label.Text = "$ " + Convert.ToString(productScheme[i - 1].productPrice);
                                    }
                                }
                                //ComboBox Cpu
                                var cbolst = panel.Controls.OfType<ComboBox>().ToList();
                                foreach (ComboBox cbo in cbolst)
                                {
                                    cbo.Items.Clear();
                                    for (int i = 1; i <= 5; i++)
                                    {
                                        if ("cboProcesador" + i.ToString() == cbo.Name)
                                        {
                                            for (int j = 1; j <= productScheme[i - 1].productStock; j++)
                                            {
                                                cbo.Items.Add(j.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 6:
                    pictureBox1.Image = Properties.Resources.Monitor1;
                    pictureBox2.Image = Properties.Resources.Monitor2;
                    pictureBox3.Image = Properties.Resources.Monitor3;
                    pictureBox4.Image = Properties.Resources.Monitor4;
                    pictureBox5.Image = Properties.Resources.Monitor5;

                    using (HttpClient client = new HttpClient())
                    {
                        var response = client.GetAsync($"https://localhost:7274/ApiTienda/Products/{main.getID}").Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var output = response.Content.ReadAsStringAsync().Result;
                            List<ProductScheme> productScheme = JsonSerializer.Deserialize<List<ProductScheme>>(output);
                            //ocultar panel sin ocupar

                            var panels = Controls.OfType<Panel>();
                            foreach (Panel panel in panels)
                            {
                                for (int i = 6; i <= 12; i++)
                                {
                                    if (("panel" + i.ToString()) == panel.Name)
                                        panel.Visible = false;
                                }
                            }

                            //LblNames cpus
                            foreach (var panel in panels)
                            {
                                var lst = panel.Controls.OfType<Label>().ToList();
                                foreach (var label in lst)
                                {
                                    for (int i = 1; i <= 5; i++)
                                    {

                                        if (("lblName" + i.ToString()) == label.Name)
                                            label.Text = productScheme[i - 1].productName;
                                        //lblDesc cpus
                                        if (("lblDesc" + i.ToString()) == label.Name)
                                            label.Text = productScheme[i - 1].productDescription;
                                        //lblPrice Cpus
                                        if (("lblPrice" + i.ToString()) == label.Name)
                                            label.Text = "$ " + Convert.ToString(productScheme[i - 1].productPrice);
                                    }
                                }
                                //ComboBox Cpu
                                var cbolst = panel.Controls.OfType<ComboBox>().ToList();
                                foreach (ComboBox cbo in cbolst)
                                {
                                    cbo.Items.Clear();
                                    for (int i = 1; i <= 5; i++)
                                    {
                                        if ("cboProcesador" + i.ToString() == cbo.Name)
                                        {
                                            for (int j = 1; j <= productScheme[i - 1].productStock; j++)
                                            {
                                                cbo.Items.Add(j.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 7:
                    pictureBox1.Image = Properties.Resources.Ssd1;
                    pictureBox2.Image = Properties.Resources.Ssd2;
                    pictureBox3.Image = Properties.Resources.Ssd3;
                    pictureBox4.Image = Properties.Resources.Ssd4;
                    pictureBox5.Image = Properties.Resources.Ssd5;

                    using (HttpClient client = new HttpClient())
                    {
                        var response = client.GetAsync($"https://localhost:7274/ApiTienda/Products/{main.getID}").Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var output = response.Content.ReadAsStringAsync().Result;
                            List<ProductScheme> productScheme = JsonSerializer.Deserialize<List<ProductScheme>>(output);
                            //ocultar panel sin ocupar

                            var panels = Controls.OfType<Panel>();
                            foreach (Panel panel in panels)
                            {
                                for (int i = 6; i <= 12; i++)
                                {
                                    if (("panel" + i.ToString()) == panel.Name)
                                        panel.Visible = false;
                                }
                            }

                            //LblNames cpus
                            foreach (var panel in panels)
                            {
                                var lst = panel.Controls.OfType<Label>().ToList();
                                foreach (var label in lst)
                                {
                                    for (int i = 1; i <= 5; i++)
                                    {

                                        if (("lblName" + i.ToString()) == label.Name)
                                            label.Text = productScheme[i - 1].productName;
                                        //lblDesc cpus
                                        if (("lblDesc" + i.ToString()) == label.Name)
                                            label.Text = productScheme[i - 1].productDescription;
                                        //lblPrice Cpus
                                        if (("lblPrice" + i.ToString()) == label.Name)
                                            label.Text = "$ " + Convert.ToString(productScheme[i - 1].productPrice);
                                    }
                                }
                                //ComboBox Cpu
                                var cbolst = panel.Controls.OfType<ComboBox>().ToList();
                                foreach (ComboBox cbo in cbolst)
                                {
                                    cbo.Items.Clear();
                                    for (int i = 1; i <= 5; i++)
                                    {
                                        if ("cboProcesador" + i.ToString() == cbo.Name)
                                        {
                                            for (int j = 1; j <= productScheme[i - 1].productStock; j++)
                                            {
                                                cbo.Items.Add(j.ToString());
                                            }
                                        }
                                    }
                                }
                            }




                        }
                    }
                    break;
                case 8:
                    pictureBox1.Image = Properties.Resources.Teclado1;
                    pictureBox2.Image = Properties.Resources.Teclado2;
                    pictureBox3.Image = Properties.Resources.Teclado3;
                    pictureBox4.Image = Properties.Resources.Mouse1;
                    pictureBox5.Image = Properties.Resources.Mouse2;
                    pictureBox6.Image = Properties.Resources.Mouse3;
                    using (HttpClient client = new HttpClient())
                    {
                        var response = client.GetAsync($"https://localhost:7274/ApiTienda/Products/{main.getID}").Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var output = response.Content.ReadAsStringAsync().Result;
                            List<ProductScheme> productScheme = JsonSerializer.Deserialize<List<ProductScheme>>(output);
                            //ocultar panel sin ocupar

                            var panels = Controls.OfType<Panel>();
                            foreach (Panel panel in panels)
                            {
                                for (int i = 7; i <= 12; i++)
                                {
                                    if (("panel" + i.ToString()) == panel.Name)
                                        panel.Visible = false;
                                }
                            }

                            //LblNames cpus
                            foreach (var panel in panels)
                            {
                                var lst = panel.Controls.OfType<Label>().ToList();
                                foreach (var label in lst)
                                {
                                    for (int i = 1; i <= 6; i++)
                                    {

                                        if (("lblName" + i.ToString()) == label.Name)
                                            label.Text = productScheme[i - 1].productName;
                                        //lblDesc cpus
                                        if (("lblDesc" + i.ToString()) == label.Name)
                                            label.Text = productScheme[i - 1].productDescription;
                                        //lblPrice Cpus
                                        if (("lblPrice" + i.ToString()) == label.Name)
                                            label.Text = "$ " + Convert.ToString(productScheme[i - 1].productPrice);
                                    }
                                }
                                //ComboBox Cpu
                                var cbolst = panel.Controls.OfType<ComboBox>().ToList();
                                foreach (ComboBox cbo in cbolst)
                                {
                                    cbo.Items.Clear();
                                    for (int i = 1; i <= 6; i++)
                                    {
                                        if ("cboProcesador" + i.ToString() == cbo.Name)
                                        {
                                            for (int j = 1; j <= productScheme[i - 1].productStock; j++)
                                            {
                                                cbo.Items.Add(j.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 9:
                    pictureBox1.Image = Properties.Resources.Case1;
                    pictureBox2.Image = Properties.Resources.Case2;
                    pictureBox3.Image = Properties.Resources.Case3;
                    pictureBox4.Image = Properties.Resources.Case4;
                    pictureBox5.Image = Properties.Resources.Case5;
                    pictureBox6.Image = Properties.Resources.Case6;
                    using (HttpClient client = new HttpClient())
                    {
                        var response = client.GetAsync($"https://localhost:7274/ApiTienda/Products/{main.getID}").Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var output = response.Content.ReadAsStringAsync().Result;
                            List<ProductScheme> productScheme = JsonSerializer.Deserialize<List<ProductScheme>>(output);
                            //ocultar panel sin ocupar

                            var panels = Controls.OfType<Panel>();
                            foreach (Panel panel in panels)
                            {
                                for (int i = 7; i <= 12; i++)
                                {
                                    if (("panel" + i.ToString()) == panel.Name)
                                        panel.Visible = false;
                                }
                            }

                            //LblNames cpus
                            foreach (var panel in panels)
                            {
                                var lst = panel.Controls.OfType<Label>().ToList();
                                foreach (var label in lst)
                                {
                                    for (int i = 1; i <= 6; i++)
                                    {

                                        if (("lblName" + i.ToString()) == label.Name)
                                            label.Text = productScheme[i - 1].productName;
                                        //lblDesc cpus
                                        if (("lblDesc" + i.ToString()) == label.Name)
                                            label.Text = productScheme[i - 1].productDescription;
                                        //lblPrice Cpus
                                        if (("lblPrice" + i.ToString()) == label.Name)
                                            label.Text = "$ " + Convert.ToString(productScheme[i - 1].productPrice);
                                    }
                                }
                                //ComboBox Cpu
                                var cbolst = panel.Controls.OfType<ComboBox>().ToList();
                                foreach (ComboBox cbo in cbolst)
                                {
                                    cbo.Items.Clear();
                                    for (int i = 1; i <= 6; i++)
                                    {
                                        if ("cboProcesador" + i.ToString() == cbo.Name)
                                        {
                                            for (int j = 1; j <= productScheme[i - 1].productStock; j++)
                                            {
                                                cbo.Items.Add(j.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

            var txt = sender as Button;
            Carrito carrito = null;
            foreach (var panel in Controls.OfType<Panel>())
            {
                if (panel.Controls.OfType<Button>().FirstOrDefault().Name == txt.Name)
                {
                    var lbls = panel.Controls.OfType<Label>().ToList();

                    carrito = new Carrito()
                    {
                        ProductName = lbls[0].Text,
                        ProductPrice = decimal.Parse(Regex.Replace(lbls[1].Text, "\\$", string.Empty)),
                        ProductDescription = lbls[2].Text,
                        Quantity = int.Parse(panel.Controls.OfType<ComboBox>().First().Text),
                    };

                    carrito.Total = carrito.ProductPrice * carrito.Quantity;

                    break;
                }
            }


            using (var cliente = new HttpClient())
            {
                var str = JsonSerializer.Serialize(carrito);
                var content = new StringContent(str, System.Text.Encoding.UTF8, "application/json");

                var result = cliente.PostAsync("https://localhost:7274/ApiTienda/Carrito", content).Result;
                if (result.IsSuccessStatusCode) MessageBox.Show("Producto agregado", "Agregado");
                else MessageBox.Show("error no agregada " + result.StatusCode.ToString());
            }
        }
    }




}
