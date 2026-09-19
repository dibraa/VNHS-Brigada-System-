namespace BrigadaEskwela_SoftwareDevelopment_II
{
    partial class ExportFileVolunteers
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
            this.VIEW_02_BrigadaVOLUNTEERS2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._01_BrigadaEskwelaDBDataSet = new BrigadaEskwela_SoftwareDevelopment_II._01_BrigadaEskwelaDBDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this._01_BrigadaEskwelaDBDataSet1 = new BrigadaEskwela_SoftwareDevelopment_II._01_BrigadaEskwelaDBDataSet();
            this.tableAdapterManager1 = new BrigadaEskwela_SoftwareDevelopment_II._01_BrigadaEskwelaDBDataSetTableAdapters.TableAdapterManager();
            this.vieW_02_BrigadaVOLUNTEERS2TableAdapter1 = new BrigadaEskwela_SoftwareDevelopment_II._01_BrigadaEskwelaDBDataSetTableAdapters.VIEW_02_BrigadaVOLUNTEERS2TableAdapter();
            this.VIEW_02_BrigadaVOLUNTEERS2TableAdapter = new BrigadaEskwela_SoftwareDevelopment_II._01_BrigadaEskwelaDBDataSetTableAdapters.VIEW_02_BrigadaVOLUNTEERS2TableAdapter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SchoolYear = new System.Windows.Forms.ComboBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.SchoolYearTXT = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.Orderbycmb = new System.Windows.Forms.ComboBox();
            this.SelectedItem = new System.Windows.Forms.Panel();
            this.OrderBy = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Exitbtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.VIEW_02_BrigadaVOLUNTEERS2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._01_BrigadaEskwelaDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._01_BrigadaEskwelaDBDataSet1)).BeginInit();
            this.panel12.SuspendLayout();
            this.SelectedItem.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VIEW_02_BrigadaVOLUNTEERS2BindingSource
            // 
            this.VIEW_02_BrigadaVOLUNTEERS2BindingSource.DataMember = "VIEW_02_BrigadaVOLUNTEERS2";
            this.VIEW_02_BrigadaVOLUNTEERS2BindingSource.DataSource = this._01_BrigadaEskwelaDBDataSet;
            // 
            // _01_BrigadaEskwelaDBDataSet
            // 
            this._01_BrigadaEskwelaDBDataSet.DataSetName = "_01_BrigadaEskwelaDBDataSet";
            this._01_BrigadaEskwelaDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.VIEW_02_BrigadaVOLUNTEERS2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BrigadaEskwela_SoftwareDevelopment_II.Report1_Volunteers.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(10, 123);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(798, 616);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // _01_BrigadaEskwelaDBDataSet1
            // 
            this._01_BrigadaEskwelaDBDataSet1.DataSetName = "_01_BrigadaEskwelaDBDataSet";
            this._01_BrigadaEskwelaDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = BrigadaEskwela_SoftwareDevelopment_II._01_BrigadaEskwelaDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // vieW_02_BrigadaVOLUNTEERS2TableAdapter1
            // 
            this.vieW_02_BrigadaVOLUNTEERS2TableAdapter1.ClearBeforeFill = true;
            // 
            // VIEW_02_BrigadaVOLUNTEERS2TableAdapter
            // 
            this.VIEW_02_BrigadaVOLUNTEERS2TableAdapter.ClearBeforeFill = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(142)))), ((int)(((byte)(99)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(808, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 626);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(142)))), ((int)(((byte)(99)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 739);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(798, 10);
            this.panel4.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(142)))), ((int)(((byte)(99)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 123);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 626);
            this.panel3.TabIndex = 3;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // SchoolYear
            // 
            this.SchoolYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.SchoolYear.ForeColor = System.Drawing.Color.Gray;
            this.SchoolYear.FormattingEnabled = true;
            this.SchoolYear.Location = new System.Drawing.Point(13, 74);
            this.SchoolYear.Name = "SchoolYear";
            this.SchoolYear.Size = new System.Drawing.Size(321, 25);
            this.SchoolYear.TabIndex = 124;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.White;
            this.panel12.Controls.Add(this.SchoolYearTXT);
            this.panel12.Location = new System.Drawing.Point(16, 75);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(291, 23);
            this.panel12.TabIndex = 125;
            // 
            // SchoolYearTXT
            // 
            this.SchoolYearTXT.AutoSize = true;
            this.SchoolYearTXT.BackColor = System.Drawing.Color.White;
            this.SchoolYearTXT.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.SchoolYearTXT.Location = new System.Drawing.Point(3, 2);
            this.SchoolYearTXT.Name = "SchoolYearTXT";
            this.SchoolYearTXT.Size = new System.Drawing.Size(76, 17);
            this.SchoolYearTXT.TabIndex = 1;
            this.SchoolYearTXT.Text = "School Year";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(142)))), ((int)(((byte)(99)))));
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(651, 73);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(151, 27);
            this.button11.TabIndex = 126;
            this.button11.Text = "PREVIEW";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // Orderbycmb
            // 
            this.Orderbycmb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Orderbycmb.ForeColor = System.Drawing.Color.Gray;
            this.Orderbycmb.FormattingEnabled = true;
            this.Orderbycmb.ItemHeight = 17;
            this.Orderbycmb.Items.AddRange(new object[] {
            "Name - Ascending",
            "Name - Descending",
            "Date - Ascending",
            "Date - Descending"});
            this.Orderbycmb.Location = new System.Drawing.Point(340, 73);
            this.Orderbycmb.Name = "Orderbycmb";
            this.Orderbycmb.Size = new System.Drawing.Size(294, 25);
            this.Orderbycmb.TabIndex = 127;
            // 
            // SelectedItem
            // 
            this.SelectedItem.BackColor = System.Drawing.Color.White;
            this.SelectedItem.Controls.Add(this.OrderBy);
            this.SelectedItem.Location = new System.Drawing.Point(341, 74);
            this.SelectedItem.Name = "SelectedItem";
            this.SelectedItem.Size = new System.Drawing.Size(276, 23);
            this.SelectedItem.TabIndex = 128;
            // 
            // OrderBy
            // 
            this.OrderBy.AutoSize = true;
            this.OrderBy.BackColor = System.Drawing.Color.White;
            this.OrderBy.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.OrderBy.Location = new System.Drawing.Point(3, 3);
            this.OrderBy.Name = "OrderBy";
            this.OrderBy.Size = new System.Drawing.Size(60, 17);
            this.OrderBy.TabIndex = 0;
            this.OrderBy.Text = "Order By";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(142)))), ((int)(((byte)(99)))));
            this.panel6.Controls.Add(this.button2);
            this.panel6.Controls.Add(this.button1);
            this.panel6.Controls.Add(this.Exitbtn);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(818, 40);
            this.panel6.TabIndex = 130;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Cornsilk;
            this.button2.Location = new System.Drawing.Point(695, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 40);
            this.button2.TabIndex = 132;
            this.button2.Text = "—";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Cornsilk;
            this.button1.Location = new System.Drawing.Point(730, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 40);
            this.button1.TabIndex = 131;
            this.button1.Text = "❏";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Exitbtn
            // 
            this.Exitbtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.Exitbtn.FlatAppearance.BorderSize = 0;
            this.Exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exitbtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exitbtn.ForeColor = System.Drawing.Color.Cornsilk;
            this.Exitbtn.Location = new System.Drawing.Point(771, 0);
            this.Exitbtn.Name = "Exitbtn";
            this.Exitbtn.Size = new System.Drawing.Size(47, 40);
            this.Exitbtn.TabIndex = 130;
            this.Exitbtn.Text = "X";
            this.Exitbtn.UseVisualStyleBackColor = true;
            this.Exitbtn.Click += new System.EventHandler(this.Exitbtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 21);
            this.label2.TabIndex = 129;
            this.label2.Text = "VOLUNTEER RECORDS FILE EXPORT";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(142)))), ((int)(((byte)(99)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 40);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 83);
            this.panel5.TabIndex = 131;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(142)))), ((int)(((byte)(99)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(808, 40);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(10, 83);
            this.panel7.TabIndex = 132;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.SelectedItem);
            this.panel1.Controls.Add(this.Orderbycmb);
            this.panel1.Controls.Add(this.button11);
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.SchoolYear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 123);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ExportFileVolunteers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 749);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExportFileVolunteers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EXPORT FILE";
            this.Load += new System.EventHandler(this.ExportFileVolunteers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VIEW_02_BrigadaVOLUNTEERS2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._01_BrigadaEskwelaDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._01_BrigadaEskwelaDBDataSet1)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.SelectedItem.ResumeLayout(false);
            this.SelectedItem.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private _01_BrigadaEskwelaDBDataSet _01_BrigadaEskwelaDBDataSet1;
        private _01_BrigadaEskwelaDBDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private _01_BrigadaEskwelaDBDataSetTableAdapters.VIEW_02_BrigadaVOLUNTEERS2TableAdapter vieW_02_BrigadaVOLUNTEERS2TableAdapter1;
        private System.Windows.Forms.BindingSource VIEW_02_BrigadaVOLUNTEERS2BindingSource;
        private _01_BrigadaEskwelaDBDataSet _01_BrigadaEskwelaDBDataSet;
        private _01_BrigadaEskwelaDBDataSetTableAdapters.VIEW_02_BrigadaVOLUNTEERS2TableAdapter VIEW_02_BrigadaVOLUNTEERS2TableAdapter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox SchoolYear;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label SchoolYearTXT;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ComboBox Orderbycmb;
        private System.Windows.Forms.Panel SelectedItem;
        private System.Windows.Forms.Label OrderBy;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Exitbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel1;
    }
}