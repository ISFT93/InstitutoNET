using System;
using System.Windows.Forms;
using ISFDyT93.Datos.Modelos;
using ISFDyT93.Negocio.Logica;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Vista.Core;
using System.Data;
using System.Linq;
using ISFDyT93.Datos.Enums;
using ISFDyT93.Vista.Core.Enums;

namespace ISFDyT93.Vista.Forms.Personal
{
    public partial class FormAgregarModificarPersonal : FormBase
    {
        #region Propiedades Públicas
        public int PersonalId { get; set; }
        public TipoAccion Accion { get; set; }
        #endregion

        #region Propiedades Privadas
        private PersonalLogica personalLogica { get; set; }

        private PersonalModelo Modelo { get; set; }
        #endregion
        
        byte Tramo;
        
        public FormAgregarModificarPersonal()
        {
            this.DoubleBuffered = true;
            personalLogica = new PersonalLogica();            
            InitializeComponent();
        }

        private void FormAgregarProfesores_Load(object sender, EventArgs e)
        {
            if(this.Accion == TipoAccion.Agregar)
            {
                this.Contenedor.SetTitulo("Agregar Personal");
            }
            else if (this.Accion == TipoAccion.Modificar)
            {
                this.Contenedor.SetTitulo("Modificar Personal");
            }
            else if(this.Accion == TipoAccion.Ver)
            {
                this.Contenedor.SetTitulo("Ver Personal");
                this.DeshabilitarControles();
            }

            this.Contenedor.SetVolver(() => {
                this.Contenedor.AbrirFormulario<FormPersonal>();
            });

            this.cmbTramoPedagogico.DataSource = this.personalLogica.ObtenerSiNo();
            this.cmbTramoPedagogico.DisplayMember = "Descripcion";
            this.cmbTramoPedagogico.ValueMember = "Codigo";

            if (this.PersonalId > 0)
            {
                this.Modelo = personalLogica.ObtenerPersonal(this.PersonalId);

                this.MapToForm<PersonalModelo>(this.Modelo);

                if (this.Modelo.PersonalEstadoId == (int)PersonalEstado.Borrador)
                {
                    txtNombre.Enabled = false;
                    txtApellido.Enabled = false;
                    txtNumeroDocumento.Enabled = false;
                    dtpFechaNacimiento.Enabled = false;
                }
            }
            AutocompletadoNacionalidad();


        }
        
        public void Limpiar()
        {
            txtNumeroDocumento.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtPiso.Text = "";
            txtDepartamento.Text = "";
            txtLocalidad.Text = "";
            txtCelular.Text = "";
            txtTelefono.Text = "";
            txtNacionalidad.Text = "";
            txtNacionalidad.Text = "";
            txtEmail.Text = "";
            txtTitulo.Text = "";
            txtFoto.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var personal = this.MapToModel<PersonalModelo>(this.Modelo);

            if (personal.Errores.Count == 0)
            {
                if (Accion == TipoAccion.Agregar)
                {
                    personalLogica.AgregarPersonal(personal);
                    Notificar(TipoNotificacion.Success, "Personal agregado correctamente");
                    Limpiar();

                    Contenedor.AbrirFormulario<FormPersonal>();
                }
                if (Accion == TipoAccion.Modificar)
                {
                    personalLogica.ModificarPersonal(personal);
                    Notificar(TipoNotificacion.Success, "Personal modificado correctamente");
                    Limpiar();

                    Contenedor.AbrirFormulario<FormPersonal>();
                }
            }
            else
            {
                this.MostrarErrores(epvProfesores, personal.Errores);
            }
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            ofdProfesores.Filter = "Imagenes|*.jpg;*.png";
            ofdProfesores.Title = "Abriendo imagen";

            if (ofdProfesores.ShowDialog() == DialogResult.OK)
            {
                txtFoto.Text = ofdProfesores.FileName;
            }
        }

        private void AutocompletadoNacionalidad()
        {
            var nacionalidades = personalLogica.ObtenerNacionalidades();
            var listaNacionalidades = nacionalidades.Rows.Cast<DataRow>().Select(r => r.Field<string>("nacionalidad")).ToArray();

            txtNacionalidad.AutoCompleteCustomSource.AddRange(listaNacionalidades);
        }
    }
}
