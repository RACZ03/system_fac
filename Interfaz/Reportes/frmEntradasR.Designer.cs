namespace Interfaz.Reportes
{
    partial class frmEntradasR
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
            this.spEntradasRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSEntradas = new Interfaz.Reportes.DSEntradas();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spEntradasRTableAdapter = new Interfaz.Reportes.DSEntradasTableAdapters.spEntradasRTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spEntradasRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSEntradas)).BeginInit();
            this.SuspendLayout();
            // 
            // spEntradasRBindingSource
            // 
            this.spEntradasRBindingSource.DataMember = "spEntradasR";
            this.spEntradasRBindingSource.DataSource = this.DSEntradas;
            // 
            // DSEntradas
            // 
            this.DSEntradas.DataSetName = "DSEntradas";
            this.DSEntradas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spEntradasRBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Interfaz.Reportes.REntradas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(668, 387);
            this.reportViewer1.TabIndex = 0;
            // 
            // spEntradasRTableAdapter
            // 
            this.spEntradasRTableAdapter.ClearBeforeFill = true;
            // 
            // frmEntradasR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 411);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmEntradasR";
            this.Load += new System.EventHandler(this.frmEntradas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spEntradasRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSEntradas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spEntradasRBindingSource;
        private DSEntradas DSEntradas;
        private DSEntradasTableAdapters.spEntradasRTableAdapter spEntradasRTableAdapter;
    }
}