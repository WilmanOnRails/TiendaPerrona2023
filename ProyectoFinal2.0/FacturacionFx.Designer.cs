namespace ProyectoFinal2._0
{
    partial class FacturacionFx
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnCerrar = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            panelContenedorFormasDePago = new Panel();
            fxFormaTarjeta1 = new FormsProducts.FxFormaTarjeta();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            lblNombreParaLaFactura = new Label();
            lblCorreoParaLaFactura = new Label();
            lblCantidadProductosComprados = new Label();
            lblTotalAPagar = new Label();
            button1 = new Button();
            label10 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panelContenedorFormasDePago.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(123, 41, 210);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(lblTotalAPagar);
            panel1.Controls.Add(lblCantidadProductosComprados);
            panel1.Controls.Add(lblCorreoParaLaFactura);
            panel1.Controls.Add(lblNombreParaLaFactura);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnCerrar);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(511, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(281, 443);
            panel1.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(3, 347);
            label6.Name = "label6";
            label6.Size = new Size(122, 24);
            label6.TabIndex = 8;
            label6.Text = "Total a pagar";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(3, 227);
            label5.Name = "label5";
            label5.Size = new Size(106, 48);
            label5.TabIndex = 7;
            label5.Text = "Productos \r\nComprados";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 79);
            label4.Name = "label4";
            label4.Size = new Size(76, 24);
            label4.TabIndex = 6;
            label4.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(74, 8);
            label3.Name = "label3";
            label3.Size = new Size(107, 28);
            label3.TabIndex = 5;
            label3.Text = "FACTURA\r\n";
            // 
            // btnCerrar
            // 
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnCerrar.ForeColor = Color.White;
            btnCerrar.Location = new Point(269, -3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(34, 30);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "X";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Small", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(172, 19);
            label1.TabIndex = 1;
            label1.Text = "Sistema de Facturacion";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.minus;
            pictureBox1.Location = new Point(12, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(172, 19);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label10);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(12, 46);
            panel2.Name = "panel2";
            panel2.Size = new Size(478, 76);
            panel2.TabIndex = 3;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.mastercard_payment_method_icon_142750;
            pictureBox2.Location = new Point(408, 22);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(57, 36);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Small", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(26, 34);
            label2.Name = "label2";
            label2.Size = new Size(237, 38);
            label2.TabIndex = 4;
            label2.Text = "Metodo seguro para pagar usando \r\ntu cuenta bancaria";
            // 
            // panelContenedorFormasDePago
            // 
            panelContenedorFormasDePago.BackColor = Color.White;
            panelContenedorFormasDePago.Controls.Add(fxFormaTarjeta1);
            panelContenedorFormasDePago.Location = new Point(12, 128);
            panelContenedorFormasDePago.Name = "panelContenedorFormasDePago";
            panelContenedorFormasDePago.Size = new Size(478, 296);
            panelContenedorFormasDePago.TabIndex = 4;
            // 
            // fxFormaTarjeta1
            // 
            fxFormaTarjeta1.Dock = DockStyle.Fill;
            fxFormaTarjeta1.Location = new Point(0, 0);
            fxFormaTarjeta1.Name = "fxFormaTarjeta1";
            fxFormaTarjeta1.Size = new Size(478, 296);
            fxFormaTarjeta1.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(59, 203);
            label7.Name = "label7";
            label7.Size = new Size(140, 24);
            label7.TabIndex = 9;
            label7.Text = "Tienda Perrona";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(3, 227);
            label8.Name = "label8";
            label8.Size = new Size(0, 24);
            label8.TabIndex = 10;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(3, 103);
            label9.Name = "label9";
            label9.Size = new Size(66, 24);
            label9.TabIndex = 11;
            label9.Text = "Correo";
            // 
            // lblNombreParaLaFactura
            // 
            lblNombreParaLaFactura.AutoSize = true;
            lblNombreParaLaFactura.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombreParaLaFactura.ForeColor = Color.White;
            lblNombreParaLaFactura.Location = new Point(219, 79);
            lblNombreParaLaFactura.Name = "lblNombreParaLaFactura";
            lblNombreParaLaFactura.Size = new Size(47, 24);
            lblNombreParaLaFactura.TabIndex = 12;
            lblNombreParaLaFactura.Text = "Var1";
            // 
            // lblCorreoParaLaFactura
            // 
            lblCorreoParaLaFactura.AutoSize = true;
            lblCorreoParaLaFactura.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblCorreoParaLaFactura.ForeColor = Color.White;
            lblCorreoParaLaFactura.Location = new Point(220, 103);
            lblCorreoParaLaFactura.Name = "lblCorreoParaLaFactura";
            lblCorreoParaLaFactura.Size = new Size(49, 24);
            lblCorreoParaLaFactura.TabIndex = 13;
            lblCorreoParaLaFactura.Text = "Var2";
            // 
            // lblCantidadProductosComprados
            // 
            lblCantidadProductosComprados.AutoSize = true;
            lblCantidadProductosComprados.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblCantidadProductosComprados.ForeColor = Color.White;
            lblCantidadProductosComprados.Location = new Point(219, 251);
            lblCantidadProductosComprados.Name = "lblCantidadProductosComprados";
            lblCantidadProductosComprados.Size = new Size(49, 24);
            lblCantidadProductosComprados.TabIndex = 14;
            lblCantidadProductosComprados.Text = "Var3";
            // 
            // lblTotalAPagar
            // 
            lblTotalAPagar.AutoSize = true;
            lblTotalAPagar.Font = new Font("Sitka Small", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalAPagar.ForeColor = Color.White;
            lblTotalAPagar.Location = new Point(219, 347);
            lblTotalAPagar.Name = "lblTotalAPagar";
            lblTotalAPagar.Size = new Size(50, 24);
            lblTotalAPagar.TabIndex = 15;
            lblTotalAPagar.Text = "Var4";
            // 
            // button1
            // 
            button1.BackColor = Color.WhiteSmoke;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(6, 404);
            button1.Name = "button1";
            button1.Size = new Size(263, 34);
            button1.TabIndex = 16;
            button1.Text = "Realizar el Pago";
            button1.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Sitka Small", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.DimGray;
            label10.Location = new Point(26, 6);
            label10.Name = "label10";
            label10.Size = new Size(210, 28);
            label10.TabIndex = 17;
            label10.Text = "PAGO POR TARJETA";
            // 
            // FacturacionFx
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 443);
            Controls.Add(panelContenedorFormasDePago);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FacturacionFx";
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panelContenedorFormasDePago.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label label2;
        private Panel panelContenedorFormasDePago;
        private FormsProducts.FxFormaTarjeta fxFormaDePagoTarjeta1;
        private Button btnCerrar;
        private FormsProducts.FxFormaTarjeta fxFormaTarjeta1;
        private PictureBox pictureBox2;
        private Label label3;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label lblTotalAPagar;
        private Label lblCantidadProductosComprados;
        private Label lblCorreoParaLaFactura;
        private Label lblNombreParaLaFactura;
        private Label label9;
        private Label label8;
        private Label label7;
        private Button button1;
        private Label label10;
    }
}