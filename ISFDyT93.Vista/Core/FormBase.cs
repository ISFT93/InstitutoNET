using ISFDyT93.Entidades.Core;
using ISFDyT93.Entidades.Core.Attributes;
using ISFDyT93.Entidades.Core.Attributes.Validaciones;
using ISFDyT93.Entidades.Modelos;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms;
using ISFDyT93.Vista.Forms.Componetes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Core
{
    public partial class FormBase : Form
    {
        public FormPrincipal Contenedor { get; set; }
        public FormBase()
        {
            InitializeComponent();
        }

        public void Notificar(TipoNotificacion TipoNotificacion, string Mensaje, ContentAlignment Alineacion = ContentAlignment.BottomCenter, int Tiempo = 3000)
        {
            if (Tiempo > 0)
            {
                new FormNotificacion(TipoNotificacion, Mensaje, Alineacion, Tiempo).Show();
            }
        }

        public void DeshabilitarControles()
        {
            var controls = this.FindControl(this.Controls);

            foreach (Control control in controls)
            {
                control.Enabled = false;
            }
        }

        public void LimpiarControlles()
        {
            var controls = this.FindControl(this.Controls);

            foreach (Control control in controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    var textBox = control as TextBox;
                    textBox.Text = "";
                }
                else if (control.GetType() == typeof(NumericUpDown))
                {
                    var numeric = control as NumericUpDown;
                    numeric.Value = 0;
                }
                else if (control.GetType() == typeof(DateTimePicker))
                {
                    var picker = control as DateTimePicker;
                    picker.Value = DateTime.Now;
                }
                else if(control.GetType() == typeof(ComboBox))
                {
                    var comboBox = control as ComboBox;
                    comboBox.SelectedIndex = 0;
                }
            }
        }

        public void MostrarErrores(ErrorProvider proveedor, IList<Error> errores)
        {
            proveedor.Clear();
            bool focus = false;
            foreach (var error in errores)
            {
                proveedor.SetError(error.Control as Control, error.Mensaje);

                if (!focus)
                {
                    ((Control)error.Control).Focus();
                    focus = true;
                }
            }
        }

        public T MapToModel<T>(T model = null, Control.ControlCollection controls = null) where T : ModeloBase, new()
        {
            Type clase = typeof(T);
            var objeto = model ?? new T();
            objeto.Nuevo = true;

            var propiedades = clase.GetProperties();

            if (model != null)
            {
                var clave = propiedades
                    .Where(p => Attribute.IsDefined(p, typeof(Clave)))
                    .FirstOrDefault();

                if (clave != null)
                {
                    var valor = Convert.ToInt32(clave.GetValue(model));

                    if (valor > 0)
                    {
                        objeto.Nuevo = false;
                    }
                }
            }

            controls = controls ?? this.Controls;

            var lista = FindControl(controls).OrderBy(p => p.TabIndex).ToList();

            this.InnerMapToModel<T>(lista, propiedades, objeto, model);

            return objeto;
        }

        public void MapToForm<T>(T datos, Control.ControlCollection controls = null)
        {
            Type tipo = typeof(T);
            var propiedades = tipo.GetProperties();
            controls = controls ?? this.Controls;

            InnerMapToForm<T>(controls, datos, propiedades);
        }

        public void SetControlConfig(Action<Control> action)
        {
            var controls = this.FindControl(this.Controls);

            foreach (Control control in controls)
            {
                action(control);
            }
        }


        private T InnerMapToModel<T>(
            IList<Control> controls,
            PropertyInfo[] propiedades,
            T objeto,
            T anterior) where T : ModeloBase
        {
            // Guardamos los controles y sus valores para validarlos después.
            var campos = new List<Tuple<Control, PropertyInfo, object, string>>();

            // PRIMERA ETAPA: Leer y asignar todos los valores.
            foreach (Control control in controls)
            {
                if (string.IsNullOrEmpty(control.Name) || !control.Visible)
                    continue;

                string nombre = control.Tag != null
                    ? control.Tag.ToString()
                    : control.Name.Length > 3 ? control.Name.Substring(3) : control.Name;

                PropertyInfo propiedad = propiedades
                    .FirstOrDefault(p => p.Name.Equals(nombre));

                if (propiedad == null)
                    continue;

                object value = null;

                if (control is TextBox)
                {
                    value = ((TextBox)control).Text;
                }
                else if (control is MaskedTextBox)
                {
                    value = ((MaskedTextBox)control).Text;
                }
                else if (control is ComboBox)
                {
                    ComboBox cmb = (ComboBox)control;
                    value = cmb.SelectedValue ?? cmb.Text;
                }
                else if (control is DateTimePicker)
                {
                    DateTimePicker dtp = (DateTimePicker)control;

                    if (!dtp.Text.Equals(" "))
                        value = dtp.Value;
                    else
                        continue;
                }
                else if (control is NumericUpDown)
                {
                    value = ((NumericUpDown)control).Value;
                }
                else if (control is CheckBox)
                {
                    value = ((CheckBox)control).Checked;
                }
                else if (control is RadioButton)
                {
                    RadioButton radio = (RadioButton)control;

                    if (!radio.Checked)
                        continue;

                    if (propiedad.PropertyType == typeof(string))
                        value = radio.Text;
                    else
                        value = radio.Name.EndsWith("Si");
                }
                else
                {
                    continue;
                }

                // Convertir al tipo de la propiedad.
                if (value != null)
                {
                    Type tipo = propiedad.PropertyType;
                    Type tipoDestino = Nullable.GetUnderlyingType(tipo) ?? tipo;

                    if (tipoDestino == typeof(string))
                    {
                        value = value.ToString();

                        if (string.IsNullOrWhiteSpace((string)value))
                            value = null;
                    }
                    else if (tipoDestino == typeof(char))
                    {
                        string texto = value.ToString();
                        value = texto.Length > 0 ? texto[0] : (char)1;
                    }
                    else if (value.GetType() != tipoDestino)
                    {
                        try
                        {
                            value = Convert.ChangeType(value, tipoDestino);
                        }
                        catch
                        {
                            objeto.Errores.Add(new Error()
                            {
                                Control = control,
                                Mensaje = "El valor ingresado no tiene un formato válido",
                                Nombre = nombre
                            });

                            continue;
                        }
                    }
                }

                // Asignar primero al modelo.
                propiedad.SetValue(objeto, value, null);

                campos.Add(Tuple.Create(control, propiedad, value, nombre));
            }

            // SEGUNDA ETAPA: Validar con todas las propiedades actualizadas.
            foreach (var campo in campos)
            {
                Control control = campo.Item1;
                PropertyInfo propiedad = campo.Item2;
                object value = campo.Item3;
                string nombre = campo.Item4;

                object[] atributos = propiedad.GetCustomAttributes(true);

                foreach (object atributo in atributos)
                {
                    Validacion validacion = atributo as Validacion;

                    if (validacion == null)
                        continue;

                    if (!validacion.Validar(value, objeto))
                    {
                        objeto.Errores.Add(new Error()
                        {
                            Control = control,
                            Mensaje = validacion.Mensaje,
                            Nombre = nombre
                        });

                        break;
                    }
                }
            }

            return objeto;
        }


        private void InnerMapToForm<T>(Control.ControlCollection controls, T datos, PropertyInfo[] propiedades)
        {
            foreach (Control control in controls)
            {
                if (control.GetType() == typeof(Label))
                {
                    continue;
                }

                if (string.IsNullOrEmpty(control.Name))
                    continue;

                //Linq
                string nombre = control.Tag != null ? control.Tag.ToString() : control.Name.Substring(3);
                var propiedad = propiedades.Where(p => p.Name == nombre).SingleOrDefault();

                if (control.Controls != null && control.Controls.Count > 0)
                {
                    InnerMapToForm(control.Controls, datos, propiedades);
                }
                else if (propiedad == null || datos == null || propiedad.GetValue(datos) == null) //Se agrego provisorio || datos == null
                {
                    continue;
                }
                else if (control.GetType() == typeof(TextBox))
                {
                    var txtBox = control as TextBox;
                    txtBox.Text = propiedad.GetValue(datos).ToString();
                }
                else if (control.GetType() == typeof(MaskedTextBox))
                {
                    var maskedtxtBox = control as MaskedTextBox;
                    maskedtxtBox.Text = propiedad.GetValue(datos).ToString();
                }
                else if (control is ComboBox cmbBox)
                {
                    var valor = propiedad.GetValue(datos);

                    if (valor == null)
                        continue;

                    // 🔹 1. Si está bindeado (DataSource) → usar SIEMPRE SelectedValue
                    if (cmbBox.DataSource != null && !string.IsNullOrEmpty(cmbBox.ValueMember))
                    {
                        try
                        {
                            cmbBox.SelectedValue = valor;
                        }
                        catch
                        {
                            // fallback por si no encuentra coincidencia
                            cmbBox.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        string valorStr = valor.ToString();

                        // 🔹 2. Buscar coincidencia exacta
                        foreach (var item in cmbBox.Items)
                        {
                            if (item.ToString().Equals(valorStr, StringComparison.OrdinalIgnoreCase))
                            {
                                cmbBox.SelectedItem = item;
                                goto FIN;
                            }
                        }

                        // 🔹 3. Buscar coincidencia por inicio (F → Femenino)
                        foreach (var item in cmbBox.Items)
                        {
                            if (item.ToString().StartsWith(valorStr, StringComparison.OrdinalIgnoreCase))
                            {
                                cmbBox.SelectedItem = item;
                                goto FIN;
                            }
                        }

                        // 🔹 4. Fallback: no encontró nada
                        cmbBox.SelectedIndex = -1;
                    }

                FIN:;
                }
                else if (control.GetType() == typeof(DateTimePicker))
                {
                    var dtpPiker = control as DateTimePicker;
                    var date = (DateTime)propiedad.GetValue(datos);

                    if (date >= dtpPiker.MinDate && date <= dtpPiker.MaxDate)
                        dtpPiker.Value = (DateTime)propiedad.GetValue(datos);
                }
                else if (control.GetType() == typeof(NumericUpDown))
                {
                    var nudNumeric = control as NumericUpDown;
                    nudNumeric.Value = (decimal)propiedad.GetValue(datos);
                }
                else if (control.GetType() == typeof(CheckBox))
                {
                    var chkBox = control as CheckBox;
                    chkBox.Checked = (bool)propiedad.GetValue(datos);
                }
                else if (control.GetType() == typeof(RadioButton))
                {
                    var rdbButton = control as RadioButton;

                    if (rdbButton.Name.EndsWith("Si"))
                    {
                        rdbButton.Checked = (bool)propiedad.GetValue(datos) == true;
                    }
                    else if (rdbButton.Name.EndsWith("No"))
                    {
                        rdbButton.Checked = (bool)propiedad.GetValue(datos) == false;
                    }
                    else
                    {
                        rdbButton.Checked = propiedad.GetValue(datos).ToString() == rdbButton.Text;
                    }
                }
            }
        }

        private IList<Control> FindControl(Control.ControlCollection controls, IList<Control> result = null)
        {
            if (result == null)
            {
                result = new List<Control>();
            }

            foreach (Control control in controls)
            {
                var admitidos = new string[] { "txt", "cmb", "nud", "dtp", "chk", "rdb" };
                var cod = control.Name.Substring(0, 3);

                if (control.Controls.Count == 0 && !admitidos.Contains(cod))
                    continue;

                var canFind = control.GetType() != typeof(NumericUpDown) && control.GetType() != typeof(DateTimePicker);

                if (control.Controls.Count > 0 && canFind)
                {
                    FindControl(control.Controls, result);
                }
                else
                {
                    result.Add(control);
                }
            }

            return result;
        }

    }
}
