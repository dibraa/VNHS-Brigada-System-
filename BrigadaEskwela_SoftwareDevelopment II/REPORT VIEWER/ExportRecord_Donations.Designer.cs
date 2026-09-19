namespace BrigadaEskwela_SoftwareDevelopment_II
{
    partial class ExportRecord_Donations
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
            this.View_03_BrigadaDONATIONS2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._01_BrigadaEskwelaDBDataSet = new BrigadaEskwela_SoftwareDevelopment_II._01_BrigadaEskwelaDBDataSet();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.DonationType = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Exitbtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectedItem = new System.Windows.Forms.Panel();
            this.OrderBy = new System.Windows.Forms.Label();
            this.Orderbycmb = new System.Windows.Forms.ComboBox();
            this.button11 = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.SchoolYearTXT = new System.Windows.Forms.Label();
            this.SchoolYear = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.reportViewerDONATIONS = new Microsoft.Reporting.WinForms.ReportViewer();
            this.View_03_BrigadaDONATIONS2TableAdapter = new BrigadaEskwela_SoftwareDevelopment_II._01_BrigadaEskwelaDBDataSetTableAdapters.View_03_BrigadaDONATIONS2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.View_03_BrigadaDONATIONS2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._01_BrigadaEskwelaDBDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SelectedItem.SuspendLayout();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // View_03_BrigadaDONATIONS2BindingSource
            // 
            this.View_03_BrigadaDONATIONS2BindingSource.DataMember = "View_03_BrigadaDONATIONS2";
            this.View_03_BrigadaDONATIONS2BindingSource.DataSource = this._01_BrigadaEskwelaDBDataSet;
            // 
            // _01_BrigadaEskwelaDBDataSet
            // 
            this._01_BrigadaEskwelaDBDataSet.DataSetName = "_01_BrigadaEskwelaDBDataSet";
            this._01_BrigadaEskwelaDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.comboBox1);
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
            this.panel1.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.DonationType);
            this.panel8.Location = new System.Drawing.Point(383, 76);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(144, 23);
            this.panel8.TabIndex = 130;
            this.panel8.Click += new System.EventHandler(this.panel8_Click);
            this.panel8.Paint += new System.Windows.Forms.PaintEventHandler(this.panel8_Paint);
            // 
            // DonationType
            // 
            this.DonationType.AutoSize = true;
            this.DonationType.BackColor = System.Drawing.Color.White;
            this.DonationType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.DonationType.Location = new System.Drawing.Point(3, 3);
            this.DonationType.Name = "DonationType";
            this.DonationType.Size = new System.Drawing.Size(92, 17);
            this.DonationType.TabIndex = 0;
            this.DonationType.Text = "Donation Type";
            this.DonationType.Click += new System.EventHandler(this.DonationType_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBox1.ForeColor = System.Drawing.Color.Gray;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 17;
            this.comboBox1.Items.AddRange(new object[] {
            "Money",
            "Tools/Materials"});
            this.comboBox1.Location = new System.Drawing.Point(382, 75);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(163, 25);
            this.comboBox1.TabIndex = 129;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(142)))), ((int)(((byte)(99)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 40);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(10, 83);
            this.panel5.TabIndex = 131;
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
            this.label2.Size = new System.Drawing.Size(203, 21);
            this.label2.TabIndex = 129;
            this.label2.Text = "DONATIONS FILE EXPORT";
            // 
            // SelectedItem
            // 
            this.SelectedItem.BackColor = System.Drawing.Color.White;
            this.SelectedItem.Controls.Add(this.OrderBy);
            this.SelectedItem.Location = new System.Drawing.Point(209, 76);
            this.SelectedItem.Name = "SelectedItem";
            this.SelectedItem.Size = new System.Drawing.Size(144, 23);
            this.SelectedItem.TabIndex = 128;
            this.SelectedItem.Click += new System.EventHandler(this.SelectedItem_Click);
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
            this.OrderBy.Click += new System.EventHandler(this.OrderBy_Click);
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
            this.Orderbycmb.Location = new System.Drawing.Point(208, 75);
            this.Orderbycmb.Name = "Orderbycmb";
            this.Orderbycmb.Size = new System.Drawing.Size(163, 25);
            this.Orderbycmb.TabIndex = 127;
            this.Orderbycmb.SelectedIndexChanged += new System.EventHandler(this.Orderbycmb_SelectedIndexChanged);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(142)))), ((int)(((byte)(99)))));
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(651, 75);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(151, 27);
            this.button11.TabIndex = 126;
            this.button11.Text = "PREVIEW";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.White;
            this.panel12.Controls.Add(this.SchoolYearTXT);
            this.panel12.Location = new System.Drawing.Point(16, 75);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(164, 23);
            this.panel12.TabIndex = 125;
            this.panel12.Click += new System.EventHandler(this.panel12_Click);
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
            this.SchoolYearTXT.Click += new System.EventHandler(this.SchoolYearTXT_Click);
            // 
            // SchoolYear
            // 
            this.SchoolYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.SchoolYear.ForeColor = System.Drawing.Color.Gray;
            this.SchoolYear.FormattingEnabled = true;
            this.SchoolYear.Location = new System.Drawing.Point(13, 74);
            this.SchoolYear.Name = "SchoolYear";
            this.SchoolYear.Size = new System.Drawing.Size(186, 25);
            this.SchoolYear.TabIndex = 124;
            this.SchoolYear.SelectedIndexChanged += new System.EventHandler(this.SchoolYear_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(142)))), ((int)(((byte)(99)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 123);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 626);
            this.panel3.TabIndex = 4;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(142)))), ((int)(((byte)(99)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(808, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 626);
            this.panel2.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(142)))), ((int)(((byte)(99)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(10, 739);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(798, 10);
            this.panel4.TabIndex = 6;
            // 
            // reportViewerDONATIONS
            // 
            this.reportViewerDONATIONS.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.View_03_BrigadaDONATIONS2BindingSource;
            this.reportViewerDONATIONS.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerDONATIONS.LocalReport.ReportEmbeddedResource = "BrigadaEskwela_SoftwareDevelopment_II.Report2_DonationsM.rdlc";
            this.reportViewerDONATIONS.Location = new System.Drawing.Point(10, 123);
            this.reportViewerDONATIONS.Name = "reportViewerDONATIONS";
            this.reportViewerDONATIONS.ServerReport.BearerToken = null;
            this.reportViewerDONATIONS.Size = new System.Drawing.Size(798, 616);
            this.reportViewerDONATIONS.TabIndex = 7;
            this.reportViewerDONATIONS.Load += new System.EventHandler(this.reportViewerDONATIONS_Load);
            // 
            // View_03_BrigadaDONATIONS2TableAdapter
            // 
            this.View_03_BrigadaDONATIONS2TableAdapter.ClearBeforeFill = true;
            // 
            // ExportRecord_Donations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 749);
            this.Controls.Add(this.reportViewerDONATIONS);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExportRecord_Donations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EXPORT FILE";
            this.Load += new System.EventHandler(this.ExportRecord_Donations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_03_BrigadaDONATIONS2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._01_BrigadaEskwelaDBDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.SelectedItem.ResumeLayout(false);
            this.SelectedItem.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Exitbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel SelectedItem;
        private System.Windows.Forms.Label OrderBy;
        private System.Windows.Forms.ComboBox Orderbycmb;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label SchoolYearTXT;
        private System.Windows.Forms.ComboBox SchoolYear;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerDONATIONS;
        private System.Windows.Forms.BindingSource View_03_BrigadaDONATIONS2BindingSource;
        private _01_BrigadaEskwelaDBDataSet _01_BrigadaEskwelaDBDataSet;
        private _01_BrigadaEskwelaDBDataSetTableAdapters.View_03_BrigadaDONATIONS2TableAdapter View_03_BrigadaDONATIONS2TableAdapter;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label DonationType;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}