using System;
using System.IO.Ports;
using System.Drawing;

namespace Impeller_Wandstärke_GUI_App
{
    class TMCM1141Controller
    {
        private readonly SerialPort _serial;
        private readonly byte _slaveAddress;
        private readonly Action<string, Color> _logger;
        private bool serial_was_open = false;

        private byte axis = 2;

        // Konstruktor
        public TMCM1141Controller(SerialPort serial, Action<string, Color> logger = null, byte slaveAddress = 2)
        {
            _serial = serial ?? throw new ArgumentNullException(nameof(serial));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _slaveAddress = slaveAddress;
        }

        // Datenlogger
        private void Log(string message, Color color)
        {
            _logger?.Invoke(message, color);
        }

        /// <summary>
        /// Sendet einen TMCL Befehl an den TMCM-3110 Controller.
        /// Stellt sicher, dass die serielle Verbindung offen ist und versucht ggf. neu zu verbinden.
        /// </summary>
        private bool SendTMCLCommand(byte command, byte type, uint value, out int replyValue, int timeoutMs = 50)
        {
            replyValue = 0;

            try
            {
                if (_serial == null)
                    Log("Serial port object is null.", Color.White);

                if (!_serial.IsOpen)
                {
                    try
                    {
                        _serial.Open();
                    }
                    catch (Exception ex)
                    {
                        if (serial_was_open) { Log($"[WARN] Unable to open serial port: {ex.Message}", Color.Yellow); }
                        serial_was_open = false;
                    }
                }

                // Frame bauen
                byte[] frame = new byte[9];
                frame[0] = _slaveAddress;
                frame[1] = command;
                frame[2] = type;
                frame[3] = axis;
                frame[4] = (byte)((value >> 24) & 0xFF);
                frame[5] = (byte)((value >> 16) & 0xFF);
                frame[6] = (byte)((value >> 8) & 0xFF);
                frame[7] = (byte)(value & 0xFF);

                // Checksumme
                byte checksum = 0;
                for (int i = 0; i < 8; i++)
                    checksum += frame[i];
                frame[8] = checksum;

                // Senden
                _serial.Write(frame, 0, frame.Length);
                _serial.BaseStream.Flush();

                // Antwort abwarten
                DateTime start = DateTime.Now;
                while (_serial.BytesToRead < 9)
                {
                    if ((DateTime.Now - start).TotalMilliseconds > timeoutMs)
                        return false;
                    System.Threading.Thread.Sleep(1);
                }

                // Antwort lesen
                byte[] response = new byte[9];
                int read = _serial.Read(response, 0, 9);
                if (read < 9) return false;

                // Prüfsumme prüfen
                byte sum = 0;
                for (int i = 0; i < 8; i++)
                    sum += response[i];
                if (sum != response[8]) return false;

                // Status prüfen
                if (response[2] != 100) return false;

                // 32-bit Wert auslesen
                replyValue = (response[4] << 24) |
                                (response[5] << 16) |
                                (response[6] << 8) |
                                response[7];

                if (!serial_was_open) { Log("Serial port reconnected", Color.White); }
                serial_was_open = true;

                return true;
            }
            catch (Exception ex)
            {
                if (serial_was_open) { Log($"[ERROR] Serial communication failed: {ex.Message}", Color.Red); }

                try { if (_serial.IsOpen) _serial.Close(); } catch { }
            }

            return false;
        }

        // Abstrahierte TMCL Write Funktion
        private bool Write(byte command, byte type, uint value)
        {
            return SendTMCLCommand(command, type, value, out _);
        }

        // Abstrahierte TMCL Read Funktion
        private bool Read(byte command, byte type, out int value)
        {
            return SendTMCLCommand(command, type, 0, out value);
        }

        // Referenzfahrt starten
        public bool StartReferenceSearch()
        {
            return Write(13, 0, 0);
        }

        // Auf eine Absolute Position in Umdrehungen bewegen (+/-)
        public bool MovePositionAbs(double revolutions)
        {
            int usteps_per_revolution = 12800;

            double position_usteps_double = Math.Round(revolutions * usteps_per_revolution, 3);
            int position_usteps = (int)Math.Round(position_usteps_double, MidpointRounding.AwayFromZero);
            uint position_uint = unchecked((uint)position_usteps);

            return Write(4, 0, position_uint);
        }

        // Achsenposition in Umdrehungen auslesen
        public bool GetActualPosition(out double position_rev)
        {
            position_rev = 0;

            bool read_status = Read(6, 1, out int position_usteps);

            int usteps_per_revolution = 12800;

            position_rev = Math.Round((double)position_usteps / usteps_per_revolution, 3);
            return read_status;
        }

        // 
        public bool GetActualSpeed(out int speed_upm)
        {
            bool read_status = Read(6, 3, out int speed);

            double speed_pps = speed * 30.5177 + 0.1105;
            speed_upm = (int)Math.Round(speed_pps * 60 / 12800, MidpointRounding.AwayFromZero);

            return read_status;
        }

        // Achse anhalten
        public bool MotorStop()
        {
            if (axis > 2) return false;
            return Write(3, 0, 0);
        }

        // Achse kontinuierlich nach rechts drehen, speed in U/min
        public bool RotateRight(int speed_upm)
        {
            double speed_pps = (double)speed_upm * 12800 / 60;
            int speed = (int)Math.Round((speed_pps - 0.1105) / 30.5177, MidpointRounding.AwayFromZero);

            return Write(1, 0, unchecked((uint)speed));
        }

        // Achse kontinuierlich nach links drehen, speed in U/min
        public bool RotateLeft(int speed_upm)
        {
            double speed_pps = (double)speed_upm * 12800 / 60;
            int speed = (int)Math.Round((speed_pps - 0.1105) / 30.5177, MidpointRounding.AwayFromZero);

            return Write(2, 0, unchecked((uint)speed));
        }

        // Achsenposition auf 0 setzen
        public bool ResetPosition()
        {
            return Write(5, 1, 0);
        }

        public bool SetPositioningSpeed(int speed_upm)
        {
            double speed_pps = (double)speed_upm * 12800 / 60;
            int speed = (int)Math.Round((speed_pps - 0.1105) / 30.5177, MidpointRounding.AwayFromZero);

            return Write(5, 4, unchecked((uint)speed));
        }
    }
}
