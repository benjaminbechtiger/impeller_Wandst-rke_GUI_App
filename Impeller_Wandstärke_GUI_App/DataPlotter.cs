using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;

namespace Impeller_Wandstärke_GUI_App
{
    class DataPlotter
    {
        private readonly Action<string, Color> _logger;
        private Chart _chart;
        private Series seriesMeasured;
        private double X_Max;

        public DataPlotter(Chart chart, Action<string, Color> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _chart = chart;

            _chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            _chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            _chart.ChartAreas[0].AxisX.LabelStyle.Format = "{0}°";
        }

        // Datenlogger
        private void Log(string message, Color color)
        {
            _logger?.Invoke(message, color);
        }

        public void SetLimits(double y_min, double y_max, double x_min = 0, double x_max = 360)
        {
            _chart.ChartAreas[0].AxisX.Minimum = x_min;
            _chart.ChartAreas[0].AxisX.Maximum = x_max;
            _chart.ChartAreas[0].AxisY.Minimum = y_min;
            _chart.ChartAreas[0].AxisY.Maximum = y_max;
            X_Max = x_max;
        }

        public void NewSeries(string name, SeriesChartType chartType = SeriesChartType.Polar, MarkerStyle markerStyle = MarkerStyle.Circle, int markerSize = 6)
        {
            _chart.Series.Clear();
            seriesMeasured = new Series(name);
            seriesMeasured.ChartType = chartType;
            seriesMeasured.MarkerStyle = markerStyle;
            seriesMeasured.MarkerSize = markerSize;
            _chart.Series.Add(seriesMeasured);
        }

        public double GetListMin(List<double> data)
        {
            double min_val = data.Count > 0 ? data[0] : 0;
            for (int i = 1; i < data.Count; i++)
            {
                if (data[i] < min_val) min_val = data[i];
            }
            return min_val;
        }

        public long GetListMax(List<long> data)
        {
            long maxVal = data.Count > 0 ? data[0] : 0;
            for (int i = 1; i < data.Count; i++)
            {
                if (data[i] > maxVal) maxVal = data[i];
            }
            return maxVal;
        }

        public void PlotData(List<long> data_x, List<double> data_y)
        {
            // Maximum der Zeit ermitteln
            long maxTime = GetListMax(data_x);

            // Alle Messpunkte in Polar-Koordinaten eintragen
            for (int i = 0; i < data_y.Count; i++)
            {
                double angle = maxTime > 0 ? (data_x[i] / (double)maxTime) * X_Max : 0;
                double radius = data_y[i];
                seriesMeasured.Points.AddXY(angle, radius);
            }
        }

        public void PlotFittedCurve(
            List<long> data_x, double[] fitted_y, int index_min, int index_max,
            string seriesName = "Wandstärke", Color? curveColor = null)
        {
            if (data_x.Count != fitted_y.Length)
                throw new ArgumentException("data_x and fitted_y must have the same length.");

            long maxTime = GetListMax(data_x);

            // === Gefittete Kurve ===
            var fittedSeries = new Series(seriesName)
            {
                ChartType = SeriesChartType.Polar,
                BorderWidth = 2,
                Color = curveColor ?? Color.Red,
                IsVisibleInLegend = true,
                LegendText = "Gefittete Kurve"
            };

            for (int i = 0; i < fitted_y.Length; i++)
            {
                double angle = maxTime > 0 ? (data_x[i] / (double)maxTime) * X_Max : 0;
                double radius = fitted_y[i];
                fittedSeries.Points.AddXY(angle, radius);
            }
            _chart.Series.Add(fittedSeries);

            // === Min-Punkt ===
            var minSeries = new Series("Minimum")
            {
                ChartType = SeriesChartType.Polar,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 12,
                Color = Color.Blue,
                IsVisibleInLegend = true,
                LegendText = "Minimum"
            };

            double angleMin = (data_x[index_min] / (double)maxTime) * X_Max;
            minSeries.Points.AddXY(angleMin, fitted_y[index_min]);
            _chart.Series.Add(minSeries);

            // === Max-Punkt ===
            var maxSeries = new Series("Maximum")
            {
                ChartType = SeriesChartType.Polar,
                MarkerStyle = MarkerStyle.Diamond,
                MarkerSize = 12,
                Color = Color.Green,
                IsVisibleInLegend = true,
                LegendText = "Maximum"
            };

            double angleMax = (data_x[index_max] / (double)maxTime) * X_Max;
            maxSeries.Points.AddXY(angleMax, fitted_y[index_max]);
            _chart.Series.Add(maxSeries);
        }
    }
}
