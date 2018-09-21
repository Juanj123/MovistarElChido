namespace ProyectoMovistar
{
    partial class recuperarContrasenia
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
            this.btnRecuperar = new System.Windows.Forms.Button();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRecuperar
            // 
            this.btnRecuperar.Location = new System.Drawing.Point(580, 20);
            this.btnRecuperar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnRecuperar.Name = "btnRecuperar";
            this.btnRecuperar.Size = new System.Drawing.Size(133, 34);
            this.btnRecuperar.TabIndex = 7;
            this.btnRecuperar.Text = "Recuperar";
            this.btnRecuperar.UseVisualStyleBackColor = true;
            this.btnRecuperar.Click += new System.EventHandler(this.btnRecuperar_Click);
            // 
            // txtMensaje
            // 
            this.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensaje.ForeColor = System.Drawing.Color.Maroon;
            this.txtMensaje.Location = new System.Drawing.Point(21, 58);
            this.txtMensaje.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.ReadOnly = true;
            this.txtMensaje.Size = new System.Drawing.Size(523, 172);
            this.txtMensaje.TabIndex = 6;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(172, 20);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(371, 23);
            this.txtCorreo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ingresa tu gmail";
            // 
            // recuperarContrasenia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 278);
            this.Controls.Add(this.btnRecuperar);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "recuperarContrasenia";
            this.Text = "recuperarContrasenia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRecuperar;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label1;
    }
}