using QuanLyKhachSan.ThongKe;

namespace QuanLyKhachSan
{
    partial class SlTrongReport
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
            this.SlTrongReportDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new QuanLyKhachSan.ThongKe.DataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SlTrongReportDataTableTableAdapter = new QuanLyKhachSan.ThongKe.DataSet1TableAdapters.SlTrongReportDataTableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SlTrongReportDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // SlTrongReportDataTableBindingSource
            // 
            this.SlTrongReportDataTableBindingSource.DataMember = "SlTrongReportDataTable";
            this.SlTrongReportDataTableBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "SlTrongDataSet";
            reportDataSource1.Value = this.SlTrongReportDataTableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyKhachSan.ThongKe.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(830, 486);
            this.reportViewer1.TabIndex = 0;
            // 
            // SlTrongReportDataTableTableAdapter
            // 
            this.SlTrongReportDataTableTableAdapter.ClearBeforeFill = true;
            // 
            // SlTrongReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 510);
            this.Controls.Add(this.reportViewer1);
            this.Name = "SlTrongReport";
            this.Text = "SlTrongReport";
            this.Load += new System.EventHandler(this.SlTrongReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SlTrongReportDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SlTrongReportDataTableBindingSource;
        private DataSet1 DataSet1;
        private ThongKe.DataSet1TableAdapters.SlTrongReportDataTableTableAdapter SlTrongReportDataTableTableAdapter;
    }
}