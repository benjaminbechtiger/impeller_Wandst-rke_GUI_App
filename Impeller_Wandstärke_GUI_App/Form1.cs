using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net.Sockets;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace Impeller_Wandstärke_GUI_App
{
    public partial class Form1 : Form
    {
        private SerialPort serialPortTMCM1070;
        private TcpClient tcpClientKeyence;
        private NetworkStream netStreamKeyence;
        private Thread tcpThreadKeyence;
        private Timer timerKeyenceRead;
        private TMCM1070Controller tmcm1070Controller;

        public Form1()
        {
            InitializeComponent();
            InitTMCM1070Controller();
            InitKeyenceSensor();
            InitTimerKeyenceSensor();
        }

        private void InitTMCM1070Controller()
        {
            try
            {
                serialPortTMCM1070 = new SerialPort("COM3", 115200, Parity.None, 8, StopBits.One);

                var task = Task.Run(() => serialPortTMCM1070.Open());
                if (!task.Wait(TimeSpan.FromSeconds(5)))
                {
                    throw new TimeoutException("Es konnte keine UART Verbindung hergestellt werden, Timeout 5000ms");
                }
                tmcm1070Controller = new TMCM1070Controller(serialPortTMCM1070);

                LogMessage("TMCM-1070 Verbindung hergestellt", Color.White);
            }
            catch (Exception ex)
            {
                LogMessage("TMCM-1070 Fehler: " + ex.Message, Color.Red);
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

                tcpThreadKeyence = new Thread(ReadTcpLoop);
                tcpThreadKeyence.IsBackground = true;
                tcpThreadKeyence.Start();

                LogMessage("Verbindung zum Keyence Sensor hergestellt", Color.White);
            }
            catch (Exception ex)

            {
                LogMessage("Keyence Fehler: " + ex.Message, Color.Red);
            }
        }

        private void InitTimerKeyenceSensor()
        {
            timerKeyenceRead = new Timer();
            timerKeyenceRead.Interval = 100;
            timerKeyenceRead.Tick += Timer_Tick_Keyence_Sensor;
            timerKeyenceRead.Start();
        }

        private void Timer_Tick_Keyence_Sensor(object sender, EventArgs e)
        {
            if (tcpClientKeyence != null && tcpClientKeyence.Connected)
            {
                try
                {
                    byte[] request = System.Text.Encoding.ASCII.GetBytes("MS,1,1\r");
                    netStreamKeyence.Write(request, 0, request.Length);
                }
                catch (Exception ex)
                {
                    LogMessage("Keyence Sensor Schreib-Fehler: " + ex.Message, Color.Red);
                }
            }
        }

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

        private void ReadTcpLoop()
        {
            byte[] buffer = new byte[1024];
            try
            {
                while (netStreamKeyence != null && tcpClientKeyence.Connected)
                {
                    int bytes = netStreamKeyence.Read(buffer, 0, buffer.Length);
                    if (bytes > 0)
                    {
                        string msg = Encoding.ASCII.GetString(buffer, 0, bytes);
                        LogMessage("Keyence Sensor: " + msg, Color.White);
                        labelActValMess.Invoke((Action)(() => labelActValMess.Text = msg));
                    }
                }         
            }
            catch (Exception ex)
            {
                LogMessage("Keyence Empfangsfehler: " + ex.Message, Color.Red);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (tmcm1070Controller != null)
            {
                try
                {
                    if (tmcm1070Controller.Write(5, 1, 0, 0))                      //Position Achse 0 auf 0 microsteps setzen
                    {
                        bool success = tmcm1070Controller.Write(4, 0, 0, 12800);   //Achse 0 auf 12800 microsteps bewegen (1 Rot)

                        if (success)
                        {
                            LogMessage("Rotation gestartet", Color.White);
                        }
                        else
                        {
                            LogMessage("Kommunikation mit TMCM-1070 nicht möglich", Color.Red);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogMessage("TMCM-1070 Ausnahme: " + ex.Message, Color.Red);
                }
            }
        }
    }
}