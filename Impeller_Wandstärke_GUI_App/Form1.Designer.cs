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
            this.groupBoxEingabe = new System.Windows.Forms.GroupBox();
            this.labelWAnr = new System.Windows.Forms.Label();
            this.textBoxWA_NR = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelActVal = new System.Windows.Forms.Label();
            this.labelActValMess = new System.Windows.Forms.Label();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.labelDiffWand = new System.Windows.Forms.Label();
            this.labelDiffWandMess = new System.Windows.Forms.Label();
            this.labelMinWand = new System.Windows.Forms.Label();
            this.labelMinWandMess = new System.Windows.Forms.Label();
            this.labelMaxWand = new System.Windows.Forms.Label();
            this.labelMaxWandMess = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartWallThickness)).BeginInit();
            this.groupBoxEingabe.SuspendLayout();
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
            this.chartWallThickness.Location = new System.Drawing.Point(890, 46);
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
            this.chartWallThickness.Size = new System.Drawing.Size(912, 763);
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
            this.buttonStart.Location = new System.Drawing.Point(528, 71);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(254, 152);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Messung Starten";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // groupBoxEingabe
            // 
            this.groupBoxEingabe.Controls.Add(this.labelWAnr);
            this.groupBoxEingabe.Controls.Add(this.textBoxWA_NR);
            this.groupBoxEingabe.Controls.Add(this.buttonSave);
            this.groupBoxEingabe.Location = new System.Drawing.Point(28, 46);
            this.groupBoxEingabe.Name = "groupBoxEingabe";
            this.groupBoxEingabe.Size = new System.Drawing.Size(396, 763);
            this.groupBoxEingabe.TabIndex = 3;
            this.groupBoxEingabe.TabStop = false;
            this.groupBoxEingabe.Text = "Benutzereingabe";
            // 
            // labelWAnr
            // 
            this.labelWAnr.AutoSize = true;
            this.labelWAnr.Location = new System.Drawing.Point(16, 55);
            this.labelWAnr.Name = "labelWAnr";
            this.labelWAnr.Size = new System.Drawing.Size(104, 20);
            this.labelWAnr.TabIndex = 1;
            this.labelWAnr.Text = "WA-Nummer:";
            // 
            // textBoxWA_NR
            // 
            this.textBoxWA_NR.Location = new System.Drawing.Point(145, 52);
            this.textBoxWA_NR.Name = "textBoxWA_NR";
            this.textBoxWA_NR.Size = new System.Drawing.Size(228, 26);
            this.textBoxWA_NR.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(214, 642);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(140, 82);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Messwerte Speichern";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // labelActVal
            // 
            this.labelActVal.AutoSize = true;
            this.labelActVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActVal.Location = new System.Drawing.Point(488, 733);
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
            this.labelActValMess.Location = new System.Drawing.Point(487, 770);
            this.labelActValMess.Name = "labelActValMess";
            this.labelActValMess.Size = new System.Drawing.Size(119, 46);
            this.labelActValMess.TabIndex = 6;
            this.labelActValMess.Text = "0.000";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.BackColor = System.Drawing.Color.Black;
            this.richTextBoxLog.ForeColor = System.Drawing.Color.White;
            this.richTextBoxLog.Location = new System.Drawing.Point(75, 884);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(1727, 206);
            this.richTextBoxLog.TabIndex = 7;
            this.richTextBoxLog.Text = "";
            // 
            // labelDiffWand
            // 
            this.labelDiffWand.AutoSize = true;
            this.labelDiffWand.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiffWand.Location = new System.Drawing.Point(488, 286);
            this.labelDiffWand.Name = "labelDiffWand";
            this.labelDiffWand.Size = new System.Drawing.Size(334, 37);
            this.labelDiffWand.TabIndex = 8;
            this.labelDiffWand.Text = "Differenz Wandstärke:";
            // 
            // labelDiffWandMess
            // 
            this.labelDiffWandMess.AutoSize = true;
            this.labelDiffWandMess.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiffWandMess.Location = new System.Drawing.Point(488, 323);
            this.labelDiffWandMess.Name = "labelDiffWandMess";
            this.labelDiffWandMess.Size = new System.Drawing.Size(119, 46);
            this.labelDiffWandMess.TabIndex = 9;
            this.labelDiffWandMess.Text = "0.000";
            // 
            // labelMinWand
            // 
            this.labelMinWand.AutoSize = true;
            this.labelMinWand.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinWand.Location = new System.Drawing.Point(488, 408);
            this.labelMinWand.Name = "labelMinWand";
            this.labelMinWand.Size = new System.Drawing.Size(316, 37);
            this.labelMinWand.TabIndex = 10;
            this.labelMinWand.Text = "Minimale Wanstärke:";
            // 
            // labelMinWandMess
            // 
            this.labelMinWandMess.AutoSize = true;
            this.labelMinWandMess.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinWandMess.Location = new System.Drawing.Point(487, 445);
            this.labelMinWandMess.Name = "labelMinWandMess";
            this.labelMinWandMess.Size = new System.Drawing.Size(119, 46);
            this.labelMinWandMess.TabIndex = 11;
            this.labelMinWandMess.Text = "0.000";
            // 
            // labelMaxWand
            // 
            this.labelMaxWand.AutoSize = true;
            this.labelMaxWand.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaxWand.Location = new System.Drawing.Point(488, 535);
            this.labelMaxWand.Name = "labelMaxWand";
            this.labelMaxWand.Size = new System.Drawing.Size(342, 37);
            this.labelMaxWand.TabIndex = 12;
            this.labelMaxWand.Text = "Maximale Wandstärke:";
            // 
            // labelMaxWandMess
            // 
            this.labelMaxWandMess.AutoSize = true;
            this.labelMaxWandMess.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaxWandMess.Location = new System.Drawing.Point(487, 572);
            this.labelMaxWandMess.Name = "labelMaxWandMess";
            this.labelMaxWandMess.Size = new System.Drawing.Size(119, 46);
            this.labelMaxWandMess.TabIndex = 13;
            this.labelMaxWandMess.Text = "0.000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1898, 1144);
            this.Controls.Add(this.labelMaxWandMess);
            this.Controls.Add(this.labelMaxWand);
            this.Controls.Add(this.labelMinWandMess);
            this.Controls.Add(this.labelMinWand);
            this.Controls.Add(this.labelDiffWandMess);
            this.Controls.Add(this.labelDiffWand);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.labelActValMess);
            this.Controls.Add(this.labelActVal);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groupBoxEingabe);
            this.Controls.Add(this.chartWallThickness);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Impeller Wandstärke";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.chartWallThickness)).EndInit();
            this.groupBoxEingabe.ResumeLayout(false);
            this.groupBoxEingabe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartWallThickness;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.GroupBox groupBoxEingabe;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelWAnr;
        private System.Windows.Forms.TextBox textBoxWA_NR;
        private System.Windows.Forms.Label labelActVal;
        private System.Windows.Forms.Label labelActValMess;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Label labelDiffWand;
        private System.Windows.Forms.Label labelDiffWandMess;
        private System.Windows.Forms.Label labelMinWand;
        private System.Windows.Forms.Label labelMinWandMess;
        private System.Windows.Forms.Label labelMaxWand;
        private System.Windows.Forms.Label labelMaxWandMess;
    }
}

