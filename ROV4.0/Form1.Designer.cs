namespace ROV4
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.debug = new System.Windows.Forms.TextBox();
            this.arduinoIP = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            this.vScrollBar3 = new System.Windows.Forms.VScrollBar();
            this.vScrollBar6 = new System.Windows.Forms.VScrollBar();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.calculate_btn = new System.Windows.Forms.Button();
            this.heading = new System.Windows.Forms.TextBox();
            this.ascent_speed = new System.Windows.Forms.TextBox();
            this.ascent_rate = new System.Windows.Forms.TextBox();
            this.failure_time = new System.Windows.Forms.TextBox();
            this.descent_speed = new System.Windows.Forms.TextBox();
            this.descent_rate = new System.Windows.Forms.TextBox();
            this.wind_direction = new System.Windows.Forms.TextBox();
            this.wind_speed = new System.Windows.Forms.TextBox();
            this.av = new System.Windows.Forms.Label();
            this.wv = new System.Windows.Forms.Label();
            this.dv = new System.Windows.Forms.Label();
            this.instructions = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.numRotors = new System.Windows.Forms.TextBox();
            this.rotorDiameter = new System.Windows.Forms.TextBox();
            this.waterDensity = new System.Windows.Forms.TextBox();
            this.LakeWashingtonMap = new System.Windows.Forms.PictureBox();
            this.tideVelocity = new System.Windows.Forms.TextBox();
            this.genEfficiency = new System.Windows.Forms.TextBox();
            this.calculateTide = new System.Windows.Forms.Button();
            this.tideOut = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LakeWashingtonMap)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(127, 12);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectBtn.TabIndex = 1;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // debug
            // 
            this.debug.Location = new System.Drawing.Point(32, 41);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(170, 20);
            this.debug.TabIndex = 2;
            // 
            // arduinoIP
            // 
            this.arduinoIP.Location = new System.Drawing.Point(12, 12);
            this.arduinoIP.Name = "arduinoIP";
            this.arduinoIP.Size = new System.Drawing.Size(100, 20);
            this.arduinoIP.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer
            // 
            this.timer.AutoSize = true;
            this.timer.Location = new System.Drawing.Point(29, 80);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(34, 13);
            this.timer.TabIndex = 4;
            this.timer.Text = "00:00";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(69, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(150, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(46, 141);
            this.vScrollBar1.Maximum = 99;
            this.vScrollBar1.Minimum = -99;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 80);
            this.vScrollBar1.TabIndex = 7;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Location = new System.Drawing.Point(127, 141);
            this.vScrollBar2.Maximum = 99;
            this.vScrollBar2.Minimum = -99;
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(17, 80);
            this.vScrollBar2.TabIndex = 8;
            this.vScrollBar2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // vScrollBar3
            // 
            this.vScrollBar3.Location = new System.Drawing.Point(208, 141);
            this.vScrollBar3.Maximum = 99;
            this.vScrollBar3.Minimum = -99;
            this.vScrollBar3.Name = "vScrollBar3";
            this.vScrollBar3.Size = new System.Drawing.Size(17, 80);
            this.vScrollBar3.TabIndex = 10;
            this.vScrollBar3.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // vScrollBar6
            // 
            this.vScrollBar6.Location = new System.Drawing.Point(296, 141);
            this.vScrollBar6.Maximum = 99;
            this.vScrollBar6.Minimum = -99;
            this.vScrollBar6.Name = "vScrollBar6";
            this.vScrollBar6.Size = new System.Drawing.Size(17, 80);
            this.vScrollBar6.TabIndex = 12;
            this.vScrollBar6.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(150, 257);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(238, 257);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "Load";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1, 234);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(51, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Vert1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(87, 234);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(51, 17);
            this.checkBox2.TabIndex = 16;
            this.checkBox2.Text = "Vert2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(176, 234);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(44, 17);
            this.checkBox3.TabIndex = 17;
            this.checkBox3.Text = "Left";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(262, 234);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(51, 17);
            this.checkBox4.TabIndex = 18;
            this.checkBox4.Text = "Right";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Heading: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Ascent Speed: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Ascent Rate: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 371);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Time til\' engine failure: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 395);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Descent Speed:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 420);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Descent Rate: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 443);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Wind Direction: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 465);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Wind Speed: ";
            // 
            // calculate_btn
            // 
            this.calculate_btn.Location = new System.Drawing.Point(150, 503);
            this.calculate_btn.Name = "calculate_btn";
            this.calculate_btn.Size = new System.Drawing.Size(75, 23);
            this.calculate_btn.TabIndex = 28;
            this.calculate_btn.Text = "Calculate";
            this.calculate_btn.UseVisualStyleBackColor = true;
            this.calculate_btn.Click += new System.EventHandler(this.calculate_btn_Click);
            // 
            // heading
            // 
            this.heading.Location = new System.Drawing.Point(150, 292);
            this.heading.Name = "heading";
            this.heading.Size = new System.Drawing.Size(100, 20);
            this.heading.TabIndex = 29;
            // 
            // ascent_speed
            // 
            this.ascent_speed.Location = new System.Drawing.Point(150, 318);
            this.ascent_speed.Name = "ascent_speed";
            this.ascent_speed.Size = new System.Drawing.Size(100, 20);
            this.ascent_speed.TabIndex = 30;
            // 
            // ascent_rate
            // 
            this.ascent_rate.Location = new System.Drawing.Point(150, 341);
            this.ascent_rate.Name = "ascent_rate";
            this.ascent_rate.Size = new System.Drawing.Size(100, 20);
            this.ascent_rate.TabIndex = 31;
            // 
            // failure_time
            // 
            this.failure_time.Location = new System.Drawing.Point(150, 364);
            this.failure_time.Name = "failure_time";
            this.failure_time.Size = new System.Drawing.Size(100, 20);
            this.failure_time.TabIndex = 32;
            // 
            // descent_speed
            // 
            this.descent_speed.Location = new System.Drawing.Point(150, 388);
            this.descent_speed.Name = "descent_speed";
            this.descent_speed.Size = new System.Drawing.Size(100, 20);
            this.descent_speed.TabIndex = 33;
            // 
            // descent_rate
            // 
            this.descent_rate.Location = new System.Drawing.Point(150, 413);
            this.descent_rate.Name = "descent_rate";
            this.descent_rate.Size = new System.Drawing.Size(100, 20);
            this.descent_rate.TabIndex = 34;
            // 
            // wind_direction
            // 
            this.wind_direction.Location = new System.Drawing.Point(150, 436);
            this.wind_direction.Name = "wind_direction";
            this.wind_direction.Size = new System.Drawing.Size(100, 20);
            this.wind_direction.TabIndex = 35;
            // 
            // wind_speed
            // 
            this.wind_speed.Location = new System.Drawing.Point(150, 458);
            this.wind_speed.Name = "wind_speed";
            this.wind_speed.Size = new System.Drawing.Size(100, 20);
            this.wind_speed.TabIndex = 36;
            // 
            // av
            // 
            this.av.AutoSize = true;
            this.av.Location = new System.Drawing.Point(29, 541);
            this.av.Name = "av";
            this.av.Size = new System.Drawing.Size(80, 13);
            this.av.TabIndex = 37;
            this.av.Text = "Ascent Vector: ";
            // 
            // wv
            // 
            this.wv.AutoSize = true;
            this.wv.Location = new System.Drawing.Point(272, 541);
            this.wv.Name = "wv";
            this.wv.Size = new System.Drawing.Size(72, 13);
            this.wv.TabIndex = 38;
            this.wv.Text = "Wind Vector: ";
            this.wv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dv
            // 
            this.dv.AutoSize = true;
            this.dv.Location = new System.Drawing.Point(147, 541);
            this.dv.Name = "dv";
            this.dv.Size = new System.Drawing.Size(87, 13);
            this.dv.TabIndex = 39;
            this.dv.Text = "Descent Vector: ";
            // 
            // instructions
            // 
            this.instructions.AutoSize = true;
            this.instructions.Location = new System.Drawing.Point(293, 364);
            this.instructions.Name = "instructions";
            this.instructions.Size = new System.Drawing.Size(0, 13);
            this.instructions.TabIndex = 40;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(697, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "# of Rotors: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(697, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Water Density: ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(697, 75);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(81, 13);
            this.label17.TabIndex = 49;
            this.label17.Text = "Rotor Diameter:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(697, 104);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 13);
            this.label18.TabIndex = 50;
            this.label18.Text = "Tide Velocity: ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(697, 131);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(109, 13);
            this.label21.TabIndex = 53;
            this.label21.Text = "Generator Efficiency: ";
            // 
            // numRotors
            // 
            this.numRotors.Location = new System.Drawing.Point(805, 5);
            this.numRotors.Name = "numRotors";
            this.numRotors.Size = new System.Drawing.Size(80, 20);
            this.numRotors.TabIndex = 54;
            // 
            // rotorDiameter
            // 
            this.rotorDiameter.Location = new System.Drawing.Point(805, 68);
            this.rotorDiameter.Name = "rotorDiameter";
            this.rotorDiameter.Size = new System.Drawing.Size(80, 20);
            this.rotorDiameter.TabIndex = 55;
            // 
            // waterDensity
            // 
            this.waterDensity.Location = new System.Drawing.Point(805, 34);
            this.waterDensity.Name = "waterDensity";
            this.waterDensity.Size = new System.Drawing.Size(80, 20);
            this.waterDensity.TabIndex = 56;
            // 
            // LakeWashingtonMap
            // 
            this.LakeWashingtonMap.Image = ((System.Drawing.Image)(resources.GetObject("LakeWashingtonMap.Image")));
            this.LakeWashingtonMap.Location = new System.Drawing.Point(358, 12);
            this.LakeWashingtonMap.Name = "LakeWashingtonMap";
            this.LakeWashingtonMap.Size = new System.Drawing.Size(324, 629);
            this.LakeWashingtonMap.TabIndex = 19;
            this.LakeWashingtonMap.TabStop = false;
            this.LakeWashingtonMap.Paint += new System.Windows.Forms.PaintEventHandler(this.LakeWashingtonMap_Paint);
            this.LakeWashingtonMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LakeWashingtonMap_MouseMove);
            this.LakeWashingtonMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LakeWashingtonMap_MouseUP);
            // 
            // tideVelocity
            // 
            this.tideVelocity.Location = new System.Drawing.Point(805, 97);
            this.tideVelocity.Name = "tideVelocity";
            this.tideVelocity.Size = new System.Drawing.Size(80, 20);
            this.tideVelocity.TabIndex = 57;
            // 
            // genEfficiency
            // 
            this.genEfficiency.Location = new System.Drawing.Point(805, 124);
            this.genEfficiency.Name = "genEfficiency";
            this.genEfficiency.Size = new System.Drawing.Size(80, 20);
            this.genEfficiency.TabIndex = 58;
            // 
            // calculateTide
            // 
            this.calculateTide.Location = new System.Drawing.Point(765, 150);
            this.calculateTide.Name = "calculateTide";
            this.calculateTide.Size = new System.Drawing.Size(75, 23);
            this.calculateTide.TabIndex = 59;
            this.calculateTide.Text = "Calculate";
            this.calculateTide.UseVisualStyleBackColor = true;
            this.calculateTide.Click += new System.EventHandler(this.calculateTide_Click);
            // 
            // tideOut
            // 
            this.tideOut.AutoSize = true;
            this.tideOut.Location = new System.Drawing.Point(697, 179);
            this.tideOut.Name = "tideOut";
            this.tideOut.Size = new System.Drawing.Size(0, 13);
            this.tideOut.TabIndex = 60;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 644);
            this.Controls.Add(this.tideOut);
            this.Controls.Add(this.calculateTide);
            this.Controls.Add(this.genEfficiency);
            this.Controls.Add(this.tideVelocity);
            this.Controls.Add(this.waterDensity);
            this.Controls.Add(this.rotorDiameter);
            this.Controls.Add(this.numRotors);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.instructions);
            this.Controls.Add(this.dv);
            this.Controls.Add(this.wv);
            this.Controls.Add(this.av);
            this.Controls.Add(this.wind_speed);
            this.Controls.Add(this.wind_direction);
            this.Controls.Add(this.descent_rate);
            this.Controls.Add(this.descent_speed);
            this.Controls.Add(this.failure_time);
            this.Controls.Add(this.ascent_rate);
            this.Controls.Add(this.ascent_speed);
            this.Controls.Add(this.heading);
            this.Controls.Add(this.calculate_btn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LakeWashingtonMap);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.vScrollBar6);
            this.Controls.Add(this.vScrollBar3);
            this.Controls.Add(this.vScrollBar2);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.timer);
            this.Controls.Add(this.arduinoIP);
            this.Controls.Add(this.debug);
            this.Controls.Add(this.ConnectBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.ConnectBtn_Click);
            ((System.ComponentModel.ISupportInitialize)(this.LakeWashingtonMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox debug;
        private System.Windows.Forms.TextBox arduinoIP;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.VScrollBar vScrollBar2;
        private System.Windows.Forms.VScrollBar vScrollBar3;
        private System.Windows.Forms.VScrollBar vScrollBar6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button calculate_btn;
        private System.Windows.Forms.TextBox heading;
        private System.Windows.Forms.TextBox ascent_speed;
        private System.Windows.Forms.TextBox ascent_rate;
        private System.Windows.Forms.TextBox failure_time;
        private System.Windows.Forms.TextBox descent_speed;
        private System.Windows.Forms.TextBox descent_rate;
        private System.Windows.Forms.TextBox wind_direction;
        private System.Windows.Forms.TextBox wind_speed;
        private System.Windows.Forms.Label av;
        private System.Windows.Forms.Label wv;
        private System.Windows.Forms.Label dv;
        private System.Windows.Forms.Label instructions;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox numRotors;
        private System.Windows.Forms.TextBox rotorDiameter;
        private System.Windows.Forms.TextBox waterDensity;
        private System.Windows.Forms.PictureBox LakeWashingtonMap;
        private System.Windows.Forms.TextBox tideVelocity;
        private System.Windows.Forms.TextBox genEfficiency;
        private System.Windows.Forms.Button calculateTide;
        private System.Windows.Forms.Label tideOut;
        private System.Windows.Forms.Timer timer2;
    }
}

