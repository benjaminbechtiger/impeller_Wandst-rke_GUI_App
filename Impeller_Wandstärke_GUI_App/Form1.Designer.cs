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
            ((System.ComponentModel.ISupportInitialize)(this.chartWallThickness)).BeginInit();
            this.groupBoxEingabe.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartWallThickness
            // 
            chartArea1.Name = "ChartArea1";
            this.chartWallThickness.ChartAreas.Add(chartArea1);
            legend1.AutoFitMinFontSize = 8;
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 5F;
            legend1.Position.Width = 30F;
            legend1.Position.X = 70F;
            legend1.Position.Y = 10F;
            this.chartWallThickness.Legends.Add(legend1);
            this.chartWallThickness.Location = new System.Drawing.Point(609, 18);
            this.chartWallThickness.Name = "chartWallThickness";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar;
            series1.CustomProperties = "CircularLabelsStyle=Circular";
            series1.Legend = "Legend1";
            series1.Name = "Letzte Messung";
            this.chartWallThickness.Series.Add(series1);
            this.chartWallThickness.Size = new System.Drawing.Size(628, 520);
            this.chartWallThickness.TabIndex = 1;
            this.chartWallThickness.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            title1.Name = "Title1";
            title1.Text = "Gemessene Wandstärke";
            this.chartWallThickness.Titles.Add(title1);
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(413, 30);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(140, 82);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Messung Starten";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // groupBoxEingabe
            // 
            this.groupBoxEingabe.Controls.Add(this.labelWAnr);
            this.groupBoxEingabe.Controls.Add(this.textBoxWA_NR);
            this.groupBoxEingabe.Location = new System.Drawing.Point(28, 18);
            this.groupBoxEingabe.Name = "groupBoxEingabe";
            this.groupBoxEingabe.Size = new System.Drawing.Size(343, 520);
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
            this.textBoxWA_NR.Size = new System.Drawing.Size(178, 26);
            this.textBoxWA_NR.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(413, 139);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(140, 82);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Messwerte Speichern";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // labelActVal
            // 
            this.labelActVal.AutoSize = true;
            this.labelActVal.Location = new System.Drawing.Point(397, 471);
            this.labelActVal.Name = "labelActVal";
            this.labelActVal.Size = new System.Drawing.Size(147, 20);
            this.labelActVal.TabIndex = 5;
            this.labelActVal.Text = "Aktueller Messwert:";
            // 
            // labelActValMess
            // 
            this.labelActValMess.AutoSize = true;
            this.labelActValMess.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActValMess.Location = new System.Drawing.Point(394, 501);
            this.labelActValMess.Name = "labelActValMess";
            this.labelActValMess.Size = new System.Drawing.Size(98, 37);
            this.labelActValMess.TabIndex = 6;
            this.labelActValMess.Text = "0.000";
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.BackColor = System.Drawing.Color.Black;
            this.richTextBoxLog.ForeColor = System.Drawing.Color.White;
            this.richTextBoxLog.Location = new System.Drawing.Point(28, 556);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(1209, 96);
            this.richTextBoxLog.TabIndex = 7;
            this.richTextBoxLog.Text = "";
            // 
            // labelDiffWand
            // 
            this.labelDiffWand.AutoSize = true;
            this.labelDiffWand.Location = new System.Drawing.Point(397, 261);
            this.labelDiffWand.Name = "labelDiffWand";
            this.labelDiffWand.Size = new System.Drawing.Size(168, 20);
            this.labelDiffWand.TabIndex = 8;
            this.labelDiffWand.Text = "Differenz Wandstärke:";
            // 
            // labelDiffWandMess
            // 
            this.labelDiffWandMess.AutoSize = true;
            this.labelDiffWandMess.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiffWandMess.Location = new System.Drawing.Point(394, 294);
            this.labelDiffWandMess.Name = "labelDiffWandMess";
            this.labelDiffWandMess.Size = new System.Drawing.Size(98, 37);
            this.labelDiffWandMess.TabIndex = 9;
            this.labelDiffWandMess.Text = "0.000";
            // 
            // labelMinWand
            // 
            this.labelMinWand.AutoSize = true;
            this.labelMinWand.Location = new System.Drawing.Point(397, 364);
            this.labelMinWand.Name = "labelMinWand";
            this.labelMinWand.Size = new System.Drawing.Size(156, 20);
            this.labelMinWand.TabIndex = 10;
            this.labelMinWand.Text = "Minimale Wanstärke:";
            // 
            // labelMinWandMess
            // 
            this.labelMinWandMess.AutoSize = true;
            this.labelMinWandMess.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinWandMess.Location = new System.Drawing.Point(394, 396);
            this.labelMinWandMess.Name = "labelMinWandMess";
            this.labelMinWandMess.Size = new System.Drawing.Size(98, 37);
            this.labelMinWandMess.TabIndex = 11;
            this.labelMinWandMess.Text = "0.000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.labelMinWandMess);
            this.Controls.Add(this.labelMinWand);
            this.Controls.Add(this.labelDiffWandMess);
            this.Controls.Add(this.labelDiffWand);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.labelActValMess);
            this.Controls.Add(this.labelActVal);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groupBoxEingabe);
            this.Controls.Add(this.chartWallThickness);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Impeller Wandstärke";
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
    }
}

