namespace ISFDyT93.Vista.UserControls
{
    partial class uscPersonalGrid
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
            this.components = new System.ComponentModel.Container();
            this.flpContenedor = new System.Windows.Forms.FlowLayoutPanel();
            this.tmrDelay = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // flpContenedor
            // 
            this.flpContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpContenedor.Location = new System.Drawing.Point(0, 0);
            this.flpContenedor.Name = "flpContenedor";
            this.flpContenedor.Size = new System.Drawing.Size(117, 46);
            this.flpContenedor.TabIndex = 0;
            // 
            // tmrDelay
            // 
            this.tmrDelay.Enabled = true;
            this.tmrDelay.Tick += new System.EventHandler(this.tmrDelay_Tick);
            // 
            // uscPersonalGrid
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.flpContenedor);
            this.Name = "uscPersonalGrid";
            this.Size = new System.Drawing.Size(117, 46);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpContenedor;
        private System.Windows.Forms.Timer tmrDelay;
    }
}
