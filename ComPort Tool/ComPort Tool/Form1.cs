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
        //callback 委派
        delegate void Display(String text);

        //取得執行程式所在的路徑
        string str = System.Windows.Forms.Application.StartupPath;

        public Form1()
        {
            InitializeComponent();

            comboBox_BaudRate.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200" });
            comboBox_BaudRate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_BaudRate.SelectedIndex = 0;

            comboBox_Port.Items.Clear();
            String[] ports = SerialPort.GetPortNames();
            comboBox_Port.Items.AddRange(ports);
            comboBox_Port.SelectedIndex = 0;
            comboBox_Port.DropDownStyle = ComboBoxStyle.DropDownList;

            int x = (System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width);
            int y = (System.Windows.Forms.SystemInformation.WorkingArea.Height - this.Size.Height);
            this.StartPosition = FormStartPosition.Manual; //窗體的位置由Location屬性決定
            this.Location = (Point)new Size(x, y);         //窗體的起始位置為(x,y)

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            textBox1.ScrollBars = ScrollBars.Vertical;
        }

        private void button_Open_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                //通訊阜基礎參數設定
                serialPort1.PortName = comboBox_Port.Text;
                //修改BaudRate
                //serialPort1.BaudRate = 9600;
                serialPort1.BaudRate = Convert.ToInt32(comboBox_BaudRate.Text);
                serialPort1.Parity = Parity.None;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                //serialPort1.Encoding = Encoding.UTF8;
                serialPort1.Encoding = Encoding.ASCII;
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(comport_DataReceived);
                serialPort1.Open();
                if (serialPort1.IsOpen)
                {
                    Console.WriteLine("comport " + comboBox_Port.Text + " is open.");
                    // set button text color to green
                    this.button_Open.ForeColor = System.Drawing.Color.Green;
                    //this.button_Open.BackColor = System.Drawing.Color.Green;
                    button_Open.Text = "Close";
                }
                else
                {
                    Console.WriteLine("comport " + comboBox_Port.Text + " is not open.");
                }
            }
            else
            {
                serialPort1.Close();
                button_Open.Text = "Open";
                this.button_Open.ForeColor = System.Drawing.Color.Black;
                Console.WriteLine("comport " + comboBox_Port.Text + " is close.");

            }
        }
        private void comport_DataReceived(Object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                while (serialPort1.BytesToRead > 0)
                {
                    String data = serialPort1.ReadExisting();
                    if (data != String.Empty)
                    {
                        this.BeginInvoke(new Display(DisplayText), new object[] { data });
                    }
                }
            }
        }
        //comport Received Display
        private void DisplayText(String text)
        {
            string tmp = "";

            if (checkBox_Time_Tag.Checked)
                tmp = DateTime.Now.ToString("[HH:mm:ss] ");

            if (checkBox_Hex_Mode.Checked)
            {
                string hexValues = BitConverter.ToString(Encoding.ASCII.GetBytes(text)).Replace("-", "");
                text = hexValues;
            }

            tmp += text;
            textBox1.Text = textBox1.Text + tmp;

            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(Environment.ExitCode);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "csv files (*.csv)|*.csv|txt files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.FilterIndex = 1;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, textBox1.Text);
                }
            }
        }
        private void comboBox_Port_MouseEnter(object sender, EventArgs e)
        {


        }
        private void comboBox_Port_Click(object sender, EventArgs e)
        {
            comboBox_Port.Items.Clear();
            String[] ports = SerialPort.GetPortNames();
            comboBox_Port.Items.AddRange(ports);
        }

        private void button_Write_Click(object sender, EventArgs e)
        {
            string tmp;
            if (serialPort1.IsOpen == true)
            {
                tmp = textBox_out.Text;

                if (checkBox_Auto_New_Line.Checked)
                    tmp += "\n";

                serialPort1.WriteLine(tmp);
                textBox_out.Clear();
            }
        }
    }
}
