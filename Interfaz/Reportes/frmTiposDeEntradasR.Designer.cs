namespace Interfaz.Reportes
{
    partial class frmTiposDeEntradasR
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.spTiposDeEntradaRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSTiposDeEntradaR = new Interfaz.Reportes.DSTiposDeEntradaR();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spTiposDeEntradaRTableAdapter = new Interfaz.Reportes.DSTiposDeEntradaRTableAdapters.spTiposDeEntradaRTableAdapter();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spTiposDeEntradaRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSTiposDeEntradaR)).BeginInit();
            this.SuspendLayout();
            // 
            // spTiposDeEntradaRBindingSource
            // 
            this.spTiposDeEntradaRBindingSource.DataMember = "spTiposDeEntradaR";
            this.spTiposDeEntradaRBindingSource.DataSource = this.DSTiposDeEntradaR;
            // 
            // DSTiposDeEntradaR
            // 
            this.DSTiposDeEntradaR.DataSetName = "DSTiposDeEntradaR";
            this.DSTiposDeEntradaR.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource4.Name = "DataSet1";
            reportDataSource4.Value = this.spTiposDeEntradaRBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Interfaz.Reportes.RTiposDeEntradas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(24, 118);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(600, 246);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // spTiposDeEntradaRTableAdapter
            // 
            this.spTiposDeEntradaRTableAdapter.ClearBeforeFill = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(156, 78);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(24, 78);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(183, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(284, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Reporte Tipos de Entrada";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(25, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ingrese el Codigo a Buscar:";
            // 
            // frmTiposDeEntradasR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 398);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmTiposDeEntradasR";
            this.Load += new System.EventHandler(this.frmTiposDeEntradas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spTiposDeEntradaRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSTiposDeEntradaR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spTiposDeEntradaRBindingSource;
        private DSTiposDeEntradaR DSTiposDeEntradaR;
        private DSTiposDeEntradaRTableAdapters.spTiposDeEntradaRTableAdapter spTiposDeEntradaRTableAdapter;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}