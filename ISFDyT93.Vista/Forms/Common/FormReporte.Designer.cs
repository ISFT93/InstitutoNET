namespace ISFDyT93.Vista.Forms.Common
{
    partial class FormReporte
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.rvwReportes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.layoutReporte = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.barraAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnImprimir = new FontAwesome.Sharp.IconButton();
            this.btnExportarPdf = new FontAwesome.Sharp.IconButton();
            this.btnAjustarPagina = new FontAwesome.Sharp.IconButton();
            this.btnAjustarAncho = new FontAwesome.Sharp.IconButton();
            this.lblEstado = new System.Windows.Forms.Label();
            this.layoutReporte.SuspendLayout();
            this.barraAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // rvwReportes
            // 
            this.rvwReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvwReportes.Location = new System.Drawing.Point(12, 90);
            this.rvwReportes.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.rvwReportes.Name = "rvwReportes";
            this.rvwReportes.ServerReport.BearerToken = null;
            this.rvwReportes.Size = new System.Drawing.Size(976, 529);
            this.rvwReportes.TabIndex = 2;
            // 
            // layoutReporte
            // 
            this.layoutReporte.ColumnCount = 1;
            this.layoutReporte.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutReporte.Controls.Add(this.lblTitulo, 0, 0);
            this.layoutReporte.Controls.Add(this.barraAcciones, 0, 1);
            this.layoutReporte.Controls.Add(this.rvwReportes, 0, 2);
            this.layoutReporte.Controls.Add(this.lblEstado, 0, 3);
            this.layoutReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutReporte.Location = new System.Drawing.Point(0, 0);
            this.layoutReporte.Margin = new System.Windows.Forms.Padding(0);
            this.layoutReporte.Name = "layoutReporte";
            this.layoutReporte.RowCount = 4;
            this.layoutReporte.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutReporte.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutReporte.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutReporte.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutReporte.Size = new System.Drawing.Size(1000, 650);
            this.layoutReporte.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.lblTitulo.Size = new System.Drawing.Size(1000, 49);
            this.lblTitulo.TabIndex = 0;
            // 
            // barraAcciones
            // 
            this.barraAcciones.AutoSize = true;
            this.barraAcciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.barraAcciones.Controls.Add(this.btnImprimir);
            this.barraAcciones.Controls.Add(this.btnExportarPdf);
            this.barraAcciones.Controls.Add(this.btnAjustarPagina);
            this.barraAcciones.Controls.Add(this.btnAjustarAncho);
            this.barraAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barraAcciones.Location = new System.Drawing.Point(0, 49);
            this.barraAcciones.Margin = new System.Windows.Forms.Padding(0);
            this.barraAcciones.Name = "barraAcciones";
            this.barraAcciones.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.barraAcciones.Size = new System.Drawing.Size(1000, 41);
            this.barraAcciones.TabIndex = 1;
            // 
            // btnImprimir
            // 
            this.btnImprimir.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnImprimir.IconColor = System.Drawing.Color.Black;
            this.btnImprimir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImprimir.Location = new System.Drawing.Point(13, 9);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 0;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnExportarPdf
            // 
            this.btnExportarPdf.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnExportarPdf.IconColor = System.Drawing.Color.Black;
            this.btnExportarPdf.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportarPdf.Location = new System.Drawing.Point(94, 9);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new System.Drawing.Size(75, 23);
            this.btnExportarPdf.TabIndex = 1;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);
            // 
            // btnAjustarPagina
            // 
            this.btnAjustarPagina.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnAjustarPagina.IconColor = System.Drawing.Color.Black;
            this.btnAjustarPagina.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAjustarPagina.Location = new System.Drawing.Point(175, 9);
            this.btnAjustarPagina.Name = "btnAjustarPagina";
            this.btnAjustarPagina.Size = new System.Drawing.Size(75, 23);
            this.btnAjustarPagina.TabIndex = 2;
            this.btnAjustarPagina.Click += new System.EventHandler(this.btnAjustarPagina_Click);
            // 
            // btnAjustarAncho
            // 
            this.btnAjustarAncho.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnAjustarAncho.IconColor = System.Drawing.Color.Black;
            this.btnAjustarAncho.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAjustarAncho.Location = new System.Drawing.Point(256, 9);
            this.btnAjustarAncho.Name = "btnAjustarAncho";
            this.btnAjustarAncho.Size = new System.Drawing.Size(75, 23);
            this.btnAjustarAncho.TabIndex = 3;
            this.btnAjustarAncho.Click += new System.EventHandler(this.btnAjustarAncho_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstado.Location = new System.Drawing.Point(3, 619);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
            this.lblEstado.Size = new System.Drawing.Size(994, 31);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Preparando reporte…";
            // 
            // FormReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.layoutReporte);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FormReporte";
            this.Text = "Vista de impresión";
            this.Load += new System.EventHandler(this.FormReporte_Load);
            this.layoutReporte.ResumeLayout(false);
            this.layoutReporte.PerformLayout();
            this.barraAcciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvwReportes;
        private System.Windows.Forms.TableLayoutPanel layoutReporte;
        private System.Windows.Forms.FlowLayoutPanel barraAcciones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEstado;
        private FontAwesome.Sharp.IconButton btnImprimir;
        private FontAwesome.Sharp.IconButton btnExportarPdf;
        private FontAwesome.Sharp.IconButton btnAjustarPagina;
        private FontAwesome.Sharp.IconButton btnAjustarAncho;
    }
}
