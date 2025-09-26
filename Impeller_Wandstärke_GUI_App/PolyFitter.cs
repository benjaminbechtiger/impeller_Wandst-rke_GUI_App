using System;
using System.Collections.Generic;
using System.Linq;

namespace Impeller_Wandstärke_GUI_App
{
    class PolyFitter
    {
        private double[] x;
        private double[] y;
        private int degree;
        private double[] coeffs;
        private double[] yFit;

        public PolyFitter(List<long> measurementTimeMs, List<double> measurementValues, int polynomialDegree = 3)
        {
            if (measurementTimeMs.Count != measurementValues.Count)
                throw new ArgumentException("x- und y-Listen müssen die gleiche Länge haben.");

            x = measurementTimeMs.Select(t => (double)t).ToArray();
            y = measurementValues.ToArray();
            degree = polynomialDegree;
        }

        /// <summary>
        /// FitCurve mit optionalem geschlossenen Fit und robustem Fit
        /// </summary>
        public void FitCurve(bool closed = false, bool robust = false)
        {
            double[] xFiltered = x;
            double[] yFiltered = y;

            if (robust)
            {
                // Einfache Ausreißer-Filterung: Werte > 2*Standardabweichung vom Mittelwert entfernen
                double mean = y.Average();
                double std = Math.Sqrt(y.Average(v => (v - mean) * (v - mean)));
                var filteredIndices = y.Select((v, i) => new { v, i })
                                       .Where(p => Math.Abs(p.v - mean) <= 2 * std)
                                       .Select(p => p.i)
                                       .ToArray();
                xFiltered = filteredIndices.Select(i => x[i]).ToArray();
                yFiltered = filteredIndices.Select(i => y[i]).ToArray();
            }

            coeffs = closed ? PolyFitClosed(xFiltered, yFiltered, degree) : PolyFit(xFiltered, yFiltered, degree);

            yFit = x.Select(xi =>
            {
                double yi = 0;
                for (int j = 0; j <= degree; j++)
                    yi += coeffs[j] * Math.Pow(xi, j);
                return yi;
            }).ToArray();
        }

        /// <summary>
        /// Sinus-Schwingung in Messwerte fitten mit Filter-Option robust
        /// </summary>
        /// <param name="period"></param>
        /// <param name="robust"></param>
        public void FitSinus(double period, bool robust = false)
        {
            double[] xFiltered = x;
            double[] yFiltered = y;

            if (robust)
            {
                // Einfache Ausreißer-Filterung
                double mean = y.Average();
                double std = Math.Sqrt(y.Average(v => (v - mean) * (v - mean)));
                var filteredIndices = y.Select((v, i) => new { v, i })
                                       .Where(p => Math.Abs(p.v - mean) <= 2 * std)
                                       .Select(p => p.i)
                                       .ToArray();
                xFiltered = filteredIndices.Select(i => x[i]).ToArray();
                yFiltered = filteredIndices.Select(i => y[i]).ToArray();
            }

            double omega = 2.0 * Math.PI / period;

            // Matrix A aufbauen
            int n = xFiltered.Length;
            double[,] A = new double[n, 3];
            double[] Y = yFiltered.ToArray();

            for (int i = 0; i < n; i++)
            {
                A[i, 0] = 1.0;                       // a0
                A[i, 1] = Math.Cos(omega * xFiltered[i]); // a1
                A[i, 2] = Math.Sin(omega * xFiltered[i]); // b1
            }

            // Normalgleichungen
            var At = Transpose(A);
            var AtA = Multiply(At, A);
            var AtY = Multiply(At, Y);

            double[] c = GaussianElimination(AtA, AtY); // [a0, a1, b1]
            coeffs = c;

            // Gefittete Werte berechnen
            yFit = x.Select(xi =>
                c[0] + c[1] * Math.Cos(omega * xi) + c[2] * Math.Sin(omega * xi)
            ).ToArray();
        }

        // Getter Methoden

        public double[] GetFittedValues()
        {
            if (yFit == null)
                throw new InvalidOperationException("Curve must be fitted first. Call FitCurve() first.");
            return yFit;
        }

        public int GetMinIndex()
        {
            if (yFit == null) throw new InvalidOperationException("FitCurve() must be called first.");
            double minVal = yFit.Min();
            return Array.IndexOf(yFit, minVal);
        }

        public int GetMaxIndex()
        {
            if (yFit == null) throw new InvalidOperationException("FitCurve() must be called first.");
            double maxVal = yFit.Max();
            return Array.IndexOf(yFit, maxVal);
        }

        public double GetMin() => yFit.Min();
        public double GetMax() => yFit.Max();
        public double GetDiff() => yFit.Max() - yFit.Min();
        public double GetSinusAmplitude() => Math.Sqrt(coeffs[1] * coeffs[1] + coeffs[2] * coeffs[2]);
        public double GetSinusPhase() => Math.Atan2(coeffs[2], coeffs[1]); // Phase in Radiant
        public double GetSinusOffset() => coeffs[0];

        // ==============================
        // Interne Hilfsmethoden
        // ==============================

        private double[] PolyFit(double[] x, double[] y, int degree)
        {
            int n = x.Length;
            double[,] X = new double[n, degree + 1];
            double[] Y = y.ToArray();

            for (int i = 0; i < n; i++)
            {
                double xi = 1.0;
                for (int j = 0; j <= degree; j++)
                {
                    X[i, j] = xi;
                    xi *= x[i];
                }
            }

            var Xt = Transpose(X);
            var XtX = Multiply(Xt, X);
            var XtY = Multiply(Xt, Y);

            return GaussianElimination(XtX, XtY);
        }

        private double[] PolyFitClosed(double[] x, double[] y, int degree)
        {
            // Normales Fit-Matrix erstellen
            int n = x.Length;
            double[,] X = new double[n, degree + 1];
            double[] Y = y.ToArray();

            for (int i = 0; i < n; i++)
            {
                double xi = 1.0;
                for (int j = 0; j <= degree; j++)
                {
                    X[i, j] = xi;
                    xi *= x[i];
                }
            }

            var Xt = Transpose(X);
            var XtX = Multiply(Xt, X);
            var XtY = Multiply(Xt, Y);

            // Bedingung für geschlossenen Fit: P(x0) = P(xn)
            double[] constraint = new double[degree + 1];
            for (int j = 0; j <= degree; j++)
                constraint[j] = Math.Pow(x[0], j) - Math.Pow(x[x.Length - 1], j);

            // Constraint als zusätzliche Gleichung einfügen
            double[,] XtX_aug = new double[degree + 2, degree + 1];
            double[] XtY_aug = new double[degree + 2];

            for (int i = 0; i <= degree; i++)
            {
                for (int j = 0; j <= degree; j++)
                    XtX_aug[i, j] = XtX[i, j];
                XtY_aug[i] = XtY[i];
            }

            // Constraint-Zeile
            for (int j = 0; j <= degree; j++)
                XtX_aug[degree + 1, j] = constraint[j];
            XtY_aug[degree + 1] = 0;

            // Lösen via pseudo-Gaussian (Augmented Matrix)
            return GaussianEliminationAugmented(XtX_aug, XtY_aug);
        }

        private double[,] Transpose(double[,] M)
        {
            int rows = M.GetLength(0), cols = M.GetLength(1);
            double[,] T = new double[cols, rows];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    T[j, i] = M[i, j];
            return T;
        }

        private double[,] Multiply(double[,] A, double[,] B)
        {
            int rA = A.GetLength(0), cA = A.GetLength(1);
            int rB = B.GetLength(0), cB = B.GetLength(1);
            double[,] R = new double[rA, cB];
            for (int i = 0; i < rA; i++)
                for (int j = 0; j < cB; j++)
                    for (int k = 0; k < cA; k++)
                        R[i, j] += A[i, k] * B[k, j];
            return R;
        }

        private double[] Multiply(double[,] A, double[] v)
        {
            int r = A.GetLength(0), c = A.GetLength(1);
            double[] R = new double[r];
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    R[i] += A[i, j] * v[j];
            return R;
        }

        private double[] GaussianElimination(double[,] A, double[] b)
        {
            int n = b.Length;
            double[,] M = new double[n, n + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++) M[i, j] = A[i, j];
                M[i, n] = b[i];
            }

            for (int i = 0; i < n; i++)
            {
                int maxRow = i;
                for (int k = i + 1; k < n; k++)
                    if (Math.Abs(M[k, i]) > Math.Abs(M[maxRow, i]))
                        maxRow = k;
                for (int k = i; k < n + 1; k++)
                {
                    double tmp = M[maxRow, k];
                    M[maxRow, k] = M[i, k];
                    M[i, k] = tmp;
                }

                for (int k = i + 1; k < n; k++)
                {
                    double c = M[k, i] / M[i, i];
                    for (int j = i; j < n + 1; j++)
                        M[k, j] -= c * M[i, j];
                }
            }

            double[] xSol = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                xSol[i] = M[i, n] / M[i, i];
                for (int k = i - 1; k >= 0; k--)
                    M[k, n] -= M[k, i] * xSol[i];
            }
            return xSol;
        }

        // Gaussian für augmentierte Gleichung (mehr Gleichungen als Unbekannte)
        private double[] GaussianEliminationAugmented(double[,] A, double[] b)
        {
            int rows = A.GetLength(0);
            int cols = A.GetLength(1); // cols = degree+1
            double[,] M = new double[rows, cols + 1];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++) M[i, j] = A[i, j];
                M[i, cols] = b[i];
            }

            // Standard-Gaussian Elimination (mit Pivot)
            for (int i = 0; i < cols; i++)
            {
                int maxRow = i;
                for (int k = i + 1; k < rows; k++)
                    if (Math.Abs(M[k, i]) > Math.Abs(M[maxRow, i]))
                        maxRow = k;

                for (int k = i; k < cols + 1; k++)
                {
                    double tmp = M[maxRow, k];
                    M[maxRow, k] = M[i, k];
                    M[i, k] = tmp;
                }

                for (int k = i + 1; k < rows; k++)
                {
                    double c = M[k, i] / M[i, i];
                    for (int j = i; j < cols + 1; j++)
                        M[k, j] -= c * M[i, j];
                }
            }

            double[] xSol = new double[cols];
            for (int i = cols - 1; i >= 0; i--)
            {
                xSol[i] = M[i, cols] / M[i, i];
                for (int k = i - 1; k >= 0; k--)
                    M[k, cols] -= M[k, i] * xSol[i];
            }
            return xSol;
        }
    }
}