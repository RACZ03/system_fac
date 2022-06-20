namespace Interfaz.Reportes
{
    partial class frmSalidasR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.spSalidasRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSSalidas = new Interfaz.Reportes.DSSalidas();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spSalidasRTableAdapter = new Interfaz.Reportes.DSSalidasTableAdapters.spSalidasRTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spSalidasRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSSalidas)).BeginInit();
            this.SuspendLayout();
            // 
            // spSalidasRBindingSource
            // 
            this.spSalidasRBindingSource.DataMember = "spSalidasR";
            this.spSalidasRBindingSource.DataSource = this.DSSalidas;
            // 
            // DSSalidas
            // 
            this.DSSalidas.DataSetName = "DSSalidas";
            this.DSSalidas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spSalidasRBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Interfaz.Reportes.RSalidas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(658, 413);
            this.reportViewer1.TabIndex = 0;
            // 
            // spSalidasRTableAdapter
            // 
            this.spSalidasRTableAdapter.ClearBeforeFill = true;
            // 
            // frmSalidasR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 437);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmSalidasR";
            this.Load += new System.EventHandler(this.frmSalidasR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spSalidasRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSSalidas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spSalidasRBindingSource;
        private DSSalidas DSSalidas;
        private DSSalidasTableAdapters.spSalidasRTableAdapter spSalidasRTableAdapter;
    }
}