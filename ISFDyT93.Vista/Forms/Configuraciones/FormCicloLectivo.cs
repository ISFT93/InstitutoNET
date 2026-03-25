
using System;
using System.Data;
using System.Windows.Forms;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Vista.Core;
using ISFDyT93.Negocio;
using ISFDyT93.Vista.Core.Enums;
using System.Collections.Generic;
using ISFDyT93.Vista.Forms.Componetes;

namespace ISFDyT93.Vista.Forms.Configuraciones
{
    public partial class FormCicloLectivo : FormBase
    {
        CicloLectivosLogica cicloLectivosLogica;
        MesasFinalesLogica mesasFinalesLogica;

        #region Propiedades Publicas
        private TipoAccion Accion { get; set; }

        private int CicloLectivoId { get; set; }
        #endregion

        //Validaciones validaciones;
        public FormCicloLectivo()
        {
            this.cicloLectivosLogica = new CicloLectivosLogica();            
            this.mesasFinalesLogica = new MesasFinalesLogica();
            InitializeComponent();
            Refrescar();
        }

        public void Refrescar()
        {           
            dgvCicloLectivo.ContextMenuStrip = cmsCicloLectivo;
            dgvCicloLectivo.DataSource = this.cicloLectivosLogica.ObtenerCargaGrillaCicloLectivo();
            dgvCicloLectivo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCicloLectivo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //AnioLectivo, FechaInicio, FechaCierre, Activo
            List<string> columnasVisibles = new List<string>() { "AnioLectivo", "FechaInicio", "FechaCierre", "Activo" };
            foreach(DataGridViewColumn column in dgvCicloLectivo.Columns)
            {
                if(columnasVisibles.IndexOf(column.Name) == -1)
                {
                    column.Visible = false;
                }
            }
        }

        private void dgvCicloLectivo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvCicloLectivo.HitTest(e.X, e.Y);
               
                if (info.Type == DataGridViewHitTestType.Cell && info.RowIndex > -1)
                {
                    if (info.RowIndex == 0)//modificar
                    {
                        tsmAgregarCicloLectivo.Visible = false;
                        tsmModificarCicloLectivo.Visible = true;
                        tsmVerCicloLectivo.Visible = true;
                        //tsmInscripcionCicloLectivo.Visible = true;
                        //tsmCargaCursadas.Visible = true;
                    }
                    else//ver
                    {
                        tsmAgregarCicloLectivo.Visible = false;
                        tsmModificarCicloLectivo.Visible = false ;
                        tsmVerCicloLectivo.Visible = true;
                        //tsmInscripcionCicloLectivo.Visible = true;
                        //tsmCargaCursadas.Visible = true;
                    }
                    
                    CicloLectivoId = Convert.ToInt32(dgvCicloLectivo.Rows[info.RowIndex].Cells["AnioLectivo"].FormattedValue.ToString());
                }               
                else//agregar
                {        
                    tsmAgregarCicloLectivo.Visible = true;
                    tsmModificarCicloLectivo.Visible = false;
                    tsmVerCicloLectivo.Visible = false;
                    //tsmInscripcionCicloLectivo.Visible = false;
                    //tsmCargaCursadas.Visible = false;
                }
               
            }
        }

        private void tsmAgregarCicloLectivo_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormAgregarModificarCicloLectivo>(form =>
            {
                form.CicloLectivoId = this.CicloLectivoId;
                form.Accion = TipoAccion.Agregar;
            });
        }

        private void tsmModificarCicloLectivo_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormAgregarModificarCicloLectivo>(form =>
            {
                form.CicloLectivoId = this.CicloLectivoId;
                form.Accion = TipoAccion.Modificar;
            });
        }

        private void FormCicloLectivo_Load(object sender, EventArgs e)
        {
            this.Contenedor.SetTitulo("Ciclo Lectivo");
        }

        private void tsmVerCicloLectivo_Click(object sender, EventArgs e)
        {
            Contenedor.AbrirFormulario<FormAgregarModificarCicloLectivo>(form =>
            {
                form.CicloLectivoId = this.CicloLectivoId;
                form.Accion = TipoAccion.Ver;
            });
        }

        //private void tsmInscripcionCicloLectivo_Click(object sender, EventArgs e)
        //{
        //    Contenedor.AbrirFormulario<FormInscripcionCicloLectivo>(form =>
        //    {
        //        form.CicloLectivoId = this.CicloLectivoId;
        //        form.Accion = TipoAccion.Inscripcion;
        //    });
        //}

        private void tsmCargaCursadas_Click(object sender, EventArgs e)
        {
            if (this.CicloLectivoId > 0)
            {
                var result = this.cicloLectivosLogica.CargarCursadas(this.CicloLectivoId);

                if (result > 0)
                {
                    FormNotificacion.Mensaje(TipoNotificacion.Success, "Cursadas Generadas Correctamente", System.Drawing.ContentAlignment.BottomCenter);
                }
            }
        }
    }
}