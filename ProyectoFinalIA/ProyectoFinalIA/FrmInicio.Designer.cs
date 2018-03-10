namespace ProyectoFinalIA
{
    partial class FrmInicio
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
            this.BtnEntrenamiento = new System.Windows.Forms.Button();
            this.BtnComprobacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnEntrenamiento
            // 
            this.BtnEntrenamiento.Location = new System.Drawing.Point(75, 27);
            this.BtnEntrenamiento.Name = "BtnEntrenamiento";
            this.BtnEntrenamiento.Size = new System.Drawing.Size(89, 45);
            this.BtnEntrenamiento.TabIndex = 0;
            this.BtnEntrenamiento.Text = "Entrenamiento";
            this.BtnEntrenamiento.UseVisualStyleBackColor = true;
            this.BtnEntrenamiento.Click += new System.EventHandler(this.BtnEntrenamiento_Click);
            // 
            // BtnComprobacion
            // 
            this.BtnComprobacion.Location = new System.Drawing.Point(75, 98);
            this.BtnComprobacion.Name = "BtnComprobacion";
            this.BtnComprobacion.Size = new System.Drawing.Size(89, 45);
            this.BtnComprobacion.TabIndex = 1;
            this.BtnComprobacion.Text = "Comprobación";
            this.BtnComprobacion.UseVisualStyleBackColor = true;
            this.BtnComprobacion.Click += new System.EventHandler(this.BtnComprobacion_Click);
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 186);
            this.Controls.Add(this.BtnComprobacion);
            this.Controls.Add(this.BtnEntrenamiento);
            this.Name = "FrmInicio";
            this.Text = "INICIO";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnEntrenamiento;
        private System.Windows.Forms.Button BtnComprobacion;
    }
}