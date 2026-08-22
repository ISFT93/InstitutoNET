using System;
using System.Drawing;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Forms.Carreras
{
    partial class FolioExamenControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblSistema;
        private System.Windows.Forms.Label lblLibro;
        private System.Windows.Forms.Label lblNumeroLibro;

        private System.Windows.Forms.Panel pnlLineaSuperior;
        private System.Windows.Forms.Panel pnlLineaRoja;
        private System.Windows.Forms.Panel pnlLineaInferior;

        private System.Windows.Forms.Label lblTituloFolio;

        private System.Windows.Forms.Panel pnlFolioActual;
        private System.Windows.Forms.Label lblFolioActual;

        private System.Windows.Forms.Panel pnlTotalFolios;
        private System.Windows.Forms.Label lblTotalFolios;

        private System.Windows.Forms.Button btnNoMostrar;
        private System.Windows.Forms.Button btnAceptar;

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
            this.lblSistema = new System.Windows.Forms.Label();
            this.lblLibro = new System.Windows.Forms.Label();
            this.lblNumeroLibro = new System.Windows.Forms.Label();
            this.pnlLineaSuperior = new System.Windows.Forms.Panel();
            this.pnlLineaRoja = new System.Windows.Forms.Panel();
            this.pnlLineaInferior = new System.Windows.Forms.Panel();
            this.lblTituloFolio = new System.Windows.Forms.Label();
            this.pnlFolioActual = new System.Windows.Forms.Panel();
            this.lblFolioActual = new System.Windows.Forms.Label();
            this.pnlTotalFolios = new System.Windows.Forms.Panel();
            this.lblTotalFolios = new System.Windows.Forms.Label();
            this.btnNoMostrar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.pnlFolioActual.SuspendLayout();
            this.pnlTotalFolios.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSistema
            // 
            this.lblSistema.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSistema.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSistema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblSistema.Location = new System.Drawing.Point(0, 1);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(433, 30);
            this.lblSistema.TabIndex = 0;
            this.lblSistema.Text = "Sistemas";
            this.lblSistema.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLibro
            // 
            this.lblLibro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.lblLibro.Location = new System.Drawing.Point(7, 36);
            this.lblLibro.Name = "lblLibro";
            this.lblLibro.Size = new System.Drawing.Size(210, 27);
            this.lblLibro.TabIndex = 2;
            this.lblLibro.Text = "Libro de Acta de Examenes";
            this.lblLibro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNumeroLibro
            // 
            this.lblNumeroLibro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.lblNumeroLibro.Location = new System.Drawing.Point(215, 36);
            this.lblNumeroLibro.Name = "lblNumeroLibro";
            this.lblNumeroLibro.Size = new System.Drawing.Size(50, 27);
            this.lblNumeroLibro.TabIndex = 3;
            this.lblNumeroLibro.Text = "2";
            this.lblNumeroLibro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLineaSuperior
            // 
            this.pnlLineaSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlLineaSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLineaSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlLineaSuperior.Name = "pnlLineaSuperior";
            this.pnlLineaSuperior.Size = new System.Drawing.Size(433, 1);
            this.pnlLineaSuperior.TabIndex = 1;
            // 
            // pnlLineaRoja
            // 
            this.pnlLineaRoja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlLineaRoja.Location = new System.Drawing.Point(0, 66);
            this.pnlLineaRoja.Name = "pnlLineaRoja";
            this.pnlLineaRoja.Size = new System.Drawing.Size(430, 2);
            this.pnlLineaRoja.TabIndex = 4;
            // 
            // pnlLineaInferior
            // 
            this.pnlLineaInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pnlLineaInferior.Location = new System.Drawing.Point(0, 168);
            this.pnlLineaInferior.Name = "pnlLineaInferior";
            this.pnlLineaInferior.Size = new System.Drawing.Size(430, 2);
            this.pnlLineaInferior.TabIndex = 10;
            // 
            // lblTituloFolio
            // 
            this.lblTituloFolio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloFolio.Location = new System.Drawing.Point(8, 77);
            this.lblTituloFolio.Name = "lblTituloFolio";
            this.lblTituloFolio.Size = new System.Drawing.Size(120, 30);
            this.lblTituloFolio.TabIndex = 5;
            this.lblTituloFolio.Text = "Folio";
            this.lblTituloFolio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFolioActual
            // 
            this.pnlFolioActual.BackColor = System.Drawing.Color.White;
            this.pnlFolioActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFolioActual.Controls.Add(this.lblFolioActual);
            this.pnlFolioActual.Location = new System.Drawing.Point(168, 72);
            this.pnlFolioActual.Name = "pnlFolioActual";
            this.pnlFolioActual.Size = new System.Drawing.Size(138, 36);
            this.pnlFolioActual.TabIndex = 6;
            // 
            // lblFolioActual
            // 
            this.lblFolioActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFolioActual.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFolioActual.ForeColor = System.Drawing.Color.Red;
            this.lblFolioActual.Location = new System.Drawing.Point(0, 0);
            this.lblFolioActual.Name = "lblFolioActual";
            this.lblFolioActual.Size = new System.Drawing.Size(136, 34);
            this.lblFolioActual.TabIndex = 0;
            this.lblFolioActual.Text = "182";
            this.lblFolioActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTotalFolios
            // 
            this.pnlTotalFolios.BackColor = System.Drawing.Color.White;
            this.pnlTotalFolios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotalFolios.Controls.Add(this.lblTotalFolios);
            this.pnlTotalFolios.Location = new System.Drawing.Point(305, 72);
            this.pnlTotalFolios.Name = "pnlTotalFolios";
            this.pnlTotalFolios.Size = new System.Drawing.Size(125, 36);
            this.pnlTotalFolios.TabIndex = 7;
            // 
            // lblTotalFolios
            // 
            this.lblTotalFolios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalFolios.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalFolios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.lblTotalFolios.Location = new System.Drawing.Point(0, 0);
            this.lblTotalFolios.Name = "lblTotalFolios";
            this.lblTotalFolios.Size = new System.Drawing.Size(123, 34);
            this.lblTotalFolios.TabIndex = 0;
            this.lblTotalFolios.Text = "200";
            this.lblTotalFolios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNoMostrar
            // 
            this.btnNoMostrar.BackColor = System.Drawing.Color.White;
            this.btnNoMostrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNoMostrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnNoMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoMostrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNoMostrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnNoMostrar.Location = new System.Drawing.Point(101, 126);
            this.btnNoMostrar.Name = "btnNoMostrar";
            this.btnNoMostrar.Size = new System.Drawing.Size(207, 34);
            this.btnNoMostrar.TabIndex = 8;
            this.btnNoMostrar.Text = "No mostrar nuevamente";
            this.btnNoMostrar.UseVisualStyleBackColor = false;
            this.btnNoMostrar.Click += new System.EventHandler(this.btnNoMostrar_Click_1);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.White;
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnAceptar.Location = new System.Drawing.Point(317, 126);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(80, 34);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click_1);
            // 
            // FolioExamenControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblSistema);
            this.Controls.Add(this.pnlLineaSuperior);
            this.Controls.Add(this.lblLibro);
            this.Controls.Add(this.lblNumeroLibro);
            this.Controls.Add(this.pnlLineaRoja);
            this.Controls.Add(this.lblTituloFolio);
            this.Controls.Add(this.pnlFolioActual);
            this.Controls.Add(this.pnlTotalFolios);
            this.Controls.Add(this.btnNoMostrar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.pnlLineaInferior);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FolioExamenControl";
            this.Size = new System.Drawing.Size(433, 180);
            this.pnlFolioActual.ResumeLayout(false);
            this.pnlTotalFolios.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
