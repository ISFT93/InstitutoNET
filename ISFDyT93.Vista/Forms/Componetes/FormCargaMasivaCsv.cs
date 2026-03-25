using System;
using System.IO;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Forms.Componentes
{
    public partial class FormCargaMasivaCsv : Form
    {
        
        public string PathArchivo { get; set; }
        public Boolean PasajeChek { get; set; }
        string extension { get; set; }


        OpenFileDialog opendia = new OpenFileDialog();

        public FormCargaMasivaCsv()
        {   
            InitializeComponent();
        }

        private void FormCargaMasivaCsv_Load(object sender, EventArgs e)
        {

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (chkModificarDatos.Checked == true)
                PasajeChek = true;
            else
                PasajeChek = false;

            this.Close();

        }
         private void btnCancelar_Click(object sender, EventArgs e)
         {
            this.Close();
         }

        private void btnBuscarRuta_Click(object sender, EventArgs e)
        {

            opendia.Filter = "Archivos Excel|*.xls;*.xlsx|Archivos .csv (*.csv)|*.csv";
            opendia.Title = "seleccione el archivo";

            this.PathArchivo = "";
            if (opendia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (opendia.FileName.Equals("") == false)
                {
                    PathArchivo = opendia.FileName;
                    txtRuta.Text = (opendia.FileName).ToString();
                    extension = Path.GetExtension(PathArchivo);


                }
            }
            if (extension == ".xls" || extension == ".xlsx")
            {
                
            }

        }
           
           
                   

    }
}
