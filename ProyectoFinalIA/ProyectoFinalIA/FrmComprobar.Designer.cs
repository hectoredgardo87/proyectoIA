namespace ProyectoFinalIA
{
    partial class FrmComprobar
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSubir = new System.Windows.Forms.Button();
            this.BtnComprobar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido:";
            // 
            // BtnSubir
            // 
            this.BtnSubir.Location = new System.Drawing.Point(182, 105);
            this.BtnSubir.Name = "BtnSubir";
            this.BtnSubir.Size = new System.Drawing.Size(75, 23);
            this.BtnSubir.TabIndex = 2;
            this.BtnSubir.Text = "Subir Firma";
            this.BtnSubir.UseVisualStyleBackColor = true;
            this.BtnSubir.Click += new System.EventHandler(this.BtnSubir_Click);
            // 
            // BtnComprobar
            // 
            this.BtnComprobar.Location = new System.Drawing.Point(134, 272);
            this.BtnComprobar.Name = "BtnComprobar";
            this.BtnComprobar.Size = new System.Drawing.Size(200, 23);
            this.BtnComprobar.TabIndex = 3;
            this.BtnComprobar.Text = "Comprobar Validez de Firma ";
            this.BtnComprobar.UseVisualStyleBackColor = true;
            this.BtnComprobar.Click += new System.EventHandler(this.BtnComprobar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(102, 144);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(268, 102);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(182, 29);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(152, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(182, 68);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(152, 20);
            this.txtApellido.TabIndex = 6;
            // 
            // FrmComprobar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 307);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnComprobar);
            this.Controls.Add(this.BtnSubir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmComprobar";
            this.Text = "COMPROBACÍON";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnSubir;
        private System.Windows.Forms.Button BtnComprobar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
    }
}