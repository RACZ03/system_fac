namespace Interfaz.Reportes
{
    partial class frmProductosR
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
            this.spProductosRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSProductosR = new Interfaz.Reportes.DSProductosR();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spProductosRTableAdapter = new Interfaz.Reportes.DSProductosRTableAdapters.spProductosRTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spProductosRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSProductosR)).BeginInit();
            this.SuspendLayout();
            // 
            // spProductosRBindingSource
            // 
            this.spProductosRBindingSource.DataMember = "spProductosR";
            this.spProductosRBindingSource.DataSource = this.DSProductosR;
            // 
            // DSProductosR
            // 
            this.DSProductosR.DataSetName = "DSProductosR";
            this.DSProductosR.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(239, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 24);
            this.label2.TabIndex = 16;
            this.label2.Text = "Informe de Productos\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(51, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Ingrese el Codigo a Buscar:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(182, 76);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(50, 76);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 13;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spProductosRBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Interfaz.Reportes.RProductos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 134);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(717, 246);
            this.reportViewer1.TabIndex = 17;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // spProductosRTableAdapter
            // 
            this.spProductosRTableAdapter.ClearBeforeFill = true;
            // 
            // frmProductosR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 425);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtId);
            this.Name = "frmProductosR";
            this.Load += new System.EventHandler(this.frmProductosR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spProductosRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSProductosR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtId;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spProductosRBindingSource;
        private DSProductosR DSProductosR;
        private DSProductosRTableAdapters.spProductosRTableAdapter spProductosRTableAdapter;
    }
}