using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace ComPort_Tool
{
    public partial class Form1 : Form
    {
        // Display delegate
        delegate void Display(String text);
        private Thread thread_receive;
        private Boolean receiving;

        /* Form1 initial function */
        public Form1()
        {
            InitializeComponent();

            /* initial comboBox_BaudRate Items */

            // CP2101 Single-Chip USB to UART Bridge 
            // Table 12. Data Formats and Baud Rates
            // 300, 600, 1200, 1800, 2400, 4000, 4800, 7200, 9600, 14400, 16000, 19200, 28800, 38400,
            // 51200, 56000, 57600, 64000, 76800, 115200, 128000, 153600, 230400, 250000, 256000,
            // 460800, 500000, 576000, 9216003

            // PL2303SA max is 115200
            comboBox_BaudRate.Items.AddRange(new object[] { "9600", "19200", "38400", "115200", "250000", "576000" });
            comboBox_BaudRate.DropDownStyle = ComboBoxStyle.DropDownList;
            // default baud rate is 115200
            comboBox_BaudRate.SelectedIndex = 3;

            /* initial comboBox_Port Items */
            comboBox_Port.Items.Clear();
            String[] ports = SerialPort.GetPortNames();  // get port
            comboBox_Port.Items.AddRange(ports);
            comboBox_Port.SelectedIndex = 0;
            comboBox_Port.DropDownStyle = ComboBoxStyle.DropDownList; // set comboBox_Port text can't change

            /* initial Form1 */
            /* Set the window position to the bottom left of the screen */
            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width);
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = (Point)new Size(x, y);
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // set Form1 size can't change

            /* initial textBox1 */
            textBox1.ScrollBars = ScrollBars.Vertical; // set textBox1 show ScrollBars
            checkBox_ASCII_Mode.Checked = true;
        }

        private void DoReceive()
        {
            Byte[] buffer = new Byte[1024];
            while (serialPort1.IsOpen == true && receiving == true)
            {
                if (serialPort1.BytesToRead > 0)
                {
                    String data = serialPort1.ReadExisting();
                    if (data != String.Empty)
                    {
                        this.BeginInvoke(new Display(DisplayText), new object[] { data });
                    }
                }
                Thread.Sleep(1);
            }
            Thread.Sleep(5);
        }

        /* open or close comport */
        private void button_Open_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                try
                {
                    /* initial serialPort1 */
                    serialPort1.PortName = comboBox_Port.Text;
                }
                catch (System.ArgumentException e1)
                {
                    MessageBox.Show("Comport not exists!", "ERROR");
                    return;
                }
                
                /* modify fixed baud rate */
                serialPort1.BaudRate = Convert.ToInt32(comboBox_BaudRate.Text);
                serialPort1.Parity = Parity.None;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                //serialPort1.Encoding = Encoding.UTF8;
                serialPort1.Encoding = Encoding.ASCII;
                //serialPort1.DataReceived += new SerialDataReceivedEventHandler(comport_DataReceived);

                try
                {
                    serialPort1.Open();
                }
                catch (System.IO.IOException e1)
                {
                    MessageBox.Show("The device does not support the selected baud rate!", "ERROR");
                }

                if (serialPort1.IsOpen)
                {
                    //Console.WriteLine("comport " + comboBox_Port.Text + " is open.");
                    // set button text color to green
                    this.button_Open.ForeColor = System.Drawing.Color.Green;
                    button_Open.Text = "Close";
                    receiving = true;
                    //if (thread_receive == null)
                        thread_receive = new Thread(DoReceive);
                    thread_receive.IsBackground = true;
                    thread_receive.Start();
                }
                else
                {
                    //Console.WriteLine("comport " + comboBox_Port.Text + " is not open.");
                }
            }
            else
            {
                receiving = false;
                serialPort1.Close();
                button_Open.Text = "Open";
                this.button_Open.ForeColor = System.Drawing.Color.Black;
                //Console.WriteLine("comport " + comboBox_Port.Text + " is close.");
            }
        }

        /* comport received display callback function */
        private void comport_DataReceived(Object sender, SerialDataReceivedEventArgs e)
        {

        }

        /* comport received display interface */
        private void DisplayText(String text)
        {
            int i = 0;
            string hexValues, tmp = "";

            /* Hex Mode */
            if (checkBox_Hex_Mode.Checked)
            {
                hexValues = BitConverter.ToString(Encoding.ASCII.GetBytes(text)).Replace("-", "");
                tmp += '[';
                foreach (char c in hexValues){
                    if (i!=0 && i% 2 == 0)
                        tmp += "] [";
                    tmp += c;
                    i++;
                }
                tmp += "] ";
                // text = hexValues;
            }

            /* Bin Mode */
            else if (checkBox_Bin_Mode.Checked)
            {
                foreach (char c in text)
                {
                    tmp += Convert.ToString(c, 2).PadLeft(8, '0');
                    tmp += " | ";
                }
            }

            /* ASCII Mode */
            if (checkBox_ASCII_Mode.Checked)
                tmp += text;

            if (checkBox_Time_Tag.Checked)
                tmp = DateTime.Now.ToString("[HH:mm:ss] ") + tmp;

            textBox1.Text = textBox1.Text + tmp;
        }

        /* auto set cursor to the bottom */
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        /* clear textBox1 text */
        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        /* close this form */
        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(Environment.ExitCode);
        }

        /* save textBox1 text */
        private void button_Save_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.FilterIndex = 1;
                sfd.FileName = "log_" + DateTime.Now.ToString("yyyy-MM-dd");

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, textBox1.Text);
                }
            }
        }

        private void comboBox_Port_MouseEnter(object sender, EventArgs e)
        {

        }

        /* update comboBox item when comboBox Click  */
        private void comboBox_Port_Click(object sender, EventArgs e)
        {
            comboBox_Port.Items.Clear();
            String[] ports = SerialPort.GetPortNames();
            comboBox_Port.Items.AddRange(ports);
        }

        /* send text to comport */

        private void send_text()
        {
            string tmp;
            if (serialPort1.IsOpen == true)
            {
                tmp = textBox_out.Text;

                if (checkBox_Auto_New_Line.Checked)
                    tmp += "\n";

                serialPort1.Write(tmp);
                textBox_out.Clear();
            }
        }
        private void button_Write_Click(object sender, EventArgs e)
        {
            send_text();
        }

        /* if ASCII_Mode is Checked, uncheck othen checkBox */
        private void checkBox_ASCII_Mode_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_ASCII_Mode.Checked)
            {
                checkBox_Hex_Mode.Checked = false;
                checkBox_Bin_Mode.Checked = false;
            }
        }

        /* if Hex_Mode is Checked, uncheck othen checkBox */
        private void checkBox_Hex_Mode_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Hex_Mode.Checked)
            {
                checkBox_Bin_Mode.Checked = false;
                checkBox_ASCII_Mode.Checked = false;
            }
        }

        /* if Bin_Mode is Checked, uncheck othen checkBox */
        private void checkBox_Bin_Mode_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Bin_Mode.Checked)
            {
                checkBox_Hex_Mode.Checked = false;
                checkBox_ASCII_Mode.Checked = false;
            }
        }

        private void textBox_out_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == Keys.Enter)
               // button_Write.Click();
        }

        private void textBox_out_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                send_text();
        }
    }
}
