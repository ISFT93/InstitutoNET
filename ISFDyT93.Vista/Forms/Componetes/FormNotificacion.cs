using ISFDyT93.Datos;
using ISFDyT93.Vista.Core.Enums;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Forms.Componetes
{
    public partial class FormNotificacion : Form
    {
        private static FormNotificacion formNotificacion {get; set;}
        public FormNotificacion(TipoNotificacion TipoNotificacion, string Mensaje, ContentAlignment Alineacion, int Tiempo)
        {            
            InitializeComponent();
            this.Tipo = TipoNotificacion;
            this.Alineacion = Alineacion;
            lblMensaje.Text = Mensaje;
            this.Tiempo = Tiempo;
        }
        public FormNotificacion(TipoNotificacion TipoNotificacion, string Mensaje, Point Ubicacion, int Tiempo = 1000)
        {
            InitializeComponent();
            this.Tipo = TipoNotificacion;
            this.Ubicacion = Ubicacion;
            lblMensaje.Text = Mensaje;
            this.Tiempo = Tiempo;
            puntual = true;
        }

        #region Propiedades

        private bool puntual = false;
        private readonly int margin = 50;
        private readonly int panelLateral = 200;
        private readonly int panelSuperior = 50;

        private int VerticalCenter { get => (panelLateral / 2) + Form.Left + (Form.Width / 2) - (this.Width / 2); }
        private int HorizontalCenter { get => Form.Top + (Form.Height / 2); }
        private int LateralRigth { get => Form.Left + Form.Width - margin - this.Width; }
        private int LateralLeft { get => panelLateral + Form.Left + margin; }
        private int LateralTop { get => Form.Top + panelSuperior + margin; }
        private int LateralBottom { get => Form.Top + Form.Height - margin - this.Height; }

        private Point Ubicacion { get; }
        private int Tiempo { get; set; }
        private Form Form { get; set; } = Cache.FormPrincipal;
        private ContentAlignment Alineacion { get; set; }
        private TipoNotificacion Tipo
        {
            set
            {
                switch (value)
                {
                    case TipoNotificacion.Success:
                        this.BackColor = Color.FromArgb(0, 192, 0);
                        break;
                    case TipoNotificacion.Error:
                        this.BackColor = Color.Red;
                        break;
                    case TipoNotificacion.Information:
                        this.BackColor = Color.FromArgb(10, 88, 209);
                        break;
                    case TipoNotificacion.Warning:
                        this.BackColor = Color.Orange;
                        break;
                    case TipoNotificacion.Message:
                        this.BackColor = Color.MediumSlateBlue;
                        break;
                }
            }
        }

        #endregion

        #region Eventos
        private void FormNotificacion_Load(object sender, EventArgs e)
        {
            if (formNotificacion != null) formNotificacion.Close();
            formNotificacion = this;            
            Estilo();
            Ubicar();
            this.BringToFront();
            this.TopMost = true;
        }
       
        private void FormNotificacion_Click(object sender, EventArgs e)
        {
            tmrTiempo.Enabled = false;
            this.Close();
        }

        private void lblMensaje_Click(object sender, EventArgs e)
        {
            tmrTiempo.Enabled = false;
            this.Close();
        }
        private void tmrTiempo_Tick(object sender, EventArgs e)
        {
            Tiempo -= 10;
            Ubicar();
            if (Tiempo <= 0)
            {
                tmrTiempo.Enabled = false;
                this.Close();
            }
        }
        #endregion

        #region Metodos
        public static void Mensaje(TipoNotificacion TipoNotificacion, string Mensaje, ContentAlignment Alineacion = ContentAlignment.BottomCenter, int Tiempo = 3000)
        {
            if (Tiempo > 0)
            {
                new FormNotificacion(TipoNotificacion, Mensaje, Alineacion, Tiempo).Show();
            }
        }
        private void Estilo()
        {
            this.Width = lblMensaje.Width + 20;
            this.Height = lblMensaje.Height + 20;
            lblMensaje.Left = 10;
            lblMensaje.Top = 10;
        }
        private void Ubicar()
        {
            if (puntual)
            {
                this.Left = Form.Left + Ubicacion.X;
                this.Top = Form.Left + Ubicacion.Y;
            }
            else
                switch (Alineacion)
                {
                    //Top
                    case ContentAlignment.TopLeft:
                        this.Left = LateralLeft;
                        this.Top = LateralTop;
                        break;
                    case ContentAlignment.TopCenter:
                        this.Left = VerticalCenter;
                        this.Top = LateralTop;
                        break;
                    case ContentAlignment.TopRight:
                        this.Left = LateralRigth;
                        this.Top = LateralTop;
                        break;
                    //Middle
                    case ContentAlignment.MiddleLeft:
                        this.Left = LateralLeft;
                        this.Top = HorizontalCenter;
                        break;
                    case ContentAlignment.MiddleCenter:
                        this.Left = VerticalCenter;
                        this.Top = HorizontalCenter;
                        break;
                    case ContentAlignment.MiddleRight:
                        this.Left = LateralRigth;
                        this.Top = HorizontalCenter;
                        break;
                    //Bottom
                    case ContentAlignment.BottomLeft:
                        this.Left = LateralLeft;
                        this.Top = LateralBottom;
                        break;
                    case ContentAlignment.BottomCenter:
                        this.Left = VerticalCenter;
                        this.Top = LateralBottom;
                        break;
                    case ContentAlignment.BottomRight:
                        this.Left = LateralRigth;
                        this.Top = LateralBottom;
                        break;
                }
        }
        #endregion

        #region Esquinas Redondas
        private int borderRadius = 5;
        private int borderSize = 1;
        private void FormNotificacion_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, this.BackColor, borderSize);
        }
        private GraphicsPath GetRoundedPath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
        private void FormRegionAndBorder(Form form, float radius, Graphics graph, Color borderColor, float borderSize)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = GetRoundedPath(form.ClientRectangle, radius))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                using (Matrix transform = new Matrix())
                {                    
                    graph.SmoothingMode = SmoothingMode.HighQuality;
                    form.Region = new Region(roundPath);
                    if (borderSize >= 1)
                    {
                        Rectangle rect = form.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);
                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);
                        graph.Transform = transform;
                        graph.DrawPath(penBorder, roundPath);
                    }
                }
            }
        }
        #endregion

        
    }
}
