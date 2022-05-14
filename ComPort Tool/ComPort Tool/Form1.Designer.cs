namespace ComPort_Tool
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_Open = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox_out = new System.Windows.Forms.TextBox();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Write = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.comboBox_Port = new System.Windows.Forms.ComboBox();
            this.comboBox_BaudRate = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.checkBox_Auto_New_Line = new System.Windows.Forms.CheckBox();
            this.checkBox_Time_Tag = new System.Windows.Forms.CheckBox();
            this.checkBox_Hex_Mode = new System.Windows.Forms.CheckBox();
            this.checkBox_Bin_Mode = new System.Windows.Forms.CheckBox();
            this.checkBox_ASCII_Mode = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_Open
            // 
            this.button_Open.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Open.Location = new System.Drawing.Point(785, 154);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(136, 36);
            this.button_Open.TabIndex = 1;
            this.button_Open.Text = "Open";
            this.button_Open.UseVisualStyleBackColor = true;
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(767, 313);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_out
            // 
            this.textBox_out.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_out.Location = new System.Drawing.Point(12, 331);
            this.textBox_out.Name = "textBox_out";
            this.textBox_out.Size = new System.Drawing.Size(767, 27);
            this.textBox_out.TabIndex = 4;
            this.textBox_out.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_out_KeyDown);
            this.textBox_out.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_out_KeyPress);
            // 
            // button_Clear
            // 
            this.button_Clear.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Clear.Location = new System.Drawing.Point(785, 196);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(136, 36);
            this.button_Clear.TabIndex = 5;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // button_Save
            // 
            this.button_Save.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Save.Location = new System.Drawing.Point(785, 238);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(136, 36);
            this.button_Save.TabIndex = 7;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Write
            // 
            this.button_Write.AccessibleDescription = "00";
            this.button_Write.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Write.Location = new System.Drawing.Point(785, 322);
            this.button_Write.Name = "button_Write";
            this.button_Write.Size = new System.Drawing.Size(136, 36);
            this.button_Write.TabIndex = 8;
            this.button_Write.Text = "Write";
            this.button_Write.UseVisualStyleBackColor = true;
            this.button_Write.Click += new System.EventHandler(this.button_Write_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Exit.Location = new System.Drawing.Point(785, 280);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(136, 36);
            this.button_Exit.TabIndex = 9;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // comboBox_Port
            // 
            this.comboBox_Port.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Port.FormattingEnabled = true;
            this.comboBox_Port.Location = new System.Drawing.Point(785, 12);
            this.comboBox_Port.Name = "comboBox_Port";
            this.comboBox_Port.Size = new System.Drawing.Size(136, 27);
            this.comboBox_Port.TabIndex = 10;
            this.comboBox_Port.Click += new System.EventHandler(this.comboBox_Port_Click);
            this.comboBox_Port.MouseEnter += new System.EventHandler(this.comboBox_Port_MouseEnter);
            // 
            // comboBox_BaudRate
            // 
            this.comboBox_BaudRate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_BaudRate.FormattingEnabled = true;
            this.comboBox_BaudRate.Location = new System.Drawing.Point(785, 45);
            this.comboBox_BaudRate.Name = "comboBox_BaudRate";
            this.comboBox_BaudRate.Size = new System.Drawing.Size(136, 27);
            this.comboBox_BaudRate.TabIndex = 11;
            // 
            // checkBox_Auto_New_Line
            // 
            this.checkBox_Auto_New_Line.AccessibleDescription = "";
            this.checkBox_Auto_New_Line.AutoSize = true;
            this.checkBox_Auto_New_Line.Location = new System.Drawing.Point(862, 78);
            this.checkBox_Auto_New_Line.Name = "checkBox_Auto_New_Line";
            this.checkBox_Auto_New_Line.Size = new System.Drawing.Size(59, 16);
            this.checkBox_Auto_New_Line.TabIndex = 12;
            this.checkBox_Auto_New_Line.Text = "Send \\n";
            this.checkBox_Auto_New_Line.UseVisualStyleBackColor = true;
            // 
            // checkBox_Time_Tag
            // 
            this.checkBox_Time_Tag.AutoSize = true;
            this.checkBox_Time_Tag.Location = new System.Drawing.Point(862, 100);
            this.checkBox_Time_Tag.Name = "checkBox_Time_Tag";
            this.checkBox_Time_Tag.Size = new System.Drawing.Size(69, 16);
            this.checkBox_Time_Tag.TabIndex = 13;
            this.checkBox_Time_Tag.Text = "Time Tag";
            this.checkBox_Time_Tag.UseVisualStyleBackColor = true;
            // 
            // checkBox_Hex_Mode
            // 
            this.checkBox_Hex_Mode.AutoSize = true;
            this.checkBox_Hex_Mode.Location = new System.Drawing.Point(785, 100);
            this.checkBox_Hex_Mode.Name = "checkBox_Hex_Mode";
            this.checkBox_Hex_Mode.Size = new System.Drawing.Size(73, 16);
            this.checkBox_Hex_Mode.TabIndex = 14;
            this.checkBox_Hex_Mode.Text = "Hex Mode";
            this.checkBox_Hex_Mode.UseVisualStyleBackColor = true;
            this.checkBox_Hex_Mode.CheckedChanged += new System.EventHandler(this.checkBox_Hex_Mode_CheckedChanged);
            // 
            // checkBox_Bin_Mode
            // 
            this.checkBox_Bin_Mode.AutoSize = true;
            this.checkBox_Bin_Mode.Location = new System.Drawing.Point(785, 78);
            this.checkBox_Bin_Mode.Name = "checkBox_Bin_Mode";
            this.checkBox_Bin_Mode.Size = new System.Drawing.Size(71, 16);
            this.checkBox_Bin_Mode.TabIndex = 15;
            this.checkBox_Bin_Mode.Text = "Bin Mode";
            this.checkBox_Bin_Mode.UseVisualStyleBackColor = true;
            this.checkBox_Bin_Mode.CheckedChanged += new System.EventHandler(this.checkBox_Bin_Mode_CheckedChanged);
            // 
            // checkBox_ASCII_Mode
            // 
            this.checkBox_ASCII_Mode.AutoSize = true;
            this.checkBox_ASCII_Mode.Location = new System.Drawing.Point(785, 122);
            this.checkBox_ASCII_Mode.Name = "checkBox_ASCII_Mode";
            this.checkBox_ASCII_Mode.Size = new System.Drawing.Size(84, 16);
            this.checkBox_ASCII_Mode.TabIndex = 16;
            this.checkBox_ASCII_Mode.Text = "ASCII Mode";
            this.checkBox_ASCII_Mode.UseVisualStyleBackColor = true;
            this.checkBox_ASCII_Mode.CheckedChanged += new System.EventHandler(this.checkBox_ASCII_Mode_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 370);
            this.Controls.Add(this.checkBox_ASCII_Mode);
            this.Controls.Add(this.checkBox_Bin_Mode);
            this.Controls.Add(this.checkBox_Hex_Mode);
            this.Controls.Add(this.checkBox_Time_Tag);
            this.Controls.Add(this.checkBox_Auto_New_Line);
            this.Controls.Add(this.comboBox_BaudRate);
            this.Controls.Add(this.comboBox_Port);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.button_Write);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.textBox_out);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_Open);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ComPort Tool  Ver.20220514";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Open;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox_out;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Write;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.ComboBox comboBox_Port;
        private System.Windows.Forms.ComboBox comboBox_BaudRate;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.CheckBox checkBox_Auto_New_Line;
        private System.Windows.Forms.CheckBox checkBox_Time_Tag;
        private System.Windows.Forms.CheckBox checkBox_Hex_Mode;
        private System.Windows.Forms.CheckBox checkBox_Bin_Mode;
        private System.Windows.Forms.CheckBox checkBox_ASCII_Mode;
    }
}

