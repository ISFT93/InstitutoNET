using System;
using System.Drawing;
using System.Windows.Forms;
using ISFDyT93.Vista.Core;
using ISFDyT93.Datos.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Datos.Modelos;

namespace ISFDyT93.Vista.UserControls
{
    public partial class uscParametro : UserControl
    {
        public uscParametro(ParametrosModelo Parametro)
        {
            InitializeComponent();
            this.Parametro = Parametro;
            Iniciar();
        }

        #region Propiedad Privada

        private string valor = "";
        DateTimePicker dateTimePicker;
        TextBox textBox;
        NumericUpDown numericUpDown;
        MaskedTextBox maskedTextBox;
        private bool cargado = false;

        #endregion

        #region Propiedad Publica
        public TipoParametro tipoParametro { get; set; }
        public string Valor
        {
            get
            {
                ObtenerValor();
                return valor;
            }
            set
            {
                valor = value;
                CargarValor();
            }
        }
        public string Nombre
        {
            get => lblTitulo.Text;
            set => lblTitulo.Text = value;
        }
        public string Descripcion { get; set; }
        public bool Activo
        {
            get => chkActivo.Checked;

            set => chkActivo.Checked = value;
        }
        public ParametrosModelo Parametro { get; set; }
        #endregion

        #region Eventos
        private void uscParametro_Load(object sender, EventArgs e)
        {
            cargado = true;
        }
        private void ValuedChanged(object sender, EventArgs e)
        {
            if (cargado)
            {
                Parametro.Valor = Valor;
            }
        }

        private void chkActivar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivo.Checked)
            {
                if (cargado)
                    FormNotificacion.Mensaje(TipoNotificacion.Information, $"({Nombre}) - Activado", Tiempo: 1000);
                this.BackColor = ThemeColor.GetColor();
            }
            else
            {
                if (cargado)
                    FormNotificacion.Mensaje(TipoNotificacion.Warning, $"({Nombre}) - Desactivado", Tiempo: 1000);
                this.BackColor = Color.Gray;
            }
            if (cargado)
                Parametro.Activo = chkActivo.Checked;
        }
        private void uscParametro_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(230, 65);
        }
        #endregion

        #region Metodos
        private void Iniciar()
        {
            tipoParametro = (TipoParametro)Parametro.TipoId;
            InstanciarTipos();
            Valor = Parametro.Valor;
            Activo = Parametro.Activo;
            Nombre = Parametro.Nombre;
            Descripcion = Parametro.Descripcion;
        }
        private void InstanciarTipos()
        {
            switch (tipoParametro)
            {
                case TipoParametro.Date:
                    dateTimePicker = new DateTimePicker();
                    dateTimePicker.Font = new Font("Tahoma", 11);
                    dateTimePicker.Format = DateTimePickerFormat.Custom;
                    dateTimePicker.CustomFormat = "dd-MMMM-yyyy";
                    pnlContenedor.Controls.Add(dateTimePicker);
                    dateTimePicker.Dock = DockStyle.Fill;
                    dateTimePicker.TextChanged += new EventHandler(ValuedChanged);
                    break;
                case TipoParametro.Text:
                    textBox = new TextBox();
                    textBox.Font = new Font("Tahoma", 11);
                    textBox.TextAlign = HorizontalAlignment.Center;
                    textBox.MaxLength = 500;
                    pnlContenedor.Controls.Add(textBox);
                    textBox.Dock = DockStyle.Fill;
                    textBox.TextChanged += new EventHandler(ValuedChanged);
                    break;
                case TipoParametro.Num:
                    numericUpDown = new NumericUpDown();
                    numericUpDown.Font = new Font("Tahoma", 11);
                    numericUpDown.TextAlign = HorizontalAlignment.Center;
                    numericUpDown.Maximum = 10000;
                    pnlContenedor.Controls.Add(numericUpDown);
                    numericUpDown.Dock = DockStyle.Fill;
                    numericUpDown.TextChanged += new EventHandler(ValuedChanged);
                    break;
                case TipoParametro.Time:
                    maskedTextBox = new MaskedTextBox();
                    maskedTextBox.Font = new Font("Tahoma", 11);
                    maskedTextBox.Mask = "00:00:00 Hs";
                    maskedTextBox.TextAlign = HorizontalAlignment.Center;
                    pnlContenedor.Controls.Add(maskedTextBox);
                    maskedTextBox.Dock = DockStyle.Fill;
                    maskedTextBox.TextChanged += new EventHandler(ValuedChanged);
                    break;
            }
        }
        private void ObtenerValor()
        {
            switch (tipoParametro)
            {
                case TipoParametro.Date:
                    valor = dateTimePicker.Text;
                    break;
                case TipoParametro.Text:
                    valor = textBox.Text;
                    break;
                case TipoParametro.Num:
                    valor = numericUpDown.Text;
                    break;
                case TipoParametro.Time:
                    valor = maskedTextBox.Text.Replace(" Hs", "");
                    break;
            }
        }
        private void CargarValor()
        {
            switch (tipoParametro)
            {
                case TipoParametro.Date:
                    if (valor.Length == 5) dateTimePicker.CustomFormat = "dd-MMMM";
                    dateTimePicker.Text = valor;
                    break;
                case TipoParametro.Text:
                    textBox.Text = valor;
                    break;
                case TipoParametro.Num:
                    numericUpDown.Text = valor;
                    break;
                case TipoParametro.Time:
                    maskedTextBox.Text = valor;
                    break;
            }
        }

        #endregion
               
        private void picMover_Click(object sender, EventArgs e)
        {
            FormNotificacion.Mensaje(TipoNotificacion.Message, $"{Nombre}\n{Descripcion}", Tiempo: 3000);
        }
    }
}
