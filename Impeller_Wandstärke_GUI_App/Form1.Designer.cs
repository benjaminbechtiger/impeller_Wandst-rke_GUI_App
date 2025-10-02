namespace Impeller_Wandstärke_GUI_App
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chartWallThickness = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBoxToleranzen = new System.Windows.Forms.GroupBox();
            this.labelTolMaxT = new System.Windows.Forms.Label();
            this.labelTolMinT = new System.Windows.Forms.Label();
            this.labelTolDiffT = new System.Windows.Forms.Label();
            this.labelTolMax = new System.Windows.Forms.Label();
            this.labelTolMin = new System.Windows.Forms.Label();
            this.labelTolDiff = new System.Windows.Forms.Label();
            this.labelMessobjekt = new System.Windows.Forms.Label();
            this.comboBoxProgram = new System.Windows.Forms.ComboBox();
            this.labelActVal = new System.Windows.Forms.Label();
            this.labelActValMess = new System.Windows.Forms.Label();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.labelDiffWand = new System.Windows.Forms.Label();
            this.labelDiffWandMess = new System.Windows.Forms.Label();
            this.labelMinWand = new System.Windows.Forms.Label();
            this.labelMinWandMess = new System.Windows.Forms.Label();
            this.labelMaxWand = new System.Windows.Forms.Label();
            this.labelMaxWandMess = new System.Windows.Forms.Label();
            this.groupBox1Messung = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartWallThickness)).BeginInit();
            this.groupBoxToleranzen.SuspendLayout();
            this.groupBox1Messung.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartWallThickness
            // 
            chartArea1.Name = "ChartArea1";
            this.chartWallThickness.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartWallThickness.Legends.Add(legend1);
            this.chartWallThickness.Location = new System.Drawing.Point(988, 46);
            this.chartWallThickness.Name = "chartWallThickness";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series1.CustomProperties = "CircularLabelsStyle=Circular";
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            series3.Legend = "Legend1";
            series3.Name = "Series3";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series4.Legend = "Legend1";
            series4.Name = "Series4";
            this.chartWallThickness.Series.Add(series1);
            this.chartWallThickness.Series.Add(series2);
            this.chartWallThickness.Series.Add(series3);
            this.chartWallThickness.Series.Add(series4);
            this.chartWallThickness.Size = new System.Drawing.Size(856, 779);
            this.chartWallThickness.TabIndex = 1;
            this.chartWallThickness.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            title1.Name = "Title1";
            title1.Text = "Gemessene Wandstärke";
            this.chartWallThickness.Titles.Add(title1);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.GreenYellow;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(63, 34);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(254, 152);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Messung Starten";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // groupBoxToleranzen
            // 
            this.groupBoxToleranzen.Controls.Add(this.labelTolMaxT);
            this.groupBoxToleranzen.Controls.Add(this.labelTolMinT);
            this.groupBoxToleranzen.Controls.Add(this.labelTolDiffT);
            this.groupBoxToleranzen.Controls.Add(this.labelTolMax);
            this.groupBoxToleranzen.Controls.Add(this.labelTolMin);
            this.groupBoxToleranzen.Controls.Add(this.labelTolDiff);
            this.groupBoxToleranzen.Controls.Add(this.labelMessobjekt);
            this.groupBoxToleranzen.Controls.Add(this.comboBoxProgram);
            this.groupBoxToleranzen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxToleranzen.Location = new System.Drawing.Point(47, 46);
            this.groupBoxToleranzen.Name = "groupBoxToleranzen";
            this.groupBoxToleranzen.Size = new System.Drawing.Size(505, 779);
            this.groupBoxToleranzen.TabIndex = 3;
            this.groupBoxToleranzen.TabStop = false;
            this.groupBoxToleranzen.Text = "Toleranzen";
            // 
            // labelTolMaxT
            // 
            this.labelTolMaxT.AutoSize = true;
            this.labelTolMaxT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTolMaxT.Location = new System.Drawing.Point(10, 489);
            this.labelTolMaxT.Name = "labelTolMaxT";
            this.labelTolMaxT.Size = new System.Drawing.Size(333, 37);
            this.labelTolMaxT.TabIndex = 7;
            this.labelTolMaxT.Text = "Maximale Wandstärke";
            // 
            // labelTolMinT
            // 
            this.labelTolMinT.AutoSize = true;
            this.labelTolMinT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTolMinT.Location = new System.Drawing.Point(10, 362);
            this.labelTolMinT.Name = "labelTolMinT";
            this.labelTolMinT.Size = new System.Drawing.Size(334, 37);
            this.labelTolMinT.TabIndex = 6;
            this.labelTolMinT.Text = "Minimale Wandstärke:";
            // 
            // labelTolDiffT
            // 
            this.labelTolDiffT.AutoSize = true;
            this.labelTolDiffT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTolDiffT.Location = new System.Drawing.Point(10, 240);
            this.labelTolDiffT.Name = "labelTolDiffT";
            this.labelTolDiffT.Size = new System.Drawing.Size(297, 37);
            this.labelTolDiffT.TabIndex = 5;
            this.labelTolDiffT.Text = "Maximale Differenz:";
            // 
            // labelTolMax
            // 
            this.labelTolMax.AutoSize = true;
            this.labelTolMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTolMax.Location = new System.Drawing.Point(10, 534);
            this.labelTolMax.Name = "labelTolMax";
            this.labelTolMax.Size = new System.Drawing.Size(98, 37);
            this.labelTolMax.TabIndex = 4;
            this.labelTolMax.Text = "0.000";
            // 
            // labelTolMin
            // 
            this.labelTolMin.AutoSize = true;
            this.labelTolMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTolMin.Location = new System.Drawing.Point(10, 408);
            this.labelTolMin.Name = "labelTolMin";
            this.labelTolMin.Size = new System.Drawing.Size(98, 37);
            this.labelTolMin.TabIndex = 3;
            this.labelTolMin.Text = "0.000";
            // 
            // labelTolDiff
            // 
            this.labelTolDiff.AutoSize = true;
            this.labelTolDiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTolDiff.ForeColor = System.Drawing.Color.Black;
            this.labelTolDiff.Location = new System.Drawing.Point(10, 286);
            this.labelTolDiff.Name = "labelTolDiff";
            this.labelTolDiff.Size = new System.Drawing.Size(98, 37);
            this.labelTolDiff.TabIndex = 2;
            this.labelTolDiff.Text = "0.000";
            // 
            // labelMessobjekt
            // 
            this.labelMessobjekt.AutoSize = true;
            this.labelMessobjekt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessobjekt.Location = new System.Drawing.Point(10, 46);
            this.labelMessobjekt.Name = "labelMessobjekt";
            this.labelMessobjekt.Size = new System.Drawing.Size(186, 37);
            this.labelMessobjekt.TabIndex = 1;
            this.labelMessobjekt.Text = "Messobjekt:";
            // 
            // comboBoxProgram
            // 
            this.comboBoxProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxProgram.FormattingEnabled = true;
            this.comboBoxProgram.Items.AddRange(new object[] {
            "2000er Zwischenbearbeitung",
            "2000er Endbearbeitung"});
            this.comboBoxProgram.Location = new System.Drawing.Point(17, 95);
            this.comboBoxProgram.Name = "comboBoxProgram";
            this.comboBoxProgram.Size = new System.Drawing.Size(466, 45);
            this.comboBoxProgram.TabIndex = 0;
            this.comboBoxProgram.SelectedIndexChanged += new System.EventHandler(this.comboBoxProgram_SelectedIndexChanged);
            // 
            // labelActVal
            // 
            this.labelActVal.AutoSize = true;
            this.labelActVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActVal.Location = new System.Drawing.Point(24, 671);
            this.labelActVal.Name = "labelActVal";
            this.labelActVal.Size = new System.Drawing.Size(294, 37);
            this.labelActVal.TabIndex = 5;
            this.labelActVal.Text = "Aktueller Messwert:";
            // 
            // labelActValMess
            // 
            this.labelActValMess.AutoSize = true;
            this.labelActValMess.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActValMess.ForeColor = System.Drawing.Color.Black;
            this.labelActValMess.Location = new System.Drawing.Point(23, 708);
            this.labelActValMess.Name = "labelActValMess";
            this.labelActValMess.Size = new System.Drawing.Size(119, 46);
            this.labelActValMess.TabIndex = 6;
            this.labelActValMess.Text = "0.000";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.BackColor = System.Drawing.Color.Black;
            this.richTextBoxLog.ForeColor = System.Drawing.Color.White;
            this.richTextBoxLog.Location = new System.Drawing.Point(47, 884);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(1797, 206);
            this.richTextBoxLog.TabIndex = 7;
            this.richTextBoxLog.Text = "";
            // 
            // labelDiffWand
            // 
            this.labelDiffWand.AutoSize = true;
            this.labelDiffWand.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiffWand.Location = new System.Drawing.Point(23, 240);
            this.labelDiffWand.Name = "labelDiffWand";
            this.labelDiffWand.Size = new System.Drawing.Size(334, 37);
            this.labelDiffWand.TabIndex = 8;
            this.labelDiffWand.Text = "Differenz Wandstärke:";
            // 
            // labelDiffWandMess
            // 
            this.labelDiffWandMess.AutoSize = true;
            this.labelDiffWandMess.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiffWandMess.Location = new System.Drawing.Point(23, 277);
            this.labelDiffWandMess.Name = "labelDiffWandMess";
            this.labelDiffWandMess.Size = new System.Drawing.Size(119, 46);
            this.labelDiffWandMess.TabIndex = 9;
            this.labelDiffWandMess.Text = "0.000";
            // 
            // labelMinWand
            // 
            this.labelMinWand.AutoSize = true;
            this.labelMinWand.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinWand.Location = new System.Drawing.Point(23, 362);
            this.labelMinWand.Name = "labelMinWand";
            this.labelMinWand.Size = new System.Drawing.Size(316, 37);
            this.labelMinWand.TabIndex = 10;
            this.labelMinWand.Text = "Minimale Wanstärke:";
            // 
            // labelMinWandMess
            // 
            this.labelMinWandMess.AutoSize = true;
            this.labelMinWandMess.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinWandMess.Location = new System.Drawing.Point(22, 399);
            this.labelMinWandMess.Name = "labelMinWandMess";
            this.labelMinWandMess.Size = new System.Drawing.Size(119, 46);
            this.labelMinWandMess.TabIndex = 11;
            this.labelMinWandMess.Text = "0.000";
            // 
            // labelMaxWand
            // 
            this.labelMaxWand.AutoSize = true;
            this.labelMaxWand.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaxWand.Location = new System.Drawing.Point(23, 489);
            this.labelMaxWand.Name = "labelMaxWand";
            this.labelMaxWand.Size = new System.Drawing.Size(342, 37);
            this.labelMaxWand.TabIndex = 12;
            this.labelMaxWand.Text = "Maximale Wandstärke:";
            // 
            // labelMaxWandMess
            // 
            this.labelMaxWandMess.AutoSize = true;
            this.labelMaxWandMess.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaxWandMess.Location = new System.Drawing.Point(22, 526);
            this.labelMaxWandMess.Name = "labelMaxWandMess";
            this.labelMaxWandMess.Size = new System.Drawing.Size(119, 46);
            this.labelMaxWandMess.TabIndex = 13;
            this.labelMaxWandMess.Text = "0.000";
            // 
            // groupBox1Messung
            // 
            this.groupBox1Messung.Controls.Add(this.buttonStart);
            this.groupBox1Messung.Controls.Add(this.labelMaxWandMess);
            this.groupBox1Messung.Controls.Add(this.labelActValMess);
            this.groupBox1Messung.Controls.Add(this.labelDiffWand);
            this.groupBox1Messung.Controls.Add(this.labelActVal);
            this.groupBox1Messung.Controls.Add(this.labelMaxWand);
            this.groupBox1Messung.Controls.Add(this.labelDiffWandMess);
            this.groupBox1Messung.Controls.Add(this.labelMinWandMess);
            this.groupBox1Messung.Controls.Add(this.labelMinWand);
            this.groupBox1Messung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1Messung.Location = new System.Drawing.Point(580, 46);
            this.groupBox1Messung.Name = "groupBox1Messung";
            this.groupBox1Messung.Size = new System.Drawing.Size(382, 779);
            this.groupBox1Messung.TabIndex = 14;
            this.groupBox1Messung.TabStop = false;
            this.groupBox1Messung.Text = "Messung";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1898, 1144);
            this.Controls.Add(this.groupBox1Messung);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.groupBoxToleranzen);
            this.Controls.Add(this.chartWallThickness);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Impeller Wandstärke";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.chartWallThickness)).EndInit();
            this.groupBoxToleranzen.ResumeLayout(false);
            this.groupBoxToleranzen.PerformLayout();
            this.groupBox1Messung.ResumeLayout(false);
            this.groupBox1Messung.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartWallThickness;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.GroupBox groupBoxToleranzen;
        private System.Windows.Forms.Label labelActVal;
        private System.Windows.Forms.Label labelActValMess;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Label labelDiffWand;
        private System.Windows.Forms.Label labelDiffWandMess;
        private System.Windows.Forms.Label labelMinWand;
        private System.Windows.Forms.Label labelMinWandMess;
        private System.Windows.Forms.Label labelMaxWand;
        private System.Windows.Forms.Label labelMaxWandMess;
        private System.Windows.Forms.ComboBox comboBoxProgram;
        private System.Windows.Forms.Label labelMessobjekt;
        private System.Windows.Forms.Label labelTolDiff;
        private System.Windows.Forms.Label labelTolMin;
        private System.Windows.Forms.Label labelTolMax;
        private System.Windows.Forms.Label labelTolDiffT;
        private System.Windows.Forms.Label labelTolMinT;
        private System.Windows.Forms.Label labelTolMaxT;
        private System.Windows.Forms.GroupBox groupBox1Messung;
    }
}

