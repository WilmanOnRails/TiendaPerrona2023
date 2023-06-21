namespace ProyectoFinal2._0
{
    partial class FxInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxInicio));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Swis721 BlkEx BT", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(123, 41, 210);
            label1.Location = new Point(16, 85);
            label1.Name = "label1";
            label1.Size = new Size(374, 45);
            label1.TabIndex = 0;
            label1.Text = "US$1,974.99";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Symbol", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(123, 41, 210);
            label2.Location = new Point(16, 53);
            label2.Name = "label2";
            label2.Size = new Size(180, 32);
            label2.TabIndex = 1;
            label2.Text = "Proximamente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Swis721 BT", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(16, 174);
            label3.Name = "label3";
            label3.Size = new Size(409, 171);
            label3.TabIndex = 2;
            label3.Text = resources.GetString("label3.Text");
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Swis721 BlkCn BT", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(27, 176);
            label4.Name = "label4";
            label4.Size = new Size(0, 25);
            label4.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Swis721 Blk BT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(16, 130);
            label5.Name = "label5";
            label5.Size = new Size(263, 29);
            label5.TabIndex = 4;
            label5.Text = "GeForce RTX 4090 ";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = Properties.Resources.rtx4090;
            pictureBox1.Location = new Point(431, 96);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(295, 256);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(123, 41, 210);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(16, 365);
            button1.Name = "button1";
            button1.Size = new Size(263, 34);
            button1.TabIndex = 6;
            button1.Text = "Reservar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FxInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "FxInicio";
            Size = new Size(746, 429);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private PictureBox pictureBox1;
        private Button button1;
    }
}
