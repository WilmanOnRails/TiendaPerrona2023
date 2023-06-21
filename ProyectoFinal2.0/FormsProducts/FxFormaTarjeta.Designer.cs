namespace ProyectoFinal2._0.FormsProducts
{
    partial class FxFormaTarjeta
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCodigoDeSeguridad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExpiracion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreTitular = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnValidarTarjeta = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtCodigoDeSeguridad);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtExpiracion);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNumeroTarjeta);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNombreTitular);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(18, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 183);
            this.panel1.TabIndex = 0;
            // 
            // txtCodigoDeSeguridad
            // 
            this.txtCodigoDeSeguridad.Location = new System.Drawing.Point(316, 46);
            this.txtCodigoDeSeguridad.Name = "txtCodigoDeSeguridad";
            this.txtCodigoDeSeguridad.Size = new System.Drawing.Size(117, 23);
            this.txtCodigoDeSeguridad.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(330, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "C. de seguridad";
            // 
            // txtExpiracion
            // 
            this.txtExpiracion.Location = new System.Drawing.Point(316, 123);
            this.txtExpiracion.Name = "txtExpiracion";
            this.txtExpiracion.Size = new System.Drawing.Size(110, 23);
            this.txtExpiracion.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(316, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Expiracion (mm/yy )";
            // 
            // txtNumeroTarjeta
            // 
            this.txtNumeroTarjeta.Location = new System.Drawing.Point(12, 123);
            this.txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            this.txtNumeroTarjeta.Size = new System.Drawing.Size(266, 23);
            this.txtNumeroTarjeta.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Numero de la tarjeta";
            // 
            // txtNombreTitular
            // 
            this.txtNombreTitular.Location = new System.Drawing.Point(12, 46);
            this.txtNombreTitular.Name = "txtNombreTitular";
            this.txtNombreTitular.Size = new System.Drawing.Size(266, 23);
            this.txtNombreTitular.TabIndex = 10;
            this.txtNombreTitular.TextChanged += new System.EventHandler(this.txtNombreTitular_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nombre del titular";
            // 
            // btnValidarTarjeta
            // 
            this.btnValidarTarjeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(41)))), ((int)(((byte)(210)))));
            this.btnValidarTarjeta.FlatAppearance.BorderSize = 0;
            this.btnValidarTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValidarTarjeta.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnValidarTarjeta.ForeColor = System.Drawing.Color.White;
            this.btnValidarTarjeta.Location = new System.Drawing.Point(328, 234);
            this.btnValidarTarjeta.Name = "btnValidarTarjeta";
            this.btnValidarTarjeta.Size = new System.Drawing.Size(154, 34);
            this.btnValidarTarjeta.TabIndex = 7;
            this.btnValidarTarjeta.Text = "Validar";
            this.btnValidarTarjeta.UseVisualStyleBackColor = false;
            this.btnValidarTarjeta.Click += new System.EventHandler(this.btnValidarTarjeta_Click);
            // 
            // FxFormaTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnValidarTarjeta);
            this.Controls.Add(this.panel1);
            this.Name = "FxFormaTarjeta";
            this.Size = new System.Drawing.Size(508, 296);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox3;
        private TextBox txtCodigoDeSeguridad;
        private Label label4;
        private TextBox txtExpiracion;
        private Label label3;
        private TextBox txtNumeroTarjeta;
        private Label label2;
        private TextBox txtNombreTitular;
        private Label label1;
        private Button btnValidarTarjeta;
    }
}
