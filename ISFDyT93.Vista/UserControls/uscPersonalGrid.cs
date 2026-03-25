using ISFDyT93.Vista.Core.Enums;
using ISFDyT93.Vista.Forms.Componetes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISFDyT93.Vista.UserControls
{
    public partial class uscPersonalGrid : UserControl
    {
        public uscPersonalGrid(string[] nameHeaders)
        {
            InitializeComponent();
            NameHeaders = nameHeaders;
            GenerarHeaders();
            AjustarAnchoAlto();
            Aviso = false;
            
        }

        public static bool Aviso { get; set; } = false;
        public static int AnchoCelda { get; set; } = 100;
        public static int AltoCelda { get; set; } = 30;
        private int NroColumnas { get => NameHeaders.Length; }
        private int NroFilas
        {
            get 
            {
                return ((Cells.Count + Headers.Count) / NroColumnas);
            }
        }

        public string[] NameHeaders { get; }

        public List<Cell> Cells = new List<Cell>();
        public List<Cell> Headers = new List<Cell>();

        public List<Cell[]> Rows
        {
            get
            {
                List<Cell[]> list = new List<Cell[]>();
                Cell[] row = new Cell[NroColumnas];
                int column = 0;
                foreach(var cell in Cells)
                {
                    row[column] = cell;
                    column++;
                    if(column == NroColumnas)
                    {
                        list.Add(row);
                        column = 0;
                        row = new Cell[NroColumnas];
                    }
                }
                return list;
            }
        }
        private void AjustarAnchoAlto()
        {
            this.Width = AnchoCelda * NroColumnas;
            this.Height = AltoCelda * NroFilas;
        }
        private void GenerarHeaders()
        {
            for(int i = 0; i < NroColumnas; i++)
            {
                Headers.Add(ByPassCell(new Cell(NameHeaders[i], -1)));
            }
        }
        public void AgregarCelda(string dato, int id = -1)
        {
           Cells.Add(ByPassCell(new Cell(dato, id)));
            AjustarAnchoAlto();            
        }
        public void AgregarCelda(string dato, bool editable , int id = -1)
        {
            Cells.Add(ByPassCell(new Cell(dato, editable, id)));
            AjustarAnchoAlto();
        }
        public void AgregarCelda(bool estado, int id = -1)
        {
            Cells.Add(ByPassCell(new Cell(estado, id)));
            AjustarAnchoAlto();
        }
        public void AgregarCelda(DataTable dataTable, string value = null, int id = -1)
        {
            Cells.Add(ByPassCell(new Cell(dataTable, value, id)));
            AjustarAnchoAlto();
            Cells[Cells.Count - 1].Value = value;
        }
        public List<Cell> ObtenerFila(int id)
        {
            List<Cell> list = new List<Cell>();
            foreach(var cell in Cells)
            {
                if(id == cell.Id)
                {
                    list.Add(cell);
                }
            }
            return list;
        }

        private Cell ByPassCell(Cell cell)
        {
            flpContenedor.Controls.Add(cell);
            return cell;
        }

        private void tmrDelay_Tick(object sender, EventArgs e)
        {
            foreach (Cell cell in Cells)
            {
                if (cell.Tipo == typeof(ComboBox))
                    cell.AplicarValor();
            }
            tmrDelay.Enabled = false;
        }

        public class Cell : Panel
        {
            private string Valor = null;
            
            private Label label = null;
            private TextBox textBox = null;
            private CheckBox checkBox = null;
            private ComboBox comboBox = null;
            public int Id { get; }

            public Cell(string nombre, int id)
            {
                Dimencionar();
                GenerarLabel(nombre);
                Id = id;
            }
            public Cell(string nombre, bool editable, int id)
            {
                Dimencionar();
                GenerarTextBox(nombre, editable);
                Id = id;
            }
            public Cell(bool estado, int id)
            {
                Dimencionar();
                GenerarCheckBox(estado);
                Id = id;
            }
            public Cell(DataTable datos, string valor, int id)
            {
                Dimencionar();
                GenerarComboBox(datos, valor);
                Id = id;
            }

            public Type Tipo
            {
                get
                {
                    if (label != null)
                        return label.GetType();
                    else if (textBox != null)
                        return textBox.GetType();
                    else if (checkBox != null)
                        return checkBox.GetType();
                    else return comboBox.GetType();
                }
            }
            public string Value
            {
                get
                {
                    if (label != null)
                        return label.Text;
                    else if (textBox != null)
                        return textBox.Text;
                    else if (checkBox != null)
                        return checkBox.Checked.ToString();
                    else return comboBox.SelectedValue.ToString();
                }
                set
                {
                    if (label != null)
                        label.Text = value;
                    else if (textBox != null)
                        textBox.Text = value;
                    else if (checkBox != null)
                        checkBox.Checked = Convert.ToBoolean(value);
                    else if(!string.IsNullOrWhiteSpace(value)) comboBox.SelectedValue = value;
                }
            }            
            private void Dimencionar()
            {
                this.Width = AnchoCelda;
                this.Height = AltoCelda;
                this.BorderStyle = BorderStyle.FixedSingle;
                this.Margin = new Padding(0);
                this.BackColor = Color.White;
            }
            private void GenerarLabel(string dato)
            {
                label = new Label();
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BackColor = Color.White;
                label.Text = dato;
                label.Font = new Font("Tahoma", 11);
                this.Controls.Add(label);
                label.Dock = DockStyle.Fill;
            }
            private void GenerarTextBox(string dato, bool editable)
            {
                textBox = new TextBox();
                textBox.BorderStyle = BorderStyle.None;
                textBox.ReadOnly = !editable;
                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.BackColor = Color.White;
                textBox.MaxLength = 50;
                textBox.Text = dato;
                textBox.Font = new Font("Tahoma", 11);
                this.Controls.Add(textBox);
                textBox.Width = this.Width;
                textBox.Top = (this.Height / 2) - (textBox.Height / 2);
            }
            private void GenerarCheckBox(bool estado)
            {
                checkBox = new CheckBox();
                checkBox.Font = new Font("Tahoma", 11);
                checkBox.Checked = estado;
                checkBox.Text = "";
                this.Controls.Add(checkBox);
                checkBox.Dock = DockStyle.Fill;
                checkBox.CheckAlign = ContentAlignment.MiddleCenter;
            }
            private void GenerarComboBox(DataTable dataTable, string valor)
            {
                Valor = valor;
                DataTable dataTable1 = new DataTable();
                dataTable1 = dataTable.Copy();
                comboBox = new ComboBox();
                comboBox.Font = new Font("Tahoma", 11);
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.ValueMember = dataTable.Columns[0].ColumnName;
                comboBox.DisplayMember = dataTable.Columns[1].ColumnName;
                comboBox.DataSource = dataTable1;
                this.Controls.Add(comboBox);
                comboBox.Dock = DockStyle.Fill;
            }
            internal void AplicarValor()
            {
                comboBox.SelectedValue = Valor;
            }            
        }
    }    
}
