using System.Windows.Forms;
namespace ProyectoFinal2._0
{
    public partial class APPFx : Form
    {
        private static int proID;

        public int getID { get => proID; }
        public APPFx()
        {
            InitializeComponent();
            SidePanel.Height = btnInicio.Height;
            //btns
            btnProcesadores.Click += masterPanel1.Listener;
            btnSSD.Click += masterPanel1.Listener;
            btnTarjetaGraficas.Click += masterPanel1.Listener;
            btnTecladoyMause.Click += masterPanel1.Listener;
            btnPlacasMadre.Click += masterPanel1.Listener;
            btnMonitores.Click += masterPanel1.Listener;
            btnMemoriaRam.Click += masterPanel1.Listener;
            btnFuenteDePoder.Click += masterPanel1.Listener;
            btnCase.Click += masterPanel1.Listener;
        }

        public APPFx(int u)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnInicio.Height;
            SidePanel.Top = btnInicio.Top;
            fxInicio1.BringToFront();
        }

        private void btnProcesadores_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnProcesadores.Height;
            SidePanel.Top = btnProcesadores.Top;
            masterPanel1.BringToFront();
            proID = 1;
        }

        private void btnTarjetaGraficas_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnTarjetaGraficas.Height;
            SidePanel.Top = btnTarjetaGraficas.Top;
            masterPanel1.BringToFront();
            proID = 4;

        }

        private void btnMemoriaRam_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnMemoriaRam.Height;
            SidePanel.Top = btnMemoriaRam.Top;
            masterPanel1.BringToFront();
            proID = 3;
        }

        private void btnSSD_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnSSD.Height;
            SidePanel.Top = btnSSD.Top;
            masterPanel1.BringToFront();
            proID = 7;
        }

        private void btnFuenteDePoder_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnFuenteDePoder.Height;
            SidePanel.Top = btnFuenteDePoder.Top;
            masterPanel1.BringToFront();
            proID = 5;
        }

        private void btnCase_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnCase.Height;
            SidePanel.Top = btnCase.Top;
            masterPanel1.BringToFront();
            proID = 9;
        }

        private void btnMonitores_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnMonitores.Height;
            SidePanel.Top = btnMonitores.Top;
            masterPanel1.BringToFront();
            proID = 6;
        }

        private void btnTecladoyMause_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnTecladoyMause.Height;
            SidePanel.Top = btnTecladoyMause.Top;
            masterPanel1.BringToFront();
            proID = 8;
        }

        private void btnCerrarAplicacion_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCarrito_Click(object sender, EventArgs e)
        {
            carritoFx1.BringToFront();
        }

        private void btnPlacasMadre_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnPlacasMadre.Height;
            SidePanel.Top = btnPlacasMadre.Top;
            masterPanel1.BringToFront();
            proID = 2;
        }

        private void fxCase2_Load(object sender, EventArgs e)
        {
        }
    }
}
