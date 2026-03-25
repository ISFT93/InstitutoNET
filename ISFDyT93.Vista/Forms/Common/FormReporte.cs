using ISFDyT93.Vista.Core;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ISFDyT93.Vista.Forms.Common
{
    public partial class FormReporte : Form
    {
        public string Reporte { get; set; }
        public IList<ReportTable> Tables { get; set; }
        public IList<ReportParameter> Parameters { get; set; }

        public FormReporte SetReporte(string value)
        {
            this.Reporte = value;
            return this;
        }

        public FormReporte AddDataSource(DataTable data, string dataBinding)
        {
            if(Tables == null)
            {
                this.Tables = new List<ReportTable>();
            }

            this.Tables.Add(new ReportTable() { DataSource = data, DataBinding = dataBinding });

            return this;
        }

        public FormReporte AddParameter(string name, string value)
        {
            if (Parameters == null)
            {
                this.Parameters = new List<ReportParameter>();
            }

            var parameter = new ReportParameter() { Name = name };
            parameter.Values.Add(value);
            this.Parameters.Add(parameter);

            return this;
        }

        public FormReporte()
        {
            InitializeComponent();
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {
            rvwReportes.Reset();
            rvwReportes.LocalReport.ReportEmbeddedResource = this.Reporte;

            if (this.Tables != null)
            {
                foreach(var table in this.Tables)
                {
                    var binding = new BindingSource();
                    binding.DataSource = table.DataSource;

                    rvwReportes.LocalReport.DataSources.Add(new ReportDataSource(table.DataBinding, binding));
                }
            }
                        
            if(this.Parameters != null)
            {
                rvwReportes.LocalReport.SetParameters(this.Parameters);
            }            
            
            this.rvwReportes.RefreshReport();
        }
    }
}
