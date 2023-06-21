using Dependencias.PasswordHandling;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal2._0
{
    public partial class LoginFx : Form
    {
        private int borderRadius = 30;
        private int bordeSize = 2;
        private Color borderColor = Color.White;



        public LoginFx()
        {
            InitializeComponent();
            this.Padding = new Padding(bordeSize);
            this.BackColor = borderColor;
            this.ShowInTaskbar = false;
            txtUsuario.PlaceholderText = "Nombre de Usuario";
            txtContraseña.PlaceholderText = "Contraseña";
            txtContraseña.UseSystemPasswordChar = true;
        }

        //Drag Form     
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void LoginFx_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panelContenedorLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private GraphicsPath GetRoundedPath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
        private void FormRegionAndBorder(Form form, float radius, Graphics graph, Color borderColor, float borderSize)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = GetRoundedPath(form.ClientRectangle, radius))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                using (Matrix transform = new Matrix())
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    form.Region = new Region(roundPath);
                    if (borderSize >= 1)
                    {
                        Rectangle rect = form.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);
                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);
                        graph.Transform = transform;
                        graph.DrawPath(penBorder, roundPath);
                    }
                }
            }
        }
        private void ControlRegionAndBorder(Control control, float radius, Graphics graph, Color borderColor)
        {
            using (GraphicsPath roundPath = GetRoundedPath(control.ClientRectangle, radius))
            using (Pen penBorder = new Pen(borderColor, 1))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                control.Region = new Region(roundPath);
                graph.DrawPath(penBorder, roundPath);
            }
        }
        private void DrawPath(Rectangle rect, Graphics graph, Color color)
        {
            using (GraphicsPath roundPath = GetRoundedPath(rect, borderRadius))
            using (Pen penBorder = new Pen(color, 3))
            {
                graph.DrawPath(penBorder, roundPath);
            }
        }
        private struct FormBoundsColors
        {
            public Color TopLeftColor;
            public Color TopRightColor;
            public Color BottomLeftColor;
            public Color BottomRightColor;
        }
        private FormBoundsColors GetFormBoundsColors()
        {
            var fbColor = new FormBoundsColors();
            using (var bmp = new Bitmap(1, 1))
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle rectBmp = new Rectangle(0, 0, 1, 1);

                //Top Left
                rectBmp.X = this.Bounds.X - 1;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopLeftColor = bmp.GetPixel(0, 0);

                //Top Right
                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopRightColor = bmp.GetPixel(0, 0);

                //Bottom Left
                rectBmp.X = this.Bounds.X;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomLeftColor = bmp.GetPixel(0, 0);

                //Bottom Right
                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomRightColor = bmp.GetPixel(0, 0);
            }
            return fbColor;
        }
        //Event Methods
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int nWidht = rectForm.Width / 2;
            int nHeight = rectForm.Height / 2;
            var fbColor = GetFormBoundsColors();
            //Top left
            DrawPath(rectForm, e.Graphics, fbColor.TopLeftColor);
            //top Right
            Rectangle rectTopRight = new Rectangle(nWidht, rectForm.Y, nWidht, nHeight);
            DrawPath(rectTopRight, e.Graphics, fbColor.TopRightColor);
            //Botton Left
            Rectangle rectBottonLeft = new Rectangle(rectForm.X, rectForm.X + nHeight, nWidht, nHeight);
            DrawPath(rectTopRight, e.Graphics, fbColor.BottomLeftColor);
            //Botton Right
            Rectangle rectBottonRight = new Rectangle(nWidht, rectForm.Y + nHeight, nWidht, nHeight);
            DrawPath(rectBottonRight, e.Graphics, fbColor.BottomRightColor);


        }

        private void LoginFx_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, bordeSize);
        }
        private void panelContenedorLogin_Paint(object sender, PaintEventArgs e)
        {
            ControlRegionAndBorder(panelContenedorLogin, borderRadius - (bordeSize / 2), e.Graphics, borderColor);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, bordeSize);
        }

        private void LoginFx_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void LoginFx_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void LoginFx_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrarLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Authentication auth = new Authentication();
            if (auth.SintaxVerifier(txtUsuario.Text, txtContraseña.Text) & auth.PasswordChecksum(txtContraseña.Text))
            {
                if (auth.LogInChechsum(txtUsuario.Text, txtContraseña.Text).Result == true)
                {
                    APPFx abrirFormPrincipal = new APPFx();
                    abrirFormPrincipal.ShowDialog();
                    this.ShowInTaskbar = false;

                }
                {
                    MessageBox.Show("ERROR EN LOS DATOS \nVERIFIQUE SUS DATOS");
                }

            }
            else
            {
                MessageBox.Show("ERROR EN LOS DATOS \nVERIFIQUE SUS DATOS");
            }

        }

        

        private void btnRegistrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegistroFx registro = new RegistroFx();
            registro.ShowDialog();
        }
    }
}
