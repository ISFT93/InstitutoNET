using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Vista.Core;
using ISFDyT93.Negocio.Logica;

namespace ISFDyT93.Vista.Forms.Carreras
{
    public partial class FormVerCorrelativas : FormBase
    {
        #region ID pickers
        public int AnioCarreraId { get; set; }
        public int CarreraId { get; set; }
        #endregion

        #region Propiedades Privadas
        private AniosCarrerasModelo anioCarrera { get; set; }
        private AniosCarreraLogica aniosLogica { get; set; }
        private CarrerasModelo carrera { get; set; }
        private CarrerasLogica carrerasLogica { get; set; }
        private CorrelativasLogica correlativasLogica { get; set; }
        #endregion
        public FormVerCorrelativas()
        {
            this.correlativasLogica = new CorrelativasLogica();
            this.aniosLogica = new AniosCarreraLogica();
            this.carrerasLogica = new CarrerasLogica();
            InitializeComponent();
        }

        private void FormVerCorrelativas_Load(object sender, EventArgs e)
        {

            if (AnioCarreraId != 0)
            {
                this.anioCarrera = aniosLogica.ObtenerAnioCarrera(AnioCarreraId);
                this.Contenedor.SetTitulo($"Correlativas de {anioCarrera.AnioCarrera}° {anioCarrera.NombreCarrera}").SetVolver(() =>
                {
                    this.Contenedor.AbrirFormulario<FormAniosCarreras>(form =>
                    {
                        form.CarreraId = this.anioCarrera.CarreraId;
                    });
                }); ;
                dgvCorrelativas.DataSource = correlativasLogica.ObtenerCorrelativasAnio(AnioCarreraId);
            }

            else
            {
                this.carrera = carrerasLogica.ObtenerCarrera(this.CarreraId);
                this.Contenedor.SetTitulo($"Correlativas de {carrera.DescripcionCorta}").SetVolver(() => 
                {
                    this.Contenedor.AbrirFormulario<FormCarreras>();
                });
                dgvCorrelativas.DataSource = correlativasLogica.ObtenerCorrelativasCarrera(CarreraId);
            }
            
            

            LimpiarDuplicadas();
        }

        private void LimpiarDuplicadas()
        {
            string anterior = "";

            for (int i = 0; i < dgvCorrelativas.Rows.Count; i++)
            {
                var dato = dgvCorrelativas.Rows[i].Cells["Para cursar"].Value.ToString();
                if (dato == anterior)
                {
                    dgvCorrelativas.Rows[i].Cells["Para cursar"].Value = "";
                }
                else
                {
                    anterior = dato;
                }
            }
        }
    }
}
