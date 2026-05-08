using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Negocio.Logica;
using System.Collections.Generic;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ISFDyT93.Vista.Core;
using ISFDyT93.Negocio.Core.Enums;
using ISFDyT93.Vista.Core.Enums;

namespace ISFDyT93.Vista.Forms.Alumnos
{
    public partial class FormAgregarModificarAlumnos : FormBase
    {
        #region Propuedades P�blicas
        public int AlumnoId { get; set; }
        public TipoAccion Accion { get; set; }
        #endregion

        #region Propiedades Privades

        AlumnosLogica alumnosLogica;

        CarrerasLogica carrerasLogica;

        AlumnosModelo DatosAlumnos = null;
        AlumnosCarrerasModelo DatosAlumnosCarrera = null;
        Negocio.Validaciones validador;
        #endregion

        public FormAgregarModificarAlumnos()
        {
            alumnosLogica = new AlumnosLogica();
            carrerasLogica = new CarrerasLogica();
            validador = new Negocio.Validaciones();
            InitializeComponent();
        }
        private Dictionary<string, string> codigosPostales = new Dictionary<string, string>()
        {

            { "san vicente", "1865" },

            { "alejandro korn", "1864" },

            { "guernica", "1862" },

            { "brandsen", "1980" },

            { "glew", "1856" }

        };
        private void FormAgregarModificarAlumnos_Load(object sender, EventArgs e)
        {
            ObtenerAniosLectivosActivos();

            cmbSexo.Items.Clear();
            cmbSexo.Items.Add("Femenino");
            cmbSexo.Items.Add("Masculino");
            cmbSexo.Items.Add("Sin Especificar");
            cmbSexo.Items.Add("Otro");
            dtpFechaNacimiento.MaxDate = DateTime.Now.AddYears(-17);

            cmbCarreraId.DataSource = carrerasLogica.ObtenerCarreras();
            cmbCarreraId.ValueMember = "CarreraId";
            cmbCarreraId.DisplayMember = "Descripción";
            cmbMayorTitulo.Text = "Ninguno";

            SetReadOnly(grbDocumentosEntregar,false);

            this.Contenedor.SetVolver(() =>
            {
                this.Contenedor.AbrirFormulario<FormAlumnos>();
            });

            if (this.AlumnoId > 0)
            {
                this.DatosAlumnos = alumnosLogica.ObtenerAlumno(this.AlumnoId);
                this.DatosAlumnosCarrera = alumnosLogica.TraerAlumnoCarrera(this.AlumnoId);

                this.MapToForm<AlumnosModelo>(DatosAlumnos);
                this.MapToForm<AlumnosCarrerasModelo>(DatosAlumnosCarrera, grbCarrera.Controls);
            }

            if (this.Accion == TipoAccion.Ver)
            {
                // Usamos un método recursivo para que funcione tanto con TextBox directos del GroupBox
                // como con TextBox anidados dentro de Panels u otros contenedores.
                SetReadOnly(grbDatosPersonales, false);
                SetReadOnly(grbFormacion, false);
                SetReadOnly(grbDocumentosEntregar, false);
                SetReadOnly(grbFichaSalud, false);
                SetReadOnly(grbDireccion, false);

                btnGuardar.Visible = false;
                
                dtpFechaNacimiento.Enabled = false;
                pnlSiNoTS.Enabled = false;
                pnlSiNoTT.Enabled = false;
                pnlSiNoTM.Enabled = false;
                pnlSiNoOS.Enabled = false;
                pnlSiNoMed.Enabled = false;
                pnlSiNoD.Enabled = false;
                pnlSiNoCert.Enabled = false;
                pnlEstadoDiscapacidad.Enabled = false;
                grbDocumentosEntregar.Enabled = false;
                cmbCicloLectivo.Visible = false;
                lblAnioLectivo.Visible=false;
                this.Contenedor.SetTitulo("Ver Alumno");

                cmbCarreraId.Enabled = false;
                cmbTipoDocumento.Enabled = false;
                cmbEstadoCivil.Enabled = false;
                cmbSexo.Enabled = false;
                cmbMayorTitulo.Enabled = false;

                ////En los groupbox a los controles de tipo textbox ponerlos solo lectura
                //grbDatosPersonales.Controls.OfType<TextBox>().ToList().ForEach(tb => tb.ReadOnly = true);
                //grbFormacion.Controls.OfType<TextBox>().ToList().ForEach(tb => tb.ReadOnly = true);
                //grbDocumentosEntregar.Controls.OfType<TextBox>().ToList().ForEach(tb => tb.ReadOnly = true);
                //grbFichaSalud.Controls.OfType<TextBox>().ToList().ForEach(tb => tb.ReadOnly = true);

                return;
            }
            else if (this.Accion == TipoAccion.Modificar)
            {
                txtNumeroDocumento.Enabled = false;
                cmbTipoDocumento.Enabled = false;

                this.Contenedor.SetTitulo("Modificar Alumno");
                ActualizarAutoComplete();
            }
            else
            {
                this.Contenedor.SetTitulo("Agregar Alumno");
                ActualizarAutoComplete();
            }

            if ((cmbMayorTitulo.Text == "Ninguno") || (cmbMayorTitulo.Text == ""))
            {
                txtOtroTitulo.Enabled = false;
                txtMayorOtorgadoPor.Enabled = false;
                txtMayorPromedio.Enabled = false;
            }
            txtTelefono.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtCelular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            txtTelefonoContacto.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
        }
        public void SetReadOnly(Control parent, bool valor)
        {
            foreach (Control ctrl in parent.Controls)
            {
                // Para los TextBox: poner ReadOnly = true (no deshabilitar), as? el usuario puede copiar texto al ver.
                if (ctrl is TextBox tb)
                {
                    tb.ReadOnly = !valor;
                }
                if (ctrl is MaskedTextBox mtb)
                {
                    mtb.ReadOnly = !valor;
                }
                // Recursividad para aplicar a controles anidados
                if (ctrl.HasChildren)
                {
                    SetReadOnly(ctrl, valor);
                }
                if (ctrl is CheckBox cb)
                {
                    cb.Enabled = valor;
                }
                if (ctrl is RadioButton rb)
                {
                    rb.Enabled = valor;
                }
                if (ctrl is ComboBox cbox)
                {
                    cbox.Enabled = valor;
                }
                if (ctrl is DateTimePicker dtp)
                {
                    dtp.Enabled = valor;
                }
            }
        }
        private void rdbSi_CheckedChanged(object sender, EventArgs e)
        {
            txtMateriasAdeuda.Enabled = !rdbTituloSecundarioSi.Checked;
            txtDescripcionMaterias.Enabled = !rdbTituloSecundarioSi.Checked;

            txtTitulo.Enabled = rdbTituloSecundarioSi.Checked;
            txtOrientacion.Enabled = rdbTituloSecundarioSi.Checked;
            txtOtorgadoPor.Enabled = rdbTituloSecundarioSi.Checked;
            txtAnioEgreso.Enabled = rdbTituloSecundarioSi.Checked;
            txtPromedio.Enabled = rdbTituloSecundarioSi.Checked;
            cmbMayorTitulo.Enabled = rdbTituloSecundarioSi.Checked;
            rdbTituloTramiteSi.Enabled = rdbTituloSecundarioSi.Checked;
            rdbTituloTramiteNo.Enabled = rdbTituloSecundarioSi.Checked;

            if (rdbTituloSecundarioSi.Checked)
            {
                txtMateriasAdeuda.Text = null;
                txtDescripcionMaterias.Text = null;
            }
            else
            {
                txtTitulo.Text = null;
                txtOrientacion.Text = null;
                txtOtorgadoPor.Text = null;
                txtAnioEgreso.Text = null;
                txtPromedio.Text = null;
                cmbMayorTitulo.Text = null;
                rdbTituloTramiteNo.Checked = true;
                txtOtroTitulo.Text = null;
                txtMayorOtorgadoPor.Text = null;
                txtMayorPromedio.Text = null;

                txtOtroTitulo.Enabled = false;
                txtMayorOtorgadoPor.Enabled = false;
                txtMayorPromedio.Enabled = false;
            }
        }

        private void chkAdeudaMaterias_CheckedChanged(object sender, EventArgs e)
        {
            txtCantidadAdeudaMaterias.Enabled = this.chkConstanciaAdeudaMaterias.Checked;
        }

        private void cmbCarreras_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((this.Accion == TipoAccion.Modificar) && ((cmbCarreraId.SelectedValue as int?) != (DatosAlumnosCarrera.CarreraId)))
            {
                grbDocumentosEntregar.Controls.OfType<TextBox>().ToList().ForEach(tb => tb.Clear());
                grbFichaSalud.Controls.OfType<TextBox>().ToList().ForEach(tb => tb.Clear());
                grbDocumentosEntregar.Controls.OfType<CheckBox>().ToList().ForEach(tb => tb.Checked = false);
            }
        }

        private void cmbMayorTitulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbMayorTitulo.Text != "Ninguno" && !string.IsNullOrEmpty(cmbMayorTitulo.Text))
            {
                txtOtroTitulo.Enabled = true;
                txtMayorOtorgadoPor.Enabled = true;
                txtMayorPromedio.Enabled = true;
            }
            else
            {
                txtOtroTitulo.Enabled = false;
                txtMayorOtorgadoPor.Enabled = false;
                txtMayorPromedio.Enabled = false;
            }
        }

        private void rdbSiMedicacion_CheckedChanged(object sender, EventArgs e)
        {
            txtDescripcionMedicacion.Enabled = rdbMedicacionSi.Checked;
        }

        private void rdbSiDiscapacidad_CheckedChanged(object sender, EventArgs e)
        {
            txtDescripcionDiscapacidad.Enabled = rdbDiscapacidadSi.Checked;
            rdbEstadoDiscapacidadPermanente.Enabled = rdbDiscapacidadSi.Checked; ;
            rdbEstadoDiscapacidadTemporal.Enabled = rdbDiscapacidadSi.Checked; ;
            rdbCertificadoDiscapacidadSi.Enabled = rdbDiscapacidadSi.Checked; ;
            rdbCertificadoDiscapacidadNo.Enabled = rdbDiscapacidadSi.Checked; ;
        }

        private void rdbSiPosee_CheckedChanged(object sender, EventArgs e)
        {
            txtDescripcionObraSocial.Enabled = rdbObraSocialPrepagaSi.Checked;
        }

        private void rdbSiTM_CheckedChanged(object sender, EventArgs e)
        {
            txtDescripcionTratamiento.Enabled = rdbTratamientoMedicoSi.Checked;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            var alumno = this.MapToModel<AlumnosModelo>(DatosAlumnos);
            
            var alumnoCarrera = this.MapToModel<AlumnosCarrerasModelo>(DatosAlumnosCarrera, grbCarrera.Controls);

            if (alumno.Errores.Count == 0 && alumnoCarrera.Errores.Count == 0)
            {
                if (this.Accion == TipoAccion.Agregar)
                {
                    //Ademas de agregar trae el ultimo alumnoId
                    alumnoCarrera.AlumnoId = alumnosLogica.AgregarAlumno(alumno);
                    //tabla intermedia
                    if (alumnoCarrera.AlumnoId > 0)
                    {
                        //lo estoy dando de alta
                        alumnoCarrera.Activo = true;
                        alumnoCarrera.FechaAlta = DateTime.Now;

                        alumnosLogica.AgregarAlumnoCarrera(alumnoCarrera);

                        Notificar(TipoNotificacion.Success, "El alumno fue\nagregado con exito");
                    }
                }
                else if (this.Accion == TipoAccion.Modificar)
                {
                    //verificar si la carrera que selecciono es distinta a la que tenia
                    if (alumnoCarrera.CarreraId != (DatosAlumnosCarrera.CarreraId))
                    {
                        //Inactivo el alumno para esa carrera
                        alumnosLogica.BajaAlumnoCarrera(alumno.AlumnoId);
                        alumnosLogica.AgregarAlumnoCarrera(alumnoCarrera);
                    }
                    else
                    {
                        //Si la carrera no es distinta solo modifico
                        //UPDATE
                        alumnosLogica.ModificarAlumnoCarrera(alumnoCarrera);
                    }

                    //Modifico la carrera
                    alumnosLogica.ModificarAlumno(alumno);
                    Notificar(TipoNotificacion.Success, "El alumno fue\nmodificado con exito");
                }

                Contenedor.AbrirFormulario<FormAlumnos>();
            }
            else
            {
                this.MostrarErrores(epvAlumnos, alumno.Errores);
            }
        }
        private bool ValidarFormulario()
        {
            if (!validador.Obligatorio(txtLocalidad.Text))

                return false;

            return true;

        }
        private void ActualizarAutoComplete()
        {
            txtPaisNacimiento.AutoCompleteCustomSource.AddRange(alumnosLogica.ObtenerPaisNacimientoAlumnos());

            txtLocalidadNacimiento.AutoCompleteCustomSource.AddRange(alumnosLogica.ObtenerLocalidadAlumnos());

            txtLocalidad.AutoCompleteCustomSource.AddRange(alumnosLogica.ObtenerLocalidadAlumnos());

            txtDistrito.AutoCompleteCustomSource.AddRange(alumnosLogica.ObtenerDistritoAlumnos());

            txtProvincia.AutoCompleteCustomSource.AddRange(alumnosLogica.ObtenerProvinciaAlumnos());
        }
        private void ObtenerAniosLectivosActivos()
        {
            cmbCicloLectivo.DataSource = new CicloLectivosLogica().ObtenerAniosCiclosLectivosActivos();
        }

        private void txtSoloNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !validador.SoloNumeros(e.KeyChar.ToString()))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        private void txtSoloLetrasEspacios_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            // permitir teclas de control
            if (char.IsControl(e.KeyChar))
                return;

            // bloquear espacio al inicio
            if (char.IsWhiteSpace(e.KeyChar) && (txt.Text.Length == 0 || txt.Text.EndsWith(" ")))
            {
                e.Handled = true;
                return;
            }

            // usar tu validador
            if (!validador.SoloLetrasEspacios(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void txtNumeroDocumento_Leave(object sender, EventArgs e)
        {
            if (this.Accion == TipoAccion.Ver || this.Accion == TipoAccion.Modificar)
                return;
            
            if (!validador.AlumnoNuevo(txtNumeroDocumento.Text))
            {
                MessageBox.Show("El numero de documento ya esta registrador");
                txtNumeroDocumento.Focus();
            }
        }
        private void txtLetrasYNumerosYEspacio_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (char.IsControl(e.KeyChar))
                return;

            if (char.IsWhiteSpace(e.KeyChar) && (txt.Text.Length == 0 || txt.Text.EndsWith(" ")))
            {
                e.Handled = true;
            }
            

            if(!validador.SoloLetrasEspaciosyNumeros(e.KeyChar.ToString()))
            {
                e.Handled = true; // Bloquea la tecla
            }
            return;
        }
        private void txtLetrasYNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !validador.SoloLetrasYNumeros(e.KeyChar.ToString()))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }
        private void txtValidarMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
                return;
            if (!validador.FormatoEmailValido(txtEmail.Text))
            {
                MessageBox.Show("Email inválido");
                txtEmail.Focus();
            }
        }
        private void txtTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !validador.TextoParrafo(e.KeyChar.ToString()))
            {
                e.Handled = true; // Bloquea la tecla
            }
        }

        private void txtLocalidad_TextChanged(object sender, EventArgs e)
        {
            string localidad = txtLocalidad.Text.Trim().ToLower();

            if (codigosPostales.ContainsKey(localidad))
            {
                txtCodigoPostal.Text = codigosPostales[localidad];
            }
            else
            {
                txtCodigoPostal.Text = "";
            }
        }
        
        private void TxtQuitarCeros_Enter(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (txt.Text == "0")
            {
                txt.Text = "";
            }

            txt.SelectAll();
        }
        private void txtQuitarCeros_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.Text = "0";
            }
        }
        private void RecorrerEspacios_Leave(object sender, EventArgs e)
        {
            MaskedTextBox txt = sender as MaskedTextBox;

            if (!txt.MaskFull)
            {
                epvAlumnos.SetError(txt, "Formato Invalido \n Tiene que usarse este formato: \n (1234)567-8900");
            }
            else
            {
                epvAlumnos.SetError(txt, "");
            }
        }
    }
}
