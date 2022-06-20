namespace Interfaz.Reportes
{
    partial class frmTiposDeSalidaR
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
            this.spTiposDeSalidaRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSTiposDeSalidaR = new Interfaz.Reportes.DSTiposDeSalidaR();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spTiposDeSalidaRTableAdapter = new Interfaz.Reportes.DSTiposDeSalidaRTableAdapters.spTiposDeSalidaRTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.spTiposDeSalidaRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSTiposDeSalidaR)).BeginInit();
            this.SuspendLayout();
            // 
            // spTiposDeSalidaRBindingSource
            // 
            this.spTiposDeSalidaRBindingSource.DataMember = "spTiposDeSalidaR";
            this.spTiposDeSalidaRBindingSource.DataSource = this.DSTiposDeSalidaR;
            // 
            // DSTiposDeSalidaR
            // 
            this.DSTiposDeSalidaR.DataSetName = "DSTiposDeSalidaR";
            this.DSTiposDeSalidaR.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spTiposDeSalidaRBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Interfaz.Reportes.RTiposDeSalidas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(24, 121);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(637, 268);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // spTiposDeSalidaRTableAdapter
            // 
            this.spTiposDeSalidaRTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(218, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(285, 24);
            this.label2.TabIndex = 16;
            this.label2.Text = "Informe Tipos de Entrada";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(60, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Ingrese el Codigo a Buscar:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(191, 78);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(59, 78);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 13;
            // 
            // frmTiposDeSalidaR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 401);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmTiposDeSalidaR";
            this.Load += new System.EventHandler(this.frmTiposDeSalidaR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spTiposDeSalidaRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSTiposDeSalidaR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource spTiposDeSalidaRBindingSource;
        private DSTiposDeSalidaR DSTiposDeSalidaR;
        private DSTiposDeSalidaRTableAdapters.spTiposDeSalidaRTableAdapter spTiposDeSalidaRTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtId;
    }
}