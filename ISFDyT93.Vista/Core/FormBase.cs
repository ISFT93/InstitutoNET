using ISFDyT93.Datos.Core;
using ISFDyT93.Datos.Core.Attributes;
using ISFDyT93.Datos.Core.Attributes.Validaciones;
using ISFDyT93.Datos.Modelos;
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

        private T InnerMapToModel<T>(IList<Control> controls, PropertyInfo[] propiedades, T objeto, T anterior) where T : ModeloBase
        {
            foreach (Control control in controls)
            {
                if (string.IsNullOrEmpty(control.Name))
                    continue;
                if (!control.Visible)
                    continue;

                var nombre = control.Tag != null ? control.Tag.ToString() : control.Name.Substring(3);
                var propiedad = propiedades.Where(p => p.Name.Equals(nombre)).FirstOrDefault();

                object value = null;

                if (control.GetType() == typeof(TextBox))
                {
                    var txtBox = control as TextBox;
                    value = txtBox.Text;
                }
                else if (control.GetType() == typeof(ComboBox))
                {
                    var cmbBox = control as ComboBox;
                    value = cmbBox.SelectedValue ?? cmbBox.Text;
                }
                else if (control.GetType() == typeof(DateTimePicker))
                {
                    var dtpPiker = control as DateTimePicker;
                    

                    if (!dtpPiker.Text.Equals(" "))
                    {
                        
                        value = dtpPiker.Value;
                    }
                }
                else if (control.GetType() == typeof(NumericUpDown))
                {
                    var nudNumeric = control as NumericUpDown;
                    value = nudNumeric.Value;
                }
                else if (control.GetType() == typeof(CheckBox))
                {
                    var chkBox = control as CheckBox;
                    value = chkBox.Checked;
                }
                else if (control.GetType() == typeof(RadioButton))
                {
                    var rdbButton = control as RadioButton;

                    if (rdbButton.Checked)
                    {
                        value = rdbButton.Name.EndsWith("Si");

                        if (propiedad != null)
                        {
                            if (propiedad.PropertyType == typeof(string))
                            {
                                value = rdbButton.Text;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                if (propiedad != null)
                {
                    var atributos = propiedad.GetCustomAttributes(true);

                    bool valido = true;
                    string mensaje = "";

                    foreach (var atributo in atributos)
                    {
                        if (atributo is Validacion validacion)
                        {
                            valido = validacion.Validar(value, objeto);
                            mensaje = validacion.Mensaje;

                            if (!valido) { break; }
                        }
                    }

                    if (valido)
                    {
                        if (value != null && value.GetType() != propiedad.PropertyType)
                        {
                            if (propiedad.PropertyType == typeof(Int64))
                            {
                                Int64.TryParse(value.ToString(), out long int64Value);
                                value = int64Value;
                            }
                            else if (propiedad.PropertyType == typeof(Int32))
                            {
                                Int32.TryParse(value.ToString(), out int int32Value);
                                value = int32Value;
                            }
                            else if (propiedad.PropertyType == typeof(Int16))
                            {
                                Int16.TryParse(value.ToString(), out short int16Value);
                                value = int16Value;
                            }
                            else if (propiedad.PropertyType == typeof(Decimal))
                            {
                                Decimal.TryParse(value.ToString(), out decimal decimalValue);
                                value = decimalValue;
                            }
                            else if (propiedad.PropertyType == typeof(Double))
                            {
                                Double.TryParse(value.ToString(), out double doubleValue);
                                value = doubleValue;
                            }
                            else if (propiedad.PropertyType == typeof(Single))
                            {
                                Single.TryParse(value.ToString(), out float floatValue);
                                value = floatValue;
                            }
                            else if (propiedad.PropertyType == typeof(Char))
                            {
                                string stringValue = value.ToString();

                                if (!string.IsNullOrEmpty(stringValue))
                                {
                                    value = stringValue[0];
                                }
                                else
                                {
                                    value = (char)1;
                                }
                            }
                            else if (propiedad.PropertyType == typeof(String))
                            {
                                if (string.IsNullOrEmpty(value as string))
                                {
                                    value = null;
                                }
                                else
                                {
                                    value = value.ToString();
                                }
                            }
                        }

                        propiedad.SetValue(objeto, value);
                    }
                    else
                    {
                        objeto.Errores.Add(new Error() { Control = control, Mensaje = mensaje, Nombre = nombre });
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
                else if (control.GetType() == typeof(ComboBox))
                {
                    var cmbBox = control as ComboBox;

                    if (propiedad.PropertyType == typeof(int) || propiedad.PropertyType == typeof(long))
                    {
                        cmbBox.SelectedValue = propiedad.GetValue(datos);
                    }
                    else
                    {
                        cmbBox.SelectedItem = propiedad.GetValue(datos).ToString();
                    }
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
