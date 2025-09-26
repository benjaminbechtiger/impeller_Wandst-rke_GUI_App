using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Globalization;
using Timer = System.Windows.Forms.Timer;


namespace Impeller_Wandstärke_GUI_App
{
    public partial class Form1 : Form
    {
        // private Variabeln
        private SerialPort serialPortTMCM1141;
        private TMCM1141Controller tmcm1141Controller;
        private DataPlotter dataPlotter;
        private TcpClient tcpClientKeyence;
        private NetworkStream netStreamKeyence;
        private Thread tcpThreadKeyence;

        private Timer timerKeyence;
        private Timer timerTMCM1141;
        private Timer measurementTimer;
        private Stopwatch stopwatch;

        private List<long> measurementTimeMs = new List<long>();
        private List<double> measurementValues = new List<double>();

        private int act_speed_TMCM1141;
        private double keyence_value;
        private readonly object keyenceLock = new object();
        bool logged = false;
        private int counter = 0;

        public Form1()
        {
            InitializeComponent();
            InitTMCM1141Controller();
            InitKeyenceSensor();
            InitTimerKeyenceSensor();
            InitTimerTMCM1141();
            InitMeasurementTimer();

            dataPlotter = new DataPlotter(chartWallThickness, LogMessage);
            groupBoxEingabe.Visible = false;
        }

        // Hardware Initialisierungen

        private void InitTMCM1141Controller()
        {
            string[] ports = SerialPort.GetPortNames(); // alle verfügbaren COM-Ports
            bool connected = false; 

            foreach (string portName in ports)
            {
                try
                {
                    using (var serialPort = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One))
                    {
                        serialPort.Open();

                        var controller = new TMCM1141Controller(serialPort, LogMessage);
                        controller.SetPositioningSpeed(10);

                        // Prüfen, ob Controller antwortet
                        if (controller.GetActualPosition(out double pos))
                        {
                            tmcm1141Controller = controller; // Verbindung erfolgreich
                            serialPortTMCM1141 = serialPort; // Port speichern
                            LogMessage($"TMCM-1141 Verbindung hergestellt auf {portName}", Color.White);
                            connected = true;
                            break;
                        }
                        else
                        {
                            serialPort.Close(); // antwortet nicht -> Port schließen
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogMessage($"Fehler auf Port {portName}: {ex.Message}", Color.Red);
                }
            }

            if (!connected && !logged)
            {
                LogMessage("TMCM-1141 konnte auf keinem Port gefunden werden!", Color.Red);
                logged = true;
            }
        }


        private void InitKeyenceSensor()
        {
            try
            {
                tcpClientKeyence = new TcpClient();

                // Async Connect starten
                var result = tcpClientKeyence.BeginConnect("192.168.0.1", 24685, null, null);

                // Warten max. 5 Sekunden
                bool success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5));

                if (!success)
                {
                    throw new TimeoutException("Es konnte keine Verbindung zum Keyence Sensor hergestellt werden, Timeout 5000 ms");
                }

                // Verbindung fertigstellen
                tcpClientKeyence.EndConnect(result);
                netStreamKeyence = tcpClientKeyence.GetStream();

                tcpThreadKeyence = new Thread(ReadKeyenceLoop);
                tcpThreadKeyence.IsBackground = true;
                tcpThreadKeyence.Start();

                LogMessage("Verbindung zum Keyence Sensor hergestellt", Color.White);
            }
            catch (Exception ex)

            {
                LogMessage("Keyence Fehler: " + ex.Message, Color.Red);
            }
        }


        // Timer Initialisierungen

        private void InitTimerKeyenceSensor()
        {
            timerKeyence = new Timer();
            timerKeyence.Interval = 50;
            timerKeyence.Tick += Timer_Tick_Keyence_Sensor;
            timerKeyence.Start();
        }

        private void InitTimerTMCM1141()
        {
            timerTMCM1141 = new Timer();
            timerTMCM1141.Interval = 50;
            timerTMCM1141.Tick += Timer_Tick_TMCM1141;
            timerTMCM1141.Start();
        }

        private void InitMeasurementTimer()
        {
            measurementTimer = new Timer();
            measurementTimer.Interval = 100;
            measurementTimer.Tick += MeasurementTimer_Tick;
            stopwatch = new Stopwatch();
        }

        // Kontinuerliche Anfragen für den aktuellen Sensormesswert
        private void Timer_Tick_Keyence_Sensor(object sender, EventArgs e)
        {
            if (tcpClientKeyence != null && tcpClientKeyence.Connected)
            {
                try
                {
                    byte[] request = Encoding.ASCII.GetBytes("MS,1,1\r");
                    netStreamKeyence.Write(request, 0, request.Length);
                }
                catch (Exception ex)
                {
                    LogMessage("Keyence Sensor Schreib-Fehler: " + ex.Message, Color.Red);
                }
            }
        }

        // Kontinuerliches Auslesen der Schrittmotor-Geschwindigkeit
        private void Timer_Tick_TMCM1141(object sender, EventArgs e)
        {
            if (tmcm1141Controller != null)
            {
                try
                {
                    tmcm1141Controller.GetActualSpeed(out act_speed_TMCM1141);
                }
                catch (Exception ex)
                {
                    LogMessage("Fehler beim Auslesen der Geschwindigkeit: " + ex.Message, Color.Red);
                }
            }
            else
            {
                counter++;
                if (counter > 100)
                {
                    InitTMCM1141Controller();
                    counter = 0;
                }
            }
        }

        // Wenn Messung gestartet wurde, werden Messwerte mit Zeitstempeln gesammelt 
        // bis die Drehung des Schrittmotors beendet ist (speed == 0)
        private void MeasurementTimer_Tick(object sender, EventArgs e)
        {
            if (act_speed_TMCM1141 != 0)
            {
                long elapsedMs = stopwatch.ElapsedMilliseconds;
                double currentValue;

                lock (keyenceLock)
                {
                    currentValue = keyence_value;
                }

                measurementTimeMs.Add(elapsedMs);
                measurementValues.Add(currentValue);

                LogMessage($"t={elapsedMs} ms | Wert={currentValue}", Color.LightBlue);
            }
            else
            {
                int count = measurementValues.Count;
                int displayCount = Math.Min(10, count);

                buttonStart.Enabled = true;
                buttonStart.BackColor = Color.GreenYellow;

                LogMessage("Messung beendet", Color.LightBlue);
                LogMessage("Letzte Messwerte: (..." + string.Join(", ", measurementValues.GetRange(count - displayCount, displayCount)) + ")", Color.LightGreen);
                LogMessage("Letzte Messzeiten: (..." + string.Join(", ", measurementTimeMs.GetRange(count - displayCount, displayCount)) + ")", Color.LightBlue);

                var fitter = new PolyFitter(measurementTimeMs, measurementValues, polynomialDegree: 5);
                fitter.FitCurve(true, true);
                double[] fittedValues = fitter.GetFittedValues();
                double diffFit = fitter.GetDiff();
                double maxVal = fitter.GetMax();
                int max_index = fitter.GetMaxIndex();
                double minVal = fitter.GetMin();
                int min_index = fitter.GetMinIndex();

                // Chart plotten
                dataPlotter.SetLimits(0, 360, 0, 2);
                dataPlotter.PlotData(measurementTimeMs, measurementValues);
                dataPlotter.PlotFittedCurve(measurementTimeMs, fittedValues, min_index, max_index, "Gefittet");

                labelMinWandMess.Text = minVal.ToString("F3");
                labelMaxWandMess.Text = maxVal.ToString("F3");
                labelDiffWandMess.Text = diffFit.ToString("F3");

                measurementTimer.Stop();
                stopwatch.Stop();
            }
        }

        // Keyence Thread für das Abholen der Messwerte
        private void ReadKeyenceLoop()
        {
            byte[] buffer = new byte[1024];
            try
            {
                while (netStreamKeyence != null && tcpClientKeyence.Connected)
                {
                    int bytes = netStreamKeyence.Read(buffer, 0, buffer.Length);
                    if (bytes > 0)
                    {
                        string msg = Encoding.ASCII.GetString(buffer, 0, bytes).Trim();

                        // CSV-Teile aufsplitten
                        string[] parts = msg.Split(',');

                        if (parts.Length >= 2)
                        {
                            string valuePart = parts[1].Trim();
                            labelActValMess.Invoke((Action)(() => labelActValMess.Text = valuePart));

                            if (double.TryParse(valuePart, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                            {
                                lock (keyenceLock)
                                {
                                    keyence_value = value;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage("Keyence Empfangsfehler: " + ex.Message, Color.Red);
            }
        }

        // Logfunktion
        private void LogMessage(string message, Color color)
        {
            if (richTextBoxLog.InvokeRequired)
            {
                richTextBoxLog.BeginInvoke(new Action(() => LogMessage(message, color)));
            }
            else
            {
                int start = richTextBoxLog.TextLength;
                richTextBoxLog.AppendText(message + Environment.NewLine);
                int end = richTextBoxLog.TextLength;

                richTextBoxLog.Select(start, end - start);
                richTextBoxLog.SelectionColor = color;
                richTextBoxLog.SelectionLength = 0;
                richTextBoxLog.ScrollToCaret();
            }
        }

        // Messung Starten gedrückt
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (tmcm1141Controller != null)
            {
                buttonStart.Enabled = false;
                buttonStart.BackColor = Color.Red;
                labelMinWandMess.Text = "0.000";
                labelDiffWandMess.Text = "0.000";
                dataPlotter.NewSeries("Wandstärke");
                try
                {
                    if (tmcm1141Controller.ResetPosition())                         //Position Achse Zurücksetzen
                    {
                        bool success = tmcm1141Controller.MovePositionAbs(-1);       //-1 Umdrehung

                        if (success) // wenn die Umdrehung gestartet wird
                        {
                            measurementTimeMs.Clear();
                            measurementValues.Clear();
                            stopwatch.Restart();
                            measurementTimer.Start();
                            LogMessage("Rotation gestartet", Color.White);
                        }
                        else
                        {
                            LogMessage("Kommunikation mit TMCM-1141 nicht möglich", Color.Red);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogMessage("TMCM-1141 Ausnahme: " + ex.Message, Color.Red);
                }
            }
            else
            {
                LogMessage("TMCM-1141 ist nicht verbunden!", Color.Yellow);
            }
        }
    }
}