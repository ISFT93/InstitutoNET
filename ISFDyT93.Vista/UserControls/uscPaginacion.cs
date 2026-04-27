using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacionAdmin.Controls
{
    public partial class uscPaginacion : UserControl
    {
        public uscPaginacion()
        {
            InitializeComponent();
            BuscarPaginacion();            
        }

        private int Paginacion { get; set; } = 100;
        public DataTable SalidaDatos { get; set; }
        public Action Recargar { get; set; }
        public DataGridView dataGridView { get; set; }
        public DataTable EntradaDatos
        {
            get { return _entradaDatos; }
            set
            {
                _entradaDatos = value;
                if (_entradaDatos != null)
                {
                    cantidadFilas = _entradaDatos.Rows.Count;
                    cantidadPartes =  (int)Math.Ceiling((double)(cantidadFilas / (double)Paginacion));
                    if (cantidadPartes == 0) cantidadPartes = 1;
                    setearContador();
                    CambiarPagina(1);
                }
            }
        }
        
        private DataTable _entradaDatos;
        private int cantidadPartes = 0;
        private int paginaActual = 1;
        private int cantidadFilas = 0;
        ParametrosModelo parametrosModelo { get; set; }

        private ParametrosLogica parametrosLogica = new ParametrosLogica();

        private void uscPaginacion_Load(object sender, EventArgs e)
        {
            EscalarControl();
        }
        private void uscPaginacion_SizeChanged(object sender, EventArgs e)
        {
            EscalarControl();
        }
        private void BuscarPaginacion()
        {
            parametrosModelo = parametrosLogica.ObtenerParametro(NombreParametro.Paginacion);
            if (parametrosModelo != null)
                Paginacion = Convert.ToInt32(parametrosModelo.Valor);
        }
        private void EscalarControl()
        {
            int btnSizes = this.Width / 5;

            panel1.Height = 37;
            btnIzquierda.Width = btnSizes;
            btnPrimero.Width = btnSizes;
            btnSegundo.Width = btnSizes;
            btnTercero.Width = btnSizes;
            btnDerecha.Width = btnSizes;
        }       
        private void Convertir()
        {  
            SalidaDatos = EntradaDatos.Copy();
            SalidaDatos.Rows.Clear();
            
            int fila = 0;
            int minimo = (paginaActual * Paginacion) - Paginacion;
            int maximo = paginaActual * Paginacion;
            foreach (DataRow dr in _entradaDatos.Rows)
            {
                if (fila > maximo) break;

                if (fila < maximo & fila >= minimo)
                {
                    SalidaDatos.ImportRow(dr);
                }                
                fila++;                
            }
            dataGridView.DataSource = SalidaDatos;
        }
        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            CambiarPagina(paginaActual - 1);
        }
        private void btnDerecha_Click(object sender, EventArgs e)
        {
            CambiarPagina(paginaActual + 1);
        }
        private void btnNumeros(object sender, EventArgs e)
        {
            string btn = ((Button)sender).Text;
            if (btn != "...")
                CambiarPagina(Convert.ToInt32(btn));
        }
        private void CambiarPagina(int pagina)
        {
            if(pagina >= 1 && pagina <= cantidadPartes)
            {                
                paginaActual = pagina;
                if(pagina >= 4)
                {
                    btnPrimero.Text = (pagina - 1).ToString();
                    btnSegundo.Text = pagina.ToString();
                    if (pagina == cantidadPartes) btnTercero.Text = "...";
                    else btnTercero.Text = (pagina + 1).ToString();
                }
                else
                {
                    btnPrimero.Text = "1";
                    btnSegundo.Text = "2";
                    btnTercero.Text = "3";
                }
                setearContador();
                Convertir();
            }
            Seleccionar();
        }
        private void Seleccionar()
        {
            btnPrimero.BackColor = Color.White;
            btnSegundo.BackColor = Color.White;
            btnTercero.BackColor = Color.White;
            if (btnPrimero.Text == paginaActual.ToString())
            {
                btnPrimero.Select();
                btnPrimero.BackColor = Color.FromArgb(156, 219, 224);
            }
            else if (btnSegundo.Text == paginaActual.ToString())
            {
                btnSegundo.Select();
                btnSegundo.BackColor = Color.FromArgb(156, 219, 224);
            }
            else
            {
                btnTercero.Select();
                btnTercero.BackColor = Color.FromArgb(156, 219, 224);
            }     
            
        }
        private void setearContador()
        {
            lblPagina.Text = $"Pagina: {paginaActual}/{cantidadPartes} - registros: {cantidadFilas}";
        }
    }
}
