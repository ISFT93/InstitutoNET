using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Vista.Core;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ISFDyT93.Vista.Forms.Parametros;

namespace ISFDyT93.Vista.UserControls
{
    public partial class uscEsquemaEvaluacion : UserControl
    {
        public uscEsquemaEvaluacion()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            CrearMenuContextual();
            AsignarMenuAControles(this);
            OpcionDeshabilitar();
            OpcionHabilitar();
        }

        EsquemaEvaluacionLogica esquemasLogica =
            new EsquemaEvaluacionLogica();

        uscPersonalGrid usc;

        public IList<EsquemaEvaluacionModelo> esquemas;


        private void uscEsquemaEvaluacion_Load(
            object sender, EventArgs e)
        {
            this.Size = new Size(0, 0);
            this.BackColor = ThemeColor.GetColor();
            CargarGrilla();
        }


        #region MenuContextual

        private void CrearMenuContextual()
        {
            agregarEsquema.Click += (s, e) =>
            {
                using (FormAgregarEsquema frmAgregarEsquema = new FormAgregarEsquema())
                {
                    frmAgregarEsquema.StartPosition = FormStartPosition.CenterParent;

                    if (frmAgregarEsquema.ShowDialog() == DialogResult.OK)
                    {
                        RecargarTabla();
                    }
                }
            };

            deshabilitarEsquema.Click += (s, e) =>
            {
                using (FormEsquemasEstado frmEsquemasEstado = new FormEsquemasEstado(false))
                {
                    frmEsquemasEstado.StartPosition = FormStartPosition.CenterParent;

                    if (frmEsquemasEstado.ShowDialog() == DialogResult.OK)
                    {
                        RecargarTabla();
                    }
                }
            };

            habilitarEsquema.Click += (s, e) =>
            {
                using (FormEsquemasEstado frmEsquemasEstado = new FormEsquemasEstado(true))
                {
                    frmEsquemasEstado.StartPosition = FormStartPosition.CenterParent;

                    if (frmEsquemasEstado.ShowDialog() == DialogResult.OK)
                    {
                        RecargarTabla();
                    }
                }
            };
        }

        private void OpcionDeshabilitar()
        {
            if (esquemasLogica.EsquemasActivos() == true)
                MostrarOpcion(deshabilitarEsquema);
            else
                OcultarOpcion(deshabilitarEsquema);
        }

        private void OpcionHabilitar()
        {
            if (esquemasLogica.EsquemasInactivos() == true)
                MostrarOpcion(habilitarEsquema);
            else
                OcultarOpcion(habilitarEsquema);
        }

        private void OcultarOpcion(ToolStripMenuItem item)
        {
            item.Visible = false;
        }

        private void MostrarOpcion(ToolStripMenuItem item)
        {
            item.Visible = true;
        }

        private void RecargarTabla()
        {
            pnlContenedor.Controls.Clear();
            CargarGrilla();

            OpcionDeshabilitar();
            OpcionHabilitar();
        }

        private void AsignarMenuAControles(Control control)
        {
            control.ContextMenuStrip = menu;

            foreach (Control hijo in control.Controls)
            {
                AsignarMenuAControles(hijo);
            }
        }

        #endregion

        private void CargarGrilla()
        {
            uscPersonalGrid.AnchoCelda = 200;

            usc = new uscPersonalGrid(new string[]
            {
                "Indice",
                "Esquema",
                "Descripcion",
                "Descripcion Planilla",
                "Tipo Dato",
                "Requerido",
                "Activo"
            });

            pnlContenedor.Controls.Add(usc);

            esquemas = esquemasLogica.ObtenerEsquemas();

            foreach (EsquemaEvaluacionModelo modelo in esquemas)
            {
                usc.AgregarCelda(
                    modelo.indice.ToString(), modelo.CodEsq);

                usc.AgregarCelda(modelo.esquema);

                usc.AgregarCelda(modelo.ex_descripc);

                usc.AgregarCelda(
                    modelo.ex_descripcion_planilla);

                usc.AgregarCelda(modelo.ex_tipo_dat);

                usc.AgregarCelda(modelo.ex_requeric);

                usc.AgregarCelda(modelo.Activo);
            }

            AsignarMenuAControles(usc);

            Dimensionar();
        }

        private void Dimensionar()
        {
            this.Width = usc.Width + 50;
            this.Height = usc.Height + 45;
            usc.Dock = DockStyle.Fill;
        }

        private void picMover_Click(object sender, EventArgs e)
        {
            FormNotificacion.Mensaje(
                TipoNotificacion.Message,
                "Esquemas Disponibles\nPermite gestionar los esquemas de evaluacion"
            );
        }

        public void Guardar()
        {
            IList<EsquemaEvaluacionModelo> actualizarEsquemas =
                new List<EsquemaEvaluacionModelo>();

            foreach (var row in usc.Rows)
            {
                int indice;

                if (!int.TryParse(
                    Convert.ToString(row[0].Value), out indice))
                {
                    FormNotificacion.Mensaje(
                        TipoNotificacion.Error,
                        "El indice debe ser un numero entero"
                    );
                    return;
                }

                actualizarEsquemas.Add(
                    new EsquemaEvaluacionModelo()
                    {
                        CodEsq = row[0].Id,
                        indice = indice,

                        esquema =
                            Convert.ToString(row[1].Value),

                        ex_descripc =
                            Convert.ToString(row[2].Value),

                        ex_descripcion_planilla =
                            Convert.ToString(row[3].Value),

                        ex_tipo_dat =
                            Convert.ToString(row[4].Value),

                        ex_requeric =
                            Convert.ToBoolean(row[5].Value),

                        Activo =
                            Convert.ToBoolean(row[6].Value)
                    });
            }

            if (esquemasLogica.ActualizarEsquemas(
                actualizarEsquemas) > 0)
            {
                FormNotificacion.Mensaje(
                    TipoNotificacion.Success,
                    "Esquemas actualizados"
                );
            }
            else
            {
                FormNotificacion.Mensaje(
                    TipoNotificacion.Error,
                    "Error al actualizar"
                );
            }
        }
        private void lblTitulo_Click(object sender, EventArgs e)
        {
        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void pnlContenedor_MouseDown(object sender, MouseEventArgs e)
        {
        }
    }
}
